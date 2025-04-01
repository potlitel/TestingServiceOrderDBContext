using FSA.Core.ServiceOrders.Models.Masters;
using FSA.Core.Utils;

namespace WebApiSO.Data.Seeders
{
    internal static class SupplyOperationsSeeder
    {
        /// <summary>
        /// Method <see cref="AddSupplyOperations"/>: Extends <see cref="AppDbContext"/> type to insert initial data on 
        /// the <see cref="SupplyOperation"/> entity.
        /// </summary>
        /// <param name="context">AppDbContext instance</param>
        /// <returns>An instance of the <see cref="Task"/> object.</returns>
        public static async Task AddSupplyOperations(this AppDbContext context)
        {
            if (!context.SupplyOperations.Any())
            {
                var Date = DateTimeHelper.Now();
                context.SupplyOperations.AddRange(new List<SupplyOperation>()
                {
                    new SupplyOperation(){
                        Code = "d4609eb9-376b-4380-ac00-445f3cd91998",
                        Description = "Correctivo",
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new SupplyOperation(){
                        Code = "3dbe1169-7245-4c2b-b1f4-536dbd4b8252",
                        Description = "Preventivo",
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new SupplyOperation(){
                        Code = "a9c353c5-86aa-4bc7-a564-e481cbe03803",
                        Description = "Predictivo",
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },new SupplyOperation(){
                        Code = "0fa4f85f-a9ea-44ee-909a-951acfc5696e",
                        Description = "Programado",
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },new SupplyOperation(){
                        Code = "d43df41f-ec7f-4932-94c8-7524d71cf619",
                        Description = "Oportunidad",
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new SupplyOperation(){
                        Code = "1135e4d3-6430-4712-bf6d-fabc67eff863",
                        Description = "Reactivo",
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new SupplyOperation(){
                        Code = "376f275f-0192-41a7-8555-f3d0bd8317d7",
                        Description = "Centrado en Fiabilidad",
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },new SupplyOperation(){
                        Code = "ba54d470-1582-499b-8447-9c1361b786a6",
                        Description = "Basado en Riesgo",
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
