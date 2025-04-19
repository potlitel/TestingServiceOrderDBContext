using FSA.Core.ServiceOrders.Models;
using FSA.Core.Utils;
using WebApiSO.Models;

namespace WebApiSO.Data.Seeders.ServiceOrderDocuments
{
    internal static class ServiceOrderDocumentsSeeder
    {
        /// <summary>
        /// Method <see cref="AddServiceOrderDocuments"/>: Extends <see cref="AppDbContext"/> type to insert initial data on 
        /// the <see cref="ServiceOrderDocument"/> entity.
        /// </summary>
        /// <param name="context">AppDbContext instance</param>
        /// <returns>An instance of the <see cref="Task"/> object.</returns>
        public static async Task AddServiceOrderDocuments(this AppDbContext context)
        {
            if (!context.ServiceOrderDocuments.Any())
            {
                //Auto-incrementing values ​​are reset for ServiceOrderDocument entity.
                context.DbccCheckIdent<ServiceOrderDocument>(1);
                var itemsCountSO = context.CountByRawSql("SELECT COUNT(*) FROM ServiceOrders");
                var itemsCountDocumentTypes = context.CountByRawSql("SELECT COUNT(*) FROM DocumentTypes");
                var rand = new Random();

                var Date = DateTimeHelper.Now();
                for (int i = 0; i < itemsCountSO; i++)
                {
                    context.ServiceOrderDocuments.AddRange(new List<ServiceOrderDocument>()
                    {
                        new ServiceOrderDocument(){
                            ServiceOrderId = rand.Next(1, itemsCountSO),
                            DocumentTypeId = rand.Next(1, itemsCountDocumentTypes),
                            Name = "Name",
                            Url = "Url",
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
