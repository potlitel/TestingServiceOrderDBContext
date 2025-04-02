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
                    #region ItemsToAdd
                    new CustomServiceOrder(){
                        Number = Guid.NewGuid().ToString(),
                        EstimatedEndingDate = Date.AddDays(uid),
                        Observations = "Revisión y mantenimiento de transformadores en Salvador.",
                        Address = "LoremNET.Lorem.Sentence(10)",
                        OwnerId = randomLong,
                        ExecutorId = randomLong,
                        ServiceOrderTypeId = 7,
                        CustomField = uid,
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new CustomServiceOrder(){
                        Number = Guid.NewGuid().ToString(),
                        EstimatedEndingDate = Date.AddDays(uid),
                        Observations = "Reparación de líneas de transmisión en Feira de Santana.",
                        Address = "LoremNET.Lorem.Sentence(10)",
                        OwnerId = randomLong,
                        ExecutorId = randomLong,
                        ServiceOrderTypeId = 7,
                        CustomField = uid,
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new CustomServiceOrder(){
                        Number = Guid.NewGuid().ToString(),
                        EstimatedEndingDate = Date.AddDays(uid),
                        Observations = "Sustitución de postes dañados en Vitória da Conquista.",
                        Address = "LoremNET.Lorem.Sentence(10)",
                        OwnerId = randomLong,
                        ExecutorId = randomLong,
                        ServiceOrderTypeId = 5,
                        CustomField = uid,
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new CustomServiceOrder(){
                        Number = Guid.NewGuid().ToString(),
                        EstimatedEndingDate = Date.AddDays(uid),
                        Observations = "Limpieza y mantenimiento de subestaciones en Ilhéus.",
                        Address = "LoremNET.Lorem.Sentence(10)",
                        OwnerId = randomLong,
                        ExecutorId = randomLong,
                        ServiceOrderTypeId = 2,
                        CustomField = uid,
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new CustomServiceOrder(){
                        Number = Guid.NewGuid().ToString(),
                        EstimatedEndingDate = Date.AddDays(uid),
                        Observations = "Inspección de redes aéreas en Juazeiro.",
                        Address = "LoremNET.Lorem.Sentence(10)",
                        OwnerId = randomLong,
                        ExecutorId = randomLong,
                        ServiceOrderTypeId = 6,
                        CustomField = uid,
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new CustomServiceOrder(){
                        Number = Guid.NewGuid().ToString(),
                        EstimatedEndingDate = Date.AddDays(uid),
                        Observations = "Reparación de fallas en el sistema de distribución en Camaçari.",
                        Address = "LoremNET.Lorem.Sentence(10)",
                        OwnerId = randomLong,
                        ExecutorId = randomLong,
                        ServiceOrderTypeId = 2,
                        CustomField = uid,
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new CustomServiceOrder(){
                        Number = Guid.NewGuid().ToString(),
                        EstimatedEndingDate = Date.AddDays(uid),
                        Observations = "Mantenimiento preventivo de redes subterráneas en Lauro de Freitas.",
                        Address = "LoremNET.Lorem.Sentence(10)",
                        OwnerId = randomLong,
                        ExecutorId = randomLong,
                        ServiceOrderTypeId = 2,
                        CustomField = uid,
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new CustomServiceOrder(){
                        Number = Guid.NewGuid().ToString(),
                        EstimatedEndingDate = Date.AddDays(uid),
                        Observations = "Reemplazo de cables deteriorados en Itabuna.",
                        Address = "LoremNET.Lorem.Sentence(10)",
                        OwnerId = randomLong,
                        ExecutorId = randomLong,
                        ServiceOrderTypeId = 2,
                        CustomField = uid,
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new CustomServiceOrder(){
                        Number = Guid.NewGuid().ToString(),
                        EstimatedEndingDate = Date.AddDays(uid),
                        Observations = "Verificación de medidores de energía en Jequié.",
                        Address = "LoremNET.Lorem.Sentence(10)",
                        OwnerId = randomLong,
                        ExecutorId = randomLong,
                        ServiceOrderTypeId = 3,
                        CustomField = uid,
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new CustomServiceOrder(){
                        Number = Guid.NewGuid().ToString(),
                        EstimatedEndingDate = Date.AddDays(uid),
                        Observations = "Reparación de cortocircuitos en Alagoinhas.",
                        Address = "LoremNET.Lorem.Sentence(10)",
                        OwnerId = randomLong,
                        ExecutorId = randomLong,
                        ServiceOrderTypeId = 1,
                        CustomField = uid,
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },new CustomServiceOrder(){
                        Number = Guid.NewGuid().ToString(),
                        EstimatedEndingDate = Date.AddDays(uid),
                        Observations = "Mantenimiento de sistemas de protección en Barreiras.",
                        Address = "LoremNET.Lorem.Sentence(10)",
                        OwnerId = randomLong,
                        ExecutorId = randomLong,
                        ServiceOrderTypeId = 7,
                        CustomField = uid,
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new CustomServiceOrder(){
                        Number = Guid.NewGuid().ToString(),
                        EstimatedEndingDate = Date.AddDays(uid),
                        Observations = "Revisión de conexiones domiciliarias en Teixeira de Freitas.",
                        Address = "LoremNET.Lorem.Sentence(10)",
                        OwnerId = randomLong,
                        ExecutorId = randomLong,
                        ServiceOrderTypeId = 2,
                        CustomField = uid,
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new CustomServiceOrder(){
                        Number = Guid.NewGuid().ToString(),
                        EstimatedEndingDate = Date.AddDays(uid),
                        Observations = "Reparación de daños por tormentas en Porto Seguro.",
                        Address = "LoremNET.Lorem.Sentence(10)",
                        OwnerId = randomLong,
                        ExecutorId = randomLong,
                        ServiceOrderTypeId = 5,
                        CustomField = uid,
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new CustomServiceOrder(){
                        Number = Guid.NewGuid().ToString(),
                        EstimatedEndingDate = Date.AddDays(uid),
                        Observations = "Sustitución de fusibles en Eunápolis.",
                        Address = "LoremNET.Lorem.Sentence(10)",
                        OwnerId = randomLong,
                        ExecutorId = randomLong,
                        ServiceOrderTypeId = 2,
                        CustomField = uid,
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new CustomServiceOrder(){
                        Number = Guid.NewGuid().ToString(),
                        EstimatedEndingDate = Date.AddDays(uid),
                        Observations = "Inspección de redes en áreas rurales de Santo Antônio de Jesus.",
                        Address = "LoremNET.Lorem.Sentence(10)",
                        OwnerId = randomLong,
                        ExecutorId = randomLong,
                        ServiceOrderTypeId = 2,
                        CustomField = uid,
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new CustomServiceOrder(){
                        Number = Guid.NewGuid().ToString(),
                        EstimatedEndingDate = Date.AddDays(uid),
                        Observations = "Mantenimiento de equipos de medición en Simões Filho.",
                        Address = "LoremNET.Lorem.Sentence(10)",
                        OwnerId = randomLong,
                        ExecutorId = randomLong,
                        ServiceOrderTypeId = 6,
                        CustomField = uid,
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new CustomServiceOrder(){
                        Number = Guid.NewGuid().ToString(),
                        EstimatedEndingDate = Date.AddDays(uid),
                        Observations = "Reparación de líneas de alta tensión en Paulo Afonso.",
                        Address = "LoremNET.Lorem.Sentence(10)",
                        OwnerId = randomLong,
                        ExecutorId = randomLong,
                        ServiceOrderTypeId = 2,
                        CustomField = uid,
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new CustomServiceOrder(){
                        Number = Guid.NewGuid().ToString(),
                        EstimatedEndingDate = Date.AddDays(uid),
                        Observations = "Revisión de sistemas de iluminación pública en Jacobina.",
                        Address = "LoremNET.Lorem.Sentence(10)",
                        OwnerId = randomLong,
                        ExecutorId = randomLong,
                        ServiceOrderTypeId = 3,
                        CustomField = uid,
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new CustomServiceOrder(){
                        Number = Guid.NewGuid().ToString(),
                        EstimatedEndingDate = Date.AddDays(uid),
                        Observations = "Mantenimiento de subestaciones en Valença.",
                        Address = "LoremNET.Lorem.Sentence(10)",
                        OwnerId = randomLong,
                        ExecutorId = randomLong,
                        ServiceOrderTypeId = 2,
                        CustomField = uid,
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new CustomServiceOrder(){
                        Number = Guid.NewGuid().ToString(),
                        EstimatedEndingDate = Date.AddDays(uid),
                        Observations = "Reparación de cables submarinos en Mata de São João.",
                        Address = "LoremNET.Lorem.Sentence(10)",
                        OwnerId = randomLong,
                        ExecutorId = randomLong,
                        ServiceOrderTypeId = 2,
                        CustomField = uid,
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },new CustomServiceOrder(){
                        Number = Guid.NewGuid().ToString(),
                        EstimatedEndingDate = Date.AddDays(uid),
                        Observations = "Inspección de redes en áreas comerciales de Senhor do Bonfim.",
                        Address = "LoremNET.Lorem.Sentence(10)",
                        OwnerId = randomLong,
                        ExecutorId = randomLong,
                        ServiceOrderTypeId = 5,
                        CustomField = uid,
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new CustomServiceOrder(){
                        Number = Guid.NewGuid().ToString(),
                        EstimatedEndingDate = Date.AddDays(uid),
                        Observations = "Mantenimiento de sistemas de control en Cruz das Almas.",
                        Address = "LoremNET.Lorem.Sentence(10)",
                        OwnerId = randomLong,
                        ExecutorId = randomLong,
                        ServiceOrderTypeId = 1,
                        CustomField = uid,
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new CustomServiceOrder(){
                        Number = Guid.NewGuid().ToString(),
                        EstimatedEndingDate = Date.AddDays(uid),
                        Observations = "Reparación de fallas en el suministro eléctrico en Guanambi.",
                        Address = "LoremNET.Lorem.Sentence(10)",
                        OwnerId = randomLong,
                        ExecutorId = randomLong,
                        ServiceOrderTypeId = 2,
                        CustomField = uid,
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new CustomServiceOrder(){
                        Number = Guid.NewGuid().ToString(),
                        EstimatedEndingDate = Date.AddDays(uid),
                        Observations = "Revisión de equipos de generación en Serrinha.",
                        Address = "LoremNET.Lorem.Sentence(10)",
                        OwnerId = randomLong,
                        ExecutorId = randomLong,
                        ServiceOrderTypeId = 3,
                        CustomField = uid,
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new CustomServiceOrder(){
                        Number = Guid.NewGuid().ToString(),
                        EstimatedEndingDate = Date.AddDays(uid),
                        Observations = "Mantenimiento de redes en áreas industriales de Candeias.",
                        Address = "LoremNET.Lorem.Sentence(10)",
                        OwnerId = randomLong,
                        ExecutorId = randomLong,
                        ServiceOrderTypeId = 3,
                        CustomField = uid,
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new CustomServiceOrder(){
                        Number = Guid.NewGuid().ToString(),
                        EstimatedEndingDate = Date.AddDays(uid),
                        Observations = "Reparación de daños por inundaciones en Itamaraju.",
                        Address = "LoremNET.Lorem.Sentence(10)",
                        OwnerId = randomLong,
                        ExecutorId = randomLong,
                        ServiceOrderTypeId = 1,
                        CustomField = uid,
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new CustomServiceOrder(){
                        Number = Guid.NewGuid().ToString(),
                        EstimatedEndingDate = Date.AddDays(uid),
                        Observations = "Inspección de líneas de transmisión en Conceição do Coité.",
                        Address = "LoremNET.Lorem.Sentence(10)",
                        OwnerId = randomLong,
                        ExecutorId = randomLong,
                        ServiceOrderTypeId = 2,
                        CustomField = uid,
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new CustomServiceOrder(){
                        Number = Guid.NewGuid().ToString(),
                        EstimatedEndingDate = Date.AddDays(uid),
                        Observations = "Mantenimiento de sistemas de distribución en Amargosa.",
                        Address = "LoremNET.Lorem.Sentence(10)",
                        OwnerId = randomLong,
                        ExecutorId = randomLong,
                        ServiceOrderTypeId = 7,
                        CustomField = uid,
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new CustomServiceOrder(){
                        Number = Guid.NewGuid().ToString(),
                        EstimatedEndingDate = Date.AddDays(uid),
                        Observations = "Reparación de cortes de energía en Santa Maria da Vitória.",
                        Address = "LoremNET.Lorem.Sentence(10)",
                        OwnerId = randomLong,
                        ExecutorId = randomLong,
                        ServiceOrderTypeId = 6,
                        CustomField = uid,
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    },
                    new CustomServiceOrder(){
                        Number = Guid.NewGuid().ToString(),
                        EstimatedEndingDate = Date.AddDays(uid),
                        Observations = "Revisión de sistemas de seguridad en Irecê.",
                        Address = "LoremNET.Lorem.Sentence(10)",
                        OwnerId = randomLong,
                        ExecutorId = randomLong,
                        ServiceOrderTypeId = 6,
                        CustomField = uid,
                        IsActive = true,
                        CreatedAt = Date,
                        UpdatedAt = Date
                    }
                    #endregion
                });

                await context.SaveChangesAsync();
            }
        }
    }
}
