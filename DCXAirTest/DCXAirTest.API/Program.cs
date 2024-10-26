using DCXAirTest.API.Endpoints;
using DCXAirTest.API.Modules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddFeature(builder.Configuration);
builder.Services.AddInjection(builder.Configuration);

//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddSwaggerExtension();
builder.Services.AddAuthorization();
builder.Services.AddValidator();
//builder.Services.AddVersioning();

builder.Services.AddLogging(logging =>
{
    logging.ClearProviders();
    logging.AddFile("logs/app.log", LogLevel.Warning);
});

var app = builder.Build();

app.UseAuthentication();
app.UseCors("policeApi");
app.UseAuthorization();

// Controllers extension methods and endPoints
app.AddFlightEndpoints();
app.AddSeederEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    // Enable middleware to serve swagger-ui.
    app.UseSwaggerUI(c =>
    {
        string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
        c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "My Api Flight");
    });
}

app.Run();
