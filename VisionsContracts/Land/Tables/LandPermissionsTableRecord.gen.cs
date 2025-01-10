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
    public partial class LandPermissionsTableService : TableService<LandPermissionsTableRecord, LandPermissionsTableRecord.LandPermissionsKey, LandPermissionsTableRecord.LandPermissionsValue>
    { 
        public LandPermissionsTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
        public virtual Task<LandPermissionsTableRecord> GetTableRecordAsync(string owner, BigInteger landId, string @operator, BlockParameter blockParameter = null)
        {
            var _key = new LandPermissionsTableRecord.LandPermissionsKey();
            _key.Owner = owner;
            _key.LandId = landId;
            _key.Operator = @operator;
            return GetTableRecordAsync(_key, blockParameter);
        }
        public virtual Task<string> SetRecordRequestAsync(string owner, BigInteger landId, string @operator, bool isOperator)
        {
            var _key = new LandPermissionsTableRecord.LandPermissionsKey();
            _key.Owner = owner;
            _key.LandId = landId;
            _key.Operator = @operator;

            var _values = new LandPermissionsTableRecord.LandPermissionsValue();
            _values.IsOperator = isOperator;
            return SetRecordRequestAsync(_key, _values);
        }
        public virtual Task<TransactionReceipt> SetRecordRequestAndWaitForReceiptAsync(string owner, BigInteger landId, string @operator, bool isOperator)
        {
            var _key = new LandPermissionsTableRecord.LandPermissionsKey();
            _key.Owner = owner;
            _key.LandId = landId;
            _key.Operator = @operator;

            var _values = new LandPermissionsTableRecord.LandPermissionsValue();
            _values.IsOperator = isOperator;
            return SetRecordRequestAndWaitForReceiptAsync(_key, _values);
        }
    }
    
    public partial class LandPermissionsTableRecord : TableRecord<LandPermissionsTableRecord.LandPermissionsKey, LandPermissionsTableRecord.LandPermissionsValue> 
    {
        public LandPermissionsTableRecord() : base("LandPermissions")
        {
        
        }
        /// <summary>
        /// Direct access to the key property 'Owner'.
        /// </summary>
        public virtual string Owner => Keys.Owner;
        /// <summary>
        /// Direct access to the key property 'LandId'.
        /// </summary>
        public virtual BigInteger LandId => Keys.LandId;
        /// <summary>
        /// Direct access to the key property 'Operator'.
        /// </summary>
        public virtual string Operator => Keys.Operator;
        /// <summary>
        /// Direct access to the value property 'IsOperator'.
        /// </summary>
        public virtual bool IsOperator => Values.IsOperator;

        public partial class LandPermissionsKey
        {
            [Parameter("address", "owner", 1)]
            public virtual string Owner { get; set; }
            [Parameter("uint256", "landId", 2)]
            public virtual BigInteger LandId { get; set; }
            [Parameter("address", "operator", 3)]
            public virtual string Operator { get; set; }
        }

        public partial class LandPermissionsValue
        {
            [Parameter("bool", "isOperator", 1)]
            public virtual bool IsOperator { get; set; }          
        }
    }
}
