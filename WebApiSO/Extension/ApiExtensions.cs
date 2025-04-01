﻿using FSA.Core.Data.Extensions;
using FSA.Core.Server.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Globalization;
using System.Reflection;
using WebApiSO.Data;
using static WebApiSO.Extension.DatabaseSeedersExtensions;

namespace WebApiSO.Extension
{
    public static class ApiExtensions
    {

        /// <summary>
        /// Method <see cref="ConfigureApi"/>: Extends <see cref="IServiceCollection"/> to registers related seetings services to the API.
        /// </summary>
        /// <param name="services">The service instance</param>
        /// <param name="configuration">The configuration instance</param>
        /// <returns>The <see cref="IServiceCollection"/> instance.</returns>
        public static IServiceCollection ConfigureApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure();
            services.AddCorsServices();
            services.AddLocalizationService();
            //services.AddHttpClient();
            services.RegisterFSACoreServerServices(configuration);

            return services;
        }

        /// <summary>
        /// Method <see cref="Configure"/>: Extends <see cref="IServiceCollection"/> to add the basic configurations to the API.
        /// </summary>
        /// <param name="services">The services</param>
        /// <returns>The <see cref="IServiceCollection"/> instance.</returns>
        public static IServiceCollection Configure(this IServiceCollection services)
        {
            services.AddControllers(); //Endpoints creados en este proyecto
            services.AddAntiforgery();
            services.AddResponseCaching();
            return services;
        }

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
        /// <see cref="AddLocalizationService"/>: Add the corresponding localization to platform.
        /// </summary>
        /// <param name="services">The services</param>
        /// <returns>The <see cref="IServiceCollection"/> instance.</returns>
        public static IServiceCollection AddLocalizationService(this IServiceCollection services)
        {
            services.AddLocalization();

            var separator = new NumberFormatInfo()
            {
                NumberDecimalDigits = 0,
                NumberGroupSeparator = "."
            };
            var culture = new CultureInfo("en")
            {
                NumberFormat = separator
            };

            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            return services;
        }

        /// <summary>
        /// Method <see cref="RegisterFSACoreServerServices"/>: Extends <see cref="IServiceCollection"/> to registers FSA core server services to the API.
        /// </summary>
        /// <param name="services">IServiceCollection instance</param>
        /// <param name="configuration">IConfiguration instance</param>
        /// <returns>An instance of the <see cref="IServiceCollection"/> object.</returns>
        public static IServiceCollection RegisterFSACoreServerServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddFSACoreServerServices(configuration);
            services.AddFSASwaggerDocumentationServices("FSA ServiceOrders Test Api", "v1");
            services.AddFSAServiceOrderDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DBConnection"));
            });
            services.AddFSAServiceOrderFeaturesServices();

            services.AddScoped<ManagementDatabaseSeeder>();

            return services;
        }

        /// <summary>
        /// Method <see cref="ConfigureServiceOrdersWebApp"/>: Extends <see cref="WebApplication"/> to registers FSA core server services to the API.
        /// </summary>
        /// <param name="app">WebApplication instances</param>
        /// <returns>An instance of the <see cref="WebApplication"/> object.</returns>
        public static WebApplication ConfigureServiceOrdersWebApp(this WebApplication app) {

            app.UseSwagger();
            app.UseSwaggerUI();

            #region FSA CoreServer
            //Run pending migrations.
            app.Services.InitialiseDatabaseAsync<AppDbContext>().GetAwaiter().GetResult();
            app.Services.SeedDataBaseBasicInfo().GetAwaiter().GetResult();
            app.UseFSACoreServerServices();
            app.MapControllers();//Register Local endpoints
            app.MapFSAServiceOrderRoutes();

            app.UseAntiforgery();
            app.UseHttpsRedirection();
            app.UseCors("WebApiCors");

            #endregion

            return app;
        }
    }
}
