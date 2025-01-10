using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Mud.Contracts.Core.Systems;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.ABI.Model;
using Nethereum.ABI.FunctionEncoding;
using Nethereum.Contracts.Create2Deployment;
using Nethereum.Mud;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using VisionsContracts.Land.Systems.CraftingSystem.ContractDefinition;

namespace VisionsContracts.Land.Systems.CraftingSystem
{
    public class CraftingSystemServiceResource : SystemResource
    {
        public CraftingSystemServiceResource() : base("CraftingSystem") { }
    }
    public partial class CraftingSystemService: ISystemService<CraftingSystemServiceResource> 
    {
        public IResource Resource => this.GetResource();

        public ISystemServiceResourceRegistration SystemServiceResourceRegistrator
        {
            get
            {
                return this.GetSystemServiceResourceRegistration<CraftingSystemServiceResource, CraftingSystemService>();
            }
        }
        

        public virtual List<FunctionABI> GetSystemFunctionABIs()
        {
            return GetAllFunctionABIs();
        }

        public virtual string CalculateCreate2Address(string deployerAddress, string salt, params ByteCodeLibrary[] byteCodeLibraries)
        {
            return new CraftingSystemDeployment().CalculateCreate2Address(deployerAddress, salt, byteCodeLibraries);
        }

        public virtual Task<Create2ContractDeploymentTransactionResult> DeployCreate2ContractAsync(string deployerAddress, string salt, params ByteCodeLibrary[] byteCodeLibraries)
        {
            var create2ProxyDeployerService = Web3.Eth.Create2DeterministicDeploymentProxyService;
            var deployment = new CraftingSystemDeployment();
            return create2ProxyDeployerService.DeployContractRequestAsync(deployment, deployerAddress, salt, byteCodeLibraries);
        }
        public virtual Task<Create2ContractDeploymentTransactionReceiptResult> DeployCreate2ContractAndWaitForReceiptAsync(string deployerAddress, string salt, ByteCodeLibrary[] byteCodeLibraries, CancellationToken cancellationToken = default)
        {
            var create2ProxyDeployerService = Web3.Eth.Create2DeterministicDeploymentProxyService;
            var deployment = new CraftingSystemDeployment();
            return create2ProxyDeployerService.DeployContractRequestAndWaitForReceiptAsync(deployment, deployerAddress, salt, byteCodeLibraries, cancellationToken);
        }
    }
}
