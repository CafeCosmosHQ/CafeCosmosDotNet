using Nethereum.RPC.Eth.DTOs;
using Org.BouncyCastle.Asn1.Mozilla;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VisionsContracts.Items;
using VisionsContracts.Items.Model;
using VisionsContracts.Land.Systems.CatalogueSystem.Exceptions;
using VisionsContracts.Land.Systems.CatalogueSystem.Mapping;
using VisionsContracts.Land.Systems.CatalogueSystem.Model;

namespace VisionsContracts.Land.Systems.CatalogueSystem
{
    public partial class CatalogueSystemService
    {

        public async Task<string> UpsertDefaultAndThemeCatalogueItemsRequestAsync()
        {
            var catalogueItems = DefaultCatalogue.GetAllCatalogueItems();
            return await this.UpsertCatalogueItemsRequestAsync(catalogueItems.MapToDTO());
        }

        public async Task<TransactionReceipt> UpsertDefaultAndThemeCatalogueItemsAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
            var catalogueItems = DefaultCatalogue.GetAllCatalogueItems();
            return await this.UpsertCatalogueItemsRequestAndWaitForReceiptAsync(catalogueItems.MapToDTO(), cancellationToken);
        }

        public async Task<TransactionReceipt> PurchaseCatalogueItemAndValidateBalanceRequestAndWaitForReceiptAsync(BigInteger landId, BigInteger itemId, BigInteger quantity, BigInteger balance, CancellationTokenSource cancellationToken = null)
        {
            var totalPurchaseCostBalance = DefaultCatalogue.CalculateTotalPurchaseCostAndBalance(balance, itemId, quantity);
            if (totalPurchaseCostBalance.Balance < totalPurchaseCostBalance.TotalCost)
            {
                throw new InsufficientBalanceException(totalPurchaseCostBalance.Balance, totalPurchaseCostBalance.TotalCost);
            }

            return await this.PurchaseCatalogueItemRequestAndWaitForReceiptAsync(landId, itemId, quantity, cancellationToken);
        }

      

        public async Task<TransactionReceipt> PurchaseCatalogueItemsAndValidateBalanceRequestAndWaitForReceiptAsync(BigInteger landId, List<CatalogueItemPurchase> catalogueItemPurchases, BigInteger balance, CancellationTokenSource cancellationToken = null)
        {
            var totalPurchaseCostBalance = DefaultCatalogue.CalculateTotalPurchaseCostAndBalance(balance, catalogueItemPurchases);
            if (totalPurchaseCostBalance.Balance < totalPurchaseCostBalance.TotalCost)
            {
                throw new InsufficientBalanceException(totalPurchaseCostBalance.Balance, totalPurchaseCostBalance.TotalCost);
            }

            return await this.PurchaseCatalogueItemsRequestAndWaitForReceiptAsync(landId, catalogueItemPurchases.MapToDTO(), cancellationToken);
        }


    }
}
