
using CafeCosmosBlazor.Services;
using Nethereum.UI;
using Nethereum.Util;
using Nethereum.Web3;
using VisionsContracts.Items;
using VisionsContracts.Land;
using VisionsContracts.Land.Model;
using VisionsContracts.SoftToken;

namespace CafeCosmosBlazor.ViewModel
{
    public class LandPlayerViewModel
    {
        public List<List<List<LandItem>>> LandItems = new List<List<List<LandItem>>>();

        public LandPlayerViewModel(SelectedEthereumHostProviderService selectedHostProviderService, IVisionsContractAddressesService visionsContractAddressesService)
        {
            SelectedHostProviderService = selectedHostProviderService;
            VisionsContractAddressesService = visionsContractAddressesService;
        }

        public string PlayerAddress { get; set; }
        public int? SelectedLandIndex { get; set; }
        public SelectedEthereumHostProviderService SelectedHostProviderService { get; }
        public IVisionsContractAddressesService VisionsContractAddressesService { get; }

        public async Task ViewPlayerLand()
        {
            
                LandItems = null;
                var web3 = await SelectedHostProviderService.SelectedHost.GetWeb3Async();
                var addresses = await VisionsContractAddressesService.GetContractAddresses();
                if (SelectedLandIndex == null)
                {
                    if (PlayerAddress != null && PlayerAddress.IsValidEthereumAddressHexFormat())
                    {
                        var landId = await LandNamespace.GetFirstLandIdFromOwnerAsync(web3, PlayerAddress, addresses.LandNFTAddress);
                        SelectedLandIndex = (int)landId;
                    }
                    else
                    {
                        return;
                    }
                }

              
                var landService = new LandNamespace(web3, addresses.LandAddress);
               
                var landItems = await landService.GetLandItemsAsync(SelectedLandIndex.Value);
                if (landItems != null && landItems.Count > 0)
                {
                    LandItems = LandNamespace.ConvertTo3dArray(LandNamespace.PadLandItems(landItems));
                }
            }
        }
    }

