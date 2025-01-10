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
    public partial class GuildTableService : TableService<GuildTableRecord, GuildTableRecord.GuildKey, GuildTableRecord.GuildValue>
    { 
        public GuildTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
        public virtual Task<GuildTableRecord> GetTableRecordAsync(uint guildId, BlockParameter blockParameter = null)
        {
            var _key = new GuildTableRecord.GuildKey();
            _key.GuildId = guildId;
            return GetTableRecordAsync(_key, blockParameter);
        }
        public virtual Task<string> SetRecordRequestAsync(uint guildId, BigInteger guildAdmin, bool exists, string guildName, List<BigInteger> guildMembers)
        {
            var _key = new GuildTableRecord.GuildKey();
            _key.GuildId = guildId;

            var _values = new GuildTableRecord.GuildValue();
            _values.GuildAdmin = guildAdmin;
            _values.Exists = exists;
            _values.GuildName = guildName;
            _values.GuildMembers = guildMembers;
            return SetRecordRequestAsync(_key, _values);
        }
        public virtual Task<TransactionReceipt> SetRecordRequestAndWaitForReceiptAsync(uint guildId, BigInteger guildAdmin, bool exists, string guildName, List<BigInteger> guildMembers)
        {
            var _key = new GuildTableRecord.GuildKey();
            _key.GuildId = guildId;

            var _values = new GuildTableRecord.GuildValue();
            _values.GuildAdmin = guildAdmin;
            _values.Exists = exists;
            _values.GuildName = guildName;
            _values.GuildMembers = guildMembers;
            return SetRecordRequestAndWaitForReceiptAsync(_key, _values);
        }
    }
    
    public partial class GuildTableRecord : TableRecord<GuildTableRecord.GuildKey, GuildTableRecord.GuildValue> 
    {
        public GuildTableRecord() : base("Guild")
        {
        
        }
        /// <summary>
        /// Direct access to the key property 'GuildId'.
        /// </summary>
        public virtual uint GuildId => Keys.GuildId;
        /// <summary>
        /// Direct access to the value property 'GuildAdmin'.
        /// </summary>
        public virtual BigInteger GuildAdmin => Values.GuildAdmin;
        /// <summary>
        /// Direct access to the value property 'Exists'.
        /// </summary>
        public virtual bool Exists => Values.Exists;
        /// <summary>
        /// Direct access to the value property 'GuildName'.
        /// </summary>
        public virtual string GuildName => Values.GuildName;
        /// <summary>
        /// Direct access to the value property 'GuildMembers'.
        /// </summary>
        public virtual List<BigInteger> GuildMembers => Values.GuildMembers;

        public partial class GuildKey
        {
            [Parameter("uint32", "guildId", 1)]
            public virtual uint GuildId { get; set; }
        }

        public partial class GuildValue
        {
            [Parameter("uint256", "guildAdmin", 1)]
            public virtual BigInteger GuildAdmin { get; set; }
            [Parameter("bool", "exists", 2)]
            public virtual bool Exists { get; set; }
            [Parameter("string", "guildName", 3)]
            public virtual string GuildName { get; set; }
            [Parameter("uint256[]", "guildMembers", 4)]
            public virtual List<BigInteger> GuildMembers { get; set; }          
        }
    }
}
