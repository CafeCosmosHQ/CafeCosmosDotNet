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
    public partial class GuildsTableService : TableSingletonService<GuildsTableRecord,GuildsTableRecord.GuildsValue>
    { 
        public GuildsTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
    }
    
    public partial class GuildsTableRecord : TableRecordSingleton<GuildsTableRecord.GuildsValue> 
    {
        public GuildsTableRecord() : base("Guilds")
        {
        
        }

        /// <summary>
        /// Direct access to the value property 'NumberOfGuilds'.
        /// </summary>
        public virtual uint NumberOfGuilds => Values.NumberOfGuilds;
        /// <summary>
        /// Direct access to the value property 'Nonce'.
        /// </summary>
        public virtual uint Nonce => Values.Nonce;

        public partial class GuildsValue
        {
            [Parameter("uint32", "numberOfGuilds", 1)]
            public virtual uint NumberOfGuilds { get; set; }
            [Parameter("uint32", "nonce", 2)]
            public virtual uint Nonce { get; set; }          
        }
    }
}
