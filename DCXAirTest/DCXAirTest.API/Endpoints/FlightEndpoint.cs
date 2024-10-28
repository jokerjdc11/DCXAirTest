namespace DCXAirTest.API.Endpoints
{
    using DCXAirTest.Application.Contracts;
    using DCXAirTest.Application.Validators;

    public static class FlightEndpoint
    {
        public static void AddFlightEndpoints(this IEndpointRouteBuilder app)
        {
            var journeyFilterValidator = new FlightFilterValidator();

            #region Endpoints

            app.MapGet("/Flights/oneWay", async (IFlightApplication _application, string origin, string destination, string currency) =>
            {

                var response = await _application.GetJourneysOneWayAsync(origin, destination, currency);

                if (response.SuccessfulResult) return Results.Ok(response);
                else return Results.BadRequest(response.Message);
            });

            app.MapGet("/Flights/roundTrip", async (IFlightApplication _application, string origin, string destination, string currency) =>
            {

                var response = await _application.GetJourneysRoundTripAsync(origin, destination, currency);

                if (response.SuccessfulResult) return Results.Ok(response);
                else return Results.BadRequest(response.Message);
            });
            #endregion
        }
    }
}
