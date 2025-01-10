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
    public partial class LandQuestTableService : TableService<LandQuestTableRecord, LandQuestTableRecord.LandQuestKey, LandQuestTableRecord.LandQuestValue>
    { 
        public LandQuestTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
        public virtual Task<LandQuestTableRecord> GetTableRecordAsync(BigInteger landId, BigInteger questGroupId, BigInteger questId, BlockParameter blockParameter = null)
        {
            var _key = new LandQuestTableRecord.LandQuestKey();
            _key.LandId = landId;
            _key.QuestGroupId = questGroupId;
            _key.QuestId = questId;
            return GetTableRecordAsync(_key, blockParameter);
        }
        public virtual Task<string> SetRecordRequestAsync(BigInteger landId, BigInteger questGroupId, BigInteger questId, BigInteger numberOfTasks, BigInteger numberOfCompletedTasks, bool claimed, bool active, BigInteger expiresAt)
        {
            var _key = new LandQuestTableRecord.LandQuestKey();
            _key.LandId = landId;
            _key.QuestGroupId = questGroupId;
            _key.QuestId = questId;

            var _values = new LandQuestTableRecord.LandQuestValue();
            _values.NumberOfTasks = numberOfTasks;
            _values.NumberOfCompletedTasks = numberOfCompletedTasks;
            _values.Claimed = claimed;
            _values.Active = active;
            _values.ExpiresAt = expiresAt;
            return SetRecordRequestAsync(_key, _values);
        }
        public virtual Task<TransactionReceipt> SetRecordRequestAndWaitForReceiptAsync(BigInteger landId, BigInteger questGroupId, BigInteger questId, BigInteger numberOfTasks, BigInteger numberOfCompletedTasks, bool claimed, bool active, BigInteger expiresAt)
        {
            var _key = new LandQuestTableRecord.LandQuestKey();
            _key.LandId = landId;
            _key.QuestGroupId = questGroupId;
            _key.QuestId = questId;

            var _values = new LandQuestTableRecord.LandQuestValue();
            _values.NumberOfTasks = numberOfTasks;
            _values.NumberOfCompletedTasks = numberOfCompletedTasks;
            _values.Claimed = claimed;
            _values.Active = active;
            _values.ExpiresAt = expiresAt;
            return SetRecordRequestAndWaitForReceiptAsync(_key, _values);
        }
    }
    
    public partial class LandQuestTableRecord : TableRecord<LandQuestTableRecord.LandQuestKey, LandQuestTableRecord.LandQuestValue> 
    {
        public LandQuestTableRecord() : base("LandQuest")
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
        /// Direct access to the value property 'NumberOfTasks'.
        /// </summary>
        public virtual BigInteger NumberOfTasks => Values.NumberOfTasks;
        /// <summary>
        /// Direct access to the value property 'NumberOfCompletedTasks'.
        /// </summary>
        public virtual BigInteger NumberOfCompletedTasks => Values.NumberOfCompletedTasks;
        /// <summary>
        /// Direct access to the value property 'Claimed'.
        /// </summary>
        public virtual bool Claimed => Values.Claimed;
        /// <summary>
        /// Direct access to the value property 'Active'.
        /// </summary>
        public virtual bool Active => Values.Active;
        /// <summary>
        /// Direct access to the value property 'ExpiresAt'.
        /// </summary>
        public virtual BigInteger ExpiresAt => Values.ExpiresAt;

        public partial class LandQuestKey
        {
            [Parameter("uint256", "landId", 1)]
            public virtual BigInteger LandId { get; set; }
            [Parameter("uint256", "questGroupId", 2)]
            public virtual BigInteger QuestGroupId { get; set; }
            [Parameter("uint256", "questId", 3)]
            public virtual BigInteger QuestId { get; set; }
        }

        public partial class LandQuestValue
        {
            [Parameter("uint256", "numberOfTasks", 1)]
            public virtual BigInteger NumberOfTasks { get; set; }
            [Parameter("uint256", "numberOfCompletedTasks", 2)]
            public virtual BigInteger NumberOfCompletedTasks { get; set; }
            [Parameter("bool", "claimed", 3)]
            public virtual bool Claimed { get; set; }
            [Parameter("bool", "active", 4)]
            public virtual bool Active { get; set; }
            [Parameter("uint256", "expiresAt", 5)]
            public virtual BigInteger ExpiresAt { get; set; }          
        }
    }
}
