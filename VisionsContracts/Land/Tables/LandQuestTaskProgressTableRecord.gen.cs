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
    public partial class LandQuestTaskProgressTableService : TableService<LandQuestTaskProgressTableRecord, LandQuestTaskProgressTableRecord.LandQuestTaskProgressKey, LandQuestTaskProgressTableRecord.LandQuestTaskProgressValue>
    { 
        public LandQuestTaskProgressTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
        public virtual Task<LandQuestTaskProgressTableRecord> GetTableRecordAsync(BigInteger landId, BigInteger questGroupId, BigInteger questId, BigInteger taskType, byte[] taskKey, BlockParameter blockParameter = null)
        {
            var _key = new LandQuestTaskProgressTableRecord.LandQuestTaskProgressKey();
            _key.LandId = landId;
            _key.QuestGroupId = questGroupId;
            _key.QuestId = questId;
            _key.TaskType = taskType;
            _key.TaskKey = taskKey;
            return GetTableRecordAsync(_key, blockParameter);
        }
        public virtual Task<string> SetRecordRequestAsync(BigInteger landId, BigInteger questGroupId, BigInteger questId, BigInteger taskType, byte[] taskKey, BigInteger taskProgress, bool taskCompleted)
        {
            var _key = new LandQuestTaskProgressTableRecord.LandQuestTaskProgressKey();
            _key.LandId = landId;
            _key.QuestGroupId = questGroupId;
            _key.QuestId = questId;
            _key.TaskType = taskType;
            _key.TaskKey = taskKey;

            var _values = new LandQuestTaskProgressTableRecord.LandQuestTaskProgressValue();
            _values.TaskProgress = taskProgress;
            _values.TaskCompleted = taskCompleted;
            return SetRecordRequestAsync(_key, _values);
        }
        public virtual Task<TransactionReceipt> SetRecordRequestAndWaitForReceiptAsync(BigInteger landId, BigInteger questGroupId, BigInteger questId, BigInteger taskType, byte[] taskKey, BigInteger taskProgress, bool taskCompleted)
        {
            var _key = new LandQuestTaskProgressTableRecord.LandQuestTaskProgressKey();
            _key.LandId = landId;
            _key.QuestGroupId = questGroupId;
            _key.QuestId = questId;
            _key.TaskType = taskType;
            _key.TaskKey = taskKey;

            var _values = new LandQuestTaskProgressTableRecord.LandQuestTaskProgressValue();
            _values.TaskProgress = taskProgress;
            _values.TaskCompleted = taskCompleted;
            return SetRecordRequestAndWaitForReceiptAsync(_key, _values);
        }
    }
    
    public partial class LandQuestTaskProgressTableRecord : TableRecord<LandQuestTaskProgressTableRecord.LandQuestTaskProgressKey, LandQuestTaskProgressTableRecord.LandQuestTaskProgressValue> 
    {
        public LandQuestTaskProgressTableRecord() : base("LandQuestTaskProgress")
        {
        
        }
        /// <summary>
        /// Direct access to the key property 'LandId'.
        /// </summary>
        public virtual BigInteger LandId => Keys.LandId;
        /// <summary>
        /// Direct access to the key property 'QuestGroupId'.
        /// </summary>
        public virtual BigInteger QuestGroupId => Keys.QuestGroupId;
        /// <summary>
        /// Direct access to the key property 'QuestId'.
        /// </summary>
        public virtual BigInteger QuestId => Keys.QuestId;
        /// <summary>
        /// Direct access to the key property 'TaskType'.
        /// </summary>
        public virtual BigInteger TaskType => Keys.TaskType;
        /// <summary>
        /// Direct access to the key property 'TaskKey'.
        /// </summary>
        public virtual byte[] TaskKey => Keys.TaskKey;
        /// <summary>
        /// Direct access to the value property 'TaskProgress'.
        /// </summary>
        public virtual BigInteger TaskProgress => Values.TaskProgress;
        /// <summary>
        /// Direct access to the value property 'TaskCompleted'.
        /// </summary>
        public virtual bool TaskCompleted => Values.TaskCompleted;

        public partial class LandQuestTaskProgressKey
        {
            [Parameter("uint256", "landId", 1)]
            public virtual BigInteger LandId { get; set; }
            [Parameter("uint256", "questGroupId", 2)]
            public virtual BigInteger QuestGroupId { get; set; }
            [Parameter("uint256", "questId", 3)]
            public virtual BigInteger QuestId { get; set; }
            [Parameter("uint256", "taskType", 4)]
            public virtual BigInteger TaskType { get; set; }
            [Parameter("bytes32", "taskKey", 5)]
            public virtual byte[] TaskKey { get; set; }
        }

        public partial class LandQuestTaskProgressValue
        {
            [Parameter("uint256", "taskProgress", 1)]
            public virtual BigInteger TaskProgress { get; set; }
            [Parameter("bool", "taskCompleted", 2)]
            public virtual bool TaskCompleted { get; set; }          
        }
    }
}
