namespace DCXAirTest.API.Modules
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Versioning;

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

                opt.ApiVersionReader =
                ApiVersionReader.Combine(
                    new HeaderApiVersionReader("Api-Version"),
                    new QueryStringApiVersionReader("Query-String-Version"));

            }).AddVersionedApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
            });

            return services;
        }
    }
}
