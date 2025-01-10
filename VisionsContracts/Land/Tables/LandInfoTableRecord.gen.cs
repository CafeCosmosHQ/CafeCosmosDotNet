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
    public partial class LandInfoTableService : TableService<LandInfoTableRecord, LandInfoTableRecord.LandInfoKey, LandInfoTableRecord.LandInfoValue>
    { 
        public LandInfoTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
        public virtual Task<LandInfoTableRecord> GetTableRecordAsync(BigInteger landId, BlockParameter blockParameter = null)
        {
            var _key = new LandInfoTableRecord.LandInfoKey();
            _key.LandId = landId;
            return GetTableRecordAsync(_key, blockParameter);
        }
        public virtual Task<string> SetRecordRequestAsync(BigInteger landId, BigInteger limitX, BigInteger limitY, BigInteger activeTables, BigInteger activeStoves, bool isInitialized, uint seed, BigInteger tokenBalance, BigInteger cumulativeXp, BigInteger lastLevelClaimed, List<BigInteger> yBound)
        {
            var _key = new LandInfoTableRecord.LandInfoKey();
            _key.LandId = landId;

            var _values = new LandInfoTableRecord.LandInfoValue();
            _values.LimitX = limitX;
            _values.LimitY = limitY;
            _values.ActiveTables = activeTables;
            _values.ActiveStoves = activeStoves;
            _values.IsInitialized = isInitialized;
            _values.Seed = seed;
            _values.TokenBalance = tokenBalance;
            _values.CumulativeXp = cumulativeXp;
            _values.LastLevelClaimed = lastLevelClaimed;
            _values.YBound = yBound;
            return SetRecordRequestAsync(_key, _values);
        }
        public virtual Task<TransactionReceipt> SetRecordRequestAndWaitForReceiptAsync(BigInteger landId, BigInteger limitX, BigInteger limitY, BigInteger activeTables, BigInteger activeStoves, bool isInitialized, uint seed, BigInteger tokenBalance, BigInteger cumulativeXp, BigInteger lastLevelClaimed, List<BigInteger> yBound)
        {
            var _key = new LandInfoTableRecord.LandInfoKey();
            _key.LandId = landId;

            var _values = new LandInfoTableRecord.LandInfoValue();
            _values.LimitX = limitX;
            _values.LimitY = limitY;
            _values.ActiveTables = activeTables;
            _values.ActiveStoves = activeStoves;
            _values.IsInitialized = isInitialized;
            _values.Seed = seed;
            _values.TokenBalance = tokenBalance;
            _values.CumulativeXp = cumulativeXp;
            _values.LastLevelClaimed = lastLevelClaimed;
            _values.YBound = yBound;
            return SetRecordRequestAndWaitForReceiptAsync(_key, _values);
        }
    }
    
    public partial class LandInfoTableRecord : TableRecord<LandInfoTableRecord.LandInfoKey, LandInfoTableRecord.LandInfoValue> 
    {
        public LandInfoTableRecord() : base("LandInfo")
        {
        
        }
        /// <summary>
        /// Direct access to the key property 'LandId'.
        /// </summary>
        public virtual BigInteger LandId => Keys.LandId;
        /// <summary>
        /// Direct access to the value property 'LimitX'.
        /// </summary>
        public virtual BigInteger LimitX => Values.LimitX;
        /// <summary>
        /// Direct access to the value property 'LimitY'.
        /// </summary>
        public virtual BigInteger LimitY => Values.LimitY;
        /// <summary>
        /// Direct access to the value property 'ActiveTables'.
        /// </summary>
        public virtual BigInteger ActiveTables => Values.ActiveTables;
        /// <summary>
        /// Direct access to the value property 'ActiveStoves'.
        /// </summary>
        public virtual BigInteger ActiveStoves => Values.ActiveStoves;
        /// <summary>
        /// Direct access to the value property 'IsInitialized'.
        /// </summary>
        public virtual bool IsInitialized => Values.IsInitialized;
        /// <summary>
        /// Direct access to the value property 'Seed'.
        /// </summary>
        public virtual uint Seed => Values.Seed;
        /// <summary>
        /// Direct access to the value property 'TokenBalance'.
        /// </summary>
        public virtual BigInteger TokenBalance => Values.TokenBalance;
        /// <summary>
        /// Direct access to the value property 'CumulativeXp'.
        /// </summary>
        public virtual BigInteger CumulativeXp => Values.CumulativeXp;
        /// <summary>
        /// Direct access to the value property 'LastLevelClaimed'.
        /// </summary>
        public virtual BigInteger LastLevelClaimed => Values.LastLevelClaimed;
        /// <summary>
        /// Direct access to the value property 'YBound'.
        /// </summary>
        public virtual List<BigInteger> YBound => Values.YBound;

        public partial class LandInfoKey
        {
            [Parameter("uint256", "landId", 1)]
            public virtual BigInteger LandId { get; set; }
        }

        public partial class LandInfoValue
        {
            [Parameter("uint256", "limitX", 1)]
            public virtual BigInteger LimitX { get; set; }
            [Parameter("uint256", "limitY", 2)]
            public virtual BigInteger LimitY { get; set; }
            [Parameter("uint256", "activeTables", 3)]
            public virtual BigInteger ActiveTables { get; set; }
            [Parameter("uint256", "activeStoves", 4)]
            public virtual BigInteger ActiveStoves { get; set; }
            [Parameter("bool", "isInitialized", 5)]
            public virtual bool IsInitialized { get; set; }
            [Parameter("uint32", "seed", 6)]
            public virtual uint Seed { get; set; }
            [Parameter("uint256", "tokenBalance", 7)]
            public virtual BigInteger TokenBalance { get; set; }
            [Parameter("uint256", "cumulativeXp", 8)]
            public virtual BigInteger CumulativeXp { get; set; }
            [Parameter("uint256", "lastLevelClaimed", 9)]
            public virtual BigInteger LastLevelClaimed { get; set; }
            [Parameter("uint256[]", "yBound", 10)]
            public virtual List<BigInteger> YBound { get; set; }          
        }
    }
}
