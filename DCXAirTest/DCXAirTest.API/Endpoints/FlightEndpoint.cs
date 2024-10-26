using Asp.Versioning.Builder;
using DCXAirTest.Application.Contracts;
using DCXAirTest.Application.DTO;
using DCXAirTest.Domain.Entity.ValueObject;

namespace DCXAirTest.API.Endpoints
{
    public static class FlightEndpoint
    {

        public static void AddFlightEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/info", () => "Page Information!");

            //app.MapGet("/flight/{application}", async (IFlightApplication _application, string origin) =>
            //{
            //    var response = await _application.GetFligthByOriginAsync(origin);

            //    if (response.SuccessfulResult) return Results.Ok(response);
            //    else return Results.BadRequest(response.Message);

            //}).RequireAuthorization();

            //app.MapPost("api/v{apiVersion:apiVersion}/journey/insertjourneys", async (IFlightApplication _application, List<JourneyDTO> listjourney) =>
            //{

            //    var response = await _application.GetByApplicationAsync(listjourney);

            //    if (response.SuccessfulResult) return Results.Ok(response);
            //    else return Results.BadRequest(response.Message);

            //})
            // .WithApiVersionSet(apiVersionSet)
            // .MapToApiVersion(new ApiVersion(1));
        }
    }
}
