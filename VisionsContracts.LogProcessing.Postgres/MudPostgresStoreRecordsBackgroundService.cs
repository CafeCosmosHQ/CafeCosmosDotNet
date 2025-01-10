using Microsoft.Extensions.Logging;
using Nethereum.Mud.Repositories.Postgres;
using System;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace VisionsContracts.LogProcessing.Postgres
{
    public class MudPostgresStoreRecordsBackgroundService : BackgroundService
    {
        private readonly MudPostgresStoreRecordsProcessingService _processingService;
        private readonly ILogger<MudPostgresStoreRecordsBackgroundService> _logger;
        private readonly BlockchainSettings _blockchainSettings;

        public MudPostgresStoreRecordsBackgroundService(
            MudPostgresStoreRecordsProcessingService processingService,
            ILogger<MudPostgresStoreRecordsBackgroundService> logger, IOptions<BlockchainSettings> blockchainSettings)
        {
            _processingService = processingService;
            _logger = logger;
            _blockchainSettings = blockchainSettings.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Starting MudPostgresStoreRecordsBackgroundService");
            _processingService.Address = _blockchainSettings.Address;
            _processingService.RpcUrl = _blockchainSettings.RpcUrl;
            _processingService.StartAtBlockNumberIfNotProcessed = _blockchainSettings.StartAtBlockNumberIfNotProcessed;
            _processingService.NumberOfBlocksToProcessPerRequest = _blockchainSettings.NumberOfBlocksToProcessPerRequest;

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation("Running MudPostgresStoreRecordsProcessingService");
                    await _processingService.ExecuteAsync(stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred in MudPostgresStoreRecordsBackgroundService");
                }
            }
        }
    }

}
