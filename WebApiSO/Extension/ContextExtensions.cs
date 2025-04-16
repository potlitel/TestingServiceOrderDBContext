using FSA.Core.ServiceOrders.Context;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections;
using System.Linq.Expressions;
using System.Reflection;

namespace WebApiSO.Extension
{
    //https://stackoverflow.com/questions/73237901/ef-core-6-given-a-primary-key-find-all-related-entities
    //https://aaronbos.dev/posts/ef-core-6-related-data
    public static class ContextExtensions
    {
        /// <summary>
        /// Returns DependencyInfo for deleted entities without duplicates. 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="maxDepth"></param>
        /// <returns></returns>
        public static async Task<List<DependencyInfo>> GetDependedDeletedEntriesAsync(this DbContext context, int maxDepth = 10)
        {
            var dependency = await GetDependencyInformationFromEntries(context, context.ChangeTracker.Entries().Where(e => e.State == EntityState.Deleted), maxDepth);

            var enrichedWithEntry = dependency.Select(d => new { Entry = context.Entry(d.Entity), Dependency = d });

            enrichedWithEntry = enrichedWithEntry.Where(x => x.Entry.State != EntityState.Deleted);

            // get only unique entries with shortest path
            var result = enrichedWithEntry
                .GroupBy(e => e.Entry)
                .Select(g => g.OrderBy(d => d.Dependency.Path.Length).Select(d => d.Dependency).First())
                .ToList();

            return result;
        }

        /// <summary>
        /// Returns depended entries without duplicates. 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="untypedEntries"></param>
        /// <param name="maxDepth"></param>
        /// <returns></returns>
        public static async Task<List<EntityEntry>> GetDependedEntriesFromEntries(DbContext context,
            IEnumerable<EntityEntry> untypedEntries, int maxDepth = 10)
        {
            var dependencies = await GetDependencyInformationFromEntries(context, untypedEntries, maxDepth);

            var result = dependencies.Select(d => context.Entry(d.Entity))
                .Distinct()
                .ToList();

            return result;
        }

        /// <summary>
        /// Collects DependencyInfo for any collection of entries
        /// </summary>
        /// <param name="context"></param>
        /// <param name="untypedEntries"></param>
        /// <param name="maxDepth"></param>
        /// <returns></returns>
        public static async Task<List<DependencyInfo>> GetDependencyInformationFromEntries(DbContext context, IEnumerable<EntityEntry> untypedEntries, int maxDepth = 10)
        {
            var byType = untypedEntries.GroupBy(d => d.Entity.GetType())
                .Select(g => new { Type = g.Key, Entries = g.ToList() })
                .ToList();

            var dependencies = new List<DependencyInfo>();

            foreach (var r in byType)
            {
                var task = (Task)_getDependedDataFromEntriesAsync.MakeGenericMethod(r.Type).Invoke(null, new object[] { context, r.Entries, maxDepth })!;
                await task;

                dynamic tasWithResult = task;

                dependencies.AddRange((List<DependencyInfo>)tasWithResult.Result);
            }

            return dependencies;
        }

        /// <summary>
        /// Appends Includes to the source query and retrieves DependencyInfo
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="context"></param>
        /// <param name="maxDepth"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static async Task<List<DependencyInfo>> GetDependencyInformationFromQueryAsync<T>(this IQueryable<T> query, DbContext context, int maxDepth = 10)
            where T : class
        {
            var entityType = context.Model.FindEntityType(typeof(T));
            if (entityType == null)
                throw new InvalidOperationException();

            var dependedNavigations = GetDependedNavigations(entityType).ToList();

            var includes = new List<string>();
            foreach (var navigation in dependedNavigations)
            {
                includes.AddRange(GenerateInclude(string.Empty, navigation, maxDepth));
            }

            var result = new List<DependencyInfo>();

            if (includes.Count == 0)
                return result;

            var queryWithIncludes = query;
            foreach (var include in includes)
            {
                queryWithIncludes = queryWithIncludes.Include(include);
            }

            var loadedRecords = await queryWithIncludes.AsSplitQuery().ToListAsync();

            if (loadedRecords.Count > 0)
            {
                var pk = entityType.FindPrimaryKey() ?? throw new InvalidOperationException();

                var related = new List<(DependencyPath[] path, object entity)>();
                foreach (var record in loadedRecords)
                {
                    related.Clear();

                    var entry = context.Entry(record);

                    foreach (var navigation in dependedNavigations)
                    {
                        CollectDependedObjects(context, Array.Empty<DependencyPath>(), navigation, entry, related, maxDepth);
                    }

                    // Currently we do not care about composite keys
                    var key = GetPrimaryKeyValue(context.Entry(record));

                    result.AddRange(related.Select(r => new DependencyInfo(r.path, key, record, r.entity)));
                }

                // removing duplicates, leaving only shortest path
                result = result
                    .GroupBy(d => d.Entity)
                    .Select(g => g.OrderBy(d => d.Path.Length).First())
                    .ToList();
            }

            return result;
        }

        private static Task<List<DependencyInfo>> GetDependedDataFromEntriesAsync<TEntity>(this IQueryable<TEntity> queryy, AppDbContext context,
            IEnumerable<EntityEntry> untypedEntries, int maxDepth)
            where TEntity : class
        {
            var entityType = context.Model.FindEntityType(typeof(TEntity));
            if (entityType == null)
                throw new InvalidOperationException();

            var pk = entityType.FindPrimaryKey();

            if (pk == null)
                return Task.FromResult(new List<DependencyInfo>());

            var entries = untypedEntries.Select(e => context.Entry((TEntity)e.Entity));

            var query = context.Set<TEntity>().AsQueryable();

            if (pk.Properties.Count == 1)
            {
                var pkProperty = pk.Properties[0];
                query = (IQueryable<TEntity>)_filterByProperty.MakeGenericMethod(typeof(TEntity), pkProperty.ClrType)
                    .Invoke(null, new object[] { query, entries, pkProperty })!;
            }
            else
            {
                query = (IQueryable<TEntity>)_filterByProperties.MakeGenericMethod(typeof(TEntity))
                    .Invoke(null, new object[] { query, entries, pk.Properties })!;
            }

            return GetDependencyInformationFromQueryAsync(query, context, maxDepth);
        }

        private static IQueryable<TEntity> FilterByProperty<TEntity, TValue>(IQueryable<TEntity> query, IEnumerable<EntityEntry<TEntity>> entries, IProperty property)
            where TEntity : class
        {
            // Extract values from entries
            var keys = entries.Select(e => e.CurrentValues.GetValue<TValue>(property))
                .ToList();

            var entityParam = Expression.Parameter(typeof(TEntity), typeof(TEntity).Name.Substring(1, 1).ToLower());

            // e => keys.Contains(e.PropName)
            var predicate =
                Expression.Lambda<Func<TEntity, bool>>(
                    Expression.Call(typeof(Enumerable), nameof(Enumerable.Contains),
                        new[] { typeof(TValue) }, Expression.Constant(keys),
                        GetPropertyExpression(entityParam, property)),
                    entityParam);

            return query.Where(predicate);
        }

        private static IQueryable<TEntity> FilterByProperties<TEntity>(IQueryable<TEntity> query, IEnumerable<EntityEntry<TEntity>> entries,
            IReadOnlyList<IProperty> properties)
            where TEntity : class
        {
            if (properties.Count == 0)
                throw new ArgumentException("Expected not empty", nameof(properties));

            var entityParam = Expression.Parameter(typeof(TEntity), typeof(TEntity).Name.Substring(1, 1).ToLower());

            Expression? predicate = null;

            var propExpressions = properties.Select(p => GetPropertyExpression(entityParam, p))
                .ToArray();

            foreach (var entry in entries)
            {
                var values = properties.Select(p => entry.Properties.Single(pe => pe.Metadata == p).CurrentValue)
                    .ToList();

                Expression? combinedCondition = null;
                for (var i = 0; i < propExpressions.Length; ++i)
                {
                    var condition = Expression.Equal(propExpressions[i], Expression.Constant(values[i]));
                    combinedCondition = combinedCondition == null ? condition : Expression.AndAlso(combinedCondition, condition);
                }

                predicate = predicate == null ? combinedCondition : Expression.OrElse(predicate, combinedCondition!);
            }

            predicate ??= Expression.Constant(false);

            var predicateLambda = Expression.Lambda<Func<TEntity, bool>>(predicate, entityParam);

            return query.Where(predicateLambda);
        }


        private static Expression GetPropertyExpression(Expression objExpression, IProperty property)
        {
            Expression propExpression;
            if (property.PropertyInfo == null)
            {
                // 'property' is Shadow property, so call via EF.Property(e, "name")
                propExpression = Expression.Call(typeof(EF), nameof(EF.Property), new[] { property.ClrType },
                    objExpression, Expression.Constant(property.Name));
            }
            else
            {
                propExpression = Expression.MakeMemberAccess(objExpression, property.PropertyInfo);
            }

            return propExpression;
        }

        private static IEnumerable<string> GenerateInclude(string prevPath, INavigation navigation, int depth)
        {
            if (depth == 0)
                yield break;

            var path = navigation.Name;
            if (!string.IsNullOrEmpty(prevPath))
                path = prevPath + "." + path;

            var found = false;

            foreach (var include in GetDependedNavigations(navigation.TargetEntityType).SelectMany(n => GenerateInclude(path, n, depth - 1)))
            {
                found = true;
                yield return include;
            }

            if (!found)
                yield return path;
        }

        private static IEnumerable<INavigation> GetDependedNavigations(IEntityType entityType)
        {
            return entityType.GetNavigations().Where(n => !n.IsOnDependent);
        }

        private static void AddDependedObject(DbContext context, DependencyPath[] prevPath, INavigation navigation, object obj, List<(DependencyPath[] path, object entity)> related, int depth)
        {
            var entry = context.Entry(obj);

            var path = new[] { new DependencyPath(navigation.Name, GetPrimaryKeyValue(entry)) };

            if (prevPath.Length > 0)
            {
                path = prevPath.Concat(path).ToArray();
            }

            related.Add((path, obj));

            if (depth > 0)
            {
                foreach (var n in GetDependedNavigations(navigation.TargetEntityType))
                {
                    CollectDependedObjects(context, path, n, entry, related, depth - 1);
                }
            }
        }

        private static object? GetEntryPropertyValue(EntityEntry entry, IPropertyBase property)
        {
            return entry.Properties.Single(ep => ep.Metadata == property).CurrentValue;
        }

        private static object? GetPrimaryKeyValue(EntityEntry entry)
        {
            var pk = entry.Metadata.FindPrimaryKey();
            if (pk == null)
                return null;

            if (pk.Properties.Count == 1)
            {
                return GetEntryPropertyValue(entry, pk.Properties[0]);
            }

            return pk.Properties.Select(p => GetEntryPropertyValue(entry, p)).ToArray();
        }

        private static void CollectDependedObjects(DbContext context, DependencyPath[] prevPath, INavigation navigation, EntityEntry entry, List<(DependencyPath[] path, object entity)> related,
            int depth)
        {
            if (depth == 0)
                return;

            var value = navigation.GetGetter().GetClrValue(entry.Entity);

            if (navigation.IsCollection)
            {
                if (value is IEnumerable collection)
                {
                    foreach (var obj in collection)
                    {
                        if (obj != null)
                            AddDependedObject(context, prevPath, navigation, obj, related, depth - 1);
                    }
                }
            }
            else
            {
                if (value != null)
                {
                    AddDependedObject(context, prevPath, navigation, value, related, depth - 1);
                }
            }
        }

        public class DependencyInfo
        {
            public DependencyInfo(DependencyPath[] path, object? rootKey, object rootEntity, object entity)
            {
                Path = path;
                RootKey = rootKey;
                RootEntity = rootEntity;
                Entity = entity;
            }

            public DependencyPath[] Path { get; }
            public object? RootKey { get; }
            public object RootEntity { get; }
            public object Entity { get; }

            public override string ToString()
            {
                return $"{RootEntity.GetType().Name}[{RootKey}].{string.Join('.', Path.Select(p => p.ToString()))}: {Entity.GetType().Name}";
            }
        }

        public class DependencyPath
        {
            public DependencyPath(string name, object? key)
            {
                Name = name;
                Key = key;
            }

            public string Name { get; }
            public object? Key { get; }

            public override string ToString()
            {
                var key = Key;
                if (key is Array array)
                {
                    key = "[" + string.Join(',', array.Cast<object>().Select(e => e.ToString())) + "]";
                }
                return $"({key}){Name}";
            }
        }

        private static MethodInfo _getDependedDataFromEntriesAsync =
            typeof(ContextExtensions).GetMethod(nameof(GetDependedDataFromEntriesAsync), BindingFlags.NonPublic | BindingFlags.Static) ??
            throw new InvalidOperationException($"Method '{nameof(GetDependedDataFromEntriesAsync)}' not found.");

        private static MethodInfo _filterByProperty =
            typeof(ContextExtensions).GetMethod(nameof(FilterByProperty), BindingFlags.NonPublic | BindingFlags.Static) ??
            throw new InvalidOperationException($"Method '{nameof(FilterByProperty)}' not found.");

        private static MethodInfo _filterByProperties =
            typeof(ContextExtensions).GetMethod(nameof(FilterByProperties), BindingFlags.NonPublic | BindingFlags.Static) ??
            throw new InvalidOperationException($"Method '{nameof(FilterByProperties)}' not found.");

    }
}
