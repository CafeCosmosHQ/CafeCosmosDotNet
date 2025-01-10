using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Nethereum.Mud.Repositories.Postgres;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using System.IO;

namespace VisionsContracts.LogProcessing.Postgres
{
    public class DesignTimeMudPostgresStoreRecordsDbContextFactory : IDesignTimeDbContextFactory<MudPostgresStoreRecordsDbContext>
    {
        public MudPostgresStoreRecordsDbContext CreateDbContext(string[] args)
        {
            // Load the configuration from the appsettings.json or other sources
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)  
                .AddEnvironmentVariables() // cloud
                .Build();

            // Get the connection string from the configuration
            var connectionString = configuration.GetConnectionString("PostgresConnection");

            // Configure the DbContext options
            var optionsBuilder = new DbContextOptionsBuilder<MudPostgresStoreRecordsDbContext>();
            optionsBuilder.UseNpgsql(connectionString, b => b.MigrationsAssembly("VisionsContracts.LogProcessing.Postgres"))
                    .UseLowerCaseNamingConvention();

            return new MudPostgresStoreRecordsDbContext(optionsBuilder.Options
                 );
        }
    }
}
