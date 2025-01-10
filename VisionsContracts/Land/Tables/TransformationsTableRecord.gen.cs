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
    public partial class TransformationsTableService : TableService<TransformationsTableRecord, TransformationsTableRecord.TransformationsKey, TransformationsTableRecord.TransformationsValue>
    { 
        public TransformationsTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
        public virtual Task<TransformationsTableRecord> GetTableRecordAsync(BigInteger @base, BigInteger input, BlockParameter blockParameter = null)
        {
            var _key = new TransformationsTableRecord.TransformationsKey();
            _key.Base = @base;
            _key.Input = input;
            return GetTableRecordAsync(_key, blockParameter);
        }
        public virtual Task<string> SetRecordRequestAsync(BigInteger @base, BigInteger input, BigInteger next, BigInteger yield, BigInteger inputNext, BigInteger yieldQuantity, BigInteger unlockTime, BigInteger timeout, BigInteger timeoutYield, BigInteger timeoutYieldQuantity, BigInteger timeoutNext, bool isRecipe, bool isWaterCollection, BigInteger xp, bool exists)
        {
            var _key = new TransformationsTableRecord.TransformationsKey();
            _key.Base = @base;
            _key.Input = input;

            var _values = new TransformationsTableRecord.TransformationsValue();
            _values.Next = next;
            _values.Yield = yield;
            _values.InputNext = inputNext;
            _values.YieldQuantity = yieldQuantity;
            _values.UnlockTime = unlockTime;
            _values.Timeout = timeout;
            _values.TimeoutYield = timeoutYield;
            _values.TimeoutYieldQuantity = timeoutYieldQuantity;
            _values.TimeoutNext = timeoutNext;
            _values.IsRecipe = isRecipe;
            _values.IsWaterCollection = isWaterCollection;
            _values.Xp = xp;
            _values.Exists = exists;
            return SetRecordRequestAsync(_key, _values);
        }
        public virtual Task<TransactionReceipt> SetRecordRequestAndWaitForReceiptAsync(BigInteger @base, BigInteger input, BigInteger next, BigInteger yield, BigInteger inputNext, BigInteger yieldQuantity, BigInteger unlockTime, BigInteger timeout, BigInteger timeoutYield, BigInteger timeoutYieldQuantity, BigInteger timeoutNext, bool isRecipe, bool isWaterCollection, BigInteger xp, bool exists)
        {
            var _key = new TransformationsTableRecord.TransformationsKey();
            _key.Base = @base;
            _key.Input = input;

            var _values = new TransformationsTableRecord.TransformationsValue();
            _values.Next = next;
            _values.Yield = yield;
            _values.InputNext = inputNext;
            _values.YieldQuantity = yieldQuantity;
            _values.UnlockTime = unlockTime;
            _values.Timeout = timeout;
            _values.TimeoutYield = timeoutYield;
            _values.TimeoutYieldQuantity = timeoutYieldQuantity;
            _values.TimeoutNext = timeoutNext;
            _values.IsRecipe = isRecipe;
            _values.IsWaterCollection = isWaterCollection;
            _values.Xp = xp;
            _values.Exists = exists;
            return SetRecordRequestAndWaitForReceiptAsync(_key, _values);
        }
    }
    
    public partial class TransformationsTableRecord : TableRecord<TransformationsTableRecord.TransformationsKey, TransformationsTableRecord.TransformationsValue> 
    {
        public TransformationsTableRecord() : base("Transformations")
        {
        
        }
        /// <summary>
        /// Direct access to the key property 'Base'.
        /// </summary>
        public virtual BigInteger Base => Keys.Base;
        /// <summary>
        /// Direct access to the key property 'Input'.
        /// </summary>
        public virtual BigInteger Input => Keys.Input;
        /// <summary>
        /// Direct access to the value property 'Next'.
        /// </summary>
        public virtual BigInteger Next => Values.Next;
        /// <summary>
        /// Direct access to the value property 'Yield'.
        /// </summary>
        public virtual BigInteger Yield => Values.Yield;
        /// <summary>
        /// Direct access to the value property 'InputNext'.
        /// </summary>
        public virtual BigInteger InputNext => Values.InputNext;
        /// <summary>
        /// Direct access to the value property 'YieldQuantity'.
        /// </summary>
        public virtual BigInteger YieldQuantity => Values.YieldQuantity;
        /// <summary>
        /// Direct access to the value property 'UnlockTime'.
        /// </summary>
        public virtual BigInteger UnlockTime => Values.UnlockTime;
        /// <summary>
        /// Direct access to the value property 'Timeout'.
        /// </summary>
        public virtual BigInteger Timeout => Values.Timeout;
        /// <summary>
        /// Direct access to the value property 'TimeoutYield'.
        /// </summary>
        public virtual BigInteger TimeoutYield => Values.TimeoutYield;
        /// <summary>
        /// Direct access to the value property 'TimeoutYieldQuantity'.
        /// </summary>
        public virtual BigInteger TimeoutYieldQuantity => Values.TimeoutYieldQuantity;
        /// <summary>
        /// Direct access to the value property 'TimeoutNext'.
        /// </summary>
        public virtual BigInteger TimeoutNext => Values.TimeoutNext;
        /// <summary>
        /// Direct access to the value property 'IsRecipe'.
        /// </summary>
        public virtual bool IsRecipe => Values.IsRecipe;
        /// <summary>
        /// Direct access to the value property 'IsWaterCollection'.
        /// </summary>
        public virtual bool IsWaterCollection => Values.IsWaterCollection;
        /// <summary>
        /// Direct access to the value property 'Xp'.
        /// </summary>
        public virtual BigInteger Xp => Values.Xp;
        /// <summary>
        /// Direct access to the value property 'Exists'.
        /// </summary>
        public virtual bool Exists => Values.Exists;

        public partial class TransformationsKey
        {
            [Parameter("uint256", "base", 1)]
            public virtual BigInteger Base { get; set; }
            [Parameter("uint256", "input", 2)]
            public virtual BigInteger Input { get; set; }
        }

        public partial class TransformationsValue
        {
            [Parameter("uint256", "next", 1)]
            public virtual BigInteger Next { get; set; }
            [Parameter("uint256", "yield", 2)]
            public virtual BigInteger Yield { get; set; }
            [Parameter("uint256", "inputNext", 3)]
            public virtual BigInteger InputNext { get; set; }
            [Parameter("uint256", "yieldQuantity", 4)]
            public virtual BigInteger YieldQuantity { get; set; }
            [Parameter("uint256", "unlockTime", 5)]
            public virtual BigInteger UnlockTime { get; set; }
            [Parameter("uint256", "timeout", 6)]
            public virtual BigInteger Timeout { get; set; }
            [Parameter("uint256", "timeoutYield", 7)]
            public virtual BigInteger TimeoutYield { get; set; }
            [Parameter("uint256", "timeoutYieldQuantity", 8)]
            public virtual BigInteger TimeoutYieldQuantity { get; set; }
            [Parameter("uint256", "timeoutNext", 9)]
            public virtual BigInteger TimeoutNext { get; set; }
            [Parameter("bool", "isRecipe", 10)]
            public virtual bool IsRecipe { get; set; }
            [Parameter("bool", "isWaterCollection", 11)]
            public virtual bool IsWaterCollection { get; set; }
            [Parameter("uint256", "xp", 12)]
            public virtual BigInteger Xp { get; set; }
            [Parameter("bool", "exists", 13)]
            public virtual bool Exists { get; set; }          
        }
    }
}
