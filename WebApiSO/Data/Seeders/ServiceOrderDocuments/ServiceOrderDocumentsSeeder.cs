using FSA.Core.Interfaces;
using FSA.Core.Server.ServiceOrders.Implementations;
using FSA.Core.ServiceOrders.Models;
using FSA.Core.Utils;
using WebApiSO.Implementations;

namespace WebApiSO.Data.Seeders.ServiceOrderDocuments
{
    internal static class ServiceOrderDocumentsSeeder
    {
        /// <summary>
        /// https://www.perplexity.ai/search/iterate-over-directory-and-add-R2C9DRU5SAGoRQ6z3xNGfQ
        /// </summary>
        /// <param name="rootDirectory"></param>
        /// <returns></returns>
        public static Dictionary<string, MemoryStream> GetFileStreams(string rootDirectory)
        {
            var fileStreams = new Dictionary<string, MemoryStream>();
            var dirs = new Stack<string>();
            dirs.Push(rootDirectory);

            while (dirs.Count > 0)
            {
                string currentDir = dirs.Pop();

                // Add subdirectories to stack
                try
                {
                    foreach (var subDir in Directory.GetDirectories(currentDir))
                        dirs.Push(subDir);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error accessing subdirectories: {ex.Message}");
                    continue;
                }

                // Process files in current directory
                string[] files;
                try
                {
                    files = Directory.GetFiles(currentDir);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error accessing files: {ex.Message}");
                    continue;
                }

                foreach (var filePath in files)
                {
                    try
                    {
                        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                        {
                            var ms = new MemoryStream();
                            fs.CopyTo(ms);
                            ms.Position = 0; // Reset stream position
                            fileStreams.Add(filePath, ms);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error reading file {filePath}: {ex.Message}");
                    }
                }
            }

            return fileStreams;
        }

        /// <summary>
        /// Method <see cref="AddServiceOrderDocuments"/>: Extends <see cref="AppDbContext"/> type to insert initial data on 
        /// the <see cref="ServiceOrderDocument"/> entity.
        /// </summary>
        /// <param name="context">AppDbContext instance</param>
        /// <returns>An instance of the <see cref="Task"/> object.</returns>
        public static async Task AddServiceOrderDocuments(this AppDbContext context)
        {
            //List<string> docsPaths = GetFilesPaths(@".\Data\Docs\ServicesOrders\");
            var fileStreams = GetFileStreams(@".\Data\Docs\ServicesOrders\");
            IAzureStorageManager azureStorageManager = ResolverServicesDependencies();

            if (!context.ServiceOrderDocuments.Any())
            {
                //Auto-incrementing values ​​are reset for ServiceOrderDocument entity.
                context.DbccCheckIdent<ServiceOrderDocument>(1);
                var itemsCountSO = context.CountByRawSql("SELECT COUNT(*) FROM ServiceOrders");
                var itemsCountDocumentTypes = context.CountByRawSql("SELECT COUNT(*) FROM DocumentTypes");
                var rand = new Random();

                var Date = DateTimeHelper.Now();
                for (int i = 0; i < itemsCountSO; i++)
                {
                    var stream = fileStreams.ElementAt(i).Value;
                    var fileName = StringGenerator.GetFileName(Path.GetFileName(fileStreams.ElementAt(i).Key));
                    var url = await azureStorageManager.UploadDocumentFromStreamAsync(stream, Path.GetFileName(fileName));
                    if (!string.IsNullOrEmpty(url))
                        context.ServiceOrderDocuments.Add(
                                new(){
                                    ServiceOrderId = rand.Next(1, itemsCountSO),
                                    DocumentTypeId = rand.Next(1, itemsCountDocumentTypes),
                                    Name = fileName,
                                    Url = url,
                                    IsActive = true,
                                    CreatedAt = Date,
                                    UpdatedAt = Date
                             }
                        );
                }
                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static IAzureStorageManager ResolverServicesDependencies()
        {
            // Register the service
            var services = new ServiceCollection();
            // Resolve IConfiguration dependency
            services.AddTransient<IConfiguration>(sp =>
            {
                IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory());
                configurationBuilder.AddJsonFile("appsettings.json");
                return configurationBuilder.Build();
            });
            services.AddScoped<ISOAzureStorageManagerFactory, ServicesOrdersAzureStorageManagerFactory>();
            services.AddScoped<IAzureStorageManager, SODocumentsAzureStorageManager>();
            //// Build the service provider
            var serviceProvider = services.BuildServiceProvider();
            // Retrieve the service instance via the interface and invoke its method
            var azureStorageManagerFactory = serviceProvider.GetRequiredService<ISOAzureStorageManagerFactory>();
            var azureStorageManager = serviceProvider.GetRequiredService<IAzureStorageManager>();
            return azureStorageManager;
        }
    }
}
