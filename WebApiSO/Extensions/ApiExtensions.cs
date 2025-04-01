using FSA.Core.Server.Extensions;
using Microsoft.EntityFrameworkCore;
using WebApiSO.Data;

namespace WebApiSO.Extensions
{
    public static class ApiExtensions
    {
        /// <summary>
        /// Method <see cref="AddCorsServices"/>: Extends <see cref="IServiceCollection"/> to registers related seetings services to the API.
        /// </summary>
        /// <param name="context">IServiceCollection instance</param>
        /// <returns>An instance of the <see cref="IServiceCollection"/> object.</returns>
        public static IServiceCollection AddCorsServices(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: "WebApiSOCors",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .WithExposedHeaders("*");
                    }
                );
            });

            return services;
        }

        /// <summary>
        /// Method <see cref="AddFSACoreServerServices"/>: Extends <see cref="IServiceCollection"/> to registers FSA core server services to the API.
        /// </summary>
        /// <param name="services">IServiceCollection instance</param>
        /// <param name="configuration">IConfiguration instance</param>
        /// <returns>An instance of the <see cref="IServiceCollection"/> object.</returns>
        public static IServiceCollection AddFSACoreServerServices(this IServiceCollection services, IConfiguration configuration) {

            services.AddFSACoreServerServices(configuration);
            services.AddFSASwaggerDocumentationServices("FSA ServiceOrders Test Api", "v1");
            services.AddFSAServiceOrderDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DBConnection"));
            });
            services.AddFSAServiceOrderFeaturesServices();

            //services.AddScoped<ManagementDatabaseSeeder>();

            return services;
        }
    }
}
