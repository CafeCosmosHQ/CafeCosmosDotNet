using Nethereum.RPC.Chain;
using System.Numerics;
using VisionsContracts;
using System.Net.Http;
using System.Net.Http.Json;
using System;
using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace CafeCosmosBlazor.Services
{

   
    public class VisionsContractAddressesService : IVisionsContractAddressesService
    {
      
        public VisionsContractAddressesService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public bool ContractsLoaded()
        {
            return _contractAddresses != null;
        }
       
        public BigInteger GetChainId()
        {
            if (_contractAddresses == null) return 690;
            return _contractAddresses.ChainId;
        
        }

        static VisionsContractAddresses contractAddresses = new VisionsContractAddresses
        {
            ChainId = 690,
            RedistributorAddress = "0xd8a94218936c2ceb6182e53f0db35edf263edce5",
            TokenAddress = "0x31212186ffe0a354335cbfb2dff837900f145f46",
            ItemsAddress = "0x7df5da1bdcc7a890efd8c8d5ece1a38e2968795a",
            LandAddress = "0xBA24a3E1980D25E3A23A0d62dDA9a49917D811D6",
            VestingAddress = "0x3f3663714e22bc1ff1df0ece6e9b06ce08ff0f32",
            LandNFTAddress = "0x678063e4171e5dd2a11d380115e986c8faed8974"
        };



        public string GetChainName()
        {
            return ChainsService.GetAddEthereumChainParameter((long)GetChainId()).ChainName;
        }

        private VisionsContractAddresses _contractAddresses = contractAddresses;
       
        private readonly HttpClient httpClient;
       

        public async Task<VisionsContractAddresses> GetContractAddresses() 
        {
            if (_contractAddresses == null)
            {
                var randomid = Guid.NewGuid().ToString();
                var json = await File.ReadAllTextAsync(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "contractAddresses.json"));

                var contractAddresses = JsonSerializer.Deserialize<VisionsContractAddresses>(json);

                if (contractAddresses != null)
                {
                    _contractAddresses = contractAddresses;
                }
            }
            return _contractAddresses; 
        }

        public void SetContractAddresses(VisionsContractAddresses contractAddresses)        
        {
            _contractAddresses = contractAddresses;
        }
    }
}
