using Nethereum.Web3;
using System.Threading.Tasks;
using Nethereum.RPC.Eth.DTOs;
using VisionsContracts.Land;
using System.Linq;
using LandItemVOTest = VisionsContracts.Land.Systems.LandScenarioUserTestingSystem.ContractDefinition.LandItemDTO;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Numerics;
using static VisionsContracts.TestScenarios.PlayerLocalStateTestScenarioFactory;
using VisionsContracts.ItemsPermissioned;
using VisionsContracts.LandNFTs;
using VisionsContracts.Land.Model;

namespace VisionsContracts.TestScenarios
{
    public class LandDemoService
    {
        public IWeb3 Web3 { get; }
        public string ContractAddress { get; }

        public LandNamespace LandService { get; }

        public LandDemoService(IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractAddress = contractAddress;
            LandService = new LandNamespace(web3, contractAddress);
        }

        public Task<string> InitialiseDefaultDemoLandRequestAsync(string player)
        {
            var land = LandScenarios.GetDefaultStartUpLand();
            return LandService.Systems.LandScenarioTesting.CreateUserTestScerarioLandRequestAsync(player, land.Max(x => x.X) + 1, land.Max(x => x.Y) + 1, land.ToLandItemVOTests());
        }

        public Task<TransactionReceipt> InitialiseDefaultDemoLandRequestAndWaitForReceiptAsync(string player)
        {
            var land = LandScenarios.GetDefaultStartUpLand();
            return LandService.Systems.LandScenarioTesting.CreateUserTestScerarioLandRequestAndWaitForReceiptAsync(player, land.Max(x => x.X) + 1, land.Max(x => x.Y) + 1, land.ToLandItemVOTests());
        }

        public Task<TransactionReceipt> InitialiseDemoUserLandRequestAndWaitForReceiptAsync(string player, BigInteger x, BigInteger y, List<LandItem> landItemVOs)
        {
            return LandService.Systems.LandScenarioTesting.CreateUserTestScerarioLandRequestAndWaitForReceiptAsync(player, x, y, landItemVOs.ToLandItemVOTests());
        }

        public Task<TransactionReceipt> ResetLandRequestAndWaitForReceiptAsync(BigInteger landId, BigInteger x, BigInteger y, List<LandItem> landItemVOs)
        {
            return LandService.Systems.LandScenarioTesting.ResetUserTestLandScenarioRequestAndWaitForReceiptAsync(landId, x, y, landItemVOs.ToLandItemVOTests());
        }

        public Task<TransactionReceipt> ResetLandRequestAndWaitForReceiptAsync(BigInteger landId, TestScenario testScenario)
        {
            var playerLocalState = PlayerLocalStateTestScenarioFactory.GetPlayerLocalState(testScenario);
            var landItems = playerLocalState.UpdatedLand;
            var x = landItems.Max(x => x.X);
            var y = landItems.Max(y => y.Y);
            return LandService.Systems.LandScenarioTesting.ResetUserTestLandScenarioRequestAndWaitForReceiptAsync(landId, x, y, landItems.ToLandItemVOTests());
        }

        public Task<TransactionReceipt> ResetLandRequestAndWaitForReceiptAsync(BigInteger landId, PlayerLocalStateTestScenarioFactory.LandScenario testScenario)
        {
            var playerLocalState = PlayerLocalStateTestScenarioFactory.GetLocalState(testScenario);
            var landItems = playerLocalState.UpdatedLand;
            var x = landItems.Max(x => x.X);
            var y = landItems.Max(y => y.Y);
            return LandService.Systems.LandScenarioTesting.ResetUserTestLandScenarioRequestAndWaitForReceiptAsync(landId, x, y, landItems.ToLandItemVOTests());
        }

        public async Task<TransactionReceipt> DepositDefaultTokensAsync(BigInteger landId)
        {
            //var balance = await LandService.Systems.LandTokens.TokenBalanceOfQueryAsync(landId);
            //if (balance < Nethereum.Util.UnitConversion.Convert.ToWei(500))
            //{
            //    return await LandService.Systems.LandTokens.DepositTokensRequestAndWaitForReceiptAsync(landId, Nethereum.Util.UnitConversion.Convert.ToWei(500));
            //}
            return null;
        }

        public async Task<TransactionReceipt> MintAllInventoryItemsAsync(BigInteger landId, string itemsAddress)
        {

            var testScenario = PlayerLocalStateTestScenarioFactory.GetPlayerLocalState(PlayerLocalStateTestScenarioFactory.TestScenario.AllFloorWithAllInventoryItems);
            var itemsService = new ItemsPermissionedService(Web3, itemsAddress);

            await itemsService.MintTestInventoryItemsAsync(Web3.TransactionManager.Account.Address, testScenario.UpdatedInventoryItems);

            return await LandService.Systems.LandItems.DepositInventoryItemsAndWaitForReceiptAsync(landId, testScenario.UpdatedInventoryItems);

        }

    }

    public static class LandItemVOExtensions
    {
        public static LandItemVOTest ToLandItemVOTest(this LandItem landItem)
        {
            return new LandItemVOTest
            {
                X = landItem.X,
                Y = landItem.Y,
                ItemId = landItem.ItemId,
                PlacementTime = landItem.PlacementTime,
                StackIndex = landItem.StackIndex,
                IsRotated = landItem.IsRotated,
                DynamicUnlockTime = landItem.DynamicUnlockTime,
                DynamicTimeoutTime = landItem.DynamicTimeoutTime
            };
        }

        public static List<LandItemVOTest> ToLandItemVOTests(this List<LandItem> landItems)
        {
            return landItems.Select(ToLandItemVOTest).ToList();
        }
    }

}
