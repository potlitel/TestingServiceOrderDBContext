using FSA.Core.ServiceOrders.Models;
using FSA.Core.ServiceOrders.Models.Masters;
using FSA.Core.Utils;
using WebApiSO.Models;

namespace WebApiSO.Data.Seeders
{
    internal static class ServiceOrderTaskSeeder
    {
        /// <summary>
        /// Method <see cref="AddServiceOrderTasks"/>: Extends <see cref="AppDbContext"/> type to insert initial data on 
        /// the <see cref="ServiceOrderTask"/> entity.
        /// </summary>
        /// <param name="context">AppDbContext instance</param>
        /// <returns>An instance of the <see cref="Task"/> object.</returns>
        public static async Task AddServiceOrderTasks(this AppDbContext context)
        {
            if (!context.ServiceOrderTasks.Any())
            {
                var observations = new List<string>
                {
                    "Inspección visual de componentes de la red",
                    "Termografía infrarroja para detectar puntos calientes.",
                    "Pruebas de aislamiento en cables y equipos.",
                    "Limpieza y lubricación de interruptores y transformadores.",
                    "Lavado de aisladores con agua desmineralizada.",
                    "Poda de árboles cercanos a las líneas eléctricas.",
                    "Despeje de vegetación en servidumbres eléctricas",
                    "Pintura y mantenimiento de torres metálicas y postes.",
                    "Tratamiento inmunizante para postes de madera.",
                    "Revisión y ajuste de conectores eléctricos.",
                    "Inspección y limpieza de cámaras subterráneas.",
                    "Mantenimiento de sistemas de puesta a tierra.",
                    "Verificación del estado de los transformadores.",
                    "Sustitución preventiva de componentes oxidados o desgastados.",
                    "Monitoreo con termovisores para identificar defectos futuros.",
                    "Inspección periódica con drones en zonas inaccesibles.",
                    "Revisión del estado estructural de postes y torres.",
                    "Reparación inmediata de líneas dañadas.",
                    "Sustitución de aisladores defectuosos.",
                    "Cambio de transformadores averiados.",
                    "Reparación o reubicación de postes dañados por accidentes o condiciones climáticas adversas.",
                    "Sustitución de conectores eléctricos defectuosos.",
                    "Reparación o cambio de cajas portabomeras y herrajes.",
                    "Monitoreo continuo del rendimiento eléctrico mediante sistemas SCADA (Supervisory Control and Data Acquisition).",
                    "Análisis termográfico avanzado para prever fallas potenciales.",
                    "Medición periódica del envejecimiento del aislamiento en cables subterráneos.",
                    "Diagnóstico del estado físico-químico del aceite dieléctrico en transformadores.",
                    "Lavado periódico con agua desmineralizada para eliminar salinidad acumulada en aislantes y componentes eléctricos",
                    "Revisión intensiva antes del verano debido al aumento del consumo energético",
                    "Inspección visual para identificar corrosión causada por niebla salina",
                    "Sustitución preventiva de componentes afectados por la salinidad marina",
                    "Instalación o reparación de sistemas contra descargas atmosféricas (pararrayos).",
                    "Verificación del correcto funcionamiento de interruptores automáticos.",
                    "Ajuste periódico en conexiones eléctricas críticas para evitar sobrecalentamientos.",
                    "Supervisión y mantenimiento del sistema eléctrico durante eventos climáticos extremos (ej., tormentas).",
                    "Actualización tecnológica en equipos obsoletos para mejorar la eficiencia energética.",
                    "Inspección de interruptores y disyuntores para identificar signos de corrosión",
                    "Inspección de sistemas de protección como fusibles y relés",
                    "Limpieza de tableros eléctricos para evitar acumulación de polvo",
                    "Lubricación de componentes electromecánicos",
                    "Revisión y ajuste periódico de tornillos y conexiones",
                    "Sustitución preventiva de piezas desgastadas",
                    "Reemplazo periódico del aceite aislante en transformadores",
                    "Limpieza externa e interna de subestaciones eléctricas",
                    "Retiro de óxido en componentes metálicos expuestos",
                    "Medición del voltaje y amperaje del sistema eléctrico",
                    "Pruebas de relés para asegurar su correcto funcionamiento",
                    "Análisis térmico mediante pruebas infrarrojas para detectar puntos calientes",
                    "Pruebas de resistencia eléctrica en cables y conexiones",
                    "Verificación del factor de potencia del sistema eléctrico"
                };

                //Auto-incrementing values ​​are reset for ServiceOrderTask entity.
                context.DbccCheckIdent<ServiceOrderTask>(0);
                var itemsCountSO = context.CountByRawSql("SELECT COUNT(*) FROM ServiceOrders");
                var itemsCountSOTS = context.CountByRawSql("SELECT COUNT(*) FROM ServiceOrderTaskStates");
                var rand = new Random();

                var Date = DateTimeHelper.Now();

                foreach (var item in observations)
                {
                    context.ServiceOrderTasks.AddRange(new List<ServiceOrderTask>()
                    {
                        new CustomServiceOrderTask(){
                            Observations = item.ToString(),
                            ExecutionDate = Date,
                            ServiceOrderTaskStateId = rand.Next(1, itemsCountSOTS),
                            ServiceOrderId = rand.Next(1, itemsCountSO),
                            CustomFieldSOTask = Guid.NewGuid().ToString(),
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
