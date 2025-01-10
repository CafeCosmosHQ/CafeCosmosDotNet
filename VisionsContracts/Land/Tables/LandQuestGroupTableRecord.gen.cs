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
    public partial class LandQuestGroupTableService : TableService<LandQuestGroupTableRecord, LandQuestGroupTableRecord.LandQuestGroupKey, LandQuestGroupTableRecord.LandQuestGroupValue>
    { 
        public LandQuestGroupTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
        public virtual Task<LandQuestGroupTableRecord> GetTableRecordAsync(BigInteger landId, BigInteger questGroupId, BlockParameter blockParameter = null)
        {
            var _key = new LandQuestGroupTableRecord.LandQuestGroupKey();
            _key.LandId = landId;
            _key.QuestGroupId = questGroupId;
            return GetTableRecordAsync(_key, blockParameter);
        }
        public virtual Task<string> SetRecordRequestAsync(BigInteger landId, BigInteger questGroupId, bool active, BigInteger numberOfQuests, BigInteger numberOfCompletedQuests, bool claimed, BigInteger expiresAt)
        {
            var _key = new LandQuestGroupTableRecord.LandQuestGroupKey();
            _key.LandId = landId;
            _key.QuestGroupId = questGroupId;

            var _values = new LandQuestGroupTableRecord.LandQuestGroupValue();
            _values.Active = active;
            _values.NumberOfQuests = numberOfQuests;
            _values.NumberOfCompletedQuests = numberOfCompletedQuests;
            _values.Claimed = claimed;
            _values.ExpiresAt = expiresAt;
            return SetRecordRequestAsync(_key, _values);
        }
        public virtual Task<TransactionReceipt> SetRecordRequestAndWaitForReceiptAsync(BigInteger landId, BigInteger questGroupId, bool active, BigInteger numberOfQuests, BigInteger numberOfCompletedQuests, bool claimed, BigInteger expiresAt)
        {
            var _key = new LandQuestGroupTableRecord.LandQuestGroupKey();
            _key.LandId = landId;
            _key.QuestGroupId = questGroupId;

            var _values = new LandQuestGroupTableRecord.LandQuestGroupValue();
            _values.Active = active;
            _values.NumberOfQuests = numberOfQuests;
            _values.NumberOfCompletedQuests = numberOfCompletedQuests;
            _values.Claimed = claimed;
            _values.ExpiresAt = expiresAt;
            return SetRecordRequestAndWaitForReceiptAsync(_key, _values);
        }
    }
    
    public partial class LandQuestGroupTableRecord : TableRecord<LandQuestGroupTableRecord.LandQuestGroupKey, LandQuestGroupTableRecord.LandQuestGroupValue> 
    {
        public LandQuestGroupTableRecord() : base("LandQuestGroup")
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
        /// Direct access to the value property 'Active'.
        /// </summary>
        public virtual bool Active => Values.Active;
        /// <summary>
        /// Direct access to the value property 'NumberOfQuests'.
        /// </summary>
        public virtual BigInteger NumberOfQuests => Values.NumberOfQuests;
        /// <summary>
        /// Direct access to the value property 'NumberOfCompletedQuests'.
        /// </summary>
        public virtual BigInteger NumberOfCompletedQuests => Values.NumberOfCompletedQuests;
        /// <summary>
        /// Direct access to the value property 'Claimed'.
        /// </summary>
        public virtual bool Claimed => Values.Claimed;
        /// <summary>
        /// Direct access to the value property 'ExpiresAt'.
        /// </summary>
        public virtual BigInteger ExpiresAt => Values.ExpiresAt;

        public partial class LandQuestGroupKey
        {
            [Parameter("uint256", "landId", 1)]
            public virtual BigInteger LandId { get; set; }
            [Parameter("uint256", "questGroupId", 2)]
            public virtual BigInteger QuestGroupId { get; set; }
        }

        public partial class LandQuestGroupValue
        {
            [Parameter("bool", "active", 1)]
            public virtual bool Active { get; set; }
            [Parameter("uint256", "numberOfQuests", 2)]
            public virtual BigInteger NumberOfQuests { get; set; }
            [Parameter("uint256", "numberOfCompletedQuests", 3)]
            public virtual BigInteger NumberOfCompletedQuests { get; set; }
            [Parameter("bool", "claimed", 4)]
            public virtual bool Claimed { get; set; }
            [Parameter("uint256", "expiresAt", 5)]
            public virtual BigInteger ExpiresAt { get; set; }          
        }
    }
}
