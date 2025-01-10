using Nethereum.Hex.HexConvertors.Extensions;
using System;

namespace VisionsContracts
{
    public class DeploymentConfiguration
    {
        public decimal CookingCost { get; set; } = 0.001m;
        public decimal LandCostPerSquare { get; set; } = 0.0000001m;
        public int Scale { get; set; } = 1;
        public string SoftDestinationAddress { get; set; }
        public string ItemsNFTUrl { get; set; } = "http://ipfs.io/";
        public string TokenName { get; set; } = "CafeCosmosWETH";
        public string TokenSymbol { get; set; } = "CWETH9";
        public int LandExpansionChunkSize { get; set; } = 100;
        public string LandNFTName { get; set; } = "CafeCosmosLands";
        public string LandNFTSymbol { get; set; } = "CCL";
        public string DeployerAddress { get; set; } = "0x4e59b44847b379578588920ca78fbf26c0b4956c";
        public int MaxLevel { get; set; } = 50;

        public WaterControllerConfiguration WaterControllerConfiguration { get; set; } = new WaterControllerConfiguration();
        public AxionConfiguration AxionConfiguration { get; set; } = new AxionConfiguration();
        public bool TestNet { get; set; } = true;
        public string TokenAddress { get; set; }
    }

    public class AxionConfiguration 
    {
       public string AxiomV2QueryAddress { get; set; } = "0xf15cc7B983749686Cd1eCca656C3D3E46407DC1f";
        public ulong CallbackSourceChainId { get; set; } = 1;
       //Hardcoded or read from file.. ?
       public byte[] QuerySchema { get; set; } = "0x0ed3b52551bffd01161ba712d4a06865f65c80f7e7da7d9ed80f0e90ac069602".HexToByteArray();

    }

    public class WaterControllerConfiguration
    {
        public int NumSamples { get; set; } = 31;
        public int BlockInterval { get; set; } = 1000;
        public int MinYieldTime { get; set; } = 387;
        public int MaxYieldTime { get; set; } = 707412;
        public int EndBlockSlippage { get; set; } = 100;
        public long MinDelta { get; set; } = -54067095249;
        public long MaxDelta { get; set; } = 3870911308;
       
    }

}
