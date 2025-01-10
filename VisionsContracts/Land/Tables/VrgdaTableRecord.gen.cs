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
    public partial class VrgdaTableService : TableSingletonService<VrgdaTableRecord,VrgdaTableRecord.VrgdaValue>
    { 
        public VrgdaTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
    }
    
    public partial class VrgdaTableRecord : TableRecordSingleton<VrgdaTableRecord.VrgdaValue> 
    {
        public VrgdaTableRecord() : base("Vrgda")
        {
        
        }

        /// <summary>
        /// Direct access to the value property 'TargetPrice'.
        /// </summary>
        public virtual BigInteger TargetPrice => Values.TargetPrice;
        /// <summary>
        /// Direct access to the value property 'DecayConstant'.
        /// </summary>
        public virtual BigInteger DecayConstant => Values.DecayConstant;
        /// <summary>
        /// Direct access to the value property 'PerTimeUnit'.
        /// </summary>
        public virtual BigInteger PerTimeUnit => Values.PerTimeUnit;
        /// <summary>
        /// Direct access to the value property 'StartingTime'.
        /// </summary>
        public virtual BigInteger StartingTime => Values.StartingTime;
        /// <summary>
        /// Direct access to the value property 'TotalUnitsSold'.
        /// </summary>
        public virtual BigInteger TotalUnitsSold => Values.TotalUnitsSold;

        public partial class VrgdaValue
        {
            [Parameter("int256", "targetPrice", 1)]
            public virtual BigInteger TargetPrice { get; set; }
            [Parameter("int256", "decayConstant", 2)]
            public virtual BigInteger DecayConstant { get; set; }
            [Parameter("int256", "perTimeUnit", 3)]
            public virtual BigInteger PerTimeUnit { get; set; }
            [Parameter("int256", "startingTime", 4)]
            public virtual BigInteger StartingTime { get; set; }
            [Parameter("uint256", "totalUnitsSold", 5)]
            public virtual BigInteger TotalUnitsSold { get; set; }          
        }
    }
}
