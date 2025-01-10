using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using VisionsContracts.Land.Systems.CraftingSystem.ContractDefinition;

namespace VisionsContracts.Land.Systems.CraftingSystem
{
    public partial class CraftingSystemService: CraftingSystemServiceBase
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.IWeb3 web3, CraftingSystemDeployment craftingSystemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<CraftingSystemDeployment>().SendRequestAndWaitForReceiptAsync(craftingSystemDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.IWeb3 web3, CraftingSystemDeployment craftingSystemDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<CraftingSystemDeployment>().SendRequestAsync(craftingSystemDeployment);
        }

        public static async Task<CraftingSystemService> DeployContractAndGetServiceAsync(Nethereum.Web3.IWeb3 web3, CraftingSystemDeployment craftingSystemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, craftingSystemDeployment, cancellationTokenSource);
            return new CraftingSystemService(web3, receipt.ContractAddress);
        }

        public CraftingSystemService(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
        {
        }

    }


    public partial class CraftingSystemServiceBase: ContractWeb3ServiceBase
    {

        public CraftingSystemServiceBase(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
        {
        }

        public Task<string> MsgSenderQueryAsync(MsgSenderFunction msgSenderFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MsgSenderFunction, string>(msgSenderFunction, blockParameter);
        }

        
        public virtual Task<string> MsgSenderQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MsgSenderFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> MsgValueQueryAsync(MsgValueFunction msgValueFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MsgValueFunction, BigInteger>(msgValueFunction, blockParameter);
        }

        
        public virtual Task<BigInteger> MsgValueQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MsgValueFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> WorldQueryAsync(WorldFunction worldFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<WorldFunction, string>(worldFunction, blockParameter);
        }

        
        public virtual Task<string> WorldQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<WorldFunction, string>(null, blockParameter);
        }

        public virtual Task<string> CraftRecipeRequestAsync(CraftRecipeFunction craftRecipeFunction)
        {
             return ContractHandler.SendRequestAsync(craftRecipeFunction);
        }

        public virtual Task<TransactionReceipt> CraftRecipeRequestAndWaitForReceiptAsync(CraftRecipeFunction craftRecipeFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(craftRecipeFunction, cancellationToken);
        }

        public virtual Task<string> CraftRecipeRequestAsync(BigInteger landId, BigInteger output)
        {
            var craftRecipeFunction = new CraftRecipeFunction();
                craftRecipeFunction.LandId = landId;
                craftRecipeFunction.Output = output;
            
             return ContractHandler.SendRequestAsync(craftRecipeFunction);
        }

        public virtual Task<TransactionReceipt> CraftRecipeRequestAndWaitForReceiptAsync(BigInteger landId, BigInteger output, CancellationTokenSource cancellationToken = null)
        {
            var craftRecipeFunction = new CraftRecipeFunction();
                craftRecipeFunction.LandId = landId;
                craftRecipeFunction.Output = output;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(craftRecipeFunction, cancellationToken);
        }

        public virtual Task<string> CreateRecipeRequestAsync(CreateRecipeFunction createRecipeFunction)
        {
             return ContractHandler.SendRequestAsync(createRecipeFunction);
        }

        public virtual Task<TransactionReceipt> CreateRecipeRequestAndWaitForReceiptAsync(CreateRecipeFunction createRecipeFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createRecipeFunction, cancellationToken);
        }

        public virtual Task<string> CreateRecipeRequestAsync(CraftingRecipeDTO recipe)
        {
            var createRecipeFunction = new CreateRecipeFunction();
                createRecipeFunction.Recipe = recipe;
            
             return ContractHandler.SendRequestAsync(createRecipeFunction);
        }

        public virtual Task<TransactionReceipt> CreateRecipeRequestAndWaitForReceiptAsync(CraftingRecipeDTO recipe, CancellationTokenSource cancellationToken = null)
        {
            var createRecipeFunction = new CreateRecipeFunction();
                createRecipeFunction.Recipe = recipe;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createRecipeFunction, cancellationToken);
        }

        public virtual Task<string> CreateRecipesRequestAsync(CreateRecipesFunction createRecipesFunction)
        {
             return ContractHandler.SendRequestAsync(createRecipesFunction);
        }

        public virtual Task<TransactionReceipt> CreateRecipesRequestAndWaitForReceiptAsync(CreateRecipesFunction createRecipesFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createRecipesFunction, cancellationToken);
        }

        public virtual Task<string> CreateRecipesRequestAsync(List<CraftingRecipeDTO> recipes)
        {
            var createRecipesFunction = new CreateRecipesFunction();
                createRecipesFunction.Recipes = recipes;
            
             return ContractHandler.SendRequestAsync(createRecipesFunction);
        }

        public virtual Task<TransactionReceipt> CreateRecipesRequestAndWaitForReceiptAsync(List<CraftingRecipeDTO> recipes, CancellationTokenSource cancellationToken = null)
        {
            var createRecipesFunction = new CreateRecipesFunction();
                createRecipesFunction.Recipes = recipes;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createRecipesFunction, cancellationToken);
        }

        public virtual Task<string> RemoveRecipeRequestAsync(RemoveRecipeFunction removeRecipeFunction)
        {
             return ContractHandler.SendRequestAsync(removeRecipeFunction);
        }

        public virtual Task<TransactionReceipt> RemoveRecipeRequestAndWaitForReceiptAsync(RemoveRecipeFunction removeRecipeFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeRecipeFunction, cancellationToken);
        }

        public virtual Task<string> RemoveRecipeRequestAsync(CraftingRecipeDTO recipe)
        {
            var removeRecipeFunction = new RemoveRecipeFunction();
                removeRecipeFunction.Recipe = recipe;
            
             return ContractHandler.SendRequestAsync(removeRecipeFunction);
        }

        public virtual Task<TransactionReceipt> RemoveRecipeRequestAndWaitForReceiptAsync(CraftingRecipeDTO recipe, CancellationTokenSource cancellationToken = null)
        {
            var removeRecipeFunction = new RemoveRecipeFunction();
                removeRecipeFunction.Recipe = recipe;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeRecipeFunction, cancellationToken);
        }

        public Task<bool> SupportsInterfaceQueryAsync(SupportsInterfaceFunction supportsInterfaceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SupportsInterfaceFunction, bool>(supportsInterfaceFunction, blockParameter);
        }

        
        public virtual Task<bool> SupportsInterfaceQueryAsync(byte[] interfaceId, BlockParameter blockParameter = null)
        {
            var supportsInterfaceFunction = new SupportsInterfaceFunction();
                supportsInterfaceFunction.InterfaceId = interfaceId;
            
            return ContractHandler.QueryAsync<SupportsInterfaceFunction, bool>(supportsInterfaceFunction, blockParameter);
        }

        public override List<Type> GetAllFunctionTypes()
        {
            return new List<Type>
            {
                typeof(MsgSenderFunction),
                typeof(MsgValueFunction),
                typeof(WorldFunction),
                typeof(CraftRecipeFunction),
                typeof(CreateRecipeFunction),
                typeof(CreateRecipesFunction),
                typeof(RemoveRecipeFunction),
                typeof(SupportsInterfaceFunction)
            };
        }

        public override List<Type> GetAllEventTypes()
        {
            return new List<Type>
            {
                typeof(CraftRecipeEventDTO),
                typeof(CraftRecipeXpRewardEventDTO),
                typeof(StoreDeleterecordEventDTO),
                typeof(StoreSetrecordEventDTO),
                typeof(StoreSplicestaticdataEventDTO)
            };
        }

        public override List<Type> GetAllErrorTypes()
        {
            return new List<Type>
            {
                typeof(AccessByNoOperatorError),
                typeof(SliceOutofboundsError),
                typeof(WorldAccessdeniedError)
            };
        }
    }
}
