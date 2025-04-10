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

                for (int i = 0; i < SampleData.Observations.Count; i++)
                {
                    for (int j = 0; j < SampleData.Address.Count; j++)
                    {
                        string currentObs = SampleData.Observations[i]; 
                        string currentAddress = SampleData.Address[j];
                        long randomLong = (uid * j+1);

                        if (!context.ServiceOrders.Any(so => so.Observations == currentObs))
                            if (!context.ServiceOrders.Any(so => so.Address == currentAddress))
                                await AddServiceOrder(context, Date, rand, uid, itemsCountSOType,
                                                      randomLong, currentObs, currentAddress);
                            else
                                j++;
                        i++;
                    }
                }

            }
        }

        /// <summary>
        /// Method <see cref="AddServiceOrder"/>: Add new service order item.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="Date"></param>
        /// <param name="rand"></param>
        /// <param name="uid"></param>
        /// <param name="itemsCountSOType"></param>
        /// <param name="randomLong"></param>
        /// <param name="obsrv"></param>
        /// <param name="addr"></param>
        /// <returns>An instance of the <see cref="Task"/> object.</returns>
        private static async Task AddServiceOrder(AppDbContext context, DateTime Date, Random rand, int uid, int itemsCountSOType,
                                                  long randomLong, string obsrv, string addr)
        {
            await context.ServiceOrders.AddAsync(
                                            new CustomServiceOrder()
                                            {
                                                Number = $"SO_{DateTimeHelper.Now().ToString("O")}",
                                                //EstimatedEndingDate = Date.AddDays(uid),
                                                EstimatedEndingDate = DateTimeHelper.Now().AddDays(15),
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
                                            );
            await context.SaveChangesAsync();
        }
    }
}
