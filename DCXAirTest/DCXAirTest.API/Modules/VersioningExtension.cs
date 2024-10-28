namespace DCXAirTest.API.Modules
{
    using Asp.Versioning;


    public static class VersioningExtension
    {
        /// <summary>
        /// Método estático que permite configurar el versionamiento.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(opt =>
            {
                opt.DefaultApiVersion = new ApiVersion(1, 0);
                opt.ReportApiVersions = true;
                opt.AssumeDefaultVersionWhenUnspecified = true;

            }).AddApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'V";
                setup.SubstituteApiVersionInUrl = true;
            });

            return services;
        }
    }
}
