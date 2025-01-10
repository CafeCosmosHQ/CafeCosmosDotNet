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
    public partial class PlayerTotalEarnedTableService : TableService<PlayerTotalEarnedTableRecord, PlayerTotalEarnedTableRecord.PlayerTotalEarnedKey, PlayerTotalEarnedTableRecord.PlayerTotalEarnedValue>
    { 
        public PlayerTotalEarnedTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
        public virtual Task<PlayerTotalEarnedTableRecord> GetTableRecordAsync(BigInteger landId, BlockParameter blockParameter = null)
        {
            var _key = new PlayerTotalEarnedTableRecord.PlayerTotalEarnedKey();
            _key.LandId = landId;
            return GetTableRecordAsync(_key, blockParameter);
        }
        public virtual Task<string> SetRecordRequestAsync(BigInteger landId, BigInteger totalEarned, BigInteger totalSpent)
        {
            var _key = new PlayerTotalEarnedTableRecord.PlayerTotalEarnedKey();
            _key.LandId = landId;

            var _values = new PlayerTotalEarnedTableRecord.PlayerTotalEarnedValue();
            _values.TotalEarned = totalEarned;
            _values.TotalSpent = totalSpent;
            return SetRecordRequestAsync(_key, _values);
        }
        public virtual Task<TransactionReceipt> SetRecordRequestAndWaitForReceiptAsync(BigInteger landId, BigInteger totalEarned, BigInteger totalSpent)
        {
            var _key = new PlayerTotalEarnedTableRecord.PlayerTotalEarnedKey();
            _key.LandId = landId;

            var _values = new PlayerTotalEarnedTableRecord.PlayerTotalEarnedValue();
            _values.TotalEarned = totalEarned;
            _values.TotalSpent = totalSpent;
            return SetRecordRequestAndWaitForReceiptAsync(_key, _values);
        }
    }
    
    public partial class PlayerTotalEarnedTableRecord : TableRecord<PlayerTotalEarnedTableRecord.PlayerTotalEarnedKey, PlayerTotalEarnedTableRecord.PlayerTotalEarnedValue> 
    {
        public PlayerTotalEarnedTableRecord() : base("PlayerTotalEarned")
        {
        
        }
        /// <summary>
        /// Direct access to the key property 'LandId'.
        /// </summary>
        public virtual BigInteger LandId => Keys.LandId;
        /// <summary>
        /// Direct access to the value property 'TotalEarned'.
        /// </summary>
        public virtual BigInteger TotalEarned => Values.TotalEarned;
        /// <summary>
        /// Direct access to the value property 'TotalSpent'.
        /// </summary>
        public virtual BigInteger TotalSpent => Values.TotalSpent;

        public partial class PlayerTotalEarnedKey
        {
            [Parameter("uint256", "landId", 1)]
            public virtual BigInteger LandId { get; set; }
        }

        public partial class PlayerTotalEarnedValue
        {
            [Parameter("uint256", "totalEarned", 1)]
            public virtual BigInteger TotalEarned { get; set; }
            [Parameter("uint256", "totalSpent", 2)]
            public virtual BigInteger TotalSpent { get; set; }          
        }
    }
}
