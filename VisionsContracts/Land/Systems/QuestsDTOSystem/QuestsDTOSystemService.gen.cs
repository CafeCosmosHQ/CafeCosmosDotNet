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
using VisionsContracts.Land.Systems.QuestsDTOSystem.ContractDefinition;

namespace VisionsContracts.Land.Systems.QuestsDTOSystem
{
    public partial class QuestsDTOSystemService: QuestsDTOSystemServiceBase
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.IWeb3 web3, QuestsDTOSystemDeployment questsDTOSystemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<QuestsDTOSystemDeployment>().SendRequestAndWaitForReceiptAsync(questsDTOSystemDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.IWeb3 web3, QuestsDTOSystemDeployment questsDTOSystemDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<QuestsDTOSystemDeployment>().SendRequestAsync(questsDTOSystemDeployment);
        }

        public static async Task<QuestsDTOSystemService> DeployContractAndGetServiceAsync(Nethereum.Web3.IWeb3 web3, QuestsDTOSystemDeployment questsDTOSystemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, questsDTOSystemDeployment, cancellationTokenSource);
            return new QuestsDTOSystemService(web3, receipt.ContractAddress);
        }

        public QuestsDTOSystemService(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
        {
        }

    }


    public partial class QuestsDTOSystemServiceBase: ContractWeb3ServiceBase
    {

        public QuestsDTOSystemServiceBase(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
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

        public virtual Task<string> AddNewQuestRequestAsync(AddNewQuestFunction addNewQuestFunction)
        {
             return ContractHandler.SendRequestAsync(addNewQuestFunction);
        }

        public virtual Task<TransactionReceipt> AddNewQuestRequestAndWaitForReceiptAsync(AddNewQuestFunction addNewQuestFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addNewQuestFunction, cancellationToken);
        }

        public virtual Task<string> AddNewQuestRequestAsync(QuestDTO questDTO)
        {
            var addNewQuestFunction = new AddNewQuestFunction();
                addNewQuestFunction.QuestDTO = questDTO;
            
             return ContractHandler.SendRequestAsync(addNewQuestFunction);
        }

        public virtual Task<TransactionReceipt> AddNewQuestRequestAndWaitForReceiptAsync(QuestDTO questDTO, CancellationTokenSource cancellationToken = null)
        {
            var addNewQuestFunction = new AddNewQuestFunction();
                addNewQuestFunction.QuestDTO = questDTO;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addNewQuestFunction, cancellationToken);
        }

        public virtual Task<string> AddNewQuestsRequestAsync(AddNewQuestsFunction addNewQuestsFunction)
        {
             return ContractHandler.SendRequestAsync(addNewQuestsFunction);
        }

        public virtual Task<TransactionReceipt> AddNewQuestsRequestAndWaitForReceiptAsync(AddNewQuestsFunction addNewQuestsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addNewQuestsFunction, cancellationToken);
        }

        public virtual Task<string> AddNewQuestsRequestAsync(List<QuestDTO> quests)
        {
            var addNewQuestsFunction = new AddNewQuestsFunction();
                addNewQuestsFunction.Quests = quests;
            
             return ContractHandler.SendRequestAsync(addNewQuestsFunction);
        }

        public virtual Task<TransactionReceipt> AddNewQuestsRequestAndWaitForReceiptAsync(List<QuestDTO> quests, CancellationTokenSource cancellationToken = null)
        {
            var addNewQuestsFunction = new AddNewQuestsFunction();
                addNewQuestsFunction.Quests = quests;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addNewQuestsFunction, cancellationToken);
        }

        public virtual Task<string> AddRewardsRequestAsync(AddRewardsFunction addRewardsFunction)
        {
             return ContractHandler.SendRequestAsync(addRewardsFunction);
        }

        public virtual Task<TransactionReceipt> AddRewardsRequestAndWaitForReceiptAsync(AddRewardsFunction addRewardsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addRewardsFunction, cancellationToken);
        }

        public virtual Task<string> AddRewardsRequestAsync(List<RewardDTO> rewardDTO)
        {
            var addRewardsFunction = new AddRewardsFunction();
                addRewardsFunction.RewardDTO = rewardDTO;
            
             return ContractHandler.SendRequestAsync(addRewardsFunction);
        }

        public virtual Task<TransactionReceipt> AddRewardsRequestAndWaitForReceiptAsync(List<RewardDTO> rewardDTO, CancellationTokenSource cancellationToken = null)
        {
            var addRewardsFunction = new AddRewardsFunction();
                addRewardsFunction.RewardDTO = rewardDTO;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addRewardsFunction, cancellationToken);
        }

        public virtual Task<GetAllActiveQuestGroupsOutputDTO> GetAllActiveQuestGroupsQueryAsync(GetAllActiveQuestGroupsFunction getAllActiveQuestGroupsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetAllActiveQuestGroupsFunction, GetAllActiveQuestGroupsOutputDTO>(getAllActiveQuestGroupsFunction, blockParameter);
        }

        public virtual Task<GetAllActiveQuestGroupsOutputDTO> GetAllActiveQuestGroupsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetAllActiveQuestGroupsFunction, GetAllActiveQuestGroupsOutputDTO>(null, blockParameter);
        }

        public virtual Task<GetAllQuestsOutputDTO> GetAllQuestsQueryAsync(GetAllQuestsFunction getAllQuestsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetAllQuestsFunction, GetAllQuestsOutputDTO>(getAllQuestsFunction, blockParameter);
        }

        public virtual Task<GetAllQuestsOutputDTO> GetAllQuestsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetAllQuestsFunction, GetAllQuestsOutputDTO>(null, blockParameter);
        }

        public virtual Task<GetQuestOutputDTO> GetQuestQueryAsync(GetQuestFunction getQuestFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetQuestFunction, GetQuestOutputDTO>(getQuestFunction, blockParameter);
        }

        public virtual Task<GetQuestOutputDTO> GetQuestQueryAsync(BigInteger questId, BlockParameter blockParameter = null)
        {
            var getQuestFunction = new GetQuestFunction();
                getQuestFunction.QuestId = questId;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetQuestFunction, GetQuestOutputDTO>(getQuestFunction, blockParameter);
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

        public virtual Task<string> UpdateQuestRequestAsync(UpdateQuestFunction updateQuestFunction)
        {
             return ContractHandler.SendRequestAsync(updateQuestFunction);
        }

        public virtual Task<TransactionReceipt> UpdateQuestRequestAndWaitForReceiptAsync(UpdateQuestFunction updateQuestFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateQuestFunction, cancellationToken);
        }

        public virtual Task<string> UpdateQuestRequestAsync(BigInteger questId, QuestData quest)
        {
            var updateQuestFunction = new UpdateQuestFunction();
                updateQuestFunction.QuestId = questId;
                updateQuestFunction.Quest = quest;
            
             return ContractHandler.SendRequestAsync(updateQuestFunction);
        }

        public virtual Task<TransactionReceipt> UpdateQuestRequestAndWaitForReceiptAsync(BigInteger questId, QuestData quest, CancellationTokenSource cancellationToken = null)
        {
            var updateQuestFunction = new UpdateQuestFunction();
                updateQuestFunction.QuestId = questId;
                updateQuestFunction.Quest = quest;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateQuestFunction, cancellationToken);
        }

        public virtual Task<string> UpsertQuestCollectionsRequestAsync(UpsertQuestCollectionsFunction upsertQuestCollectionsFunction)
        {
             return ContractHandler.SendRequestAsync(upsertQuestCollectionsFunction);
        }

        public virtual Task<TransactionReceipt> UpsertQuestCollectionsRequestAndWaitForReceiptAsync(UpsertQuestCollectionsFunction upsertQuestCollectionsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(upsertQuestCollectionsFunction, cancellationToken);
        }

        public virtual Task<string> UpsertQuestCollectionsRequestAsync(List<QuestCollectionDTO> questCollections)
        {
            var upsertQuestCollectionsFunction = new UpsertQuestCollectionsFunction();
                upsertQuestCollectionsFunction.QuestCollections = questCollections;
            
             return ContractHandler.SendRequestAsync(upsertQuestCollectionsFunction);
        }

        public virtual Task<TransactionReceipt> UpsertQuestCollectionsRequestAndWaitForReceiptAsync(List<QuestCollectionDTO> questCollections, CancellationTokenSource cancellationToken = null)
        {
            var upsertQuestCollectionsFunction = new UpsertQuestCollectionsFunction();
                upsertQuestCollectionsFunction.QuestCollections = questCollections;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(upsertQuestCollectionsFunction, cancellationToken);
        }

        public virtual Task<string> UpsertRewardColletionsRequestAsync(UpsertRewardColletionsFunction upsertRewardColletionsFunction)
        {
             return ContractHandler.SendRequestAsync(upsertRewardColletionsFunction);
        }

        public virtual Task<TransactionReceipt> UpsertRewardColletionsRequestAndWaitForReceiptAsync(UpsertRewardColletionsFunction upsertRewardColletionsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(upsertRewardColletionsFunction, cancellationToken);
        }

        public virtual Task<string> UpsertRewardColletionsRequestAsync(List<RewardCollectionDTO> rewardCollections)
        {
            var upsertRewardColletionsFunction = new UpsertRewardColletionsFunction();
                upsertRewardColletionsFunction.RewardCollections = rewardCollections;
            
             return ContractHandler.SendRequestAsync(upsertRewardColletionsFunction);
        }

        public virtual Task<TransactionReceipt> UpsertRewardColletionsRequestAndWaitForReceiptAsync(List<RewardCollectionDTO> rewardCollections, CancellationTokenSource cancellationToken = null)
        {
            var upsertRewardColletionsFunction = new UpsertRewardColletionsFunction();
                upsertRewardColletionsFunction.RewardCollections = rewardCollections;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(upsertRewardColletionsFunction, cancellationToken);
        }

        public virtual Task<string> UpsertTransformationCategoriesRequestAsync(UpsertTransformationCategoriesFunction upsertTransformationCategoriesFunction)
        {
             return ContractHandler.SendRequestAsync(upsertTransformationCategoriesFunction);
        }

        public virtual Task<TransactionReceipt> UpsertTransformationCategoriesRequestAndWaitForReceiptAsync(UpsertTransformationCategoriesFunction upsertTransformationCategoriesFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(upsertTransformationCategoriesFunction, cancellationToken);
        }

        public virtual Task<string> UpsertTransformationCategoriesRequestAsync(List<TransformationWithCategoriesDTO> transformationCategories)
        {
            var upsertTransformationCategoriesFunction = new UpsertTransformationCategoriesFunction();
                upsertTransformationCategoriesFunction.TransformationCategories = transformationCategories;
            
             return ContractHandler.SendRequestAsync(upsertTransformationCategoriesFunction);
        }

        public virtual Task<TransactionReceipt> UpsertTransformationCategoriesRequestAndWaitForReceiptAsync(List<TransformationWithCategoriesDTO> transformationCategories, CancellationTokenSource cancellationToken = null)
        {
            var upsertTransformationCategoriesFunction = new UpsertTransformationCategoriesFunction();
                upsertTransformationCategoriesFunction.TransformationCategories = transformationCategories;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(upsertTransformationCategoriesFunction, cancellationToken);
        }

        public override List<Type> GetAllFunctionTypes()
        {
            return new List<Type>
            {
                typeof(MsgSenderFunction),
                typeof(MsgValueFunction),
                typeof(WorldFunction),
                typeof(AddNewQuestFunction),
                typeof(AddNewQuestsFunction),
                typeof(AddRewardsFunction),
                typeof(GetAllActiveQuestGroupsFunction),
                typeof(GetAllQuestsFunction),
                typeof(GetQuestFunction),
                typeof(SupportsInterfaceFunction),
                typeof(UpdateQuestFunction),
                typeof(UpsertQuestCollectionsFunction),
                typeof(UpsertRewardColletionsFunction),
                typeof(UpsertTransformationCategoriesFunction)
            };
        }

        public override List<Type> GetAllEventTypes()
        {
            return new List<Type>
            {
                typeof(StoreSetrecordEventDTO),
                typeof(StoreSplicedynamicdataEventDTO),
                typeof(StoreSplicestaticdataEventDTO)
            };
        }

        public override List<Type> GetAllErrorTypes()
        {
            return new List<Type>
            {
                typeof(EncodedlengthsInvalidlengthError),
                typeof(SliceOutofboundsError),
                typeof(StoreIndexoutofboundsError),
                typeof(StoreInvalidresourcetypeError),
                typeof(StoreInvalidspliceError),
                typeof(WorldAccessdeniedError)
            };
        }
    }
}
