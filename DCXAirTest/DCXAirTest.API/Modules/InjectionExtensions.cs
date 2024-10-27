namespace DCXAirTest.API.Modules
{
    using DCXAirTest.Application.Contracts;
    using DCXAirTest.Application.Implementations;
    using DCXAirTest.Common;
    using DCXAirTest.Common.Connections;
    using DCXAirTest.Common.Logging;
    using DCXAirTest.Domain.Core;
    using DCXAirTest.Domain.Interface;
    using DCXAirTest.Domain.Repository;
    using DCXAirTest.Infraestructure.Repository;

    public static class InjectionExtensions
    {
        // Orientados a potrones de diseño
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            // Permite acceder al archivo de configuración appsettings.json 
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            //Database
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();

            //inyeccion de Seeders 
            services.AddSingleton<ISeederApplication, SeederApplication>();
            services.AddSingleton<ISeederDomain, SeederDomain>();
            services.AddSingleton<ISeederRepository, SeederRepository>();

            //inyeccion de Flights 
            services.AddSingleton <IFlightApplication, FlightApplication>();
            services.AddSingleton<IFlightDomain, FlightDomain>();
            services.AddSingleton<IFlightRepository, FlightRepository>();

            return services;
        }
    }
}
