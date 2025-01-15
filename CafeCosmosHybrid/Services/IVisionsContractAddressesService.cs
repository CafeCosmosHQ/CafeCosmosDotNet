using System.Numerics;
using VisionsContracts;

namespace CafeCosmosBlazor.Services
{
    public interface IVisionsContractAddressesService
    {
        bool ContractsLoaded();
        BigInteger GetChainId();
        string GetChainName();
        Task<VisionsContractAddresses> GetContractAddresses();
        void SetContractAddresses(VisionsContractAddresses contractAddresses);
    }
}