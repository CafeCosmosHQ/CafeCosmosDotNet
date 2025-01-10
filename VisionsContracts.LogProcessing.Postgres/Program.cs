using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Nethereum.Mud.Repositories.Postgres;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace VisionsContracts.LogProcessing.Postgres
{
    //To: setup the database use dotnet ef migrations add InitialCreate and dotnet ef database update
    //dotnet ef migrations add InitialCreate
    //dotnet ef database update 
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Create the HostBuilder
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    // Load the configuration from appsettings.json and environment variables
                    config.SetBasePath(AppContext.BaseDirectory)
                          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                          .AddEnvironmentVariables();  // Add environment variables as a source
                })
                .ConfigureLogging(logging =>
                {
                    // Set the log level here
                    logging.ClearProviders();
                    logging.AddConsole();
                    logging.SetMinimumLevel(LogLevel.Trace); // Ensure logging is at least Information level
                })
                .ConfigureServices((context, services) =>
                {
                    // Access configuration
                    var configuration = context.Configuration;
           
                    services.Configure<BlockchainSettings>(configuration.GetSection("BlockchainSettings"));
                    
                    // Register DbContext
                    services.AddDbContext<MudPostgresStoreRecordsDbContext>(options =>
                        options.UseNpgsql(configuration.GetConnectionString("PostgresConnection"))
                               .UseLowerCaseNamingConvention());

                    // Register logging
                    services.AddLogging();

                    // Register processing service
                    services.AddTransient<MudPostgresStoreRecordsProcessingService>(sp =>
                    {
                        var context = sp.GetRequiredService<MudPostgresStoreRecordsDbContext>();
                        var loggerFactory = sp.GetRequiredService<ILoggerFactory>();
                        var logger = loggerFactory.CreateLogger("MudPostgresStoreRecordsProcessingService");
                        return new MudPostgresStoreRecordsProcessingService(context, logger);
                    });

                    // Register the background service
                    services.AddHostedService<MudPostgresStoreRecordsBackgroundService>();
                })
                .Build();

            // Run the host, which will start the background service
            await host.RunAsync();
        }
    }
}

