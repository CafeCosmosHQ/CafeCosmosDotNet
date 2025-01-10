using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Nethereum.Mud.Repositories.Postgres;
using Microsoft.Extensions.Configuration;

namespace VisionContracts.StoredRecordsRestApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Load configuration from appsettings.json and environment variables
            builder.Configuration
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables(); // Load settings from environment variables as well

            var configuration = builder.Configuration;

            // Add services to the container
            // Register the DbContext for PostgreSQL
            builder.Services.AddDbContext<MudPostgresStoreRecordsDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("PostgresConnection"))
                       .UseLowerCaseNamingConvention());

            // Add logging
            builder.Services.AddLogging(config =>
            {
                config.ClearProviders();
                config.AddConsole();
                config.AddConfiguration(configuration.GetSection("Logging")); // Configure logging levels from appsettings
            });

            // Add controllers
            builder.Services.AddControllers();

            // Add Swagger/OpenAPI support for development
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            // Map the controller endpoints
            app.MapControllers();

            // Start the app
            app.Run();
        }
    }
}
