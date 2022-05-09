namespace PromocodeFactoryApi.Extensions
{
    public static  class ServiceExtensions
    {
        // Метод расширения для CORS
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.AllowAnyMethod().AllowAnyHeader());
            });

        }
        // Метод расширения для IIS
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>{});
        }
    }
}
