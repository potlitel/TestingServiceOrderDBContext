using FSA.Core.ServiceOrders.Models;
using FSA.Core.Utils;

namespace WebApiSO.Data.Seeders.Supplies
{
    internal static class SuppliesSeeder
    {
        /// <summary>
        /// Method <see cref="AddServiceOrderSupplies"/>: Extends <see cref="AppDbContext"/> type to insert initial data on 
        /// the <see cref="Supply"/> entity.
        /// </summary>
        /// <param name="context">AppDbContext instance</param>
        /// <returns>An instance of the <see cref="Task"/> object.</returns>
        public static async Task AddServiceOrderSupplies(this AppDbContext context)
        {
            if (!context.Supplies.Any())
            {
                //Auto-incrementing values ​​are reset for ServiceOrderDocument entity.
                context.DbccCheckIdent<Supply>(1);
                var itemsCountTasks = context.CountByRawSql("SELECT COUNT(*) FROM ServiceOrderTasks");
                var itemsCountSupplyOperations = context.CountByRawSql("SELECT COUNT(*) FROM SupplyOperations");
                var rand = new Random();

                var Date = DateTimeHelper.Now();
                for (int i = 0; i < itemsCountTasks; i++)
                {
                    context.Supplies.AddRange(new List<Supply>()
                    {
                        new(){
                            Amount = rand.Next(1, itemsCountTasks),
                            Price = rand.Next(1, itemsCountTasks)/8.5,
                            Description = "Description",
                            SupplyOperationId = rand.Next(1, itemsCountSupplyOperations),
                            ServiceOrderTaskId = rand.Next(1, itemsCountTasks),
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
