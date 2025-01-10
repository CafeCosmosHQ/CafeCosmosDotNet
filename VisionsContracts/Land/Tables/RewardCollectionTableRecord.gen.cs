using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Mud;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Mud.Contracts.Core.Tables;
using Nethereum.Web3;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

namespace VisionsContracts.Land.Tables
{
    public partial class RewardCollectionTableService : TableService<RewardCollectionTableRecord, RewardCollectionTableRecord.RewardCollectionKey, RewardCollectionTableRecord.RewardCollectionValue>
    { 
        public RewardCollectionTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
        public virtual Task<RewardCollectionTableRecord> GetTableRecordAsync(BigInteger rewardType, BlockParameter blockParameter = null)
        {
            var _key = new RewardCollectionTableRecord.RewardCollectionKey();
            _key.RewardType = rewardType;
            return GetTableRecordAsync(_key, blockParameter);
        }
        public virtual Task<string> SetRecordRequestAsync(BigInteger rewardType, List<BigInteger> rewardIds)
        {
            var _key = new RewardCollectionTableRecord.RewardCollectionKey();
            _key.RewardType = rewardType;

            var _values = new RewardCollectionTableRecord.RewardCollectionValue();
            _values.RewardIds = rewardIds;
            return SetRecordRequestAsync(_key, _values);
        }
        public virtual Task<TransactionReceipt> SetRecordRequestAndWaitForReceiptAsync(BigInteger rewardType, List<BigInteger> rewardIds)
        {
            var _key = new RewardCollectionTableRecord.RewardCollectionKey();
            _key.RewardType = rewardType;

            var _values = new RewardCollectionTableRecord.RewardCollectionValue();
            _values.RewardIds = rewardIds;
            return SetRecordRequestAndWaitForReceiptAsync(_key, _values);
        }
    }
    
    public partial class RewardCollectionTableRecord : TableRecord<RewardCollectionTableRecord.RewardCollectionKey, RewardCollectionTableRecord.RewardCollectionValue> 
    {
        public RewardCollectionTableRecord() : base("RewardCollection")
        {
        
        }
        /// <summary>
        /// Direct access to the key property 'RewardType'.
        /// </summary>
        public virtual BigInteger RewardType => Keys.RewardType;
        /// <summary>
        /// Direct access to the value property 'RewardIds'.
        /// </summary>
        public virtual List<BigInteger> RewardIds => Values.RewardIds;

        public partial class RewardCollectionKey
        {
            [Parameter("uint256", "rewardType", 1)]
            public virtual BigInteger RewardType { get; set; }
        }

        public partial class RewardCollectionValue
        {
            [Parameter("uint256[]", "rewardIds", 1)]
            public virtual List<BigInteger> RewardIds { get; set; }          
        }
    }
}
