using WebApiSO.Data;
using WebApiSO.Data.Seeders;

namespace WebApiSO.Extension
{
    public static class DatabaseSeedersExtensions
    {
        /// <summary>
        /// Method <see cref="SeedDataBaseBasicInfo"/>: Extends <see cref="IServiceProvider"/> to configure the initial data ingestion of the API.
        /// </summary>
        /// <param name="sp"><see cref="IServiceProvider"/> instance</param>
        /// <returns>An instance of the <see cref="Task"/> object.</returns>
        public static async Task SeedDataBaseBasicInfo(this IServiceProvider sp)
        {
            using var scope = sp.CreateScope();
            var managerSeeder = scope.ServiceProvider.GetRequiredService<ManagementDatabaseSeeder>();
            await managerSeeder.SeedAsync();
        }

        internal class ManagementDatabaseSeeder
        {
            private readonly ILogger<ManagementDatabaseSeeder> logger;
            private readonly AppDbContext context;

            public ManagementDatabaseSeeder(ILogger<ManagementDatabaseSeeder> logger, AppDbContext context)
            {
                this.logger = logger;
                this.context = context;
            }

            /// <summary>
            /// Method <see cref="SeedAsync"/>: Responsible for the initial ingestion of data from the API..
            /// </summary>
            /// <returns>An instance of the <see cref="Task"/> object.</returns>
            public async Task SeedAsync()
            {
                try
                {
                    await DocumentTypesSeeder.AddDocumentTypes(context);
                    await ServiceOrderTaskStatesSeeder.AddServiceOrderTaskStates(context);
                    await ServiceOrderTypesSeeder.AddServiceOrderTypes(context);
                    await SupplyOperationsSeeder.AddSupplyOperations(context);
                    await ServiceOrderSeeder.AddServicesOrders(context);
                    await ServiceOrderTaskSeeder.AddServiceOrderTasks(context);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while ingesting initial data into the database.");
                    throw;
                }
            }
        }
    }
}
