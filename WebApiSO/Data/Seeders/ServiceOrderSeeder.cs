using FSA.Core.Utils;
using WebApiSO.Data.Seeders.Helpers;
using WebApiSO.Models;

namespace WebApiSO.Data.Seeders
{
    internal static class ServiceOrderSeeder
    {
        /// <summary>
        /// Method <see cref="AddServicesOrders"/>: Extends <see cref="AppDbContext"/> type to insert initial data on 
        /// the <see cref="CustomServiceOrder"/> entity.
        /// </summary>
        /// <param name="context">AppDbContext instance</param>
        /// <returns>An instance of the <see cref="Task"/> object.</returns>
        public static async Task AddServicesOrders(this AppDbContext context)
        {
            if (!context.ServiceOrders.Any())
            {
                //Auto-incrementing values ​​are reset.
                context.DbccCheckIdent<CustomServiceOrder>(0);

                var Date = DateTimeHelper.Now();
                var rand = new Random();
                var uid = rand.Next(10, 80);

                var itemsCountSOType = context.CountByRawSql("SELECT COUNT(*) FROM ServiceOrderTypes");

                long randomLong = (uid * 2);

                foreach (var obsrv in SampleData.Observations)
                {
                    foreach (var addr in SampleData.Address)
                    {    
                        context.ServiceOrders.AddRange(new List<CustomServiceOrder>()
                        {
                            #region ItemsToAdd
                            new CustomServiceOrder(){
                                Number = Guid.NewGuid().ToString(),
                                EstimatedEndingDate = Date.AddDays(uid),
                                Observations = obsrv,
                                Address = addr,
                                OwnerId = randomLong,
                                ExecutorId = randomLong,
                                ServiceOrderTypeId = rand.Next(1, itemsCountSOType),
                                CustomField = rand.Next(10, 80),
                                IsActive = true,
                                CreatedAt = Date,
                                UpdatedAt = Date
                            }
                            #endregion
                        });
                    }
                }

                await context.SaveChangesAsync();
            }
        }
    }
}
