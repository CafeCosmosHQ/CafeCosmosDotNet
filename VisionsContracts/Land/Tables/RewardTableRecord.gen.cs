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
    public partial class RewardTableService : TableService<RewardTableRecord, RewardTableRecord.RewardKey, RewardTableRecord.RewardValue>
    { 
        public RewardTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
        public virtual Task<RewardTableRecord> GetTableRecordAsync(BigInteger id, BlockParameter blockParameter = null)
        {
            var _key = new RewardTableRecord.RewardKey();
            _key.Id = id;
            return GetTableRecordAsync(_key, blockParameter);
        }
        public virtual Task<string> SetRecordRequestAsync(BigInteger id, BigInteger itemId, BigInteger rewardType, BigInteger quantity)
        {
            var _key = new RewardTableRecord.RewardKey();
            _key.Id = id;

            var _values = new RewardTableRecord.RewardValue();
            _values.ItemId = itemId;
            _values.RewardType = rewardType;
            _values.Quantity = quantity;
            return SetRecordRequestAsync(_key, _values);
        }
        public virtual Task<TransactionReceipt> SetRecordRequestAndWaitForReceiptAsync(BigInteger id, BigInteger itemId, BigInteger rewardType, BigInteger quantity)
        {
            var _key = new RewardTableRecord.RewardKey();
            _key.Id = id;

            var _values = new RewardTableRecord.RewardValue();
            _values.ItemId = itemId;
            _values.RewardType = rewardType;
            _values.Quantity = quantity;
            return SetRecordRequestAndWaitForReceiptAsync(_key, _values);
        }
    }
    
    public partial class RewardTableRecord : TableRecord<RewardTableRecord.RewardKey, RewardTableRecord.RewardValue> 
    {
        public RewardTableRecord() : base("Reward")
        {
        
        }
        /// <summary>
        /// Direct access to the key property 'Id'.
        /// </summary>
        public virtual BigInteger Id => Keys.Id;
        /// <summary>
        /// Direct access to the value property 'ItemId'.
        /// </summary>
        public virtual BigInteger ItemId => Values.ItemId;
        /// <summary>
        /// Direct access to the value property 'RewardType'.
        /// </summary>
        public virtual BigInteger RewardType => Values.RewardType;
        /// <summary>
        /// Direct access to the value property 'Quantity'.
        /// </summary>
        public virtual BigInteger Quantity => Values.Quantity;

        public partial class RewardKey
        {
            [Parameter("uint256", "id", 1)]
            public virtual BigInteger Id { get; set; }
        }

        public partial class RewardValue
        {
            [Parameter("uint256", "itemId", 1)]
            public virtual BigInteger ItemId { get; set; }
            [Parameter("uint256", "rewardType", 2)]
            public virtual BigInteger RewardType { get; set; }
            [Parameter("uint256", "quantity", 3)]
            public virtual BigInteger Quantity { get; set; }          
        }
    }
}
