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
using VisionsContracts.Redistributor.ContractDefinition;

namespace VisionsContracts.Redistributor
{
    public partial class RedistributorService: RedistributorServiceBase
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.IWeb3 web3, RedistributorDeployment redistributorDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<RedistributorDeployment>().SendRequestAndWaitForReceiptAsync(redistributorDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.IWeb3 web3, RedistributorDeployment redistributorDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<RedistributorDeployment>().SendRequestAsync(redistributorDeployment);
        }

        public static async Task<RedistributorService> DeployContractAndGetServiceAsync(Nethereum.Web3.IWeb3 web3, RedistributorDeployment redistributorDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, redistributorDeployment, cancellationTokenSource);
            return new RedistributorService(web3, receipt.ContractAddress);
        }

        public RedistributorService(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
        {
        }

    }


    public partial class RedistributorServiceBase: ContractWeb3ServiceBase
    {

        public RedistributorServiceBase(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
        {
        }

        public virtual Task<string> BurnSharesRequestAsync(BurnSharesFunction burnSharesFunction)
        {
             return ContractHandler.SendRequestAsync(burnSharesFunction);
        }

        public virtual Task<TransactionReceipt> BurnSharesRequestAndWaitForReceiptAsync(BurnSharesFunction burnSharesFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(burnSharesFunction, cancellationToken);
        }

        public virtual Task<string> BurnSharesRequestAsync(BigInteger identifier, BigInteger shares)
        {
            var burnSharesFunction = new BurnSharesFunction();
                burnSharesFunction.Identifier = identifier;
                burnSharesFunction.Shares = shares;
            
             return ContractHandler.SendRequestAsync(burnSharesFunction);
        }

        public virtual Task<TransactionReceipt> BurnSharesRequestAndWaitForReceiptAsync(BigInteger identifier, BigInteger shares, CancellationTokenSource cancellationToken = null)
        {
            var burnSharesFunction = new BurnSharesFunction();
                burnSharesFunction.Identifier = identifier;
                burnSharesFunction.Shares = shares;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(burnSharesFunction, cancellationToken);
        }

        public virtual Task<string> CreatePoolRequestAsync(CreatePoolFunction createPoolFunction)
        {
             return ContractHandler.SendRequestAsync(createPoolFunction);
        }

        public virtual Task<TransactionReceipt> CreatePoolRequestAndWaitForReceiptAsync(CreatePoolFunction createPoolFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createPoolFunction, cancellationToken);
        }

        public virtual Task<string> CreatePoolRequestAsync(BigInteger identifier, BigInteger subsectionIndex, bool isActive)
        {
            var createPoolFunction = new CreatePoolFunction();
                createPoolFunction.Identifier = identifier;
                createPoolFunction.SubsectionIndex = subsectionIndex;
                createPoolFunction.IsActive = isActive;
            
             return ContractHandler.SendRequestAsync(createPoolFunction);
        }

        public virtual Task<TransactionReceipt> CreatePoolRequestAndWaitForReceiptAsync(BigInteger identifier, BigInteger subsectionIndex, bool isActive, CancellationTokenSource cancellationToken = null)
        {
            var createPoolFunction = new CreatePoolFunction();
                createPoolFunction.Identifier = identifier;
                createPoolFunction.SubsectionIndex = subsectionIndex;
                createPoolFunction.IsActive = isActive;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createPoolFunction, cancellationToken);
        }

        public virtual Task<string> CreateSubSectionRequestAsync(CreateSubSectionFunction createSubSectionFunction)
        {
             return ContractHandler.SendRequestAsync(createSubSectionFunction);
        }

        public virtual Task<TransactionReceipt> CreateSubSectionRequestAndWaitForReceiptAsync(CreateSubSectionFunction createSubSectionFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createSubSectionFunction, cancellationToken);
        }

        public virtual Task<string> CreateSubSectionRequestAsync(BigInteger masterShares, string name)
        {
            var createSubSectionFunction = new CreateSubSectionFunction();
                createSubSectionFunction.MasterShares = masterShares;
                createSubSectionFunction.Name = name;
            
             return ContractHandler.SendRequestAsync(createSubSectionFunction);
        }

        public virtual Task<TransactionReceipt> CreateSubSectionRequestAndWaitForReceiptAsync(BigInteger masterShares, string name, CancellationTokenSource cancellationToken = null)
        {
            var createSubSectionFunction = new CreateSubSectionFunction();
                createSubSectionFunction.MasterShares = masterShares;
                createSubSectionFunction.Name = name;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createSubSectionFunction, cancellationToken);
        }

        public virtual Task<string> CreateSubSectionsRequestAsync(CreateSubSectionsFunction createSubSectionsFunction)
        {
             return ContractHandler.SendRequestAsync(createSubSectionsFunction);
        }

        public virtual Task<TransactionReceipt> CreateSubSectionsRequestAndWaitForReceiptAsync(CreateSubSectionsFunction createSubSectionsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createSubSectionsFunction, cancellationToken);
        }

        public virtual Task<string> CreateSubSectionsRequestAsync(List<SubSectionCreation> subsections)
        {
            var createSubSectionsFunction = new CreateSubSectionsFunction();
                createSubSectionsFunction.Subsections = subsections;
            
             return ContractHandler.SendRequestAsync(createSubSectionsFunction);
        }

        public virtual Task<TransactionReceipt> CreateSubSectionsRequestAndWaitForReceiptAsync(List<SubSectionCreation> subsections, CancellationTokenSource cancellationToken = null)
        {
            var createSubSectionsFunction = new CreateSubSectionsFunction();
                createSubSectionsFunction.Subsections = subsections;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createSubSectionsFunction, cancellationToken);
        }

        public virtual Task<GetPoolOutputDTO> GetPoolQueryAsync(GetPoolFunction getPoolFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetPoolFunction, GetPoolOutputDTO>(getPoolFunction, blockParameter);
        }

        public virtual Task<GetPoolOutputDTO> GetPoolQueryAsync(BigInteger identifier, BlockParameter blockParameter = null)
        {
            var getPoolFunction = new GetPoolFunction();
                getPoolFunction.Identifier = identifier;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetPoolFunction, GetPoolOutputDTO>(getPoolFunction, blockParameter);
        }

        public virtual Task<GetSubSectionOutputDTO> GetSubSectionQueryAsync(GetSubSectionFunction getSubSectionFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetSubSectionFunction, GetSubSectionOutputDTO>(getSubSectionFunction, blockParameter);
        }

        public virtual Task<GetSubSectionOutputDTO> GetSubSectionQueryAsync(BigInteger subsectionIndex, BlockParameter blockParameter = null)
        {
            var getSubSectionFunction = new GetSubSectionFunction();
                getSubSectionFunction.SubsectionIndex = subsectionIndex;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetSubSectionFunction, GetSubSectionOutputDTO>(getSubSectionFunction, blockParameter);
        }

        public virtual Task<GetSubSectionsOutputDTO> GetSubSectionsQueryAsync(GetSubSectionsFunction getSubSectionsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetSubSectionsFunction, GetSubSectionsOutputDTO>(getSubSectionsFunction, blockParameter);
        }

        public virtual Task<GetSubSectionsOutputDTO> GetSubSectionsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetSubSectionsFunction, GetSubSectionsOutputDTO>(null, blockParameter);
        }

        public Task<BigInteger> IdentifierToPoolIdQueryAsync(IdentifierToPoolIdFunction identifierToPoolIdFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IdentifierToPoolIdFunction, BigInteger>(identifierToPoolIdFunction, blockParameter);
        }

        
        public virtual Task<BigInteger> IdentifierToPoolIdQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var identifierToPoolIdFunction = new IdentifierToPoolIdFunction();
                identifierToPoolIdFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<IdentifierToPoolIdFunction, BigInteger>(identifierToPoolIdFunction, blockParameter);
        }

        public virtual Task<string> MintSharesRequestAsync(MintSharesFunction mintSharesFunction)
        {
             return ContractHandler.SendRequestAsync(mintSharesFunction);
        }

        public virtual Task<TransactionReceipt> MintSharesRequestAndWaitForReceiptAsync(MintSharesFunction mintSharesFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(mintSharesFunction, cancellationToken);
        }

        public virtual Task<string> MintSharesRequestAsync(BigInteger identifier, BigInteger shares)
        {
            var mintSharesFunction = new MintSharesFunction();
                mintSharesFunction.Identifier = identifier;
                mintSharesFunction.Shares = shares;
            
             return ContractHandler.SendRequestAsync(mintSharesFunction);
        }

        public virtual Task<TransactionReceipt> MintSharesRequestAndWaitForReceiptAsync(BigInteger identifier, BigInteger shares, CancellationTokenSource cancellationToken = null)
        {
            var mintSharesFunction = new MintSharesFunction();
                mintSharesFunction.Identifier = identifier;
                mintSharesFunction.Shares = shares;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(mintSharesFunction, cancellationToken);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public virtual Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }

        public virtual Task<string> RedistributeFundsRequestAsync(RedistributeFundsFunction redistributeFundsFunction)
        {
             return ContractHandler.SendRequestAsync(redistributeFundsFunction);
        }

        public virtual Task<string> RedistributeFundsRequestAsync()
        {
             return ContractHandler.SendRequestAsync<RedistributeFundsFunction>();
        }

        public virtual Task<TransactionReceipt> RedistributeFundsRequestAndWaitForReceiptAsync(RedistributeFundsFunction redistributeFundsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(redistributeFundsFunction, cancellationToken);
        }

        public virtual Task<TransactionReceipt> RedistributeFundsRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<RedistributeFundsFunction>(null, cancellationToken);
        }

        public virtual Task<string> RenounceOwnershipRequestAsync(RenounceOwnershipFunction renounceOwnershipFunction)
        {
             return ContractHandler.SendRequestAsync(renounceOwnershipFunction);
        }

        public virtual Task<string> RenounceOwnershipRequestAsync()
        {
             return ContractHandler.SendRequestAsync<RenounceOwnershipFunction>();
        }

        public virtual Task<TransactionReceipt> RenounceOwnershipRequestAndWaitForReceiptAsync(RenounceOwnershipFunction renounceOwnershipFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(renounceOwnershipFunction, cancellationToken);
        }

        public virtual Task<TransactionReceipt> RenounceOwnershipRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<RenounceOwnershipFunction>(null, cancellationToken);
        }

        public virtual Task<string> SetLandAddressRequestAsync(SetLandAddressFunction setLandAddressFunction)
        {
             return ContractHandler.SendRequestAsync(setLandAddressFunction);
        }

        public virtual Task<TransactionReceipt> SetLandAddressRequestAndWaitForReceiptAsync(SetLandAddressFunction setLandAddressFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setLandAddressFunction, cancellationToken);
        }

        public virtual Task<string> SetLandAddressRequestAsync(string land)
        {
            var setLandAddressFunction = new SetLandAddressFunction();
                setLandAddressFunction.Land = land;
            
             return ContractHandler.SendRequestAsync(setLandAddressFunction);
        }

        public virtual Task<TransactionReceipt> SetLandAddressRequestAndWaitForReceiptAsync(string land, CancellationTokenSource cancellationToken = null)
        {
            var setLandAddressFunction = new SetLandAddressFunction();
                setLandAddressFunction.Land = land;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setLandAddressFunction, cancellationToken);
        }

        public virtual Task<string> SetPoolActivityRequestAsync(SetPoolActivityFunction setPoolActivityFunction)
        {
             return ContractHandler.SendRequestAsync(setPoolActivityFunction);
        }

        public virtual Task<TransactionReceipt> SetPoolActivityRequestAndWaitForReceiptAsync(SetPoolActivityFunction setPoolActivityFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setPoolActivityFunction, cancellationToken);
        }

        public virtual Task<string> SetPoolActivityRequestAsync(BigInteger identifier, bool isActive)
        {
            var setPoolActivityFunction = new SetPoolActivityFunction();
                setPoolActivityFunction.Identifier = identifier;
                setPoolActivityFunction.IsActive = isActive;
            
             return ContractHandler.SendRequestAsync(setPoolActivityFunction);
        }

        public virtual Task<TransactionReceipt> SetPoolActivityRequestAndWaitForReceiptAsync(BigInteger identifier, bool isActive, CancellationTokenSource cancellationToken = null)
        {
            var setPoolActivityFunction = new SetPoolActivityFunction();
                setPoolActivityFunction.Identifier = identifier;
                setPoolActivityFunction.IsActive = isActive;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setPoolActivityFunction, cancellationToken);
        }

        public virtual Task<string> SetSubSectionMasterSharesRequestAsync(SetSubSectionMasterSharesFunction setSubSectionMasterSharesFunction)
        {
             return ContractHandler.SendRequestAsync(setSubSectionMasterSharesFunction);
        }

        public virtual Task<TransactionReceipt> SetSubSectionMasterSharesRequestAndWaitForReceiptAsync(SetSubSectionMasterSharesFunction setSubSectionMasterSharesFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setSubSectionMasterSharesFunction, cancellationToken);
        }

        public virtual Task<string> SetSubSectionMasterSharesRequestAsync(BigInteger subsectionIndex, BigInteger masterShares)
        {
            var setSubSectionMasterSharesFunction = new SetSubSectionMasterSharesFunction();
                setSubSectionMasterSharesFunction.SubsectionIndex = subsectionIndex;
                setSubSectionMasterSharesFunction.MasterShares = masterShares;
            
             return ContractHandler.SendRequestAsync(setSubSectionMasterSharesFunction);
        }

        public virtual Task<TransactionReceipt> SetSubSectionMasterSharesRequestAndWaitForReceiptAsync(BigInteger subsectionIndex, BigInteger masterShares, CancellationTokenSource cancellationToken = null)
        {
            var setSubSectionMasterSharesFunction = new SetSubSectionMasterSharesFunction();
                setSubSectionMasterSharesFunction.SubsectionIndex = subsectionIndex;
                setSubSectionMasterSharesFunction.MasterShares = masterShares;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setSubSectionMasterSharesFunction, cancellationToken);
        }

        public virtual Task<SubSectionsOutputDTO> SubSectionsQueryAsync(SubSectionsFunction subSectionsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<SubSectionsFunction, SubSectionsOutputDTO>(subSectionsFunction, blockParameter);
        }

        public virtual Task<SubSectionsOutputDTO> SubSectionsQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var subSectionsFunction = new SubSectionsFunction();
                subSectionsFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryDeserializingToObjectAsync<SubSectionsFunction, SubSectionsOutputDTO>(subSectionsFunction, blockParameter);
        }

        public Task<BigInteger> SubsectionNameToIndexQueryAsync(SubsectionNameToIndexFunction subsectionNameToIndexFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SubsectionNameToIndexFunction, BigInteger>(subsectionNameToIndexFunction, blockParameter);
        }

        
        public virtual Task<BigInteger> SubsectionNameToIndexQueryAsync(string returnValue1, BlockParameter blockParameter = null)
        {
            var subsectionNameToIndexFunction = new SubsectionNameToIndexFunction();
                subsectionNameToIndexFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<SubsectionNameToIndexFunction, BigInteger>(subsectionNameToIndexFunction, blockParameter);
        }

        public Task<string> TokenQueryAsync(TokenFunction tokenFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TokenFunction, string>(tokenFunction, blockParameter);
        }

        
        public virtual Task<string> TokenQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TokenFunction, string>(null, blockParameter);
        }

        public virtual Task<string> TransferOwnershipRequestAsync(TransferOwnershipFunction transferOwnershipFunction)
        {
             return ContractHandler.SendRequestAsync(transferOwnershipFunction);
        }

        public virtual Task<TransactionReceipt> TransferOwnershipRequestAndWaitForReceiptAsync(TransferOwnershipFunction transferOwnershipFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferOwnershipFunction, cancellationToken);
        }

        public virtual Task<string> TransferOwnershipRequestAsync(string newOwner)
        {
            var transferOwnershipFunction = new TransferOwnershipFunction();
                transferOwnershipFunction.NewOwner = newOwner;
            
             return ContractHandler.SendRequestAsync(transferOwnershipFunction);
        }

        public virtual Task<TransactionReceipt> TransferOwnershipRequestAndWaitForReceiptAsync(string newOwner, CancellationTokenSource cancellationToken = null)
        {
            var transferOwnershipFunction = new TransferOwnershipFunction();
                transferOwnershipFunction.NewOwner = newOwner;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferOwnershipFunction, cancellationToken);
        }

        public virtual Task<string> WithdrawFundsRequestAsync(WithdrawFundsFunction withdrawFundsFunction)
        {
             return ContractHandler.SendRequestAsync(withdrawFundsFunction);
        }

        public virtual Task<TransactionReceipt> WithdrawFundsRequestAndWaitForReceiptAsync(WithdrawFundsFunction withdrawFundsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawFundsFunction, cancellationToken);
        }

        public virtual Task<string> WithdrawFundsRequestAsync(BigInteger identifier, BigInteger shares)
        {
            var withdrawFundsFunction = new WithdrawFundsFunction();
                withdrawFundsFunction.Identifier = identifier;
                withdrawFundsFunction.Shares = shares;
            
             return ContractHandler.SendRequestAsync(withdrawFundsFunction);
        }

        public virtual Task<TransactionReceipt> WithdrawFundsRequestAndWaitForReceiptAsync(BigInteger identifier, BigInteger shares, CancellationTokenSource cancellationToken = null)
        {
            var withdrawFundsFunction = new WithdrawFundsFunction();
                withdrawFundsFunction.Identifier = identifier;
                withdrawFundsFunction.Shares = shares;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawFundsFunction, cancellationToken);
        }

        public override List<Type> GetAllFunctionTypes()
        {
            return new List<Type>
            {
                typeof(BurnSharesFunction),
                typeof(CreatePoolFunction),
                typeof(CreateSubSectionFunction),
                typeof(CreateSubSectionsFunction),
                typeof(GetPoolFunction),
                typeof(GetSubSectionFunction),
                typeof(GetSubSectionsFunction),
                typeof(IdentifierToPoolIdFunction),
                typeof(MintSharesFunction),
                typeof(OwnerFunction),
                typeof(RedistributeFundsFunction),
                typeof(RenounceOwnershipFunction),
                typeof(SetLandAddressFunction),
                typeof(SetPoolActivityFunction),
                typeof(SetSubSectionMasterSharesFunction),
                typeof(SubSectionsFunction),
                typeof(SubsectionNameToIndexFunction),
                typeof(TokenFunction),
                typeof(TransferOwnershipFunction),
                typeof(WithdrawFundsFunction)
            };
        }

        public override List<Type> GetAllEventTypes()
        {
            return new List<Type>
            {
                typeof(EmptyWithdrawalEventDTO),
                typeof(FundsWithdrawnEventDTO),
                typeof(OwnershipTransferredEventDTO),
                typeof(PoolActivityChangedEventDTO),
                typeof(PoolCreatedEventDTO),
                typeof(SharesMintedEventDTO),
                typeof(SubSectionCreatedEventDTO)
            };
        }

        public override List<Type> GetAllErrorTypes()
        {
            return new List<Type>
            {

            };
        }
    }
}
