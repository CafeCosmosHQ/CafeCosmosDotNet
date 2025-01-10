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
    public partial class MarketplaceNonceTableService : TableSingletonService<MarketplaceNonceTableRecord,MarketplaceNonceTableRecord.MarketplaceNonceValue>
    { 
        public MarketplaceNonceTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
    }
    
    public partial class MarketplaceNonceTableRecord : TableRecordSingleton<MarketplaceNonceTableRecord.MarketplaceNonceValue> 
    {
        public MarketplaceNonceTableRecord() : base("MarketplaceNonce")
        {
        
        }

        /// <summary>
        /// Direct access to the value property 'Nonce'.
        /// </summary>
        public virtual BigInteger Nonce => Values.Nonce;
        /// <summary>
        /// Direct access to the value property 'TotalListings'.
        /// </summary>
        public virtual BigInteger TotalListings => Values.TotalListings;

        public partial class MarketplaceNonceValue
        {
            [Parameter("uint256", "nonce", 1)]
            public virtual BigInteger Nonce { get; set; }
            [Parameter("uint256", "totalListings", 2)]
            public virtual BigInteger TotalListings { get; set; }          
        }
    }
}
