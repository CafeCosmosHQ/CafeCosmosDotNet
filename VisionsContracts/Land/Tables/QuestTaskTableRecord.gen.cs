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
    public partial class QuestTaskTableService : TableService<QuestTaskTableRecord, QuestTaskTableRecord.QuestTaskKey, QuestTaskTableRecord.QuestTaskValue>
    { 
        public QuestTaskTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
        public virtual Task<QuestTaskTableRecord> GetTableRecordAsync(byte[] taskId, BlockParameter blockParameter = null)
        {
            var _key = new QuestTaskTableRecord.QuestTaskKey();
            _key.TaskId = taskId;
            return GetTableRecordAsync(_key, blockParameter);
        }
        public virtual Task<string> SetRecordRequestAsync(byte[] taskId, BigInteger questId, BigInteger taskType, byte[] key, BigInteger quantity, bool exists, string name, List<byte[]> taskKeys)
        {
            var _key = new QuestTaskTableRecord.QuestTaskKey();
            _key.TaskId = taskId;

            var _values = new QuestTaskTableRecord.QuestTaskValue();
            _values.QuestId = questId;
            _values.TaskType = taskType;
            _values.Key = key;
            _values.Quantity = quantity;
            _values.Exists = exists;
            _values.Name = name;
            _values.TaskKeys = taskKeys;
            return SetRecordRequestAsync(_key, _values);
        }
        public virtual Task<TransactionReceipt> SetRecordRequestAndWaitForReceiptAsync(byte[] taskId, BigInteger questId, BigInteger taskType, byte[] key, BigInteger quantity, bool exists, string name, List<byte[]> taskKeys)
        {
            var _key = new QuestTaskTableRecord.QuestTaskKey();
            _key.TaskId = taskId;

            var _values = new QuestTaskTableRecord.QuestTaskValue();
            _values.QuestId = questId;
            _values.TaskType = taskType;
            _values.Key = key;
            _values.Quantity = quantity;
            _values.Exists = exists;
            _values.Name = name;
            _values.TaskKeys = taskKeys;
            return SetRecordRequestAndWaitForReceiptAsync(_key, _values);
        }
    }
    
    public partial class QuestTaskTableRecord : TableRecord<QuestTaskTableRecord.QuestTaskKey, QuestTaskTableRecord.QuestTaskValue> 
    {
        public QuestTaskTableRecord() : base("QuestTask")
        {
        
        }
        /// <summary>
        /// Direct access to the key property 'TaskId'.
        /// </summary>
        public virtual byte[] TaskId => Keys.TaskId;
        /// <summary>
        /// Direct access to the value property 'QuestId'.
        /// </summary>
        public virtual BigInteger QuestId => Values.QuestId;
        /// <summary>
        /// Direct access to the value property 'TaskType'.
        /// </summary>
        public virtual BigInteger TaskType => Values.TaskType;
        /// <summary>
        /// Direct access to the value property 'Key'.
        /// </summary>
        public virtual byte[] Key => Values.Key;
        /// <summary>
        /// Direct access to the value property 'Quantity'.
        /// </summary>
        public virtual BigInteger Quantity => Values.Quantity;
        /// <summary>
        /// Direct access to the value property 'Exists'.
        /// </summary>
        public virtual bool Exists => Values.Exists;
        /// <summary>
        /// Direct access to the value property 'Name'.
        /// </summary>
        public virtual string Name => Values.Name;
        /// <summary>
        /// Direct access to the value property 'TaskKeys'.
        /// </summary>
        public virtual List<byte[]> TaskKeys => Values.TaskKeys;

        public partial class QuestTaskKey
        {
            [Parameter("bytes32", "taskId", 1)]
            public virtual byte[] TaskId { get; set; }
        }

        public partial class QuestTaskValue
        {
            [Parameter("uint256", "questId", 1)]
            public virtual BigInteger QuestId { get; set; }
            [Parameter("uint256", "taskType", 2)]
            public virtual BigInteger TaskType { get; set; }
            [Parameter("bytes32", "key", 3)]
            public virtual byte[] Key { get; set; }
            [Parameter("uint256", "quantity", 4)]
            public virtual BigInteger Quantity { get; set; }
            [Parameter("bool", "exists", 5)]
            public virtual bool Exists { get; set; }
            [Parameter("string", "name", 6)]
            public virtual string Name { get; set; }
            [Parameter("bytes32[]", "taskKeys", 7)]
            public virtual List<byte[]> TaskKeys { get; set; }          
        }
    }
}
