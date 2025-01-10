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
    public partial class LandCellTableService : TableService<LandCellTableRecord, LandCellTableRecord.LandCellKey, LandCellTableRecord.LandCellValue>
    { 
        public LandCellTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
        public virtual Task<LandCellTableRecord> GetTableRecordAsync(BigInteger landId, BigInteger x, BigInteger y, BlockParameter blockParameter = null)
        {
            var _key = new LandCellTableRecord.LandCellKey();
            _key.LandId = landId;
            _key.X = x;
            _key.Y = y;
            return GetTableRecordAsync(_key, blockParameter);
        }
        public virtual Task<string> SetRecordRequestAsync(BigInteger landId, BigInteger x, BigInteger y, ushort zItemCount)
        {
            var _key = new LandCellTableRecord.LandCellKey();
            _key.LandId = landId;
            _key.X = x;
            _key.Y = y;

            var _values = new LandCellTableRecord.LandCellValue();
            _values.ZItemCount = zItemCount;
            return SetRecordRequestAsync(_key, _values);
        }
        public virtual Task<TransactionReceipt> SetRecordRequestAndWaitForReceiptAsync(BigInteger landId, BigInteger x, BigInteger y, ushort zItemCount)
        {
            var _key = new LandCellTableRecord.LandCellKey();
            _key.LandId = landId;
            _key.X = x;
            _key.Y = y;

            var _values = new LandCellTableRecord.LandCellValue();
            _values.ZItemCount = zItemCount;
            return SetRecordRequestAndWaitForReceiptAsync(_key, _values);
        }
    }
    
    public partial class LandCellTableRecord : TableRecord<LandCellTableRecord.LandCellKey, LandCellTableRecord.LandCellValue> 
    {
        public LandCellTableRecord() : base("LandCell")
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
        /// Direct access to the value property 'ZItemCount'.
        /// </summary>
        public virtual ushort ZItemCount => Values.ZItemCount;

        public partial class LandCellKey
        {
            [Parameter("uint256", "landId", 1)]
            public virtual BigInteger LandId { get; set; }
            [Parameter("uint256", "x", 2)]
            public virtual BigInteger X { get; set; }
            [Parameter("uint256", "y", 3)]
            public virtual BigInteger Y { get; set; }
        }

        public partial class LandCellValue
        {
            [Parameter("uint16", "zItemCount", 1)]
            public virtual ushort ZItemCount { get; set; }          
        }
    }
}
