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
    public partial class ActiveStovesTableService : TableService<ActiveStovesTableRecord, ActiveStovesTableRecord.ActiveStovesKey, ActiveStovesTableRecord.ActiveStovesValue>
    { 
        public ActiveStovesTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
        public virtual Task<ActiveStovesTableRecord> GetTableRecordAsync(BigInteger itemId, BlockParameter blockParameter = null)
        {
            var _key = new ActiveStovesTableRecord.ActiveStovesKey();
            _key.ItemId = itemId;
            return GetTableRecordAsync(_key, blockParameter);
        }
        public virtual Task<string> SetRecordRequestAsync(BigInteger itemId, BigInteger totalActiveStoves)
        {
            var _key = new ActiveStovesTableRecord.ActiveStovesKey();
            _key.ItemId = itemId;

            var _values = new ActiveStovesTableRecord.ActiveStovesValue();
            _values.TotalActiveStoves = totalActiveStoves;
            return SetRecordRequestAsync(_key, _values);
        }
        public virtual Task<TransactionReceipt> SetRecordRequestAndWaitForReceiptAsync(BigInteger itemId, BigInteger totalActiveStoves)
        {
            var _key = new ActiveStovesTableRecord.ActiveStovesKey();
            _key.ItemId = itemId;

            var _values = new ActiveStovesTableRecord.ActiveStovesValue();
            _values.TotalActiveStoves = totalActiveStoves;
            return SetRecordRequestAndWaitForReceiptAsync(_key, _values);
        }
    }
    
    public partial class ActiveStovesTableRecord : TableRecord<ActiveStovesTableRecord.ActiveStovesKey, ActiveStovesTableRecord.ActiveStovesValue> 
    {
        public ActiveStovesTableRecord() : base("ActiveStoves")
        {
        
        }
        /// <summary>
        /// Direct access to the key property 'ItemId'.
        /// </summary>
        public virtual BigInteger ItemId => Keys.ItemId;
        /// <summary>
        /// Direct access to the value property 'TotalActiveStoves'.
        /// </summary>
        public virtual BigInteger TotalActiveStoves => Values.TotalActiveStoves;

        public partial class ActiveStovesKey
        {
            [Parameter("uint256", "itemId", 1)]
            public virtual BigInteger ItemId { get; set; }
        }

        public partial class ActiveStovesValue
        {
            [Parameter("uint256", "totalActiveStoves", 1)]
            public virtual BigInteger TotalActiveStoves { get; set; }          
        }
    }
}
