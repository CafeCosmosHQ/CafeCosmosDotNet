using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using VisionsContracts.Faucet;

namespace HttpUtil
{
    public class HttpHelper : IHttpHelper
    {
        private readonly HttpClient _httpClient;

        public HttpHelper(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> GetAsync<T>(string path)
        {
            Console.WriteLine(path);
            var response = await _httpClient.GetAsync(path);

            // response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }
            else
            {

                throw new Exception($"Error: {response.StatusCode}, {response.Content.ReadAsStringAsync().Result}, {response.Headers.ToString()}");
            }
        }

        public async Task<TResponse> PostAsync<TResponse, TRequest>(string path, TRequest request)
        {
            Console.WriteLine(path);
            var response = await _httpClient.PostAsJsonAsync(path, request);
            // response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<TResponse>();
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}, {response.Content.ReadAsStringAsync().Result}");
            }
        }
    }
}
