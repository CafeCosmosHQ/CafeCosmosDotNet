namespace CafeCosmosBlazor.ViewModel.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddViewModels(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<GameViewModel>();
            serviceCollection.AddSingleton<LandPlayerViewModel>();
            serviceCollection.AddSingleton<LandTestScenarioViewModel>();
            return serviceCollection;
        }
    }
    
}
