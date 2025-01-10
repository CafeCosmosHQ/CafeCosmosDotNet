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
    public partial class LandQuestGroupsTableService : TableService<LandQuestGroupsTableRecord, LandQuestGroupsTableRecord.LandQuestGroupsKey, LandQuestGroupsTableRecord.LandQuestGroupsValue>
    { 
        public LandQuestGroupsTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
        public virtual Task<LandQuestGroupsTableRecord> GetTableRecordAsync(BigInteger landId, BlockParameter blockParameter = null)
        {
            var _key = new LandQuestGroupsTableRecord.LandQuestGroupsKey();
            _key.LandId = landId;
            return GetTableRecordAsync(_key, blockParameter);
        }
        public virtual Task<string> SetRecordRequestAsync(BigInteger landId, List<BigInteger> activeQuestGroupIds, List<BigInteger> questGroupIds)
        {
            var _key = new LandQuestGroupsTableRecord.LandQuestGroupsKey();
            _key.LandId = landId;

            var _values = new LandQuestGroupsTableRecord.LandQuestGroupsValue();
            _values.ActiveQuestGroupIds = activeQuestGroupIds;
            _values.QuestGroupIds = questGroupIds;
            return SetRecordRequestAsync(_key, _values);
        }
        public virtual Task<TransactionReceipt> SetRecordRequestAndWaitForReceiptAsync(BigInteger landId, List<BigInteger> activeQuestGroupIds, List<BigInteger> questGroupIds)
        {
            var _key = new LandQuestGroupsTableRecord.LandQuestGroupsKey();
            _key.LandId = landId;

            var _values = new LandQuestGroupsTableRecord.LandQuestGroupsValue();
            _values.ActiveQuestGroupIds = activeQuestGroupIds;
            _values.QuestGroupIds = questGroupIds;
            return SetRecordRequestAndWaitForReceiptAsync(_key, _values);
        }
    }
    
    public partial class LandQuestGroupsTableRecord : TableRecord<LandQuestGroupsTableRecord.LandQuestGroupsKey, LandQuestGroupsTableRecord.LandQuestGroupsValue> 
    {
        public LandQuestGroupsTableRecord() : base("LandQuestGroups")
        {
        
        }
        /// <summary>
        /// Direct access to the key property 'LandId'.
        /// </summary>
        public virtual BigInteger LandId => Keys.LandId;
        /// <summary>
        /// Direct access to the value property 'ActiveQuestGroupIds'.
        /// </summary>
        public virtual List<BigInteger> ActiveQuestGroupIds => Values.ActiveQuestGroupIds;
        /// <summary>
        /// Direct access to the value property 'QuestGroupIds'.
        /// </summary>
        public virtual List<BigInteger> QuestGroupIds => Values.QuestGroupIds;

        public partial class LandQuestGroupsKey
        {
            [Parameter("uint256", "landId", 1)]
            public virtual BigInteger LandId { get; set; }
        }

        public partial class LandQuestGroupsValue
        {
            [Parameter("uint256[]", "activeQuestGroupIds", 1)]
            public virtual List<BigInteger> ActiveQuestGroupIds { get; set; }
            [Parameter("uint256[]", "questGroupIds", 2)]
            public virtual List<BigInteger> QuestGroupIds { get; set; }          
        }
    }
}
