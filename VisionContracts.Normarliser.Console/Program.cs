using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Nethereum.Mud.Repositories.Postgres;
using System;
using System.Threading.Tasks;
using System.Threading;
using Npgsql;
using Nethereum.Mud.Repositories.Postgres.StoreRecordsNormaliser;

namespace VisionContracts.Normaliser.Console
{
    internal class Program
    {
        static async Task Main(string[] args)
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

                    services.Configure<NormaliserSettings>(configuration.GetSection("NormaliserSettings"));

                    // Register DbContext
                    services.AddDbContext<MudPostgresStoreRecordsDbContext>(options =>
                        options.UseNpgsql(configuration.GetConnectionString("PostgresConnection"))
                               .UseLowerCaseNamingConvention());

                    services.AddTransient<NpgsqlConnection>(provider =>
                    {
                        return new NpgsqlConnection(configuration.GetConnectionString("PostgresConnection"));
                    });

                    // Register logging
                    services.AddLogging();

                    // Register processing service
                 
                    services.AddTransient<MudPostgresStoreRecordsTableRepository>(sp =>
                    {
                        var context = sp.GetRequiredService<MudPostgresStoreRecordsDbContext>();
                        return new MudPostgresStoreRecordsTableRepository(context);
                    });

                    services.AddTransient<MudPostgresNormaliserProcessingService>();

                    
                    // Register the background service
                    services.AddHostedService<MudPostgresNormaliserBackgroundService>();
                })
                .Build();

            // Run the host, which will start the background service
            await host.RunAsync();
        }
    }
}
