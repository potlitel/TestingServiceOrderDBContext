namespace SOWebApi.Extensions
{
    public static class ApiExtensions
    {
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
    }
}
