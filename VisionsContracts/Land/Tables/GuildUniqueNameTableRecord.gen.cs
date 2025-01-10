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
    public partial class GuildUniqueNameTableService : TableService<GuildUniqueNameTableRecord, GuildUniqueNameTableRecord.GuildUniqueNameKey, GuildUniqueNameTableRecord.GuildUniqueNameValue>
    { 
        public GuildUniqueNameTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
        public virtual Task<GuildUniqueNameTableRecord> GetTableRecordAsync(byte[] guildName, BlockParameter blockParameter = null)
        {
            var _key = new GuildUniqueNameTableRecord.GuildUniqueNameKey();
            _key.GuildName = guildName;
            return GetTableRecordAsync(_key, blockParameter);
        }
        public virtual Task<string> SetRecordRequestAsync(byte[] guildName, uint guildId, bool exists)
        {
            var _key = new GuildUniqueNameTableRecord.GuildUniqueNameKey();
            _key.GuildName = guildName;

            var _values = new GuildUniqueNameTableRecord.GuildUniqueNameValue();
            _values.GuildId = guildId;
            _values.Exists = exists;
            return SetRecordRequestAsync(_key, _values);
        }
        public virtual Task<TransactionReceipt> SetRecordRequestAndWaitForReceiptAsync(byte[] guildName, uint guildId, bool exists)
        {
            var _key = new GuildUniqueNameTableRecord.GuildUniqueNameKey();
            _key.GuildName = guildName;

            var _values = new GuildUniqueNameTableRecord.GuildUniqueNameValue();
            _values.GuildId = guildId;
            _values.Exists = exists;
            return SetRecordRequestAndWaitForReceiptAsync(_key, _values);
        }
    }
    
    public partial class GuildUniqueNameTableRecord : TableRecord<GuildUniqueNameTableRecord.GuildUniqueNameKey, GuildUniqueNameTableRecord.GuildUniqueNameValue> 
    {
        public GuildUniqueNameTableRecord() : base("GuildUniqueName")
        {
        
        }
        /// <summary>
        /// Direct access to the key property 'GuildName'.
        /// </summary>
        public virtual byte[] GuildName => Keys.GuildName;
        /// <summary>
        /// Direct access to the value property 'GuildId'.
        /// </summary>
        public virtual uint GuildId => Values.GuildId;
        /// <summary>
        /// Direct access to the value property 'Exists'.
        /// </summary>
        public virtual bool Exists => Values.Exists;

        public partial class GuildUniqueNameKey
        {
            [Parameter("bytes32", "guildName", 1)]
            public virtual byte[] GuildName { get; set; }
        }

        public partial class GuildUniqueNameValue
        {
            [Parameter("uint32", "guildId", 1)]
            public virtual uint GuildId { get; set; }
            [Parameter("bool", "exists", 2)]
            public virtual bool Exists { get; set; }          
        }
    }
}
