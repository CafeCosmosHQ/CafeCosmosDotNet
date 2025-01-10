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
using VisionsContracts.Land.Systems.LandTablesAndChairsContract.ContractDefinition;

namespace VisionsContracts.Land.Systems.LandTablesAndChairsContract
{
    public partial class LandTablesAndChairsContractService: LandTablesAndChairsContractServiceBase
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.IWeb3 web3, LandTablesAndChairsContractDeployment landTablesAndChairsContractDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<LandTablesAndChairsContractDeployment>().SendRequestAndWaitForReceiptAsync(landTablesAndChairsContractDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.IWeb3 web3, LandTablesAndChairsContractDeployment landTablesAndChairsContractDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<LandTablesAndChairsContractDeployment>().SendRequestAsync(landTablesAndChairsContractDeployment);
        }

        public static async Task<LandTablesAndChairsContractService> DeployContractAndGetServiceAsync(Nethereum.Web3.IWeb3 web3, LandTablesAndChairsContractDeployment landTablesAndChairsContractDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, landTablesAndChairsContractDeployment, cancellationTokenSource);
            return new LandTablesAndChairsContractService(web3, receipt.ContractAddress);
        }

        public LandTablesAndChairsContractService(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
        {
        }

    }


    public partial class LandTablesAndChairsContractServiceBase: ContractWeb3ServiceBase
    {

        public LandTablesAndChairsContractServiceBase(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
        {
        }

        public virtual Task<string> CheckPlaceTableOrChairRequestAsync(CheckPlaceTableOrChairFunction checkPlaceTableOrChairFunction)
        {
             return ContractHandler.SendRequestAsync(checkPlaceTableOrChairFunction);
        }

        public virtual Task<TransactionReceipt> CheckPlaceTableOrChairRequestAndWaitForReceiptAsync(CheckPlaceTableOrChairFunction checkPlaceTableOrChairFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(checkPlaceTableOrChairFunction, cancellationToken);
        }

        public virtual Task<string> CheckPlaceTableOrChairRequestAsync(BigInteger landId, BigInteger itemId, BigInteger x, BigInteger y)
        {
            var checkPlaceTableOrChairFunction = new CheckPlaceTableOrChairFunction();
                checkPlaceTableOrChairFunction.LandId = landId;
                checkPlaceTableOrChairFunction.ItemId = itemId;
                checkPlaceTableOrChairFunction.X = x;
                checkPlaceTableOrChairFunction.Y = y;
            
             return ContractHandler.SendRequestAsync(checkPlaceTableOrChairFunction);
        }

        public virtual Task<TransactionReceipt> CheckPlaceTableOrChairRequestAndWaitForReceiptAsync(BigInteger landId, BigInteger itemId, BigInteger x, BigInteger y, CancellationTokenSource cancellationToken = null)
        {
            var checkPlaceTableOrChairFunction = new CheckPlaceTableOrChairFunction();
                checkPlaceTableOrChairFunction.LandId = landId;
                checkPlaceTableOrChairFunction.ItemId = itemId;
                checkPlaceTableOrChairFunction.X = x;
                checkPlaceTableOrChairFunction.Y = y;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(checkPlaceTableOrChairFunction, cancellationToken);
        }

        public virtual Task<string> CheckRemoveTableOrChairRequestAsync(CheckRemoveTableOrChairFunction checkRemoveTableOrChairFunction)
        {
             return ContractHandler.SendRequestAsync(checkRemoveTableOrChairFunction);
        }

        public virtual Task<TransactionReceipt> CheckRemoveTableOrChairRequestAndWaitForReceiptAsync(CheckRemoveTableOrChairFunction checkRemoveTableOrChairFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(checkRemoveTableOrChairFunction, cancellationToken);
        }

        public virtual Task<string> CheckRemoveTableOrChairRequestAsync(BigInteger landId, BigInteger itemId, BigInteger x, BigInteger y)
        {
            var checkRemoveTableOrChairFunction = new CheckRemoveTableOrChairFunction();
                checkRemoveTableOrChairFunction.LandId = landId;
                checkRemoveTableOrChairFunction.ItemId = itemId;
                checkRemoveTableOrChairFunction.X = x;
                checkRemoveTableOrChairFunction.Y = y;
            
             return ContractHandler.SendRequestAsync(checkRemoveTableOrChairFunction);
        }

        public virtual Task<TransactionReceipt> CheckRemoveTableOrChairRequestAndWaitForReceiptAsync(BigInteger landId, BigInteger itemId, BigInteger x, BigInteger y, CancellationTokenSource cancellationToken = null)
        {
            var checkRemoveTableOrChairFunction = new CheckRemoveTableOrChairFunction();
                checkRemoveTableOrChairFunction.LandId = landId;
                checkRemoveTableOrChairFunction.ItemId = itemId;
                checkRemoveTableOrChairFunction.X = x;
                checkRemoveTableOrChairFunction.Y = y;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(checkRemoveTableOrChairFunction, cancellationToken);
        }

        public override List<Type> GetAllFunctionTypes()
        {
            return new List<Type>
            {
                typeof(CheckPlaceTableOrChairFunction),
                typeof(CheckRemoveTableOrChairFunction)
            };
        }

        public override List<Type> GetAllEventTypes()
        {
            return new List<Type>
            {
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
                typeof(StoreInvalidspliceError)
            };
        }
    }
}
