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
    public partial class LevelRewardTableService : TableService<LevelRewardTableRecord, LevelRewardTableRecord.LevelRewardKey, LevelRewardTableRecord.LevelRewardValue>
    { 
        public LevelRewardTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
        public virtual Task<LevelRewardTableRecord> GetTableRecordAsync(BigInteger level, BlockParameter blockParameter = null)
        {
            var _key = new LevelRewardTableRecord.LevelRewardKey();
            _key.Level = level;
            return GetTableRecordAsync(_key, blockParameter);
        }
        public virtual Task<string> SetRecordRequestAsync(BigInteger level, BigInteger cumulativeXp, BigInteger tokens, List<BigInteger> items)
        {
            var _key = new LevelRewardTableRecord.LevelRewardKey();
            _key.Level = level;

            var _values = new LevelRewardTableRecord.LevelRewardValue();
            _values.CumulativeXp = cumulativeXp;
            _values.Tokens = tokens;
            _values.Items = items;
            return SetRecordRequestAsync(_key, _values);
        }
        public virtual Task<TransactionReceipt> SetRecordRequestAndWaitForReceiptAsync(BigInteger level, BigInteger cumulativeXp, BigInteger tokens, List<BigInteger> items)
        {
            var _key = new LevelRewardTableRecord.LevelRewardKey();
            _key.Level = level;

            var _values = new LevelRewardTableRecord.LevelRewardValue();
            _values.CumulativeXp = cumulativeXp;
            _values.Tokens = tokens;
            _values.Items = items;
            return SetRecordRequestAndWaitForReceiptAsync(_key, _values);
        }
    }
    
    public partial class LevelRewardTableRecord : TableRecord<LevelRewardTableRecord.LevelRewardKey, LevelRewardTableRecord.LevelRewardValue> 
    {
        public LevelRewardTableRecord() : base("LevelReward")
        {
        
        }
        /// <summary>
        /// Direct access to the key property 'Level'.
        /// </summary>
        public virtual BigInteger Level => Keys.Level;
        /// <summary>
        /// Direct access to the value property 'CumulativeXp'.
        /// </summary>
        public virtual BigInteger CumulativeXp => Values.CumulativeXp;
        /// <summary>
        /// Direct access to the value property 'Tokens'.
        /// </summary>
        public virtual BigInteger Tokens => Values.Tokens;
        /// <summary>
        /// Direct access to the value property 'Items'.
        /// </summary>
        public virtual List<BigInteger> Items => Values.Items;

        public partial class LevelRewardKey
        {
            [Parameter("uint256", "level", 1)]
            public virtual BigInteger Level { get; set; }
        }

        public partial class LevelRewardValue
        {
            [Parameter("uint256", "cumulativeXp", 1)]
            public virtual BigInteger CumulativeXp { get; set; }
            [Parameter("uint256", "tokens", 2)]
            public virtual BigInteger Tokens { get; set; }
            [Parameter("uint256[]", "items", 3)]
            public virtual List<BigInteger> Items { get; set; }          
        }
    }
}
