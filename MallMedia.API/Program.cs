using MallMedia.API.Extensions;
using MallMedia.API.Middlewares;
using MallMedia.Application.Extensions;
using MallMedia.Infrastructure.Extensions;
using MallMedia.Infrastructure.Seeders;
using Serilog;
try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.


    builder.AddPresentation();
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration);
    // Add CORS policy to allow requests from localhost:7220
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowLocalhost", policy =>
            policy
            .WithOrigins("https://localhost:7220")
                  // Allow frontend origin
                  .AllowAnyHeader()  // Allow any headers
                  .AllowAnyMethod()); // Allow any HTTP method (GET, POST, etc.)
    });

    var app = builder.Build();

    // Enable CORS globally (apply to all controllers)
    app.UseCors("AllowLocalhost");

    var scope = app.Services.CreateScope();
    var seeder = scope.ServiceProvider.GetRequiredService<IInitialSeeder>();
    await seeder.Seed();

    app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseMiddleware<RequestTimeLoggingMiddleware>();
    app.UseSerilogRequestLogging();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }


    app.UseHttpsRedirection();

    app.UseAuthorization();
    app.UseStaticFiles();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application startup failed");
}
finally
{
    Log.CloseAndFlush();
}