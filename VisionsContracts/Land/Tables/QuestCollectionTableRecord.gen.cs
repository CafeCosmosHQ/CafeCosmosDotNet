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
    public partial class QuestCollectionTableService : TableService<QuestCollectionTableRecord, QuestCollectionTableRecord.QuestCollectionKey, QuestCollectionTableRecord.QuestCollectionValue>
    { 
        public QuestCollectionTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
        public virtual Task<QuestCollectionTableRecord> GetTableRecordAsync(BigInteger questGroupType, BlockParameter blockParameter = null)
        {
            var _key = new QuestCollectionTableRecord.QuestCollectionKey();
            _key.QuestGroupType = questGroupType;
            return GetTableRecordAsync(_key, blockParameter);
        }
        public virtual Task<string> SetRecordRequestAsync(BigInteger questGroupType, List<BigInteger> questIds, List<BigInteger> previousQuestIds)
        {
            var _key = new QuestCollectionTableRecord.QuestCollectionKey();
            _key.QuestGroupType = questGroupType;

            var _values = new QuestCollectionTableRecord.QuestCollectionValue();
            _values.QuestIds = questIds;
            _values.PreviousQuestIds = previousQuestIds;
            return SetRecordRequestAsync(_key, _values);
        }
        public virtual Task<TransactionReceipt> SetRecordRequestAndWaitForReceiptAsync(BigInteger questGroupType, List<BigInteger> questIds, List<BigInteger> previousQuestIds)
        {
            var _key = new QuestCollectionTableRecord.QuestCollectionKey();
            _key.QuestGroupType = questGroupType;

            var _values = new QuestCollectionTableRecord.QuestCollectionValue();
            _values.QuestIds = questIds;
            _values.PreviousQuestIds = previousQuestIds;
            return SetRecordRequestAndWaitForReceiptAsync(_key, _values);
        }
    }
    
    public partial class QuestCollectionTableRecord : TableRecord<QuestCollectionTableRecord.QuestCollectionKey, QuestCollectionTableRecord.QuestCollectionValue> 
    {
        public QuestCollectionTableRecord() : base("QuestCollection")
        {
        
        }
        /// <summary>
        /// Direct access to the key property 'QuestGroupType'.
        /// </summary>
        public virtual BigInteger QuestGroupType => Keys.QuestGroupType;
        /// <summary>
        /// Direct access to the value property 'QuestIds'.
        /// </summary>
        public virtual List<BigInteger> QuestIds => Values.QuestIds;
        /// <summary>
        /// Direct access to the value property 'PreviousQuestIds'.
        /// </summary>
        public virtual List<BigInteger> PreviousQuestIds => Values.PreviousQuestIds;

        public partial class QuestCollectionKey
        {
            [Parameter("uint256", "questGroupType", 1)]
            public virtual BigInteger QuestGroupType { get; set; }
        }

        public partial class QuestCollectionValue
        {
            [Parameter("uint256[]", "questIds", 1)]
            public virtual List<BigInteger> QuestIds { get; set; }
            [Parameter("uint256[]", "previousQuestIds", 2)]
            public virtual List<BigInteger> PreviousQuestIds { get; set; }          
        }
    }
}
