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
    public partial class LandItemTableService : TableService<LandItemTableRecord, LandItemTableRecord.LandItemKey, LandItemTableRecord.LandItemValue>
    { 
        public LandItemTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
        public virtual Task<LandItemTableRecord> GetTableRecordAsync(BigInteger landId, BigInteger x, BigInteger y, BigInteger z, BlockParameter blockParameter = null)
        {
            var _key = new LandItemTableRecord.LandItemKey();
            _key.LandId = landId;
            _key.X = x;
            _key.Y = y;
            _key.Z = z;
            return GetTableRecordAsync(_key, blockParameter);
        }
        public virtual Task<string> SetRecordRequestAsync(BigInteger landId, BigInteger x, BigInteger y, BigInteger z, BigInteger itemId, BigInteger placementTime, BigInteger dynamicUnlockTimes, BigInteger dynamicTimeoutTimes, bool isRotated)
        {
            var _key = new LandItemTableRecord.LandItemKey();
            _key.LandId = landId;
            _key.X = x;
            _key.Y = y;
            _key.Z = z;

            var _values = new LandItemTableRecord.LandItemValue();
            _values.ItemId = itemId;
            _values.PlacementTime = placementTime;
            _values.DynamicUnlockTimes = dynamicUnlockTimes;
            _values.DynamicTimeoutTimes = dynamicTimeoutTimes;
            _values.IsRotated = isRotated;
            return SetRecordRequestAsync(_key, _values);
        }
        public virtual Task<TransactionReceipt> SetRecordRequestAndWaitForReceiptAsync(BigInteger landId, BigInteger x, BigInteger y, BigInteger z, BigInteger itemId, BigInteger placementTime, BigInteger dynamicUnlockTimes, BigInteger dynamicTimeoutTimes, bool isRotated)
        {
            var _key = new LandItemTableRecord.LandItemKey();
            _key.LandId = landId;
            _key.X = x;
            _key.Y = y;
            _key.Z = z;

            var _values = new LandItemTableRecord.LandItemValue();
            _values.ItemId = itemId;
            _values.PlacementTime = placementTime;
            _values.DynamicUnlockTimes = dynamicUnlockTimes;
            _values.DynamicTimeoutTimes = dynamicTimeoutTimes;
            _values.IsRotated = isRotated;
            return SetRecordRequestAndWaitForReceiptAsync(_key, _values);
        }
    }
    
    public partial class LandItemTableRecord : TableRecord<LandItemTableRecord.LandItemKey, LandItemTableRecord.LandItemValue> 
    {
        public LandItemTableRecord() : base("LandItem")
        {
        
        }
        /// <summary>
        /// Direct access to the key property 'LandId'.
        /// </summary>
        public virtual BigInteger LandId => Keys.LandId;
        /// <summary>
        /// Direct access to the key property 'X'.
        /// </summary>
        public virtual BigInteger X => Keys.X;
        /// <summary>
        /// Direct access to the key property 'Y'.
        /// </summary>
        public virtual BigInteger Y => Keys.Y;
        /// <summary>
        /// Direct access to the key property 'Z'.
        /// </summary>
        public virtual BigInteger Z => Keys.Z;
        /// <summary>
        /// Direct access to the value property 'ItemId'.
        /// </summary>
        public virtual BigInteger ItemId => Values.ItemId;
        /// <summary>
        /// Direct access to the value property 'PlacementTime'.
        /// </summary>
        public virtual BigInteger PlacementTime => Values.PlacementTime;
        /// <summary>
        /// Direct access to the value property 'DynamicUnlockTimes'.
        /// </summary>
        public virtual BigInteger DynamicUnlockTimes => Values.DynamicUnlockTimes;
        /// <summary>
        /// Direct access to the value property 'DynamicTimeoutTimes'.
        /// </summary>
        public virtual BigInteger DynamicTimeoutTimes => Values.DynamicTimeoutTimes;
        /// <summary>
        /// Direct access to the value property 'IsRotated'.
        /// </summary>
        public virtual bool IsRotated => Values.IsRotated;

        public partial class LandItemKey
        {
            [Parameter("uint256", "landId", 1)]
            public virtual BigInteger LandId { get; set; }
            [Parameter("uint256", "x", 2)]
            public virtual BigInteger X { get; set; }
            [Parameter("uint256", "y", 3)]
            public virtual BigInteger Y { get; set; }
            [Parameter("uint256", "z", 4)]
            public virtual BigInteger Z { get; set; }
        }

        public partial class LandItemValue
        {
            [Parameter("uint256", "itemId", 1)]
            public virtual BigInteger ItemId { get; set; }
            [Parameter("uint256", "placementTime", 2)]
            public virtual BigInteger PlacementTime { get; set; }
            [Parameter("uint256", "dynamicUnlockTimes", 3)]
            public virtual BigInteger DynamicUnlockTimes { get; set; }
            [Parameter("uint256", "dynamicTimeoutTimes", 4)]
            public virtual BigInteger DynamicTimeoutTimes { get; set; }
            [Parameter("bool", "isRotated", 5)]
            public virtual bool IsRotated { get; set; }          
        }
    }
}
