using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VisionsContracts.Vesting.ContractDefinition;

namespace VisionsContracts.Vesting
{
    public partial class VestingService
    {
        public async static Task<VestingDeployment> CreateVestingDeploymentStartingNowAsync(IWeb3 web3, string softTokenAddress, string redistributorAddress, DateTime targetDateTime)
        {
            var block = await web3.Eth.Blocks.GetBlockWithTransactionsByNumber.SendRequestAsync(BlockParameter.CreateLatest()).ConfigureAwait(false);
            var blockTimestamp = block.Timestamp.Value;

            var targetUnixTimestamp = ((DateTimeOffset)targetDateTime).ToUnixTimeSeconds();

            ulong durationDifference = (ulong)targetUnixTimestamp - (ulong)blockTimestamp;
            var deployment = new VestingDeployment
            {
                SoftToken = softTokenAddress,
                Redistributor = redistributorAddress,
                StartTimestamp = (ulong)blockTimestamp,
                DurationSeconds = durationDifference,
            };
            return deployment;
        }

        public static async Task<VestingDeployment> CreateVestingDeploymentAsync(IWeb3 web3, string softTokenAddress, string redistributorAddress, DateTime startDateTime, DateTime endDateTime)
        {
            // Get the latest block timestamp
            var block = await web3.Eth.Blocks.GetBlockWithTransactionsByNumber.SendRequestAsync(BlockParameter.CreateLatest()).ConfigureAwait(false);
            var blockTimestamp = block.Timestamp.Value;

            // Convert the start and end DateTime to Unix timestamps
            var startUnixTimestamp = ((DateTimeOffset)startDateTime).ToUnixTimeSeconds();
            var endUnixTimestamp = ((DateTimeOffset)endDateTime).ToUnixTimeSeconds();

            // Ensure the start date is not earlier than the block timestamp
            var effectiveStartTimestamp = (ulong)Math.Max((long)blockTimestamp, startUnixTimestamp);

            // Calculate the duration between the start and end timestamps
            ulong durationDifference = (ulong)(endUnixTimestamp - startUnixTimestamp);

            var deployment = new VestingDeployment
            {
                SoftToken = softTokenAddress,
                Redistributor = redistributorAddress,
                StartTimestamp = effectiveStartTimestamp,
                DurationSeconds = durationDifference,
            };

            return deployment;
        }
    }
}
