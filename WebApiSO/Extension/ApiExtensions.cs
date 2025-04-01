using FSA.Core.Server.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Globalization;
using System.Reflection;
using System.Text.Json.Serialization;
using WebApiSO.Data;

namespace WebApiSO.Extension
{
    public static class ApiExtensions
    {

        /// <summary>
        /// <see cref="ConfigureApi"/>: Configure Api proyect.
        /// </summary>
        /// <param name="services">The service instance</param>
        /// <param name="configuration">The configuration instance</param>
        /// <returns>The <see cref="IServiceCollection"/> instance.</returns>
        public static IServiceCollection ConfigureApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure();
            services.AddCorsServices();
            //services.AddSwaggerService();
            services.AddLocalizationService();
            services.AddResponseCaching();
            services.AddHttpClient();
            //services.AddHttpContextResolverService();
            //services.RegisterFSACoreServerServices(configuration);

            return services;
        }

        /// <summary>
        /// <see cref="Configure"/>: Add the basic configurations.
        /// </summary>
        /// <param name="services">The services</param>
        /// <returns>The <see cref="IServiceCollection"/> instance.</returns>
        public static IServiceCollection Configure(this IServiceCollection services)
        {
            services.AddControllers(); //Endpoints creados en este proyecto
            //.AddJsonOptions(options =>
            //{
            //    options.JsonSerializerOptions.PropertyNamingPolicy = null;
            //    //To avoid error likes this: "System.Text.Json.JsonException: A possible object cycle was detected."
            //    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            //});
            services.AddAntiforgery();

            return services;
        }

        /// <summary>
        /// Method <see cref="AddCorsServices"/>: Extends <see cref="IServiceCollection"/> to registers related seetings services to the Item API.
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
        /// <see cref="AddSwaggerService"/>: Add configurations for the Swagger service.
        /// </summary>
        /// <param name="services">The services</param>
        /// <returns>The <see cref="IServiceCollection"/> instance.</returns>
        public static IServiceCollection AddSwaggerService(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc(
                    "v1",
                    new OpenApiInfo { Title = "Service Orders API", Version = "v1" }
                );
                option.TagActionsBy(api => new[] { api.GroupName });
                option.DocInclusionPredicate((name, api) => true);
                option.ExampleFilters();
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //option.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
            });
            services.AddSwaggerExamplesFromAssemblyOf<Program>();
            return services;
        }

        /// <summary>
        /// <see cref="AddHttpContextResolverService"/>: Responsible for implementing the IHttpContextResolverService interface, <br/>
        /// declared in the Map.Application project.
        /// </summary>
        /// <param name="services">The service instance</param>
        /// <returns></returns>
        //public static IServiceCollection AddHttpContextResolverService(this IServiceCollection services)
        //{
        //    services.AddHttpContextAccessor();
        //    //services.AddTransient<IHttpContextResolverService, HttpContextResolverService>();
        //    return services;
        //}

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

            //services.AddScoped<ManagementDatabaseSeeder>();

            return services;
        }
    }
}
