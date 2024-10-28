namespace DCXAirTest.API.Endpoints
{
    using DCXAirTest.Application.Contracts;
    using DCXAirTest.Application.DTO;
    using Microsoft.AspNetCore.Mvc;

    public static class SeederEndpoint
    {
        public static void AddSeederEndpoints(this IEndpointRouteBuilder app)
        {

            #region Endpoints

            //Posible implementacion de CQRS por tiempo no implementado
            app.MapPost("/seedFlights", async (ISeederApplication _application, [FromBody] List<FlightDTO> listFlights) =>
            {
                if (listFlights == null || !listFlights.Any())
                {
                    return Results.BadRequest("La lista de vuelos no puede estar vacía.");
                }
                var response = await _application.setNewFligthsAsync(listFlights);

                if (response.SuccessfulResult) return Results.Ok(response);
                else return Results.BadRequest(response.Message);
            });
            #endregion
        }
    }
}
