using Nethereum.Contracts.QueryHandlers.MultiCall;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace VisionsContracts.Faucet
{
    public interface IHttpHelper
    {
        Task<T> GetAsync<T>(string path);
        Task<TResponse> PostAsync<TResponse, TRequest>(string path, TRequest request);
    }

    public class FaucetApiClientService
    {
        public FaucetApiClientService(string url, IHttpHelper httpHelper)
        {
            Url = url;
            HttpHelper = httpHelper;
        }

        public string Url { get; }
        public IHttpHelper HttpHelper { get; }  

        public Task<bool> CanRequestFundsAsync(string address)
        {
            var url =  $"{Url}/api/faucet/canrequestfunds/{address}";
            return HttpHelper.GetAsync<bool>(url);
        }

        public Task<FaucetRequestResult> RequestFundsAsync(string address)
        {
            var url = $"{Url}/api/faucet";
            return HttpHelper.PostAsync<FaucetRequestResult, string>(url, address);
        }

        public class FaucetRequestResult
        {
            public string TransactionHash { get; set; }
            public decimal Amount { get; set; }
        }
    }
}
