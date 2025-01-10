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
    public partial class LandItemCookingStateTableService : TableService<LandItemCookingStateTableRecord, LandItemCookingStateTableRecord.LandItemCookingStateKey, LandItemCookingStateTableRecord.LandItemCookingStateValue>
    { 
        public LandItemCookingStateTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
        public virtual Task<LandItemCookingStateTableRecord> GetTableRecordAsync(BigInteger landId, BigInteger x, BigInteger y, BigInteger z, BlockParameter blockParameter = null)
        {
            var _key = new LandItemCookingStateTableRecord.LandItemCookingStateKey();
            _key.LandId = landId;
            _key.X = x;
            _key.Y = y;
            _key.Z = z;
            return GetTableRecordAsync(_key, blockParameter);
        }
        public virtual Task<string> SetRecordRequestAsync(BigInteger landId, BigInteger x, BigInteger y, BigInteger z, BigInteger yieldShares, BigInteger collateral, BigInteger recipeId, BigInteger stoveId)
        {
            var _key = new LandItemCookingStateTableRecord.LandItemCookingStateKey();
            _key.LandId = landId;
            _key.X = x;
            _key.Y = y;
            _key.Z = z;

            var _values = new LandItemCookingStateTableRecord.LandItemCookingStateValue();
            _values.YieldShares = yieldShares;
            _values.Collateral = collateral;
            _values.RecipeId = recipeId;
            _values.StoveId = stoveId;
            return SetRecordRequestAsync(_key, _values);
        }
        public virtual Task<TransactionReceipt> SetRecordRequestAndWaitForReceiptAsync(BigInteger landId, BigInteger x, BigInteger y, BigInteger z, BigInteger yieldShares, BigInteger collateral, BigInteger recipeId, BigInteger stoveId)
        {
            var _key = new LandItemCookingStateTableRecord.LandItemCookingStateKey();
            _key.LandId = landId;
            _key.X = x;
            _key.Y = y;
            _key.Z = z;

            var _values = new LandItemCookingStateTableRecord.LandItemCookingStateValue();
            _values.YieldShares = yieldShares;
            _values.Collateral = collateral;
            _values.RecipeId = recipeId;
            _values.StoveId = stoveId;
            return SetRecordRequestAndWaitForReceiptAsync(_key, _values);
        }
    }
    
    public partial class LandItemCookingStateTableRecord : TableRecord<LandItemCookingStateTableRecord.LandItemCookingStateKey, LandItemCookingStateTableRecord.LandItemCookingStateValue> 
    {
        public LandItemCookingStateTableRecord() : base("LandItemCookingState")
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
        /// Direct access to the value property 'YieldShares'.
        /// </summary>
        public virtual BigInteger YieldShares => Values.YieldShares;
        /// <summary>
        /// Direct access to the value property 'Collateral'.
        /// </summary>
        public virtual BigInteger Collateral => Values.Collateral;
        /// <summary>
        /// Direct access to the value property 'RecipeId'.
        /// </summary>
        public virtual BigInteger RecipeId => Values.RecipeId;
        /// <summary>
        /// Direct access to the value property 'StoveId'.
        /// </summary>
        public virtual BigInteger StoveId => Values.StoveId;

        public partial class LandItemCookingStateKey
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

        public partial class LandItemCookingStateValue
        {
            [Parameter("uint256", "yieldShares", 1)]
            public virtual BigInteger YieldShares { get; set; }
            [Parameter("uint256", "collateral", 2)]
            public virtual BigInteger Collateral { get; set; }
            [Parameter("uint256", "recipeId", 3)]
            public virtual BigInteger RecipeId { get; set; }
            [Parameter("uint256", "stoveId", 4)]
            public virtual BigInteger StoveId { get; set; }          
        }
    }
}
