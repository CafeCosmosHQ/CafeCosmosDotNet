using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using CafeCosmosBlazor;
using Microsoft.AspNetCore.Components.Authorization;
using Nethereum.Blazor;
using Nethereum.Metamask.Blazor;
using Nethereum.Metamask;
using Nethereum.UI;
using CafeCosmosBlazor.ViewModel.Extensions;
using CafeCosmosBlazor.Services;
using CafeCosmosBlazor.ViewModel;
using Microsoft.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.Services.AddAuthorizationCore();

builder.RootComponents.Add<HeadOutlet>("head::after");

var httpClient = new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
};
builder.Services.AddSingleton(sp => httpClient);
builder.Services.AddMudServices();

builder.Services.AddSingleton<IMetamaskInterop, MetamaskBlazorInterop>();
builder.Services.AddSingleton<MetamaskHostProvider>();

var nethereumHostProvider = new NethereumHostProvider();
builder.Services.AddSingleton<NethereumHostProvider>(nethereumHostProvider);

var visionsContractsAddressService = new VisionsContractAddressesService(httpClient);
builder.Services.AddSingleton<IVisionsContractAddressesService>(visionsContractsAddressService);

await visionsContractsAddressService.GetContractAddresses();

//Add metamask as the selected ethereum host provider
builder.Services.AddSingleton(services =>
{
    //var metamaskHostProvider = services.GetService<NethereumHostProvider>();
    var metamaskHostProvider = services.GetService<MetamaskHostProvider>();
    var selectedHostProvider = new SelectedEthereumHostProviderService();
    selectedHostProvider.SetSelectedEthereumHostProvider(metamaskHostProvider);
    return selectedHostProvider;
});


builder.Logging.SetMinimumLevel(LogLevel.Warning);

builder.Services.AddSingleton<AuthenticationStateProvider, EthereumAuthenticationStateProvider>();



builder.Services.AddViewModels();




await builder.Build().RunAsync();
