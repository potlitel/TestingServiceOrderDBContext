using FSA.Core.ServiceOrders.Models.Masters;
using FSA.Core.Utils;
using WebApiSO.Extension;
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

                long randomLong = (uid * 2);

                context.ServiceOrders.AddRange(new List<CustomServiceOrder>()
                {
                    new CustomServiceOrder(){
                        Number = Guid.NewGuid().ToString(),
                        EstimatedEndingDate = Date.AddDays(uid),
                        Observations = "LoremNET.Lorem.Sentence(50)",
                        Address = "LoremNET.Lorem.Sentence(10)",
                        OwnerId = randomLong,
                        ExecutorId = randomLong,
                        ServiceOrderTypeId = 2,
                        CustomField = uid,
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    }
                });

                await context.SaveChangesAsync();
            }
        }
    }
}
