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
    public partial class QuestTableService : TableService<QuestTableRecord, QuestTableRecord.QuestKey, QuestTableRecord.QuestValue>
    { 
        public QuestTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
        public virtual Task<QuestTableRecord> GetTableRecordAsync(BigInteger id, BlockParameter blockParameter = null)
        {
            var _key = new QuestTableRecord.QuestKey();
            _key.Id = id;
            return GetTableRecordAsync(_key, blockParameter);
        }
        public virtual Task<string> SetRecordRequestAsync(BigInteger id, BigInteger duration, bool exists, string questName, List<BigInteger> rewardIds, List<byte[]> tasks)
        {
            var _key = new QuestTableRecord.QuestKey();
            _key.Id = id;

            var _values = new QuestTableRecord.QuestValue();
            _values.Duration = duration;
            _values.Exists = exists;
            _values.QuestName = questName;
            _values.RewardIds = rewardIds;
            _values.Tasks = tasks;
            return SetRecordRequestAsync(_key, _values);
        }
        public virtual Task<TransactionReceipt> SetRecordRequestAndWaitForReceiptAsync(BigInteger id, BigInteger duration, bool exists, string questName, List<BigInteger> rewardIds, List<byte[]> tasks)
        {
            var _key = new QuestTableRecord.QuestKey();
            _key.Id = id;

            var _values = new QuestTableRecord.QuestValue();
            _values.Duration = duration;
            _values.Exists = exists;
            _values.QuestName = questName;
            _values.RewardIds = rewardIds;
            _values.Tasks = tasks;
            return SetRecordRequestAndWaitForReceiptAsync(_key, _values);
        }
    }
    
    public partial class QuestTableRecord : TableRecord<QuestTableRecord.QuestKey, QuestTableRecord.QuestValue> 
    {
        public QuestTableRecord() : base("Quest")
        {
        
        }
        /// <summary>
        /// Direct access to the key property 'Id'.
        /// </summary>
        public virtual BigInteger Id => Keys.Id;
        /// <summary>
        /// Direct access to the value property 'Duration'.
        /// </summary>
        public virtual BigInteger Duration => Values.Duration;
        /// <summary>
        /// Direct access to the value property 'Exists'.
        /// </summary>
        public virtual bool Exists => Values.Exists;
        /// <summary>
        /// Direct access to the value property 'QuestName'.
        /// </summary>
        public virtual string QuestName => Values.QuestName;
        /// <summary>
        /// Direct access to the value property 'RewardIds'.
        /// </summary>
        public virtual List<BigInteger> RewardIds => Values.RewardIds;
        /// <summary>
        /// Direct access to the value property 'Tasks'.
        /// </summary>
        public virtual List<byte[]> Tasks => Values.Tasks;

        public partial class QuestKey
        {
            [Parameter("uint256", "id", 1)]
            public virtual BigInteger Id { get; set; }
        }

        public partial class QuestValue
        {
            [Parameter("uint256", "duration", 1)]
            public virtual BigInteger Duration { get; set; }
            [Parameter("bool", "exists", 2)]
            public virtual bool Exists { get; set; }
            [Parameter("string", "questName", 3)]
            public virtual string QuestName { get; set; }
            [Parameter("uint256[]", "rewardIds", 4)]
            public virtual List<BigInteger> RewardIds { get; set; }
            [Parameter("bytes32[]", "tasks", 5)]
            public virtual List<byte[]> Tasks { get; set; }          
        }
    }
}
