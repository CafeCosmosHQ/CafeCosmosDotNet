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
    public partial class TransformationCategoriesTableService : TableService<TransformationCategoriesTableRecord, TransformationCategoriesTableRecord.TransformationCategoriesKey, TransformationCategoriesTableRecord.TransformationCategoriesValue>
    { 
        public TransformationCategoriesTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
        public virtual Task<TransformationCategoriesTableRecord> GetTableRecordAsync(BigInteger @base, BigInteger input, BlockParameter blockParameter = null)
        {
            var _key = new TransformationCategoriesTableRecord.TransformationCategoriesKey();
            _key.Base = @base;
            _key.Input = input;
            return GetTableRecordAsync(_key, blockParameter);
        }
        public virtual Task<string> SetRecordRequestAsync(BigInteger @base, BigInteger input, List<BigInteger> categories)
        {
            var _key = new TransformationCategoriesTableRecord.TransformationCategoriesKey();
            _key.Base = @base;
            _key.Input = input;

            var _values = new TransformationCategoriesTableRecord.TransformationCategoriesValue();
            _values.Categories = categories;
            return SetRecordRequestAsync(_key, _values);
        }
        public virtual Task<TransactionReceipt> SetRecordRequestAndWaitForReceiptAsync(BigInteger @base, BigInteger input, List<BigInteger> categories)
        {
            var _key = new TransformationCategoriesTableRecord.TransformationCategoriesKey();
            _key.Base = @base;
            _key.Input = input;

            var _values = new TransformationCategoriesTableRecord.TransformationCategoriesValue();
            _values.Categories = categories;
            return SetRecordRequestAndWaitForReceiptAsync(_key, _values);
        }
    }
    
    public partial class TransformationCategoriesTableRecord : TableRecord<TransformationCategoriesTableRecord.TransformationCategoriesKey, TransformationCategoriesTableRecord.TransformationCategoriesValue> 
    {
        public TransformationCategoriesTableRecord() : base("TransformationCategories")
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
        /// Direct access to the value property 'Categories'.
        /// </summary>
        public virtual List<BigInteger> Categories => Values.Categories;

        public partial class TransformationCategoriesKey
        {
            [Parameter("uint256", "base", 1)]
            public virtual BigInteger Base { get; set; }
            [Parameter("uint256", "input", 2)]
            public virtual BigInteger Input { get; set; }
        }

        public partial class TransformationCategoriesValue
        {
            [Parameter("uint256[]", "categories", 1)]
            public virtual List<BigInteger> Categories { get; set; }          
        }
    }
}
