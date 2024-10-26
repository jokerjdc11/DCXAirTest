using DCXAirTest.Application.Contracts;
using DCXAirTest.Application.DTO;

namespace DCXAirTest.API.Endpoints
{
    public static class SeederEndpoint
    {
        public static void AddSeederEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/seedFlights/", async (ISeederApplication _application, List<FlightDTO> flights) =>
            {
                var response = await _application.setNewFligthsAsync(flights);

                if (response.SuccessfulResult) return Results.Ok(response);
                else return Results.BadRequest(response.Message);

            }).RequireAuthorization();
        }
    }
}
