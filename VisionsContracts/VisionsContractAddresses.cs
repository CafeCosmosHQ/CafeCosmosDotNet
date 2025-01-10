using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace VisionsContracts
{
    [System.Serializable]
    public class VisionsContractAddresses
    {
        public int ChainId { get; set; }
        public string RedistributorAddress { get; set; }
        public string TokenAddress { get; set; }
        public string ItemsAddress { get; set; }
        public string LandAddress { get; set; }
        public string VestingAddress { get; set; }
        public string LandNFTAddress { get; set; }
    }

    public class LandDiamondSystemsContractAddresses
    {
        public string CraftingSystem { get; set; }
        public string LandConfigSystem { get; set; }
        public string LandCreationSystem { get; set; }
        public string LandItemInteractionSystem { get; set; }
        public string LandScenarioTestingSystem { get; set; }
        public string LandViewSystem { get; set; }
        public string WaterControllerSystem { get; set; }
        public string LandItemsSystem { get; set; }
        public string LandTokensSystem { get; set; }
        public string LandERC1155HolderSystem { get; internal set; }
    }

    public static class VisionContractAddressesExtensions
    {
        public static string ToVariableInitialisingString(this VisionsContractAddresses contractAddresses)
        {

            return $@"contractAddresses = new VisionsContractAddresses
            {{ 
                ChainId = {contractAddresses.ChainId},
                RedistributorAddress = ""{contractAddresses.RedistributorAddress}"",
                TokenAddress = ""{contractAddresses.TokenAddress}"",
                ItemsAddress = ""{contractAddresses.ItemsAddress}"",
                LandAddress = ""{contractAddresses.LandAddress}"",
                VestingAddress = ""{contractAddresses.VestingAddress}"",
                LandNFTAddress = ""{contractAddresses.LandNFTAddress}""
            }};";
        }


        public static string ToJson(this VisionsContractAddresses contractAddresses)
        {
            return JsonConvert.SerializeObject(contractAddresses, Formatting.Indented);
        }
    }
}
