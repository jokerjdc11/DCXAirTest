using Asp.Versioning.ApiExplorer;
using Asp.Versioning.Builder;
using DCXAirTest.API.Endpoints;
using DCXAirTest.API.Modules;
using DCXAirTest.API.OpenApi;
using DCXAirTest.Common;
using DCXAirTest.Infraestructure.Data;
using SQLitePCL;

var builder = WebApplication.CreateBuilder(args);
// api version
builder.Services.AddSingleton<ApiVersionSetBuilder>(new ApiVersionSetBuilder("1"));

// Inicializa SQLitePCL
SQLitePCL.Batteries.Init();

// Add services to the container.
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddFeature(builder.Configuration);
builder.Services.AddInjection(builder.Configuration);
builder.Services.AddTransient<DataSeeder>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddSwaggerExtension();
builder.Services.ConfigureOptions<ConfigureSwaggerGenOptions>();
//builder.Services.AddAuthorization();
builder.Services.AddValidator();
builder.Services.AddVersioning();

builder.Services.AddLogging(logging =>
{
    logging.ClearProviders();
    logging.AddFile("logs/app.log", LogLevel.Warning);
});

var app = builder.Build();

// Run the seeder at application startup
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
    await seeder.SeedDataAsync(); // Llama al método de seed
}

app.UseAuthentication();
app.UseCors("policeApi");
//app.UseAuthorization();

// Controllers extension methods and endPoints
app.AddFlightEndpoints();
app.AddSeederEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) { }

app.UseSwagger();

// Enable middleware to serve swagger-ui.
app.UseSwaggerUI(c =>
{
    string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";

    IReadOnlyList<ApiVersionDescription> descriptions = app.DescribeApiVersions();

    foreach (ApiVersionDescription description in descriptions)
    {
        string url = $"{swaggerJsonBasePath}/swagger/{description.GroupName}/swagger.json";
        string name = $" My Api Flight {description.GroupName.ToLowerInvariant()}";

        c.SwaggerEndpoint(url, name);
    }
});
app.Run();
