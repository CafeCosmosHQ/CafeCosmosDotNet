
using CafeCosmosBlazor.Services;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.UI;
using Nethereum.Web3;
using System.Net.Http.Json;
using VisionsContracts.Land;
using VisionsContracts.Land.Model;
using VisionsContracts.SoftToken;

using VisionsContracts.TestScenarios;

namespace CafeCosmosBlazor.ViewModel
{

    public class TestingSettings
    {
        public string OwnerKey { get; set; }
        public string OwnerAddress { get; set; }
        public string RpcUrl { get; set; }
    }

    public class LandTestScenarioViewModel
    {
        public List<List<List<LandItem>>> LandItems = new List<List<List<LandItem>>>();
        

        public LandTestScenarioViewModel(SelectedEthereumHostProviderService selectedHostProviderService, IVisionsContractAddressesService visionsContractAddressesService, HttpClient httpClient)
        {
            SelectedHostProviderService = selectedHostProviderService;
            VisionsContractAddressesService = visionsContractAddressesService;
            HttpClient = httpClient;
        }

        public PlayerLocalStateTestScenarioFactory.LandScenario SelectedTestScenario { get; set; }

        public void SelectMockLand()
        {
            var testScenario = PlayerLocalStateTestScenarioFactory.GetLocalState(SelectedTestScenario);
            LandItems = LandNamespace.ConvertTo3dArray(LandNamespace.PadLandItems(testScenario.OriginalLand));
        }

        public SelectedEthereumHostProviderService SelectedHostProviderService { get; }
        public IVisionsContractAddressesService VisionsContractAddressesService { get; }
        public HttpClient HttpClient { get; }

        public bool InitialisingPlayerLand = false;

        private TestingSettings _testingSettings;


        public async Task<TransactionReceipt> InitialisePlayerLandAsync()
        {
            try
            {
                InitialisingPlayerLand = true;
              
                var web3 = await SelectedHostProviderService.SelectedHost.GetWeb3Async();
                
                var addresses = await VisionsContractAddressesService.GetContractAddresses();
                var playerAddress = SelectedHostProviderService.SelectedHost.SelectedAccount;
                var landService = new LandNamespace(web3, addresses.LandAddress);
                var landId = await LandNamespace.GetFirstLandIdFromOwnerAsync(web3, playerAddress, addresses.LandNFTAddress);
                var landTestingService = new LandDemoService(web3, addresses.LandAddress);
               
                return await landTestingService.ResetLandRequestAndWaitForReceiptAsync(landId, SelectedTestScenario);
                

            }
            finally
            {
               InitialisingPlayerLand = false;
            }
        }

        public async Task<TransactionReceipt> DepositDefaultTestingTokensToLandAsync()
        {

            try
            {
                InitialisingPlayerLand = true;

                var web3 = await GetDeployerWeb3Async();

                var addresses = await VisionsContractAddressesService.GetContractAddresses();
                var playerAddress = SelectedHostProviderService.SelectedHost.SelectedAccount;
                var tokenService = new SoftTokenService(web3, addresses.TokenAddress);
                return await tokenService.TransferRequestAndWaitForReceiptAsync(playerAddress, Web3.Convert.ToWei(500));

                //var landService = new LandNamespace(web3, addresses.LandAddress);
                //var landId = await LandNamespace.GetFirstLandIdFromOwnerAsync(web3, playerAddress, addresses.LandNFTAddress);
                //var landTestingService = new LandDemoService(web3, addresses.LandAddress);

                //return await landTestingService.DepositDefaultTokensAsync(landId);


            }
            finally
            {
                InitialisingPlayerLand = false;
            }

        }

        public async Task<TransactionReceipt> MintAllInventoryItemsAsync()
        {

            try
            {
                InitialisingPlayerLand = true;

                var web3 = await GetDeployerWeb3Async();

                var addresses = await VisionsContractAddressesService.GetContractAddresses();
                var playerAddress = SelectedHostProviderService.SelectedHost.SelectedAccount;
                var landService = new LandNamespace(web3, addresses.LandAddress);
                var landId = await LandNamespace.GetFirstLandIdFromOwnerAsync(web3, playerAddress, addresses.LandNFTAddress);
                var landTestingService = new LandDemoService(web3, addresses.LandAddress);

                return await landTestingService.MintAllInventoryItemsAsync(landId, addresses.ItemsAddress);


            }
            finally
            {
                InitialisingPlayerLand = false;
            }

        }

        private async Task<IWeb3> GetDeployerWeb3Async()
        {
            var testingSettings = await GetTestingSettings();
            if (testingSettings == null) throw new Exception("Testing settings not found");
            return new Web3(new Nethereum.Web3.Accounts.Account(testingSettings.OwnerKey),
                testingSettings.RpcUrl);
        }

        public async Task<TestingSettings> GetTestingSettings()
        {
            if (_testingSettings == null)
            {
                var randomid = Guid.NewGuid().ToString();
                var testingSettings = await HttpClient.GetFromJsonAsync<TestingSettings>($"testingSettings.json?{randomid}");

                if (testingSettings != null)
                {
                    _testingSettings = testingSettings;
                }
            }
            return _testingSettings;
        }
    }
}

