using Microsoft.Extensions.Logging;
using Nethereum.Mud.Repositories.Postgres;
using System;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Nethereum.Mud.Contracts.Store;
using Nethereum.Web3;
using Npgsql;
using Nethereum.Mud;
using System.Numerics;
using Nethereum.Util;
using Nethereum.Mud.Repositories.Postgres.StoreRecordsNormaliser;

namespace VisionContracts.Normaliser.Console
{
    public class MudPostgresNormaliserBackgroundService : BackgroundService
    {
        private readonly MudPostgresNormaliserProcessingService _processingService;
        private readonly ILogger<MudPostgresNormaliserBackgroundService> _logger;
        private readonly NormaliserSettings _normaliserSettings;

        public MudPostgresNormaliserBackgroundService(
            MudPostgresNormaliserProcessingService processingService,
            ILogger<MudPostgresNormaliserBackgroundService> logger,
            IOptions<NormaliserSettings> normaliserSettings)
        {
            _processingService = processingService;
            _logger = logger;
            _normaliserSettings = normaliserSettings.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Starting MudPostgresNormaliserBackgroundService");

            // Pass the settings to the processing service
            _processingService.Address = _normaliserSettings.Address;
            _processingService.RpcUrl = _normaliserSettings.RpcUrl;
            _processingService.PageSize = _normaliserSettings.PageSize;

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation("Running MudPostgresNormaliserBackgroundService");
                    await _processingService.ExecuteAsync(stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred in MudPostgresNormaliserBackgroundService");
                }
            }
        }
    }
}
