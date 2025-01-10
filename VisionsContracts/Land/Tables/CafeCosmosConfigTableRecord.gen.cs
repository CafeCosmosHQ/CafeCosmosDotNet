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
    public partial class CafeCosmosConfigTableService : TableSingletonService<CafeCosmosConfigTableRecord,CafeCosmosConfigTableRecord.CafeCosmosConfigValue>
    { 
        public CafeCosmosConfigTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
    }
    
    public partial class CafeCosmosConfigTableRecord : TableRecordSingleton<CafeCosmosConfigTableRecord.CafeCosmosConfigValue> 
    {
        public CafeCosmosConfigTableRecord() : base("CafeCosmosConfig")
        {
        
        }

        /// <summary>
        /// Direct access to the value property 'CookingCost'.
        /// </summary>
        public virtual BigInteger CookingCost => Values.CookingCost;
        /// <summary>
        /// Direct access to the value property 'SoftCostPerSquare'.
        /// </summary>
        public virtual BigInteger SoftCostPerSquare => Values.SoftCostPerSquare;
        /// <summary>
        /// Direct access to the value property 'LandNonce'.
        /// </summary>
        public virtual BigInteger LandNonce => Values.LandNonce;
        /// <summary>
        /// Direct access to the value property 'InitialLimitX'.
        /// </summary>
        public virtual BigInteger InitialLimitX => Values.InitialLimitX;
        /// <summary>
        /// Direct access to the value property 'InitialLimitY'.
        /// </summary>
        public virtual BigInteger InitialLimitY => Values.InitialLimitY;
        /// <summary>
        /// Direct access to the value property 'MinStartingX'.
        /// </summary>
        public virtual BigInteger MinStartingX => Values.MinStartingX;
        /// <summary>
        /// Direct access to the value property 'MinStartingY'.
        /// </summary>
        public virtual BigInteger MinStartingY => Values.MinStartingY;
        /// <summary>
        /// Direct access to the value property 'TotalLandSlotsSold'.
        /// </summary>
        public virtual BigInteger TotalLandSlotsSold => Values.TotalLandSlotsSold;
        /// <summary>
        /// Direct access to the value property 'StartTime'.
        /// </summary>
        public virtual BigInteger StartTime => Values.StartTime;
        /// <summary>
        /// Direct access to the value property 'DefaultLandType'.
        /// </summary>
        public virtual BigInteger DefaultLandType => Values.DefaultLandType;
        /// <summary>
        /// Direct access to the value property 'SeedMask'.
        /// </summary>
        public virtual BigInteger SeedMask => Values.SeedMask;
        /// <summary>
        /// Direct access to the value property 'GlobalBoosterId'.
        /// </summary>
        public virtual BigInteger GlobalBoosterId => Values.GlobalBoosterId;
        /// <summary>
        /// Direct access to the value property 'MaxGroupIdNumber'.
        /// </summary>
        public virtual BigInteger MaxGroupIdNumber => Values.MaxGroupIdNumber;
        /// <summary>
        /// Direct access to the value property 'ChunkSize'.
        /// </summary>
        public virtual BigInteger ChunkSize => Values.ChunkSize;
        /// <summary>
        /// Direct access to the value property 'MaxLevel'.
        /// </summary>
        public virtual BigInteger MaxLevel => Values.MaxLevel;
        /// <summary>
        /// Direct access to the value property 'CategoryMaxBoost'.
        /// </summary>
        public virtual List<BigInteger> CategoryMaxBoost => Values.CategoryMaxBoost;
        /// <summary>
        /// Direct access to the value property 'MaxBoosts'.
        /// </summary>
        public virtual List<BigInteger> MaxBoosts => Values.MaxBoosts;
        /// <summary>
        /// Direct access to the value property 'StartingItems'.
        /// </summary>
        public virtual List<BigInteger> StartingItems => Values.StartingItems;
        /// <summary>
        /// Direct access to the value property 'StartingItemsQuantities'.
        /// </summary>
        public virtual List<BigInteger> StartingItemsQuantities => Values.StartingItemsQuantities;

        public partial class CafeCosmosConfigValue
        {
            [Parameter("uint256", "cookingCost", 1)]
            public virtual BigInteger CookingCost { get; set; }
            [Parameter("uint256", "softCostPerSquare", 2)]
            public virtual BigInteger SoftCostPerSquare { get; set; }
            [Parameter("uint256", "landNonce", 3)]
            public virtual BigInteger LandNonce { get; set; }
            [Parameter("uint256", "initialLimitX", 4)]
            public virtual BigInteger InitialLimitX { get; set; }
            [Parameter("uint256", "initialLimitY", 5)]
            public virtual BigInteger InitialLimitY { get; set; }
            [Parameter("uint256", "minStartingX", 6)]
            public virtual BigInteger MinStartingX { get; set; }
            [Parameter("uint256", "minStartingY", 7)]
            public virtual BigInteger MinStartingY { get; set; }
            [Parameter("uint256", "totalLandSlotsSold", 8)]
            public virtual BigInteger TotalLandSlotsSold { get; set; }
            [Parameter("uint256", "startTime", 9)]
            public virtual BigInteger StartTime { get; set; }
            [Parameter("uint256", "defaultLandType", 10)]
            public virtual BigInteger DefaultLandType { get; set; }
            [Parameter("uint160", "seedMask", 11)]
            public virtual BigInteger SeedMask { get; set; }
            [Parameter("uint256", "globalBoosterId", 12)]
            public virtual BigInteger GlobalBoosterId { get; set; }
            [Parameter("uint256", "maxGroupIdNumber", 13)]
            public virtual BigInteger MaxGroupIdNumber { get; set; }
            [Parameter("uint256", "chunkSize", 14)]
            public virtual BigInteger ChunkSize { get; set; }
            [Parameter("uint256", "maxLevel", 15)]
            public virtual BigInteger MaxLevel { get; set; }
            [Parameter("uint256[7]", "categoryMaxBoost", 16)]
            public virtual List<BigInteger> CategoryMaxBoost { get; set; }
            [Parameter("uint256[3]", "maxBoosts", 17)]
            public virtual List<BigInteger> MaxBoosts { get; set; }
            [Parameter("uint256[]", "startingItems", 18)]
            public virtual List<BigInteger> StartingItems { get; set; }
            [Parameter("uint256[]", "startingItemsQuantities", 19)]
            public virtual List<BigInteger> StartingItemsQuantities { get; set; }          
        }
    }
}
