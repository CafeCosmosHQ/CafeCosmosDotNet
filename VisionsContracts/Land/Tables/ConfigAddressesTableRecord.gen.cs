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
    public partial class ConfigAddressesTableService : TableSingletonService<ConfigAddressesTableRecord,ConfigAddressesTableRecord.ConfigAddressesValue>
    { 
        public ConfigAddressesTableService(IWeb3 web3, string contractAddress) : base(web3, contractAddress) {}
    }
    
    public partial class ConfigAddressesTableRecord : TableRecordSingleton<ConfigAddressesTableRecord.ConfigAddressesValue> 
    {
        public ConfigAddressesTableRecord() : base("ConfigAddresses")
        {
        
        }

        /// <summary>
        /// Direct access to the value property 'VestingAddress'.
        /// </summary>
        public virtual string VestingAddress => Values.VestingAddress;
        /// <summary>
        /// Direct access to the value property 'SoftTokenAddress'.
        /// </summary>
        public virtual string SoftTokenAddress => Values.SoftTokenAddress;
        /// <summary>
        /// Direct access to the value property 'ItemsAddress'.
        /// </summary>
        public virtual string ItemsAddress => Values.ItemsAddress;
        /// <summary>
        /// Direct access to the value property 'RedistributorAddress'.
        /// </summary>
        public virtual string RedistributorAddress => Values.RedistributorAddress;
        /// <summary>
        /// Direct access to the value property 'LandNFTsAddress'.
        /// </summary>
        public virtual string LandNFTsAddress => Values.LandNFTsAddress;
        /// <summary>
        /// Direct access to the value property 'SoftDestinationAddress'.
        /// </summary>
        public virtual string SoftDestinationAddress => Values.SoftDestinationAddress;
        /// <summary>
        /// Direct access to the value property 'PerlinItemConfigAddress'.
        /// </summary>
        public virtual string PerlinItemConfigAddress => Values.PerlinItemConfigAddress;
        /// <summary>
        /// Direct access to the value property 'LandTransformAddress'.
        /// </summary>
        public virtual string LandTransformAddress => Values.LandTransformAddress;
        /// <summary>
        /// Direct access to the value property 'LandTablesAndChairsAddress'.
        /// </summary>
        public virtual string LandTablesAndChairsAddress => Values.LandTablesAndChairsAddress;
        /// <summary>
        /// Direct access to the value property 'LandQuestTaskProgressUpdateAddress'.
        /// </summary>
        public virtual string LandQuestTaskProgressUpdateAddress => Values.LandQuestTaskProgressUpdateAddress;
        /// <summary>
        /// Direct access to the value property 'VrgdaAddress'.
        /// </summary>
        public virtual string VrgdaAddress => Values.VrgdaAddress;

        public partial class ConfigAddressesValue
        {
            [Parameter("address", "vestingAddress", 1)]
            public virtual string VestingAddress { get; set; }
            [Parameter("address", "softTokenAddress", 2)]
            public virtual string SoftTokenAddress { get; set; }
            [Parameter("address", "itemsAddress", 3)]
            public virtual string ItemsAddress { get; set; }
            [Parameter("address", "redistributorAddress", 4)]
            public virtual string RedistributorAddress { get; set; }
            [Parameter("address", "landNFTsAddress", 5)]
            public virtual string LandNFTsAddress { get; set; }
            [Parameter("address", "softDestinationAddress", 6)]
            public virtual string SoftDestinationAddress { get; set; }
            [Parameter("address", "perlinItemConfigAddress", 7)]
            public virtual string PerlinItemConfigAddress { get; set; }
            [Parameter("address", "landTransformAddress", 8)]
            public virtual string LandTransformAddress { get; set; }
            [Parameter("address", "landTablesAndChairsAddress", 9)]
            public virtual string LandTablesAndChairsAddress { get; set; }
            [Parameter("address", "landQuestTaskProgressUpdateAddress", 10)]
            public virtual string LandQuestTaskProgressUpdateAddress { get; set; }
            [Parameter("address", "vrgdaAddress", 11)]
            public virtual string VrgdaAddress { get; set; }          
        }
    }
}
