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
    public partial class ItemInfoTableService : TableService<ItemInfoTableRecord, ItemInfoTableRecord.ItemInfoKey, ItemInfoTableRecord.ItemInfoValue>
    { 
        public ItemInfoTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
        public virtual Task<ItemInfoTableRecord> GetTableRecordAsync(BigInteger itemId, BlockParameter blockParameter = null)
        {
            var _key = new ItemInfoTableRecord.ItemInfoKey();
            _key.ItemId = itemId;
            return GetTableRecordAsync(_key, blockParameter);
        }
        public virtual Task<string> SetRecordRequestAsync(BigInteger itemId, bool nonRemovable, bool nonPlaceable, bool isTool, bool isTable, bool isChair, bool isRotatable, BigInteger themeId, BigInteger itemCategory, BigInteger returnsItem)
        {
            var _key = new ItemInfoTableRecord.ItemInfoKey();
            _key.ItemId = itemId;

            var _values = new ItemInfoTableRecord.ItemInfoValue();
            _values.NonRemovable = nonRemovable;
            _values.NonPlaceable = nonPlaceable;
            _values.IsTool = isTool;
            _values.IsTable = isTable;
            _values.IsChair = isChair;
            _values.IsRotatable = isRotatable;
            _values.ThemeId = themeId;
            _values.ItemCategory = itemCategory;
            _values.ReturnsItem = returnsItem;
            return SetRecordRequestAsync(_key, _values);
        }
        public virtual Task<TransactionReceipt> SetRecordRequestAndWaitForReceiptAsync(BigInteger itemId, bool nonRemovable, bool nonPlaceable, bool isTool, bool isTable, bool isChair, bool isRotatable, BigInteger themeId, BigInteger itemCategory, BigInteger returnsItem)
        {
            var _key = new ItemInfoTableRecord.ItemInfoKey();
            _key.ItemId = itemId;

            var _values = new ItemInfoTableRecord.ItemInfoValue();
            _values.NonRemovable = nonRemovable;
            _values.NonPlaceable = nonPlaceable;
            _values.IsTool = isTool;
            _values.IsTable = isTable;
            _values.IsChair = isChair;
            _values.IsRotatable = isRotatable;
            _values.ThemeId = themeId;
            _values.ItemCategory = itemCategory;
            _values.ReturnsItem = returnsItem;
            return SetRecordRequestAndWaitForReceiptAsync(_key, _values);
        }
    }
    
    public partial class ItemInfoTableRecord : TableRecord<ItemInfoTableRecord.ItemInfoKey, ItemInfoTableRecord.ItemInfoValue> 
    {
        public ItemInfoTableRecord() : base("ItemInfo")
        {
        
        }
        /// <summary>
        /// Direct access to the key property 'ItemId'.
        /// </summary>
        public virtual BigInteger ItemId => Keys.ItemId;
        /// <summary>
        /// Direct access to the value property 'NonRemovable'.
        /// </summary>
        public virtual bool NonRemovable => Values.NonRemovable;
        /// <summary>
        /// Direct access to the value property 'NonPlaceable'.
        /// </summary>
        public virtual bool NonPlaceable => Values.NonPlaceable;
        /// <summary>
        /// Direct access to the value property 'IsTool'.
        /// </summary>
        public virtual bool IsTool => Values.IsTool;
        /// <summary>
        /// Direct access to the value property 'IsTable'.
        /// </summary>
        public virtual bool IsTable => Values.IsTable;
        /// <summary>
        /// Direct access to the value property 'IsChair'.
        /// </summary>
        public virtual bool IsChair => Values.IsChair;
        /// <summary>
        /// Direct access to the value property 'IsRotatable'.
        /// </summary>
        public virtual bool IsRotatable => Values.IsRotatable;
        /// <summary>
        /// Direct access to the value property 'ThemeId'.
        /// </summary>
        public virtual BigInteger ThemeId => Values.ThemeId;
        /// <summary>
        /// Direct access to the value property 'ItemCategory'.
        /// </summary>
        public virtual BigInteger ItemCategory => Values.ItemCategory;
        /// <summary>
        /// Direct access to the value property 'ReturnsItem'.
        /// </summary>
        public virtual BigInteger ReturnsItem => Values.ReturnsItem;

        public partial class ItemInfoKey
        {
            [Parameter("uint256", "itemId", 1)]
            public virtual BigInteger ItemId { get; set; }
        }

        public partial class ItemInfoValue
        {
            [Parameter("bool", "nonRemovable", 1)]
            public virtual bool NonRemovable { get; set; }
            [Parameter("bool", "nonPlaceable", 2)]
            public virtual bool NonPlaceable { get; set; }
            [Parameter("bool", "isTool", 3)]
            public virtual bool IsTool { get; set; }
            [Parameter("bool", "isTable", 4)]
            public virtual bool IsTable { get; set; }
            [Parameter("bool", "isChair", 5)]
            public virtual bool IsChair { get; set; }
            [Parameter("bool", "isRotatable", 6)]
            public virtual bool IsRotatable { get; set; }
            [Parameter("uint256", "themeId", 7)]
            public virtual BigInteger ThemeId { get; set; }
            [Parameter("uint256", "itemCategory", 8)]
            public virtual BigInteger ItemCategory { get; set; }
            [Parameter("uint256", "returnsItem", 9)]
            public virtual BigInteger ReturnsItem { get; set; }          
        }
    }
}
