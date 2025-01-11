using Nethereum.RPC.Chain;
using System.Numerics;
using VisionsContracts;
using System.Net.Http;
using System.Net.Http.Json;
using System;

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
            if (_contractAddresses == null) return 0;
            return _contractAddresses.ChainId;
        
        }

       

        public string GetChainName()
        {
            return ChainsService.GetAddEthereumChainParameter((long)GetChainId()).ChainName;
        }

        private VisionsContractAddresses _contractAddresses = null;
       
        private readonly HttpClient httpClient;

        public async Task<VisionsContractAddresses> GetContractAddresses() 
        {
            if (_contractAddresses == null)
            {
                var randomid = Guid.NewGuid().ToString();
                var contractAddresses = await httpClient.GetFromJsonAsync<VisionsContractAddresses>($"contractAddresses.json?{randomid}");
                
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
