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
                        Address = "Avenida Mar Azul, 456 – Salvador, BA – CEP: 401 BA – CEP: 40000-001",
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
                        Address = "Travessa das Palmeiras, ente, 456 – Feira de Santana, BA – CEP: 44000-002",
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
                        Address = "Travessa do789 – Feira de Santana, BA – CEP: 44001-230",
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
                        Address = "Rua dos Coqueiros, 101 – Camaçari,101** – Vitória da Conquista, BA – CEP: 45020- BA – CEP: 42800-004",
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
                        Address = "Alameda das Ondas, 202 – Ilhéus, BAabuna, BA – CEP: 45600-005",
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
                        Address = "Alameda do Horizonte, 404** – Ilhéus, BA – CEP: 45650-0077. Avenida Beira-Mar, 404 – Itacaré",
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
                        Address = "Rua do Farol, 505 – Porto Seguro, BA – CEP: 45800 BA – CEP: 45530-600",
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
                        Address = "Rua das Dunas, 707 – JequiTravessa do Pôr do Sol, 606é, BA – CEP: 45200-010",
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
                        Address = "Lauro de Freitas, BA – CEP: 42700-Estrada do Sol, 808** – Barreiras, BA – CEP: 47800800",
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
                        Address = "Avenida do Farol – Alagoinhas, BA – CEP: 48000, 808 – Juazeiro, BA – CEP: 48900-012",
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
                        Address = "Rua do Cacau, 909 – Il Teixeira de Freitas, BA – CEP: 45900-013",
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
                        Address = "Praça das Águas14. Rua das Araras, 222 – Simões Filho, BA – CEP: 43700 Claras, 111 – Alagoinhas, BA – CEP: 48000-300",
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
                        Address = "Praça do Pôr do Sol, 333 – Paulo Afonso, Rua do Mar Sereno, 222 – Itab BA – CEP: 48600-015",
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
                        Address = "Eunápolis, BA – CEP: 45820-. Estrada das Dunas, 333 – Valença, BA – CEP:016",
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
                        Address = "Rua das Ar Valença, BA – CEP: aras, 444 – Jequié45400-017",
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
                        Address = "Alameda das Gaivotas Santo Antônio de Jesus, BA – CEP: 44500-018",
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
                        Address = "Simões Filho,Travessa do L BA – CEP: 43700-700",
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
                        Address = "Avenida das Estrelas, 777 – Santo – Senhor do Bonfim, BA – CEP: 48970-020",
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
                        Address = "Guanambi, BA – CEP: 46400Rua da Brisa Suave, 666** – Paulo Afonso, BA – CEP-019",
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
                        Address = "Avenida das Palmeiras Antônio de Jesus, BA – CEP: 44500-900",
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
                        Address = "Travessa do Horizonte, 999 – Jacobina, BA – CEP: 44700-, 888** – Eunápolis, BA – CEP: 021",
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
                        Address = "Rua dos Ventos do Norte, 999 Irecê, BA – CEP: 44900-022",
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
                        Address = "Alameda – Teixeira de Freitas, BA – CEP: 45985-200",
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
                        Address = "Avenida Lago Azul, 1234 – Serrinha 43800-023",
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
                        Address = "Avenida Costa Azul, 343 – Itapetinga, BA – CEP: 48700-300",
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
                        Address = "Travessa dos Pescadores, 565 – Ipirá, BA – CEP: 44600 – Jacobina, BA – CEP: 44700-500",
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
                        Address = "Rua do Rio Doce, Serena, 1122 – Cruz das Al 676** – Brumado, BA – CEP: 46100-027",
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
                        Address = "Rua doRua das Andorinhas, 898 – Serrinha, BA – CEP: 48700",
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
                        Address = "Estrada das Mangueiras, 909 Guanambi, BA – CEP: 46430-800",
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
                        Address = "Estrada do – Conceição do Coité, BA – CEP: 48730- Sol Radiante, 7788 – Bom Jesus da Lapa030",
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
