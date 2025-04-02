using FSA.Core.BaseEntities;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

//using System.Data.Entity.Core.Objects;
//using System.Data.Entity.Infrastructure;
using System.Text.RegularExpressions;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace WebApiSO.Extension
{
    /// <summary>
    /// https://stackoverflow.com/questions/26155856/how-to-reseed-localdb-table-using-entity-framework
    /// https://stackoverflow.com/questions/45667126/how-to-get-table-name-of-mapped-entity-in-entity-framework-core
    /// </summary>
    public static class DBContextExtensions
    {
        /// <summary>
        /// Method <see cref="DbccCheckIdent"/>: Extends <see cref="DbContext"/> to reseed database tables autoincrement identity.
        /// </summary>
        /// <typeparam name="T">Generic type, must be a Record</typeparam>
        /// <param name="context">DbContext instance</param>
        /// <param name="reseedTo">int value, can be null</param>
        public static void DbccCheckIdent<T>(this DbContext context, int? reseedTo = null) where T : Record
        {
            context.Database.ExecuteSqlRaw(
                $"DBCC CHECKIDENT('{context.GetTableName<T>()}',RESEED{(reseedTo != null ? "," + reseedTo : "")});" +
                $"DBCC CHECKIDENT('{context.GetTableName<T>()}',RESEED);");
        }

        /// <summary>
        /// Method <see cref="GetTableName"/>: Extends <see cref="DbContext"/> to get the table name of an entity T.
        /// </summary>
        /// <typeparam name="T">Generic type, must be a Record</typeparam>
        /// <param name="context">DbContext instance</param>
        /// <returns>An instance of the <see cref="string"/> with the value of the table name or an exception in case of error.</returns>
        public static string GetTableName<T>(this DbContext context) where T : Record
        {
            string tableName = string.Empty;
            try
            {
                var entityType = context.Model.FindEntityType(typeof(T));
                tableName = entityType!.GetTableName()!;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return tableName!;
        }
    }
}
