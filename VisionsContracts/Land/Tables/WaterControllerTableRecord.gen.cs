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
    public partial class WaterControllerTableService : TableSingletonService<WaterControllerTableRecord,WaterControllerTableRecord.WaterControllerValue>
    { 
        public WaterControllerTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
    }
    
    public partial class WaterControllerTableRecord : TableRecordSingleton<WaterControllerTableRecord.WaterControllerValue> 
    {
        public WaterControllerTableRecord() : base("WaterController")
        {
        
        }

        /// <summary>
        /// Direct access to the value property 'QuerySchema'.
        /// </summary>
        public virtual byte[] QuerySchema => Values.QuerySchema;
        /// <summary>
        /// Direct access to the value property 'MinDelta'.
        /// </summary>
        public virtual BigInteger MinDelta => Values.MinDelta;
        /// <summary>
        /// Direct access to the value property 'MaxDelta'.
        /// </summary>
        public virtual BigInteger MaxDelta => Values.MaxDelta;
        /// <summary>
        /// Direct access to the value property 'SourceChainId'.
        /// </summary>
        public virtual ulong SourceChainId => Values.SourceChainId;
        /// <summary>
        /// Direct access to the value property 'NumSamples'.
        /// </summary>
        public virtual BigInteger NumSamples => Values.NumSamples;
        /// <summary>
        /// Direct access to the value property 'BlockInterval'.
        /// </summary>
        public virtual BigInteger BlockInterval => Values.BlockInterval;
        /// <summary>
        /// Direct access to the value property 'MinYieldTime'.
        /// </summary>
        public virtual BigInteger MinYieldTime => Values.MinYieldTime;
        /// <summary>
        /// Direct access to the value property 'MaxYieldTime'.
        /// </summary>
        public virtual BigInteger MaxYieldTime => Values.MaxYieldTime;
        /// <summary>
        /// Direct access to the value property 'EndBlockSlippage'.
        /// </summary>
        public virtual BigInteger EndBlockSlippage => Values.EndBlockSlippage;
        /// <summary>
        /// Direct access to the value property 'LastTWAP'.
        /// </summary>
        public virtual BigInteger LastTWAP => Values.LastTWAP;
        /// <summary>
        /// Direct access to the value property 'WaterYieldTime'.
        /// </summary>
        public virtual BigInteger WaterYieldTime => Values.WaterYieldTime;
        /// <summary>
        /// Direct access to the value property 'LastUpdate'.
        /// </summary>
        public virtual BigInteger LastUpdate => Values.LastUpdate;

        public partial class WaterControllerValue
        {
            [Parameter("bytes32", "QUERY_SCHEMA", 1)]
            public virtual byte[] QuerySchema { get; set; }
            [Parameter("int256", "minDelta", 2)]
            public virtual BigInteger MinDelta { get; set; }
            [Parameter("int256", "maxDelta", 3)]
            public virtual BigInteger MaxDelta { get; set; }
            [Parameter("uint64", "SOURCE_CHAIN_ID", 4)]
            public virtual ulong SourceChainId { get; set; }
            [Parameter("uint256", "numSamples", 5)]
            public virtual BigInteger NumSamples { get; set; }
            [Parameter("uint256", "blockInterval", 6)]
            public virtual BigInteger BlockInterval { get; set; }
            [Parameter("uint256", "minYieldTime", 7)]
            public virtual BigInteger MinYieldTime { get; set; }
            [Parameter("uint256", "maxYieldTime", 8)]
            public virtual BigInteger MaxYieldTime { get; set; }
            [Parameter("uint256", "endBlockSlippage", 9)]
            public virtual BigInteger EndBlockSlippage { get; set; }
            [Parameter("uint256", "lastTWAP", 10)]
            public virtual BigInteger LastTWAP { get; set; }
            [Parameter("uint256", "waterYieldTime", 11)]
            public virtual BigInteger WaterYieldTime { get; set; }
            [Parameter("uint256", "lastUpdate", 12)]
            public virtual BigInteger LastUpdate { get; set; }          
        }
    }
}
