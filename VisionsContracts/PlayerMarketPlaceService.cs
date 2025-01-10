using Nethereum.RPC.Eth.DTOs;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using VisionsContracts.Land;
using VisionsContracts.PlayerBalancePurchasing;
using VisionsContracts.Land.Systems.MarketplaceSystem.Model;
using VisionsContracts.LandLocalState;
using Nethereum.Mud.Contracts.Core.StoreEvents;

namespace VisionsContracts
{
    public class PlayerMarketPlaceService
    {
        public LandNamespace LandNamespace { get; private set; }
        public PlayerBalancePurchasingService PlayerBalancePurchasingService { get; private set; }

        public int SelectedLandId { get; set; }

        public PlayerMarketPlaceService(LandNamespace landNamespace, PlayerBalancePurchasingService playerBalancePurchasingService, int selectedLandId)
        {
            LandNamespace = landNamespace;
            PlayerBalancePurchasingService = playerBalancePurchasingService;
            SelectedLandId = selectedLandId;
        }

        public async Task<List<MarketPlaceListing>> GetMarketPlaceListingsAsync()
        {
            return await LandNamespace.Systems.Marketplace.GetMarketPlaceListingsAsync();
        }

        public async Task<TransactionReceipt> WaitForReceiptToHaveLogsAsync(TransactionReceipt transactionReceipt)
        {
            if(transactionReceipt.Logs == null || transactionReceipt.Logs.Count == 0)
            {
                await Task.Delay(500);
                transactionReceipt = await LandNamespace.Web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(transactionReceipt.TransactionHash);
            }

            return transactionReceipt;
        }

        public async Task<TransactionReceipt> BuyFromMarketplaceValidateAndApproveItemRequestAndWaitForReceiptAsync(BigInteger listingId, BigInteger quantity, PlayerLocalState playerLocalState)
        {
            var receipt = await LandNamespace.Systems.Marketplace.BuyValidateAndApproveItemRequestAndWaitForReceiptAsync(SelectedLandId, listingId, quantity, PlayerBalancePurchasingService);
            receipt = await WaitForReceiptToHaveLogsAsync(receipt);
            await ProcessAllChangesFromReceiptAsync(playerLocalState, receipt);
            return receipt;
        }

        public async Task<TransactionReceipt> ListMarketplaceItemAndWaitForReceiptAsync(BigInteger itemId, decimal unitPriceInMainUnit, BigInteger quantity, PlayerLocalState playerLocalState)
        {
            var unitPrice = Nethereum.Web3.Web3.Convert.ToWei(unitPriceInMainUnit);
            var receipt = await LandNamespace.Systems.Marketplace.ListItemRequestAndWaitForReceiptAsync(SelectedLandId, itemId, unitPrice, quantity);
            receipt = await WaitForReceiptToHaveLogsAsync(receipt);
            await ProcessAllChangesFromReceiptAsync(playerLocalState, receipt);
            return receipt;
        }

        public async Task<TransactionReceipt> CancelListingAndWaitForReceiptAsync(BigInteger listingId, PlayerLocalState playerLocalState)
        {
            var receipt = await LandNamespace.Systems.Marketplace.CancelListingRequestAndWaitForReceiptAsync(SelectedLandId, listingId);
            receipt = await WaitForReceiptToHaveLogsAsync(receipt);
            await ProcessAllChangesFromReceiptAsync(playerLocalState, receipt);
            return receipt;
        }

        public async Task<TransactionReceipt> EditListingAndWaitForReceiptAsync(BigInteger listingId, decimal unitPriceInMainUnit, BigInteger quantity, PlayerLocalState playerLocalState)
        {
            var unitPrice = Nethereum.Web3.Web3.Convert.ToWei(unitPriceInMainUnit);
            var receipt = await LandNamespace.Systems.Marketplace.EditListingRequestAndWaitForReceiptAsync(SelectedLandId, listingId, unitPrice, quantity);
            receipt = await WaitForReceiptToHaveLogsAsync(receipt);
            await ProcessAllChangesFromReceiptAsync(playerLocalState, receipt);
            return receipt;
        }

        private async Task ProcessAllChangesFromReceiptAsync(PlayerLocalState playerLocalState, TransactionReceipt receipt)
        {
            await StoreEventsLogProcessingService.ProcessAllStoreChangesFromLogs(playerLocalState.InMemoryTableRepository, receipt);
            //only interested on the inventory changes
            var inventoryItems = await LandNamespace.GetAllInventoryItemsFromTableRepositoryAsync(playerLocalState.InMemoryTableRepository, SelectedLandId);
            playerLocalState.InitInventory(inventoryItems);
            
        }
    }
}
