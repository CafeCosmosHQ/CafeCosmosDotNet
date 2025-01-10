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
using VisionsContracts.ItemsPermissioned.ContractDefinition;

namespace VisionsContracts.ItemsPermissioned
{
    public partial class ItemsPermissionedService: ItemsPermissionedServiceBase
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.IWeb3 web3, ItemsPermissionedDeployment itemsPermissionedDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<ItemsPermissionedDeployment>().SendRequestAndWaitForReceiptAsync(itemsPermissionedDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.IWeb3 web3, ItemsPermissionedDeployment itemsPermissionedDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<ItemsPermissionedDeployment>().SendRequestAsync(itemsPermissionedDeployment);
        }

        public static async Task<ItemsPermissionedService> DeployContractAndGetServiceAsync(Nethereum.Web3.IWeb3 web3, ItemsPermissionedDeployment itemsPermissionedDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, itemsPermissionedDeployment, cancellationTokenSource);
            return new ItemsPermissionedService(web3, receipt.ContractAddress);
        }

        public ItemsPermissionedService(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
        {
        }

    }


    public partial class ItemsPermissionedServiceBase: ContractWeb3ServiceBase
    {

        public ItemsPermissionedServiceBase(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
        {
        }

        public Task<BigInteger> BalanceOfQueryAsync(BalanceOfFunction balanceOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction, blockParameter);
        }

        
        public virtual Task<BigInteger> BalanceOfQueryAsync(string account, BigInteger id, BlockParameter blockParameter = null)
        {
            var balanceOfFunction = new BalanceOfFunction();
                balanceOfFunction.Account = account;
                balanceOfFunction.Id = id;
            
            return ContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction, blockParameter);
        }

        public Task<List<BigInteger>> BalanceOfBatchQueryAsync(BalanceOfBatchFunction balanceOfBatchFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BalanceOfBatchFunction, List<BigInteger>>(balanceOfBatchFunction, blockParameter);
        }

        
        public virtual Task<List<BigInteger>> BalanceOfBatchQueryAsync(List<string> accounts, List<BigInteger> ids, BlockParameter blockParameter = null)
        {
            var balanceOfBatchFunction = new BalanceOfBatchFunction();
                balanceOfBatchFunction.Accounts = accounts;
                balanceOfBatchFunction.Ids = ids;
            
            return ContractHandler.QueryAsync<BalanceOfBatchFunction, List<BigInteger>>(balanceOfBatchFunction, blockParameter);
        }

        public Task<List<BigInteger>> BalanceOfBatchSingleQueryAsync(BalanceOfBatchSingleFunction balanceOfBatchSingleFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BalanceOfBatchSingleFunction, List<BigInteger>>(balanceOfBatchSingleFunction, blockParameter);
        }

        
        public virtual Task<List<BigInteger>> BalanceOfBatchSingleQueryAsync(string account, List<BigInteger> ids, BlockParameter blockParameter = null)
        {
            var balanceOfBatchSingleFunction = new BalanceOfBatchSingleFunction();
                balanceOfBatchSingleFunction.Account = account;
                balanceOfBatchSingleFunction.Ids = ids;
            
            return ContractHandler.QueryAsync<BalanceOfBatchSingleFunction, List<BigInteger>>(balanceOfBatchSingleFunction, blockParameter);
        }

        public virtual Task<string> BurnBatchRequestAsync(BurnBatchFunction burnBatchFunction)
        {
             return ContractHandler.SendRequestAsync(burnBatchFunction);
        }

        public virtual Task<TransactionReceipt> BurnBatchRequestAndWaitForReceiptAsync(BurnBatchFunction burnBatchFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(burnBatchFunction, cancellationToken);
        }

        public virtual Task<string> BurnBatchRequestAsync(List<BigInteger> ids, List<BigInteger> amounts)
        {
            var burnBatchFunction = new BurnBatchFunction();
                burnBatchFunction.Ids = ids;
                burnBatchFunction.Amounts = amounts;
            
             return ContractHandler.SendRequestAsync(burnBatchFunction);
        }

        public virtual Task<TransactionReceipt> BurnBatchRequestAndWaitForReceiptAsync(List<BigInteger> ids, List<BigInteger> amounts, CancellationTokenSource cancellationToken = null)
        {
            var burnBatchFunction = new BurnBatchFunction();
                burnBatchFunction.Ids = ids;
                burnBatchFunction.Amounts = amounts;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(burnBatchFunction, cancellationToken);
        }

        public Task<bool> IsApprovedForAllQueryAsync(IsApprovedForAllFunction isApprovedForAllFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsApprovedForAllFunction, bool>(isApprovedForAllFunction, blockParameter);
        }

        
        public virtual Task<bool> IsApprovedForAllQueryAsync(string account, string @operator, BlockParameter blockParameter = null)
        {
            var isApprovedForAllFunction = new IsApprovedForAllFunction();
                isApprovedForAllFunction.Account = account;
                isApprovedForAllFunction.Operator = @operator;
            
            return ContractHandler.QueryAsync<IsApprovedForAllFunction, bool>(isApprovedForAllFunction, blockParameter);
        }

        public virtual Task<string> MintRequestAsync(MintFunction mintFunction)
        {
             return ContractHandler.SendRequestAsync(mintFunction);
        }

        public virtual Task<TransactionReceipt> MintRequestAndWaitForReceiptAsync(MintFunction mintFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(mintFunction, cancellationToken);
        }

        public virtual Task<string> MintRequestAsync(string account, BigInteger id, BigInteger amount, byte[] data)
        {
            var mintFunction = new MintFunction();
                mintFunction.Account = account;
                mintFunction.Id = id;
                mintFunction.Amount = amount;
                mintFunction.Data = data;
            
             return ContractHandler.SendRequestAsync(mintFunction);
        }

        public virtual Task<TransactionReceipt> MintRequestAndWaitForReceiptAsync(string account, BigInteger id, BigInteger amount, byte[] data, CancellationTokenSource cancellationToken = null)
        {
            var mintFunction = new MintFunction();
                mintFunction.Account = account;
                mintFunction.Id = id;
                mintFunction.Amount = amount;
                mintFunction.Data = data;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(mintFunction, cancellationToken);
        }

        public virtual Task<string> MintBatchRequestAsync(MintBatchFunction mintBatchFunction)
        {
             return ContractHandler.SendRequestAsync(mintBatchFunction);
        }

        public virtual Task<TransactionReceipt> MintBatchRequestAndWaitForReceiptAsync(MintBatchFunction mintBatchFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(mintBatchFunction, cancellationToken);
        }

        public virtual Task<string> MintBatchRequestAsync(string account, List<BigInteger> ids, List<BigInteger> amounts, byte[] data)
        {
            var mintBatchFunction = new MintBatchFunction();
                mintBatchFunction.Account = account;
                mintBatchFunction.Ids = ids;
                mintBatchFunction.Amounts = amounts;
                mintBatchFunction.Data = data;
            
             return ContractHandler.SendRequestAsync(mintBatchFunction);
        }

        public virtual Task<TransactionReceipt> MintBatchRequestAndWaitForReceiptAsync(string account, List<BigInteger> ids, List<BigInteger> amounts, byte[] data, CancellationTokenSource cancellationToken = null)
        {
            var mintBatchFunction = new MintBatchFunction();
                mintBatchFunction.Account = account;
                mintBatchFunction.Ids = ids;
                mintBatchFunction.Amounts = amounts;
                mintBatchFunction.Data = data;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(mintBatchFunction, cancellationToken);
        }

        public Task<bool> MintersQueryAsync(MintersFunction mintersFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MintersFunction, bool>(mintersFunction, blockParameter);
        }

        
        public virtual Task<bool> MintersQueryAsync(string returnValue1, BlockParameter blockParameter = null)
        {
            var mintersFunction = new MintersFunction();
                mintersFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<MintersFunction, bool>(mintersFunction, blockParameter);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public virtual Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
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

        public virtual Task<string> SafeBatchTransferFromRequestAsync(SafeBatchTransferFromFunction safeBatchTransferFromFunction)
        {
             return ContractHandler.SendRequestAsync(safeBatchTransferFromFunction);
        }

        public virtual Task<TransactionReceipt> SafeBatchTransferFromRequestAndWaitForReceiptAsync(SafeBatchTransferFromFunction safeBatchTransferFromFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(safeBatchTransferFromFunction, cancellationToken);
        }

        public virtual Task<string> SafeBatchTransferFromRequestAsync(string from, string to, List<BigInteger> ids, List<BigInteger> amounts, byte[] data)
        {
            var safeBatchTransferFromFunction = new SafeBatchTransferFromFunction();
                safeBatchTransferFromFunction.From = from;
                safeBatchTransferFromFunction.To = to;
                safeBatchTransferFromFunction.Ids = ids;
                safeBatchTransferFromFunction.Amounts = amounts;
                safeBatchTransferFromFunction.Data = data;
            
             return ContractHandler.SendRequestAsync(safeBatchTransferFromFunction);
        }

        public virtual Task<TransactionReceipt> SafeBatchTransferFromRequestAndWaitForReceiptAsync(string from, string to, List<BigInteger> ids, List<BigInteger> amounts, byte[] data, CancellationTokenSource cancellationToken = null)
        {
            var safeBatchTransferFromFunction = new SafeBatchTransferFromFunction();
                safeBatchTransferFromFunction.From = from;
                safeBatchTransferFromFunction.To = to;
                safeBatchTransferFromFunction.Ids = ids;
                safeBatchTransferFromFunction.Amounts = amounts;
                safeBatchTransferFromFunction.Data = data;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(safeBatchTransferFromFunction, cancellationToken);
        }

        public virtual Task<string> SafeTransferFromRequestAsync(SafeTransferFromFunction safeTransferFromFunction)
        {
             return ContractHandler.SendRequestAsync(safeTransferFromFunction);
        }

        public virtual Task<TransactionReceipt> SafeTransferFromRequestAndWaitForReceiptAsync(SafeTransferFromFunction safeTransferFromFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFromFunction, cancellationToken);
        }

        public virtual Task<string> SafeTransferFromRequestAsync(string from, string to, BigInteger id, BigInteger amount, byte[] data)
        {
            var safeTransferFromFunction = new SafeTransferFromFunction();
                safeTransferFromFunction.From = from;
                safeTransferFromFunction.To = to;
                safeTransferFromFunction.Id = id;
                safeTransferFromFunction.Amount = amount;
                safeTransferFromFunction.Data = data;
            
             return ContractHandler.SendRequestAsync(safeTransferFromFunction);
        }

        public virtual Task<TransactionReceipt> SafeTransferFromRequestAndWaitForReceiptAsync(string from, string to, BigInteger id, BigInteger amount, byte[] data, CancellationTokenSource cancellationToken = null)
        {
            var safeTransferFromFunction = new SafeTransferFromFunction();
                safeTransferFromFunction.From = from;
                safeTransferFromFunction.To = to;
                safeTransferFromFunction.Id = id;
                safeTransferFromFunction.Amount = amount;
                safeTransferFromFunction.Data = data;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFromFunction, cancellationToken);
        }

        public virtual Task<string> SetApprovalForAllRequestAsync(SetApprovalForAllFunction setApprovalForAllFunction)
        {
             return ContractHandler.SendRequestAsync(setApprovalForAllFunction);
        }

        public virtual Task<TransactionReceipt> SetApprovalForAllRequestAndWaitForReceiptAsync(SetApprovalForAllFunction setApprovalForAllFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setApprovalForAllFunction, cancellationToken);
        }

        public virtual Task<string> SetApprovalForAllRequestAsync(string @operator, bool approved)
        {
            var setApprovalForAllFunction = new SetApprovalForAllFunction();
                setApprovalForAllFunction.Operator = @operator;
                setApprovalForAllFunction.Approved = approved;
            
             return ContractHandler.SendRequestAsync(setApprovalForAllFunction);
        }

        public virtual Task<TransactionReceipt> SetApprovalForAllRequestAndWaitForReceiptAsync(string @operator, bool approved, CancellationTokenSource cancellationToken = null)
        {
            var setApprovalForAllFunction = new SetApprovalForAllFunction();
                setApprovalForAllFunction.Operator = @operator;
                setApprovalForAllFunction.Approved = approved;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setApprovalForAllFunction, cancellationToken);
        }

        public virtual Task<string> SetMinterRequestAsync(SetMinterFunction setMinterFunction)
        {
             return ContractHandler.SendRequestAsync(setMinterFunction);
        }

        public virtual Task<TransactionReceipt> SetMinterRequestAndWaitForReceiptAsync(SetMinterFunction setMinterFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setMinterFunction, cancellationToken);
        }

        public virtual Task<string> SetMinterRequestAsync(string minter, bool status)
        {
            var setMinterFunction = new SetMinterFunction();
                setMinterFunction.Minter = minter;
                setMinterFunction.Status = status;
            
             return ContractHandler.SendRequestAsync(setMinterFunction);
        }

        public virtual Task<TransactionReceipt> SetMinterRequestAndWaitForReceiptAsync(string minter, bool status, CancellationTokenSource cancellationToken = null)
        {
            var setMinterFunction = new SetMinterFunction();
                setMinterFunction.Minter = minter;
                setMinterFunction.Status = status;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setMinterFunction, cancellationToken);
        }

        public virtual Task<string> SetWhitelistRequestAsync(SetWhitelistFunction setWhitelistFunction)
        {
             return ContractHandler.SendRequestAsync(setWhitelistFunction);
        }

        public virtual Task<TransactionReceipt> SetWhitelistRequestAndWaitForReceiptAsync(SetWhitelistFunction setWhitelistFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setWhitelistFunction, cancellationToken);
        }

        public virtual Task<string> SetWhitelistRequestAsync(List<string> addresses, List<bool> isWhitelisted)
        {
            var setWhitelistFunction = new SetWhitelistFunction();
                setWhitelistFunction.Addresses = addresses;
                setWhitelistFunction.IsWhitelisted = isWhitelisted;
            
             return ContractHandler.SendRequestAsync(setWhitelistFunction);
        }

        public virtual Task<TransactionReceipt> SetWhitelistRequestAndWaitForReceiptAsync(List<string> addresses, List<bool> isWhitelisted, CancellationTokenSource cancellationToken = null)
        {
            var setWhitelistFunction = new SetWhitelistFunction();
                setWhitelistFunction.Addresses = addresses;
                setWhitelistFunction.IsWhitelisted = isWhitelisted;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setWhitelistFunction, cancellationToken);
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

        public Task<string> UriQueryAsync(UriFunction uriFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<UriFunction, string>(uriFunction, blockParameter);
        }

        
        public virtual Task<string> UriQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var uriFunction = new UriFunction();
                uriFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<UriFunction, string>(uriFunction, blockParameter);
        }

        public Task<bool> WhitelistQueryAsync(WhitelistFunction whitelistFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<WhitelistFunction, bool>(whitelistFunction, blockParameter);
        }

        
        public virtual Task<bool> WhitelistQueryAsync(string returnValue1, BlockParameter blockParameter = null)
        {
            var whitelistFunction = new WhitelistFunction();
                whitelistFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<WhitelistFunction, bool>(whitelistFunction, blockParameter);
        }

        public override List<Type> GetAllFunctionTypes()
        {
            return new List<Type>
            {
                typeof(BalanceOfFunction),
                typeof(BalanceOfBatchFunction),
                typeof(BalanceOfBatchSingleFunction),
                typeof(BurnBatchFunction),
                typeof(IsApprovedForAllFunction),
                typeof(MintFunction),
                typeof(MintBatchFunction),
                typeof(MintersFunction),
                typeof(OwnerFunction),
                typeof(RenounceOwnershipFunction),
                typeof(SafeBatchTransferFromFunction),
                typeof(SafeTransferFromFunction),
                typeof(SetApprovalForAllFunction),
                typeof(SetMinterFunction),
                typeof(SetWhitelistFunction),
                typeof(SupportsInterfaceFunction),
                typeof(TransferOwnershipFunction),
                typeof(UriFunction),
                typeof(WhitelistFunction)
            };
        }

        public override List<Type> GetAllEventTypes()
        {
            return new List<Type>
            {
                typeof(ApprovalForAllEventDTO),
                typeof(OwnershipTransferredEventDTO),
                typeof(TransferBatchEventDTO),
                typeof(TransferSingleEventDTO),
                typeof(UriEventDTO)
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
