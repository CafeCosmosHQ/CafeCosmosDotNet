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
    public partial class QuestGroupTableService : TableService<QuestGroupTableRecord, QuestGroupTableRecord.QuestGroupKey, QuestGroupTableRecord.QuestGroupValue>
    { 
        public QuestGroupTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
        public virtual Task<QuestGroupTableRecord> GetTableRecordAsync(BigInteger id, BlockParameter blockParameter = null)
        {
            var _key = new QuestGroupTableRecord.QuestGroupKey();
            _key.Id = id;
            return GetTableRecordAsync(_key, blockParameter);
        }
        public virtual Task<string> SetRecordRequestAsync(BigInteger id, BigInteger startsAt, BigInteger expiresAt, bool sequential, BigInteger questGroupType, List<BigInteger> questIds, List<BigInteger> rewardIds)
        {
            var _key = new QuestGroupTableRecord.QuestGroupKey();
            _key.Id = id;

            var _values = new QuestGroupTableRecord.QuestGroupValue();
            _values.StartsAt = startsAt;
            _values.ExpiresAt = expiresAt;
            _values.Sequential = sequential;
            _values.QuestGroupType = questGroupType;
            _values.QuestIds = questIds;
            _values.RewardIds = rewardIds;
            return SetRecordRequestAsync(_key, _values);
        }
        public virtual Task<TransactionReceipt> SetRecordRequestAndWaitForReceiptAsync(BigInteger id, BigInteger startsAt, BigInteger expiresAt, bool sequential, BigInteger questGroupType, List<BigInteger> questIds, List<BigInteger> rewardIds)
        {
            var _key = new QuestGroupTableRecord.QuestGroupKey();
            _key.Id = id;

            var _values = new QuestGroupTableRecord.QuestGroupValue();
            _values.StartsAt = startsAt;
            _values.ExpiresAt = expiresAt;
            _values.Sequential = sequential;
            _values.QuestGroupType = questGroupType;
            _values.QuestIds = questIds;
            _values.RewardIds = rewardIds;
            return SetRecordRequestAndWaitForReceiptAsync(_key, _values);
        }
    }
    
    public partial class QuestGroupTableRecord : TableRecord<QuestGroupTableRecord.QuestGroupKey, QuestGroupTableRecord.QuestGroupValue> 
    {
        public QuestGroupTableRecord() : base("QuestGroup")
        {
        
        }
        /// <summary>
        /// Direct access to the key property 'Id'.
        /// </summary>
        public virtual BigInteger Id => Keys.Id;
        /// <summary>
        /// Direct access to the value property 'StartsAt'.
        /// </summary>
        public virtual BigInteger StartsAt => Values.StartsAt;
        /// <summary>
        /// Direct access to the value property 'ExpiresAt'.
        /// </summary>
        public virtual BigInteger ExpiresAt => Values.ExpiresAt;
        /// <summary>
        /// Direct access to the value property 'Sequential'.
        /// </summary>
        public virtual bool Sequential => Values.Sequential;
        /// <summary>
        /// Direct access to the value property 'QuestGroupType'.
        /// </summary>
        public virtual BigInteger QuestGroupType => Values.QuestGroupType;
        /// <summary>
        /// Direct access to the value property 'QuestIds'.
        /// </summary>
        public virtual List<BigInteger> QuestIds => Values.QuestIds;
        /// <summary>
        /// Direct access to the value property 'RewardIds'.
        /// </summary>
        public virtual List<BigInteger> RewardIds => Values.RewardIds;

        public partial class QuestGroupKey
        {
            [Parameter("uint256", "id", 1)]
            public virtual BigInteger Id { get; set; }
        }

        public partial class QuestGroupValue
        {
            [Parameter("uint256", "startsAt", 1)]
            public virtual BigInteger StartsAt { get; set; }
            [Parameter("uint256", "expiresAt", 2)]
            public virtual BigInteger ExpiresAt { get; set; }
            [Parameter("bool", "sequential", 3)]
            public virtual bool Sequential { get; set; }
            [Parameter("uint256", "questGroupType", 4)]
            public virtual BigInteger QuestGroupType { get; set; }
            [Parameter("uint256[]", "questIds", 5)]
            public virtual List<BigInteger> QuestIds { get; set; }
            [Parameter("uint256[]", "rewardIds", 6)]
            public virtual List<BigInteger> RewardIds { get; set; }          
        }
    }
}
