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
    public partial class CraftingRecipeTableService : TableService<CraftingRecipeTableRecord, CraftingRecipeTableRecord.CraftingRecipeKey, CraftingRecipeTableRecord.CraftingRecipeValue>
    { 
        public CraftingRecipeTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
        public virtual Task<CraftingRecipeTableRecord> GetTableRecordAsync(BigInteger output, BlockParameter blockParameter = null)
        {
            var _key = new CraftingRecipeTableRecord.CraftingRecipeKey();
            _key.Output = output;
            return GetTableRecordAsync(_key, blockParameter);
        }
        public virtual Task<string> SetRecordRequestAsync(BigInteger output, BigInteger outputQuantity, BigInteger xp, bool exists, List<BigInteger> inputs, List<BigInteger> quantities)
        {
            var _key = new CraftingRecipeTableRecord.CraftingRecipeKey();
            _key.Output = output;

            var _values = new CraftingRecipeTableRecord.CraftingRecipeValue();
            _values.OutputQuantity = outputQuantity;
            _values.Xp = xp;
            _values.Exists = exists;
            _values.Inputs = inputs;
            _values.Quantities = quantities;
            return SetRecordRequestAsync(_key, _values);
        }
        public virtual Task<TransactionReceipt> SetRecordRequestAndWaitForReceiptAsync(BigInteger output, BigInteger outputQuantity, BigInteger xp, bool exists, List<BigInteger> inputs, List<BigInteger> quantities)
        {
            var _key = new CraftingRecipeTableRecord.CraftingRecipeKey();
            _key.Output = output;

            var _values = new CraftingRecipeTableRecord.CraftingRecipeValue();
            _values.OutputQuantity = outputQuantity;
            _values.Xp = xp;
            _values.Exists = exists;
            _values.Inputs = inputs;
            _values.Quantities = quantities;
            return SetRecordRequestAndWaitForReceiptAsync(_key, _values);
        }
    }
    
    public partial class CraftingRecipeTableRecord : TableRecord<CraftingRecipeTableRecord.CraftingRecipeKey, CraftingRecipeTableRecord.CraftingRecipeValue> 
    {
        public CraftingRecipeTableRecord() : base("CraftingRecipe")
        {
        
        }
        /// <summary>
        /// Direct access to the key property 'Output'.
        /// </summary>
        public virtual BigInteger Output => Keys.Output;
        /// <summary>
        /// Direct access to the value property 'OutputQuantity'.
        /// </summary>
        public virtual BigInteger OutputQuantity => Values.OutputQuantity;
        /// <summary>
        /// Direct access to the value property 'Xp'.
        /// </summary>
        public virtual BigInteger Xp => Values.Xp;
        /// <summary>
        /// Direct access to the value property 'Exists'.
        /// </summary>
        public virtual bool Exists => Values.Exists;
        /// <summary>
        /// Direct access to the value property 'Inputs'.
        /// </summary>
        public virtual List<BigInteger> Inputs => Values.Inputs;
        /// <summary>
        /// Direct access to the value property 'Quantities'.
        /// </summary>
        public virtual List<BigInteger> Quantities => Values.Quantities;

        public partial class CraftingRecipeKey
        {
            [Parameter("uint256", "output", 1)]
            public virtual BigInteger Output { get; set; }
        }

        public partial class CraftingRecipeValue
        {
            [Parameter("uint256", "outputQuantity", 1)]
            public virtual BigInteger OutputQuantity { get; set; }
            [Parameter("uint256", "xp", 2)]
            public virtual BigInteger Xp { get; set; }
            [Parameter("bool", "exists", 3)]
            public virtual bool Exists { get; set; }
            [Parameter("uint256[]", "inputs", 4)]
            public virtual List<BigInteger> Inputs { get; set; }
            [Parameter("uint256[]", "quantities", 5)]
            public virtual List<BigInteger> Quantities { get; set; }          
        }
    }
}
