using Nethereum.Mud.Contracts.Core.Tables;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using System.Numerics;
using System.Threading.Tasks;


namespace VisionsContracts.Land.Tables
{

    public partial class WaterControllerTableService : TableSingletonService<WaterControllerTableRecord, WaterControllerTableRecord.WaterControllerValue>
    {
      

        public virtual Task<string> SetRecordRequestAsync(
                                             byte[] querySchema,
                                             BigInteger minDelta,
                                             BigInteger maxDelta,
                                             ulong sourceChainId,
                                             BigInteger numSamples,
                                             BigInteger blockInterval,
                                             BigInteger minYieldTime,
                                             BigInteger maxYieldTime,
                                             BigInteger endBlockSlippage,
                                             BigInteger lastTWAP,
                                             BigInteger waterYieldTime,
                                             BigInteger lastUpdate)
        {
            var values = new WaterControllerTableRecord.WaterControllerValue
            {
                QuerySchema = querySchema,
                MinDelta = minDelta,
                MaxDelta = maxDelta,
                SourceChainId = sourceChainId,
                NumSamples = numSamples,
                BlockInterval = blockInterval,
                MinYieldTime = minYieldTime,
                MaxYieldTime = maxYieldTime,
                EndBlockSlippage = endBlockSlippage,
                LastTWAP = lastTWAP,
                WaterYieldTime = waterYieldTime,
                LastUpdate = lastUpdate
            };

            return SetRecordRequestAsync(values);
        }

        public async Task<TransactionReceipt> SetRecordRequestAndWaitForReceiptAsync(
                                             byte[] querySchema,
                                             BigInteger minDelta,
                                             BigInteger maxDelta,
                                             ulong sourceChainId,
                                             BigInteger numSamples,
                                             BigInteger blockInterval,
                                             BigInteger minYieldTime,
                                             BigInteger maxYieldTime,
                                             BigInteger endBlockSlippage,
                                             BigInteger lastTWAP,
                                             BigInteger waterYieldTime,
                                             BigInteger lastUpdate)
        {
            var values = new WaterControllerTableRecord.WaterControllerValue
            {
                QuerySchema = querySchema,
                MinDelta = minDelta,
                MaxDelta = maxDelta,
                SourceChainId = sourceChainId,
                NumSamples = numSamples,
                BlockInterval = blockInterval,
                MinYieldTime = minYieldTime,
                MaxYieldTime = maxYieldTime,
                EndBlockSlippage = endBlockSlippage,
                LastTWAP = lastTWAP,
                WaterYieldTime = waterYieldTime,
                LastUpdate = lastUpdate
            };

            return await SetRecordRequestAndWaitForReceiptAsync(values);
        }

    }
}
