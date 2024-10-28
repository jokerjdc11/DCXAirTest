namespace DCXAirTest.API.Modules
{
    using DCXAirTest.API.Helpers;
    public static class FeatureExtensions
    {
        /// <summary>
        /// Método estático que permite configurar las características generales como los CORS.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddFeature(this IServiceCollection services, IConfiguration configuration)
        {
            #region Features Configuration.

            // Se define la politica.
            string myPolice = "policeApi";

            // Se mapea la información de la sección config en el helper AppSettings para tener dicha info en memoria.
            var appSettingsSection = configuration.GetSection("Config");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();

            // Se define la configuración para las peticiones de origenes cruzados.
            services.AddCors(options =>
            {
                options.AddPolicy(myPolice,
                                 builder => builder
                                    .WithOrigins(appSettings.OriginCors)
                                    .AllowAnyMethod()
                                    .AllowAnyHeader()
                                );
            });

            #endregion

            return services;
        }
    }
}
