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
    public partial class LandTablesAndChairsTableService : TableService<LandTablesAndChairsTableRecord, LandTablesAndChairsTableRecord.LandTablesAndChairsKey, LandTablesAndChairsTableRecord.LandTablesAndChairsValue>
    { 
        public LandTablesAndChairsTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
        public virtual Task<LandTablesAndChairsTableRecord> GetTableRecordAsync(BigInteger landId, BigInteger x, BigInteger y, BlockParameter blockParameter = null)
        {
            var _key = new LandTablesAndChairsTableRecord.LandTablesAndChairsKey();
            _key.LandId = landId;
            _key.X = x;
            _key.Y = y;
            return GetTableRecordAsync(_key, blockParameter);
        }
        public virtual Task<string> SetRecordRequestAsync(BigInteger landId, BigInteger x, BigInteger y, List<BigInteger> chairsOfTables, List<BigInteger> tablesOfChairs)
        {
            var _key = new LandTablesAndChairsTableRecord.LandTablesAndChairsKey();
            _key.LandId = landId;
            _key.X = x;
            _key.Y = y;

            var _values = new LandTablesAndChairsTableRecord.LandTablesAndChairsValue();
            _values.ChairsOfTables = chairsOfTables;
            _values.TablesOfChairs = tablesOfChairs;
            return SetRecordRequestAsync(_key, _values);
        }
        public virtual Task<TransactionReceipt> SetRecordRequestAndWaitForReceiptAsync(BigInteger landId, BigInteger x, BigInteger y, List<BigInteger> chairsOfTables, List<BigInteger> tablesOfChairs)
        {
            var _key = new LandTablesAndChairsTableRecord.LandTablesAndChairsKey();
            _key.LandId = landId;
            _key.X = x;
            _key.Y = y;

            var _values = new LandTablesAndChairsTableRecord.LandTablesAndChairsValue();
            _values.ChairsOfTables = chairsOfTables;
            _values.TablesOfChairs = tablesOfChairs;
            return SetRecordRequestAndWaitForReceiptAsync(_key, _values);
        }
    }
    
    public partial class LandTablesAndChairsTableRecord : TableRecord<LandTablesAndChairsTableRecord.LandTablesAndChairsKey, LandTablesAndChairsTableRecord.LandTablesAndChairsValue> 
    {
        public LandTablesAndChairsTableRecord() : base("LandTablesAndChairs")
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
        /// Direct access to the value property 'ChairsOfTables'.
        /// </summary>
        public virtual List<BigInteger> ChairsOfTables => Values.ChairsOfTables;
        /// <summary>
        /// Direct access to the value property 'TablesOfChairs'.
        /// </summary>
        public virtual List<BigInteger> TablesOfChairs => Values.TablesOfChairs;

        public partial class LandTablesAndChairsKey
        {
            [Parameter("uint256", "landId", 1)]
            public virtual BigInteger LandId { get; set; }
            [Parameter("uint256", "x", 2)]
            public virtual BigInteger X { get; set; }
            [Parameter("uint256", "y", 3)]
            public virtual BigInteger Y { get; set; }
        }

        public partial class LandTablesAndChairsValue
        {
            [Parameter("uint256[3]", "chairsOfTables", 1)]
            public virtual List<BigInteger> ChairsOfTables { get; set; }
            [Parameter("uint256[3]", "tablesOfChairs", 2)]
            public virtual List<BigInteger> TablesOfChairs { get; set; }          
        }
    }
}
