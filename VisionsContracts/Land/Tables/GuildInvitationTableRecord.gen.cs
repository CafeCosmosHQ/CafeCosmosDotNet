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
    public partial class GuildInvitationTableService : TableService<GuildInvitationTableRecord, GuildInvitationTableRecord.GuildInvitationKey, GuildInvitationTableRecord.GuildInvitationValue>
    { 
        public GuildInvitationTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
        public virtual Task<GuildInvitationTableRecord> GetTableRecordAsync(BigInteger landId, uint guildId, BlockParameter blockParameter = null)
        {
            var _key = new GuildInvitationTableRecord.GuildInvitationKey();
            _key.LandId = landId;
            _key.GuildId = guildId;
            return GetTableRecordAsync(_key, blockParameter);
        }
        public virtual Task<string> SetRecordRequestAsync(BigInteger landId, uint guildId, bool isInvited)
        {
            var _key = new GuildInvitationTableRecord.GuildInvitationKey();
            _key.LandId = landId;
            _key.GuildId = guildId;

            var _values = new GuildInvitationTableRecord.GuildInvitationValue();
            _values.IsInvited = isInvited;
            return SetRecordRequestAsync(_key, _values);
        }
        public virtual Task<TransactionReceipt> SetRecordRequestAndWaitForReceiptAsync(BigInteger landId, uint guildId, bool isInvited)
        {
            var _key = new GuildInvitationTableRecord.GuildInvitationKey();
            _key.LandId = landId;
            _key.GuildId = guildId;

            var _values = new GuildInvitationTableRecord.GuildInvitationValue();
            _values.IsInvited = isInvited;
            return SetRecordRequestAndWaitForReceiptAsync(_key, _values);
        }
    }
    
    public partial class GuildInvitationTableRecord : TableRecord<GuildInvitationTableRecord.GuildInvitationKey, GuildInvitationTableRecord.GuildInvitationValue> 
    {
        public GuildInvitationTableRecord() : base("GuildInvitation")
        {
        
        }
        /// <summary>
        /// Direct access to the key property 'LandId'.
        /// </summary>
        public virtual BigInteger LandId => Keys.LandId;
        /// <summary>
        /// Direct access to the key property 'GuildId'.
        /// </summary>
        public virtual uint GuildId => Keys.GuildId;
        /// <summary>
        /// Direct access to the value property 'IsInvited'.
        /// </summary>
        public virtual bool IsInvited => Values.IsInvited;

        public partial class GuildInvitationKey
        {
            [Parameter("uint256", "landId", 1)]
            public virtual BigInteger LandId { get; set; }
            [Parameter("uint32", "guildId", 2)]
            public virtual uint GuildId { get; set; }
        }

        public partial class GuildInvitationValue
        {
            [Parameter("bool", "isInvited", 1)]
            public virtual bool IsInvited { get; set; }          
        }
    }
}
