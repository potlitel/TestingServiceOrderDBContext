using FSA.Core.ServiceOrders.Models.Masters;
using FSA.Core.Utils;
using WebApiSO.Extension;

namespace WebApiSO.Data.Seeders
{
    internal static class ServiceOrderTaskStatesSeeder
    {
        /// <summary>
        /// Method <see cref="AddServiceOrderTaskStates"/>: Extends <see cref="AppDbContext"/> type to insert initial data on 
        /// the <see cref="ServiceOrderTaskState"/> entity.
        /// </summary>
        /// <param name="context">AppDbContext instance</param>
        /// <returns>An instance of the <see cref="Task"/> object.</returns>
        public static async Task AddServiceOrderTaskStates(this AppDbContext context)
        {
            if (!context.ServiceOrderTaskStates.Any())
            {
                //Auto-incrementing values ​​are reset.
                context.DbccCheckIdent<ServiceOrderTaskState>(1);

                var Date = DateTimeHelper.Now();
                context.ServiceOrderTaskStates.AddRange(new List<ServiceOrderTaskState>()
                {
                    new ServiceOrderTaskState(){
                        Code = "d4609eb9-376b-4380-ac00-445f3cd91998",
                        Description = "Pendiente",
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new ServiceOrderTaskState(){
                        Code = "3dbe1169-7245-4c2b-b1f4-536dbd4b8252",
                        Description = "Programada",
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new ServiceOrderTaskState(){
                        Code = "a9c353c5-86aa-4bc7-a564-e481cbe03803",
                        Description = "En proceso",
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },new ServiceOrderTaskState(){
                        Code = "0fa4f85f-a9ea-44ee-909a-951acfc5696e",
                        Description = "En espera",
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },new ServiceOrderTaskState(){
                        Code = "d43df41f-ec7f-4932-94c8-7524d71cf619",
                        Description = "Terminada",
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new ServiceOrderTaskState(){
                        Code = "1135e4d3-6430-4712-bf6d-fabc67eff863",
                        Description = "Cancelada",
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
