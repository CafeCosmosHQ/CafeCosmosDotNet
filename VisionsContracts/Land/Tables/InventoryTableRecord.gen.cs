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
    public partial class InventoryTableService : TableService<InventoryTableRecord, InventoryTableRecord.InventoryKey, InventoryTableRecord.InventoryValue>
    { 
        public InventoryTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
        public virtual Task<InventoryTableRecord> GetTableRecordAsync(BigInteger landId, BigInteger item, BlockParameter blockParameter = null)
        {
            var _key = new InventoryTableRecord.InventoryKey();
            _key.LandId = landId;
            _key.Item = item;
            return GetTableRecordAsync(_key, blockParameter);
        }
        public virtual Task<string> SetRecordRequestAsync(BigInteger landId, BigInteger item, BigInteger quantity)
        {
            var _key = new InventoryTableRecord.InventoryKey();
            _key.LandId = landId;
            _key.Item = item;

            var _values = new InventoryTableRecord.InventoryValue();
            _values.Quantity = quantity;
            return SetRecordRequestAsync(_key, _values);
        }
        public virtual Task<TransactionReceipt> SetRecordRequestAndWaitForReceiptAsync(BigInteger landId, BigInteger item, BigInteger quantity)
        {
            var _key = new InventoryTableRecord.InventoryKey();
            _key.LandId = landId;
            _key.Item = item;

            var _values = new InventoryTableRecord.InventoryValue();
            _values.Quantity = quantity;
            return SetRecordRequestAndWaitForReceiptAsync(_key, _values);
        }
    }
    
    public partial class InventoryTableRecord : TableRecord<InventoryTableRecord.InventoryKey, InventoryTableRecord.InventoryValue> 
    {
        public InventoryTableRecord() : base("Inventory")
        {
        
        }
        /// <summary>
        /// Direct access to the key property 'LandId'.
        /// </summary>
        public virtual BigInteger LandId => Keys.LandId;
        /// <summary>
        /// Direct access to the key property 'Item'.
        /// </summary>
        public virtual BigInteger Item => Keys.Item;
        /// <summary>
        /// Direct access to the value property 'Quantity'.
        /// </summary>
        public virtual BigInteger Quantity => Values.Quantity;

        public partial class InventoryKey
        {
            [Parameter("uint256", "landId", 1)]
            public virtual BigInteger LandId { get; set; }
            [Parameter("uint256", "item", 2)]
            public virtual BigInteger Item { get; set; }
        }

        public partial class InventoryValue
        {
            [Parameter("uint256", "quantity", 1)]
            public virtual BigInteger Quantity { get; set; }          
        }
    }
}
