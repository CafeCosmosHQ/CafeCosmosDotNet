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
    public partial class CatalogueItemTableService : TableService<CatalogueItemTableRecord, CatalogueItemTableRecord.CatalogueItemKey, CatalogueItemTableRecord.CatalogueItemValue>
    { 
        public CatalogueItemTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
        public virtual Task<CatalogueItemTableRecord> GetTableRecordAsync(BigInteger itemId, BlockParameter blockParameter = null)
        {
            var _key = new CatalogueItemTableRecord.CatalogueItemKey();
            _key.ItemId = itemId;
            return GetTableRecordAsync(_key, blockParameter);
        }
        public virtual Task<string> SetRecordRequestAsync(BigInteger itemId, BigInteger catalogueId, BigInteger price, bool exists)
        {
            var _key = new CatalogueItemTableRecord.CatalogueItemKey();
            _key.ItemId = itemId;

            var _values = new CatalogueItemTableRecord.CatalogueItemValue();
            _values.CatalogueId = catalogueId;
            _values.Price = price;
            _values.Exists = exists;
            return SetRecordRequestAsync(_key, _values);
        }
        public virtual Task<TransactionReceipt> SetRecordRequestAndWaitForReceiptAsync(BigInteger itemId, BigInteger catalogueId, BigInteger price, bool exists)
        {
            var _key = new CatalogueItemTableRecord.CatalogueItemKey();
            _key.ItemId = itemId;

            var _values = new CatalogueItemTableRecord.CatalogueItemValue();
            _values.CatalogueId = catalogueId;
            _values.Price = price;
            _values.Exists = exists;
            return SetRecordRequestAndWaitForReceiptAsync(_key, _values);
        }
    }
    
    public partial class CatalogueItemTableRecord : TableRecord<CatalogueItemTableRecord.CatalogueItemKey, CatalogueItemTableRecord.CatalogueItemValue> 
    {
        public CatalogueItemTableRecord() : base("CatalogueItem")
        {
        
        }
        /// <summary>
        /// Direct access to the key property 'ItemId'.
        /// </summary>
        public virtual BigInteger ItemId => Keys.ItemId;
        /// <summary>
        /// Direct access to the value property 'CatalogueId'.
        /// </summary>
        public virtual BigInteger CatalogueId => Values.CatalogueId;
        /// <summary>
        /// Direct access to the value property 'Price'.
        /// </summary>
        public virtual BigInteger Price => Values.Price;
        /// <summary>
        /// Direct access to the value property 'Exists'.
        /// </summary>
        public virtual bool Exists => Values.Exists;

        public partial class CatalogueItemKey
        {
            [Parameter("uint256", "itemId", 1)]
            public virtual BigInteger ItemId { get; set; }
        }

        public partial class CatalogueItemValue
        {
            [Parameter("uint256", "catalogueId", 1)]
            public virtual BigInteger CatalogueId { get; set; }
            [Parameter("uint256", "price", 2)]
            public virtual BigInteger Price { get; set; }
            [Parameter("bool", "exists", 3)]
            public virtual bool Exists { get; set; }          
        }
    }
}
