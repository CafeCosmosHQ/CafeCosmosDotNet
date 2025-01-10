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
    public partial class MarketplaceListingsTableService : TableService<MarketplaceListingsTableRecord, MarketplaceListingsTableRecord.MarketplaceListingsKey, MarketplaceListingsTableRecord.MarketplaceListingsValue>
    { 
        public MarketplaceListingsTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
        public virtual Task<MarketplaceListingsTableRecord> GetTableRecordAsync(BigInteger listingId, BlockParameter blockParameter = null)
        {
            var _key = new MarketplaceListingsTableRecord.MarketplaceListingsKey();
            _key.ListingId = listingId;
            return GetTableRecordAsync(_key, blockParameter);
        }
        public virtual Task<string> SetRecordRequestAsync(BigInteger listingId, BigInteger owner, BigInteger itemId, BigInteger unitPrice, BigInteger quantity, bool exists)
        {
            var _key = new MarketplaceListingsTableRecord.MarketplaceListingsKey();
            _key.ListingId = listingId;

            var _values = new MarketplaceListingsTableRecord.MarketplaceListingsValue();
            _values.Owner = owner;
            _values.ItemId = itemId;
            _values.UnitPrice = unitPrice;
            _values.Quantity = quantity;
            _values.Exists = exists;
            return SetRecordRequestAsync(_key, _values);
        }
        public virtual Task<TransactionReceipt> SetRecordRequestAndWaitForReceiptAsync(BigInteger listingId, BigInteger owner, BigInteger itemId, BigInteger unitPrice, BigInteger quantity, bool exists)
        {
            var _key = new MarketplaceListingsTableRecord.MarketplaceListingsKey();
            _key.ListingId = listingId;

            var _values = new MarketplaceListingsTableRecord.MarketplaceListingsValue();
            _values.Owner = owner;
            _values.ItemId = itemId;
            _values.UnitPrice = unitPrice;
            _values.Quantity = quantity;
            _values.Exists = exists;
            return SetRecordRequestAndWaitForReceiptAsync(_key, _values);
        }
    }
    
    public partial class MarketplaceListingsTableRecord : TableRecord<MarketplaceListingsTableRecord.MarketplaceListingsKey, MarketplaceListingsTableRecord.MarketplaceListingsValue> 
    {
        public MarketplaceListingsTableRecord() : base("MarketplaceListings")
        {
        
        }
        /// <summary>
        /// Direct access to the key property 'ListingId'.
        /// </summary>
        public virtual BigInteger ListingId => Keys.ListingId;
        /// <summary>
        /// Direct access to the value property 'Owner'.
        /// </summary>
        public virtual BigInteger Owner => Values.Owner;
        /// <summary>
        /// Direct access to the value property 'ItemId'.
        /// </summary>
        public virtual BigInteger ItemId => Values.ItemId;
        /// <summary>
        /// Direct access to the value property 'UnitPrice'.
        /// </summary>
        public virtual BigInteger UnitPrice => Values.UnitPrice;
        /// <summary>
        /// Direct access to the value property 'Quantity'.
        /// </summary>
        public virtual BigInteger Quantity => Values.Quantity;
        /// <summary>
        /// Direct access to the value property 'Exists'.
        /// </summary>
        public virtual bool Exists => Values.Exists;

        public partial class MarketplaceListingsKey
        {
            [Parameter("uint256", "listingId", 1)]
            public virtual BigInteger ListingId { get; set; }
        }

        public partial class MarketplaceListingsValue
        {
            [Parameter("uint256", "owner", 1)]
            public virtual BigInteger Owner { get; set; }
            [Parameter("uint256", "itemId", 2)]
            public virtual BigInteger ItemId { get; set; }
            [Parameter("uint256", "unitPrice", 3)]
            public virtual BigInteger UnitPrice { get; set; }
            [Parameter("uint256", "quantity", 4)]
            public virtual BigInteger Quantity { get; set; }
            [Parameter("bool", "exists", 5)]
            public virtual bool Exists { get; set; }          
        }
    }
}
