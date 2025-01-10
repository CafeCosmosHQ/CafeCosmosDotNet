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
    public partial class StackableItemTableService : TableService<StackableItemTableRecord, StackableItemTableRecord.StackableItemKey, StackableItemTableRecord.StackableItemValue>
    { 
        public StackableItemTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
        public virtual Task<StackableItemTableRecord> GetTableRecordAsync(BigInteger @base, BigInteger input, BlockParameter blockParameter = null)
        {
            var _key = new StackableItemTableRecord.StackableItemKey();
            _key.Base = @base;
            _key.Input = input;
            return GetTableRecordAsync(_key, blockParameter);
        }
        public virtual Task<string> SetRecordRequestAsync(BigInteger @base, BigInteger input, bool stackable)
        {
            var _key = new StackableItemTableRecord.StackableItemKey();
            _key.Base = @base;
            _key.Input = input;

            var _values = new StackableItemTableRecord.StackableItemValue();
            _values.Stackable = stackable;
            return SetRecordRequestAsync(_key, _values);
        }
        public virtual Task<TransactionReceipt> SetRecordRequestAndWaitForReceiptAsync(BigInteger @base, BigInteger input, bool stackable)
        {
            var _key = new StackableItemTableRecord.StackableItemKey();
            _key.Base = @base;
            _key.Input = input;

            var _values = new StackableItemTableRecord.StackableItemValue();
            _values.Stackable = stackable;
            return SetRecordRequestAndWaitForReceiptAsync(_key, _values);
        }
    }
    
    public partial class StackableItemTableRecord : TableRecord<StackableItemTableRecord.StackableItemKey, StackableItemTableRecord.StackableItemValue> 
    {
        public StackableItemTableRecord() : base("StackableItem")
        {
        
        }
        /// <summary>
        /// Direct access to the key property 'Base'.
        /// </summary>
        public virtual BigInteger Base => Keys.Base;
        /// <summary>
        /// Direct access to the key property 'Input'.
        /// </summary>
        public virtual BigInteger Input => Keys.Input;
        /// <summary>
        /// Direct access to the value property 'Stackable'.
        /// </summary>
        public virtual bool Stackable => Values.Stackable;

        public partial class StackableItemKey
        {
            [Parameter("uint256", "base", 1)]
            public virtual BigInteger Base { get; set; }
            [Parameter("uint256", "input", 2)]
            public virtual BigInteger Input { get; set; }
        }

        public partial class StackableItemValue
        {
            [Parameter("bool", "stackable", 1)]
            public virtual bool Stackable { get; set; }          
        }
    }
}
