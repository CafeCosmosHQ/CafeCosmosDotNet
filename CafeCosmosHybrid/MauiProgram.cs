using CafeCosmosBlazor.Services;
using CafeCosmosBlazor.ViewModel.Extensions;
using Microsoft.Extensions.Logging;
using Nethereum.UI;
using MudBlazor;
using Microsoft.AspNetCore.Components.Authorization;
using Nethereum.Blazor;
using MudBlazor.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CafeCosmosBlazor
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddAuthorizationCore();
            builder.Services.AddSingleton(new HttpClient());
            builder.Services.AddMudServices();


            var nethereumHostProvider = new NethereumHostProvider();
            nethereumHostProvider.SetUrl("https://rpc.redstonechain.com");
            builder.Services.AddSingleton<NethereumHostProvider>(nethereumHostProvider);


            builder.Services.AddSingleton<IVisionsContractAddressesService, VisionsContractAddressesService>();

            //Add nethereum as the selected ethereum host provider
            builder.Services.AddSingleton(services =>
            {
                var nethereumHostProvider = services.GetService<NethereumHostProvider>();
                var selectedHostProvider = new SelectedEthereumHostProviderService();
                selectedHostProvider.SetSelectedEthereumHostProvider(nethereumHostProvider);
                return selectedHostProvider;
            });


            builder.Logging.SetMinimumLevel(LogLevel.Warning);

            builder.Services.AddSingleton<AuthenticationStateProvider, EthereumAuthenticationStateProvider>();



            builder.Services.AddViewModels();

            return builder.Build();
        }
    }
}
