using FSA.Core.ServiceOrders.Models;
using FSA.Core.Utils;

namespace WebApiSO.Data.Seeders.ServiceOrderTasksDocuments
{
    internal static class ServiceOrderTasksDocumentsSeeder
    {
        /// <summary>
        /// Method <see cref="ServiceOrderTasksDocuments"/>: Extends <see cref="AppDbContext"/> type to insert initial data on 
        /// the <see cref="ServiceOrderTaskDocument"/> entity.
        /// </summary>
        /// <param name="context">AppDbContext instance</param>
        /// <returns>An instance of the <see cref="Task"/> object.</returns>
        public static async Task AddServiceOrderTasksDocuments(this AppDbContext context)
        {
            if (!context.ServiceOrderTaskDocuments.Any())
            {
                //Auto-incrementing values ​​are reset for ServiceOrderTaskDocument entity.
                context.DbccCheckIdent<ServiceOrderTaskDocument>(1);
                var itemsCountTasks = context.CountByRawSql("SELECT COUNT(*) FROM ServiceOrderTasks");
                var itemsCountDocumentTypes = context.CountByRawSql("SELECT COUNT(*) FROM DocumentTypes");
                var rand = new Random();

                var Date = DateTimeHelper.Now();
                for (int i = 0; i < itemsCountTasks; i++)
                {
                    context.ServiceOrderTaskDocuments.AddRange(new List<ServiceOrderTaskDocument>()
                    {
                        new ServiceOrderTaskDocument(){
                            ServiceOrderTaskId = rand.Next(1, itemsCountTasks),
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
