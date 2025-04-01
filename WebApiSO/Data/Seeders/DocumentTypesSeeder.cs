using FSA.Core.ServiceOrders.Models.Masters;
using FSA.Core.Utils;

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
                var Date = DateTimeHelper.Now();
                context.DocumentTypes.AddRange(new List<DocumentType>()
                {
                    new DocumentType(){
                        Code = "d4609eb9-376b-4380-ac00-445f3cd91998",
                        Description = "Orden de Trabajo",
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new DocumentType(){
                        Code = "3dbe1169-7245-4c2b-b1f4-536dbd4b8252",
                        Description = "Solicitud de Servicio",
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new DocumentType(){
                        Code = "a9c353c5-86aa-4bc7-a564-e481cbe03803",
                        Description = "Checklist de mantenimiento",
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },new DocumentType(){
                        Code = "0fa4f85f-a9ea-44ee-909a-951acfc5696e",
                        Description = "Manual de uso y mantenimiento",
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },new DocumentType(){
                        Code = "d43df41f-ec7f-4932-94c8-7524d71cf619",
                        Description = "Programa de mantenimiento preventivo",
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new DocumentType(){
                        Code = "1135e4d3-6430-4712-bf6d-fabc67eff863",
                        Description = "Procedimientos operativos estándar",
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new DocumentType(){
                        Code = "376f275f-0192-41a7-8555-f3d0bd8317d7",
                        Description = "Informes y Reportes",
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },new DocumentType(){
                        Code = "ba54d470-1582-499b-8447-9c1361b786a6",
                        Description = "Especificaciones Técnicas",
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
