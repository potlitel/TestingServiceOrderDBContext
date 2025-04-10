using FSA.Core.ServiceOrders.Models.Masters;
using FSA.Core.Utils;
using WebApiSO.Data.Seeders.Helpers;

namespace WebApiSO.Data.Seeders
{
    internal static class DocumentTypesSeeder
    {
        /// <summary>
        /// Method <see cref="AddDocumentTypes"/>: Extends <see cref="AppDbContext"/> type to insert initial data on 
        /// the <see cref="DocumentType"/> entity.
        /// </summary>
        /// <param name="context">AppDbContext instance</param>
        /// <returns>An instance of the <see cref="Task"/> object.</returns>
        public static async Task AddDocumentTypes(this AppDbContext context)
        {
            if (!context.DocumentTypes.Any())
            {
                //Auto-incrementing values ​​are reset.
                context.DbccCheckIdent<DocumentType>(1);
                var Date = DateTimeHelper.Now();

                foreach (var desc in SampleData.Descriptions)
                {

                    context.DocumentTypes.AddRange(new List<DocumentType>()
                    {
                        new(){
                            Code = Guid.NewGuid().ToString(),
                            Description = desc,
                            IsActive = true,
                            CreatedAt = Date,
                            UpdatedAt = Date
                        }
                    });
                }
                await context.SaveChangesAsync();
            }
        }
    }
}
