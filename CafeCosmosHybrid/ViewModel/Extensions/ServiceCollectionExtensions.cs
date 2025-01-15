using Microsoft.Extensions.DependencyInjection;

namespace CafeCosmosBlazor.ViewModel.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddViewModels(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<GameViewModel>();
            serviceCollection.AddScoped<LandPlayerViewModel>();
            serviceCollection.AddScoped<LandTestScenarioViewModel>();
            return serviceCollection;
        }
    }
    
}
