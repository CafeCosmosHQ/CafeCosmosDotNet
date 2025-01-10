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
using VisionsContracts.Land.Systems.LevelingSystem.ContractDefinition;

namespace VisionsContracts.Land.Systems.LevelingSystem
{
    public partial class LevelingSystemService: LevelingSystemServiceBase
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.IWeb3 web3, LevelingSystemDeployment levelingSystemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<LevelingSystemDeployment>().SendRequestAndWaitForReceiptAsync(levelingSystemDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.IWeb3 web3, LevelingSystemDeployment levelingSystemDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<LevelingSystemDeployment>().SendRequestAsync(levelingSystemDeployment);
        }

        public static async Task<LevelingSystemService> DeployContractAndGetServiceAsync(Nethereum.Web3.IWeb3 web3, LevelingSystemDeployment levelingSystemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, levelingSystemDeployment, cancellationTokenSource);
            return new LevelingSystemService(web3, receipt.ContractAddress);
        }

        public LevelingSystemService(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
        {
        }

    }


    public partial class LevelingSystemServiceBase: ContractWeb3ServiceBase
    {

        public LevelingSystemServiceBase(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
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

        public virtual Task<string> UnlockAllLevelsRequestAsync(UnlockAllLevelsFunction unlockAllLevelsFunction)
        {
             return ContractHandler.SendRequestAsync(unlockAllLevelsFunction);
        }

        public virtual Task<TransactionReceipt> UnlockAllLevelsRequestAndWaitForReceiptAsync(UnlockAllLevelsFunction unlockAllLevelsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(unlockAllLevelsFunction, cancellationToken);
        }

        public virtual Task<string> UnlockAllLevelsRequestAsync(BigInteger landId)
        {
            var unlockAllLevelsFunction = new UnlockAllLevelsFunction();
                unlockAllLevelsFunction.LandId = landId;
            
             return ContractHandler.SendRequestAsync(unlockAllLevelsFunction);
        }

        public virtual Task<TransactionReceipt> UnlockAllLevelsRequestAndWaitForReceiptAsync(BigInteger landId, CancellationTokenSource cancellationToken = null)
        {
            var unlockAllLevelsFunction = new UnlockAllLevelsFunction();
                unlockAllLevelsFunction.LandId = landId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(unlockAllLevelsFunction, cancellationToken);
        }

        public virtual Task<string> UnlockLevelRequestAsync(UnlockLevelFunction unlockLevelFunction)
        {
             return ContractHandler.SendRequestAsync(unlockLevelFunction);
        }

        public virtual Task<TransactionReceipt> UnlockLevelRequestAndWaitForReceiptAsync(UnlockLevelFunction unlockLevelFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(unlockLevelFunction, cancellationToken);
        }

        public virtual Task<string> UnlockLevelRequestAsync(BigInteger landId, BigInteger level)
        {
            var unlockLevelFunction = new UnlockLevelFunction();
                unlockLevelFunction.LandId = landId;
                unlockLevelFunction.Level = level;
            
             return ContractHandler.SendRequestAsync(unlockLevelFunction);
        }

        public virtual Task<TransactionReceipt> UnlockLevelRequestAndWaitForReceiptAsync(BigInteger landId, BigInteger level, CancellationTokenSource cancellationToken = null)
        {
            var unlockLevelFunction = new UnlockLevelFunction();
                unlockLevelFunction.LandId = landId;
                unlockLevelFunction.Level = level;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(unlockLevelFunction, cancellationToken);
        }

        public virtual Task<string> UnlockLevelsRequestAsync(UnlockLevelsFunction unlockLevelsFunction)
        {
             return ContractHandler.SendRequestAsync(unlockLevelsFunction);
        }

        public virtual Task<TransactionReceipt> UnlockLevelsRequestAndWaitForReceiptAsync(UnlockLevelsFunction unlockLevelsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(unlockLevelsFunction, cancellationToken);
        }

        public virtual Task<string> UnlockLevelsRequestAsync(BigInteger landId, List<BigInteger> levels)
        {
            var unlockLevelsFunction = new UnlockLevelsFunction();
                unlockLevelsFunction.LandId = landId;
                unlockLevelsFunction.Levels = levels;
            
             return ContractHandler.SendRequestAsync(unlockLevelsFunction);
        }

        public virtual Task<TransactionReceipt> UnlockLevelsRequestAndWaitForReceiptAsync(BigInteger landId, List<BigInteger> levels, CancellationTokenSource cancellationToken = null)
        {
            var unlockLevelsFunction = new UnlockLevelsFunction();
                unlockLevelsFunction.LandId = landId;
                unlockLevelsFunction.Levels = levels;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(unlockLevelsFunction, cancellationToken);
        }

        public virtual Task<string> UpsertLevelRewardRequestAsync(UpsertLevelRewardFunction upsertLevelRewardFunction)
        {
             return ContractHandler.SendRequestAsync(upsertLevelRewardFunction);
        }

        public virtual Task<TransactionReceipt> UpsertLevelRewardRequestAndWaitForReceiptAsync(UpsertLevelRewardFunction upsertLevelRewardFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(upsertLevelRewardFunction, cancellationToken);
        }

        public virtual Task<string> UpsertLevelRewardRequestAsync(LevelRewardDTO levelReward)
        {
            var upsertLevelRewardFunction = new UpsertLevelRewardFunction();
                upsertLevelRewardFunction.LevelReward = levelReward;
            
             return ContractHandler.SendRequestAsync(upsertLevelRewardFunction);
        }

        public virtual Task<TransactionReceipt> UpsertLevelRewardRequestAndWaitForReceiptAsync(LevelRewardDTO levelReward, CancellationTokenSource cancellationToken = null)
        {
            var upsertLevelRewardFunction = new UpsertLevelRewardFunction();
                upsertLevelRewardFunction.LevelReward = levelReward;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(upsertLevelRewardFunction, cancellationToken);
        }

        public virtual Task<string> UpsertLevelRewardsRequestAsync(UpsertLevelRewardsFunction upsertLevelRewardsFunction)
        {
             return ContractHandler.SendRequestAsync(upsertLevelRewardsFunction);
        }

        public virtual Task<TransactionReceipt> UpsertLevelRewardsRequestAndWaitForReceiptAsync(UpsertLevelRewardsFunction upsertLevelRewardsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(upsertLevelRewardsFunction, cancellationToken);
        }

        public virtual Task<string> UpsertLevelRewardsRequestAsync(List<LevelRewardDTO> levelRewards)
        {
            var upsertLevelRewardsFunction = new UpsertLevelRewardsFunction();
                upsertLevelRewardsFunction.LevelRewards = levelRewards;
            
             return ContractHandler.SendRequestAsync(upsertLevelRewardsFunction);
        }

        public virtual Task<TransactionReceipt> UpsertLevelRewardsRequestAndWaitForReceiptAsync(List<LevelRewardDTO> levelRewards, CancellationTokenSource cancellationToken = null)
        {
            var upsertLevelRewardsFunction = new UpsertLevelRewardsFunction();
                upsertLevelRewardsFunction.LevelRewards = levelRewards;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(upsertLevelRewardsFunction, cancellationToken);
        }

        public override List<Type> GetAllFunctionTypes()
        {
            return new List<Type>
            {
                typeof(MsgSenderFunction),
                typeof(MsgValueFunction),
                typeof(WorldFunction),
                typeof(SupportsInterfaceFunction),
                typeof(UnlockAllLevelsFunction),
                typeof(UnlockLevelFunction),
                typeof(UnlockLevelsFunction),
                typeof(UpsertLevelRewardFunction),
                typeof(UpsertLevelRewardsFunction)
            };
        }

        public override List<Type> GetAllEventTypes()
        {
            return new List<Type>
            {
                typeof(StoreSetrecordEventDTO),
                typeof(StoreSplicestaticdataEventDTO)
            };
        }

        public override List<Type> GetAllErrorTypes()
        {
            return new List<Type>
            {
                typeof(SliceOutofboundsError),
                typeof(WorldAccessdeniedError)
            };
        }
    }
}
