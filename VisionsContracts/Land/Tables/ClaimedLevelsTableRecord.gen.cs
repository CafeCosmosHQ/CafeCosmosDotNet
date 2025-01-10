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
    public partial class ClaimedLevelsTableService : TableService<ClaimedLevelsTableRecord, ClaimedLevelsTableRecord.ClaimedLevelsKey, ClaimedLevelsTableRecord.ClaimedLevelsValue>
    { 
        public ClaimedLevelsTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
        public virtual Task<ClaimedLevelsTableRecord> GetTableRecordAsync(BigInteger level, BigInteger landId, BlockParameter blockParameter = null)
        {
            var _key = new ClaimedLevelsTableRecord.ClaimedLevelsKey();
            _key.Level = level;
            _key.LandId = landId;
            return GetTableRecordAsync(_key, blockParameter);
        }
        public virtual Task<string> SetRecordRequestAsync(BigInteger level, BigInteger landId, bool claimed)
        {
            var _key = new ClaimedLevelsTableRecord.ClaimedLevelsKey();
            _key.Level = level;
            _key.LandId = landId;

            var _values = new ClaimedLevelsTableRecord.ClaimedLevelsValue();
            _values.Claimed = claimed;
            return SetRecordRequestAsync(_key, _values);
        }
        public virtual Task<TransactionReceipt> SetRecordRequestAndWaitForReceiptAsync(BigInteger level, BigInteger landId, bool claimed)
        {
            var _key = new ClaimedLevelsTableRecord.ClaimedLevelsKey();
            _key.Level = level;
            _key.LandId = landId;

            var _values = new ClaimedLevelsTableRecord.ClaimedLevelsValue();
            _values.Claimed = claimed;
            return SetRecordRequestAndWaitForReceiptAsync(_key, _values);
        }
    }
    
    public partial class ClaimedLevelsTableRecord : TableRecord<ClaimedLevelsTableRecord.ClaimedLevelsKey, ClaimedLevelsTableRecord.ClaimedLevelsValue> 
    {
        public ClaimedLevelsTableRecord() : base("ClaimedLevels")
        {
        
        }
        /// <summary>
        /// Direct access to the key property 'Level'.
        /// </summary>
        public virtual BigInteger Level => Keys.Level;
        /// <summary>
        /// Direct access to the key property 'LandId'.
        /// </summary>
        public virtual BigInteger LandId => Keys.LandId;
        /// <summary>
        /// Direct access to the value property 'Claimed'.
        /// </summary>
        public virtual bool Claimed => Values.Claimed;

        public partial class ClaimedLevelsKey
        {
            [Parameter("uint256", "level", 1)]
            public virtual BigInteger Level { get; set; }
            [Parameter("uint256", "landId", 2)]
            public virtual BigInteger LandId { get; set; }
        }

        public partial class ClaimedLevelsValue
        {
            [Parameter("bool", "claimed", 1)]
            public virtual bool Claimed { get; set; }          
        }
    }
}
