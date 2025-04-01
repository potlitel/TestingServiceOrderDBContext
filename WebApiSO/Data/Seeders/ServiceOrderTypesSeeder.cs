using FSA.Core.ServiceOrders.Models.Masters;
using FSA.Core.Utils;

namespace WebApiSO.Data.Seeders
{
    internal static class ServiceOrderTypesSeeder
    {
        /// <summary>
        /// Method <see cref="AddServiceOrderTypes"/>: Extends <see cref="AppDbContext"/> type to insert initial data on 
        /// the <see cref="ServiceOrderType"/> entity.
        /// </summary>
        /// <param name="context">AppDbContext instance</param>
        /// <returns>An instance of the <see cref="Task"/> object.</returns>
        public static async Task AddServiceOrderTypes(this AppDbContext context)
        {
            if (!context.ServiceOrderTypes.Any())
            {
                var Date = DateTimeHelper.Now();
                context.ServiceOrderTypes.AddRange(new List<ServiceOrderType>()
                {
                    new ServiceOrderType(){
                        Code = "d4609eb9-376b-4380-ac00-445f3cd91998",
                        Description = "Mantenimiento",
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new ServiceOrderType(){
                        Code = "3dbe1169-7245-4c2b-b1f4-536dbd4b8252",
                        Description = "Técnica",
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new ServiceOrderType(){
                        Code = "a9c353c5-86aa-4bc7-a564-e481cbe03803",
                        Description = "Instalación",
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },new ServiceOrderType(){
                        Code = "0fa4f85f-a9ea-44ee-909a-951acfc5696e",
                        Description = "Atención al cliente",
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },new ServiceOrderType(){
                        Code = "d43df41f-ec7f-4932-94c8-7524d71cf619",
                        Description = "Logística y transporte",
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new ServiceOrderType(){
                        Code = "1135e4d3-6430-4712-bf6d-fabc67eff863",
                        Description = "Emergencia",
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new ServiceOrderType(){
                        Code = "376f275f-0192-41a7-8555-f3d0bd8317d7",
                        Description = "Servicios especializados o de proyectos",
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
