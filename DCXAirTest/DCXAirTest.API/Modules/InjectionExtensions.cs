namespace DCXAirTest.API.Modules
{
    using DCXAirTest.Common.Connections;
    using DCXAirTest.Infraestructure.Repository;

    public static class InjectionExtensions
    {
        // Orientados a potrones de diseño
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            // Permite acceder al archivo de configuración appsettings.json 
            services.AddSingleton<IConfiguration>(configuration);

            services.AddSingleton<IConnectionFactory, ConnectionFactory>();

            //services.AddSingleton<ILogApplication, LogApplication>();
            //services.AddSingleton<ILogRepository, LogRepository>();

            return services;
        }
    }
}
