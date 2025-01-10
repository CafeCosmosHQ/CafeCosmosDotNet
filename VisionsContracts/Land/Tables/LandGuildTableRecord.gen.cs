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
    public partial class LandGuildTableService : TableService<LandGuildTableRecord, LandGuildTableRecord.LandGuildKey, LandGuildTableRecord.LandGuildValue>
    { 
        public LandGuildTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
        public virtual Task<LandGuildTableRecord> GetTableRecordAsync(BigInteger landId, BlockParameter blockParameter = null)
        {
            var _key = new LandGuildTableRecord.LandGuildKey();
            _key.LandId = landId;
            return GetTableRecordAsync(_key, blockParameter);
        }
        public virtual Task<string> SetRecordRequestAsync(BigInteger landId, uint guildId)
        {
            var _key = new LandGuildTableRecord.LandGuildKey();
            _key.LandId = landId;

            var _values = new LandGuildTableRecord.LandGuildValue();
            _values.GuildId = guildId;
            return SetRecordRequestAsync(_key, _values);
        }
        public virtual Task<TransactionReceipt> SetRecordRequestAndWaitForReceiptAsync(BigInteger landId, uint guildId)
        {
            var _key = new LandGuildTableRecord.LandGuildKey();
            _key.LandId = landId;

            var _values = new LandGuildTableRecord.LandGuildValue();
            _values.GuildId = guildId;
            return SetRecordRequestAndWaitForReceiptAsync(_key, _values);
        }
    }
    
    public partial class LandGuildTableRecord : TableRecord<LandGuildTableRecord.LandGuildKey, LandGuildTableRecord.LandGuildValue> 
    {
        public LandGuildTableRecord() : base("LandGuild")
        {
        
        }
        /// <summary>
        /// Direct access to the key property 'LandId'.
        /// </summary>
        public virtual BigInteger LandId => Keys.LandId;
        /// <summary>
        /// Direct access to the value property 'GuildId'.
        /// </summary>
        public virtual uint GuildId => Values.GuildId;

        public partial class LandGuildKey
        {
            [Parameter("uint256", "landId", 1)]
            public virtual BigInteger LandId { get; set; }
        }

        public partial class LandGuildValue
        {
            [Parameter("uint32", "guildId", 1)]
            public virtual uint GuildId { get; set; }          
        }
    }
}
