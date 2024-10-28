using DCXAirTest.Application.Contracts;
using DCXAirTest.Common.Configuration;

namespace DCXAirTest.API.Endpoints
{
    public static class InfoEndpoint
    {
        public static void AddInfoEndpoints(this IEndpointRouteBuilder app)
        {
            #region Endpoints
            app.MapGet("/info", () => Constants.MESSAGE_INFO);
            #endregion
        }
    }
}
