using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace VisionsContracts.Land.Systems.LandViewSystem.ContractDefinition
{


    public partial class LandViewSystemDeployment : LandViewSystemDeploymentBase
    {
        public LandViewSystemDeployment() : base(BYTECODE) { }
        public LandViewSystemDeployment(string byteCode) : base(byteCode) { }
    }

    public class LandViewSystemDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x60808060405234601557611c1a908161001a8239f35b5f80fdfe60806040526004361015610011575f80fd5b5f3560e01c806301ffc9a7146100f4578063119df25f146100ef57806317f05bd8146100ea5780632712950e146100e55780632c1b47e5146100e057806340e88943146100db57806345ec9354146100d65780634d3802a0146100d157806394c45e76146100cc578063b3df3846146100c7578063cd9cca4b146100c2578063d35e5ce7146100bd578063e15b346b146100b85763e1af802c146100b3575f80fd5b610783565b610706565b6106d8565b6106b2565b61063a565b61059c565b610506565b6104a0565b610473565b6103bf565b610256565b6101e6565b61014e565b3461014a57602036600319011261014a5760043563ffffffff60e01b811680910361014a5760209063b5dee12760e01b8114908115610139575b506040519015158152f35b6301ffc9a760e01b1490505f61012e565b5f80fd5b3461014a575f36600319011261014a5736603319013560601c8015610183575b6040516001600160a01b039091168152602090f35b503361016e565b6040809180518452602081015160208501520151910152565b60206040818301928281528451809452019201905f5b8181106101c65750505090565b90919260206060826101db600194885161018a565b0194019291016101b9565b3461014a57602036600319011261014a576004356001600160401b03811161014a573660238201121561014a576004810135906001600160401b03821161014a573660248360051b8301011161014a5761025291602461024692016108a6565b604051918291826101a3565b0390f35b3461014a57602036600319011261014a57600435610272610c32565b90815115610292578161028a91602080940152610f6d565b604051908152f35b61085e565b90602080835192838152019201905f5b8181106102b45750505090565b909192602061010060019260e0875180518352848101518584015260408101516040840152606081015160608401526080810151608084015260a0810151151560a084015260c081015160c0840152015160e082015201940191019190916102a7565b602081016020825282518091526040820191602060408360051b8301019401925f915b83831061034957505050505090565b9091929394603f19828203018352855190815180825260208201906020808260051b8501019401925f5b8281106103945750505050506020806001929701930193019193929061033a565b90919293946020806103b2600193601f198782030189528951610297565b9701950193929101610373565b3461014a57602036600319011261014a576004356103dc81610cf3565b519060206103e982610cf3565b0151916103f581610931565b925f5b82811061040d57604051806102528782610317565b61041682610931565b6104208287610892565b5261042b8186610892565b505f5b82811061043e57506001016103f8565b8061046c81610450600194868a610b79565b61045a868b610892565b51906104668383610892565b52610892565b500161042e565b3461014a57602036600319011261014a57606061049160043561097a565b61049e604051809261018a565bf35b3461014a575f36600319011261014a576020604051601f193601358152f35b606090600319011261014a57600435906024359060443590565b919060608301925f905b600382106104f057505050565b60208060019285518152019301910190916104e3565b3461014a57610514366104bf565b91606060405161052482826107e4565b369037606060405161053682826107e4565b369037610541610c54565b908151156102925760208201528051600110156102925761058661057e826102529561059095604061058b96015261057882610872565b52611501565b805190611635565b6116ba565b611715565b604051918291826104d9565b3461014a576105aa366104bf565b919061ffff6105c26105bd858486610dda565b6109fb565b16906105cc610c76565b9283511561029257602084015282516001101561029257604083015281516002101561029257610615826106229261025295606061062896015261060f82610882565b52611047565b6001600160f81b03191690565b60f81c90565b60405190151581529081906020820190565b3461014a57610648366104bf565b91606060405161065882826107e4565b369037606060405161066a82826107e4565b369037610675610c54565b908151156102925760208201528051600110156102925761058661057e826102529561059095604061058b9601526106ac82610872565b526115aa565b3461014a576102526106cc6106c6366104bf565b91610a2e565b60405191829182610317565b3461014a576102526106f26106ec366104bf565b91610b79565b604051918291602083526020830190610297565b3461014a57610714366104bf565b909161ffff6107276105bd848685610dda565b1692610731610c76565b91825115610292576020830152815160011015610292576040820152805160021015610292576102529261077392606083015261076d82610882565b526110d2565b6040519081529081906020820190565b3461014a575f36600319011261014a57602061079d611740565b6040516001600160a01b039091168152f35b634e487b7160e01b5f52604160045260245ffd5b61010081019081106001600160401b038211176107df57604052565b6107af565b601f909101601f19168101906001600160401b038211908210176107df57604052565b60405190610817610100836107e4565b565b6001600160401b0381116107df5760051b60200190565b60405190606082016001600160401b038111838210176107df576040525f6040838281528260208201520152565b634e487b7160e01b5f52603260045260245ffd5b8051600210156102925760600190565b8051600310156102925760800190565b80518210156102925760209160051b010190565b9190916108b283610819565b916108c060405193846107e4565b838352601f196108cf85610819565b015f5b81811061091a5750505f5b84811015610913576001906108f78160051b85013561097a565b6109018287610892565b5261090c8186610892565b50016108dd565b5092505090565b602090610925610830565b828288010152016108d2565b9061093b82610819565b61094860405191826107e4565b8281526020819361095b601f1991610819565b0191015f5b82811061096c57505050565b606082820152602001610960565b610982610830565b5061098b610db2565b50610994610c32565b80511561029257808260206109aa93015261128b565b505060406109b6610db2565b91602081015191829101519283602082015252604051926109d86060856107e4565b83526020830152604082015290565b634e487b7160e01b5f52601160045260245ffd5b61ffff5f199116019061ffff8211610a0f57565b6109e7565b91908201809211610a0f57565b91908203918211610a0f57565b9091610a3982610cf3565b516020610a4584610cf3565b01519080851015610af057808591610a5d8584610a14565b11610add575b5050610a6e82610931565b935f5b838110610a8057505050505090565b610a8983610931565b610a938288610892565b52610a9e8187610892565b505f5b838110610ab15750600101610a71565b80610ad681610acc600194610ac68789610a14565b8b610b79565b61045a868c610892565b5001610aa1565b610ae8929350610a21565b90835f610a63565b5050505050606090565b90610b0482610819565b610b1160405191826107e4565b8281528092610b22601f1991610819565b01905f5b828110610b3257505050565b602090604051610b41816107c3565b5f81525f838201525f60408201525f60608201525f60808201525f60a08201525f60c08201525f60e082015282828501015201610b26565b9190610b90610b89838386610dda565b61ffff1690565b91610b9a83610afa565b935f5b848110610bac57505050505090565b80610bbb600192858786610e5d565b805190602081015190610c0c610bd46080830151151590565b6060604084015193015193610be7610807565b958b87528a60208801526040870152606086015285608086015260a085019015159052565b60c083015260e0820152610c208289610892565b52610c2b8188610892565b5001610b9d565b60408051909190610c4383826107e4565b6001815291601f1901366020840137565b60405160809190610c6583826107e4565b6003815291601f1901366020840137565b60405160a09190610c8783826107e4565b6004815291601f1901366020840137565b6040519061014082016001600160401b038111838210176107df576040526060610120835f81525f60208201525f60408201525f838201525f60808201525f60a08201525f60c08201525f60e08201525f6101008201520152565b610cfb610c98565b50610d04610c32565b908151156102925781610d1e916020610da9940152611372565b90610d2a939293610c98565b93602081015190604081015190606081015190610d93608082015191610d8a60a082015160f81c918b60a182015160e01c9160e060a58201519260e560c5840151930151610100820152015260c08d015260a08c019063ffffffff169052565b151560808a0152565b60608801526040870152602086015284526118f1565b61012082015290565b60408051919082016001600160401b038111838210176107df576040525f6020838281520152565b9190610de4610c54565b928351156102925760208401528251600110156102925760408301528151600210156102925781610e1c91606061ffff94015261115e565b60f01c1690565b6040519060a082016001600160401b038111838210176107df576040525f6080838281528260208201528260408201528260608201520152565b919290610e68610e23565b50610e71610c76565b9283511561029257602084015282516001101561029257604083015281516002101561029257610eaf926060830152610ea982610882565b5261142b565b5050610eb9610e23565b9060208101519060408101519060608101519060a0608082015191015160f81c15156080860152606085015260408401526020830152815290565b9081602091031261014a575190565b90602080835192838152019201905f5b818110610f205750505090565b8251845260209384019390920191600101610f13565b90610f5760609360ff92979695978452608060208501526080840190610f03565b951660408201520152565b6040513d5f823e3d90fd5b6001600160a01b03610f7d611740565b16308103610fb95750610fb6906b072848090101010008210101609d1b90600290674c616e64496e666f60401b613a3160f11b01611775565b90565b604051638c364d5960e01b815291602091839182908190611004906b072848090101010008210101609d1b90600290674c616e64496e666f60401b613a3160f11b0160048601610f36565b03915afa908115611042575f91611019575090565b610fb6915060203d60201161103b575b61103381836107e4565b810190610ef4565b503d611029565b610f62565b6001600160a01b03611057611740565b1630810361108c5750610fb69067810500202020200160b81b90600490674c616e644974656d60401b613a3160f11b01611775565b604051638c364d5960e01b8152916020918391829081906110049067810500202020200160b81b90600490674c616e644974656d60401b613a3160f11b01828601610f36565b6001600160a01b036110e2611740565b163081036111175750610fb69067810500202020200160b81b90600190674c616e644974656d60401b613a3160f11b01611775565b604051638c364d5960e01b8152916020918391829081906110049067810500202020200160b81b90600190674c616e644974656d60401b613a3160f11b0160048601610f36565b6001600160a01b0361116e611740565b1630810361119e5750610fb690630100800160d91b905f906713185b9910d95b1b60421b613a3160f11b01611775565b604051638c364d5960e01b81529160209183918290819061100490630100800160d91b905f906713185b9910d95b1b60421b613a3160f11b0160048601610f36565b6001600160401b0381116107df57601f01601f191660200190565b81601f8201121561014a57805190611212826111e0565b9261122060405194856107e4565b8284526020838301011161014a57815f9260208093018386015e8301015290565b9160608383031261014a5782516001600160401b03811161014a57826112689185016111fb565b92602081015192604082015160018060401b03811161014a57610fb692016111fb565b6001600160a01b0361129b611740565b163081036112d657506112cf9064020010010160d51b906f506c61796572546f74616c4561726e65613a3160f11b0161182d565b9192909190565b60405163419b58fd60e01b81526f506c61796572546f74616c4561726e65613a3160f11b0160048201526060602482015292915f9184918290819061131f906064830190610f03565b64020010010160d51b604483015203915afa908115611042575f5f935f93611348575b50929190565b9193505061136891503d805f833e61136081836107e4565b810190611241565b929092915f611342565b6001600160a01b03611382611740565b163081036113b857506112cf906b072848090101010008210101609d1b90674c616e64496e666f60401b613a3160f11b0161182d565b60405163419b58fd60e01b8152674c616e64496e666f60401b613a3160f11b0160048201526060602482015292915f918491829081906113fc906064830190610f03565b6b072848090101010008210101609d1b604483015203915afa908115611042575f5f935f936113485750929190565b6001600160a01b0361143b611740565b1630810361146d57506112cf9067810500202020200160b81b90674c616e644974656d60401b613a3160f11b0161182d565b60405163419b58fd60e01b8152674c616e644974656d60401b613a3160f11b0160048201526060602482015292915f918491829081906114b1906064830190610f03565b67810500202020200160b81b604483015203915afa908115611042575f5f935f936113485750929190565b9060208282031261014a5781516001600160401b03811161014a57610fb692016111fb565b6001600160a01b03611511611740565b163081036115345750610fb6906001905f516020611bc55f395f51905f52611909565b604051631e78897760e01b81525f516020611bc55f395f51905f52600482015260606024820152915f91839182908190611572906064830190610f03565b6001604483015203915afa908115611042575f9161158e575090565b610fb691503d805f833e6115a281836107e4565b8101906114dc565b6001600160a01b036115ba611740565b163081036115dc5750610fb6905f905f516020611bc55f395f51905f52611909565b604051631e78897760e01b81525f516020611bc55f395f51905f52600482015260606024820152915f9183918290819061161a906064830190610f03565b85604483015203915afa908115611042575f9161158e575090565b8051821161166d576116575f61165181602061165e9501610a14565b93610a21565b9160801b90565b6001600160801b039091161790565b60849060206040519384926323230fa360e01b8452606060048501528051928391826064870152018585015e5f838301850181905260248401526044830152601f01601f19168101030190fd5b6040805160206020600160801b0384168201810190925260016001607b1b03600584901c168082529092909160809190911c9083015f5b8381106116ff575050505090565b60206001819285518552019201920191906116f1565b6040516117236060826107e4565b60603682379060038151105f14611738575090565b602091500190565b7f629a4c26e296b22a8e0856e9f6ecb2d1008d7e00081111962cd175fa7488e175546001600160a01b031680610fb657503390565b60ff9161178491949394611965565b92169161179a838360ff91601b0360031b1c1690565b915f935f915b8183106117f257505050828160208210156117dc575b505080548360031b1b926020038092116117cf57505090565b600101549060031b1c1790565b90809450601f925060051c019216915f806117b6565b909194611808868360ff91601b0360031b1c1690565b8101809111610a0f579460010191906117a0565b60ff1660ff8114610a0f5760010190565b91925f9260609260ff6118448760f01c83856119b4565b9660e01c168061185357505050565b91945092506118628385611b83565b549366ffffffffffffff851693611878856111e0565b9461188660405196876107e4565b808652611895601f19916111e0565b013660208701375f9186602087015b8560ff8616106118b657505050505050565b6118e991816118de6118e3936118d7896118d1818b8b6119e6565b95611a38565b8094611a4d565b610a14565b9361181c565b9287906118a4565b610fb69164ffffffffff6105869260381c1690611635565b90610fb69261192661192c926119208382876119e6565b94611b83565b54611a38565b90611b60565b60209181520160208251919201905f5b81811061194f5750505090565b8251845260209384019390920191600101611942565b9061198c61197e91604051928391602083019586611932565b03601f1981018352826107e4565b5190207f86425bff6b57326c7859e89024fe4f238ca327a1ae4a230180dd2f0e88aaa7d91890565b91909181156119cf57610fb6926119ca91611965565b611b60565b5050506040516119e06020826107e4565b5f815290565b61197e611a207f3b4102da22e32d82fc925482184f16c09fd4281692720b87d124aef6da48a0f19493604051928391602083019586611932565b51902060f89190911b6001600160f81b031916181890565b60ff64ffffffffff92166028026038011c1690565b905b6020811015611a785780611a6257505050565b5f199060031b1c90818351169119905416179052565b919060018160209254845201910191601f1901611a4f565b919080611adc575b505b6020811015611ac45780611aad57505050565b5f1960039190911b1c825191548119169116179052565b919060018160209254845201910191601f1901611a9a565b6020811015611b44575b8015611a9857929183602003908183105f14611b37575f19600384901b1c5b81548660031b1b8186511691191617845281831115611b3057600101920192601f199101015f611a98565b5050505050565b5f19600383901b1c611b05565b91611b5b90611b538460051c90565b0192601f1690565b611ae6565b610fb69060405192601f19603f82860101166040528084525f6020850192611a90565b90611b9c61197e91604051928391602083019586611932565b5190207f14e2fcc58e58e68ec7edc30c8d50dccc3ce2714a623ec81f46b6a63922d76569189056fe746200000000000000000000000000004c616e645461626c6573416e64436861a26469706673582212203fe5f2d7e9b84c8804c9ed1cf24b8ffefe4738d67448a116615ea66643b2da2464736f6c634300081c0033";
        public LandViewSystemDeploymentBase() : base(BYTECODE) { }
        public LandViewSystemDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class MsgSenderFunction : MsgSenderFunctionBase { }

    [Function("_msgSender", "address")]
    public class MsgSenderFunctionBase : FunctionMessage
    {

    }

    public partial class MsgValueFunction : MsgValueFunctionBase { }

    [Function("_msgValue", "uint256")]
    public class MsgValueFunctionBase : FunctionMessage
    {

    }

    public partial class WorldFunction : WorldFunctionBase { }

    [Function("_world", "address")]
    public class WorldFunctionBase : FunctionMessage
    {

    }

    public partial class GetActiveTablesFunction : GetActiveTablesFunctionBase { }

    [Function("getActiveTables", "uint256")]
    public class GetActiveTablesFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "landId", 1)]
        public virtual BigInteger LandId { get; set; }
    }

    public partial class GetChairsOfTablesFunction : GetChairsOfTablesFunctionBase { }

    [Function("getChairsOfTables", "uint256[3]")]
    public class GetChairsOfTablesFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "landId", 1)]
        public virtual BigInteger LandId { get; set; }
        [Parameter("uint256", "x", 2)]
        public virtual BigInteger X { get; set; }
        [Parameter("uint256", "y", 3)]
        public virtual BigInteger Y { get; set; }
    }

    public partial class GetLandItemsFunction : GetLandItemsFunctionBase { }

    [Function("getLandItems", typeof(GetLandItemsOutputDTO))]
    public class GetLandItemsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "landId", 1)]
        public virtual BigInteger LandId { get; set; }
        [Parameter("uint256", "x", 2)]
        public virtual BigInteger X { get; set; }
        [Parameter("uint256", "y", 3)]
        public virtual BigInteger Y { get; set; }
    }

    public partial class GetLandItems3dFunction : GetLandItems3dFunctionBase { }

    [Function("getLandItems3d", typeof(GetLandItems3dOutputDTO))]
    public class GetLandItems3dFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "landId", 1)]
        public virtual BigInteger LandId { get; set; }
    }

    public partial class GetLandItems3dPagedFunction : GetLandItems3dPagedFunctionBase { }

    [Function("getLandItems3dPaged", typeof(GetLandItems3dPagedOutputDTO))]
    public class GetLandItems3dPagedFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "landId", 1)]
        public virtual BigInteger LandId { get; set; }
        [Parameter("uint256", "startX", 2)]
        public virtual BigInteger StartX { get; set; }
        [Parameter("uint256", "maxRecords", 3)]
        public virtual BigInteger MaxRecords { get; set; }
    }

    public partial class GetLandsTotalEarnedFunction : GetLandsTotalEarnedFunctionBase { }

    [Function("getLandsTotalEarned", typeof(GetLandsTotalEarnedOutputDTO))]
    public class GetLandsTotalEarnedFunctionBase : FunctionMessage
    {
        [Parameter("uint256[]", "landIds", 1)]
        public virtual List<BigInteger> LandIds { get; set; }
    }

    public partial class GetPlacementTimeFunction : GetPlacementTimeFunctionBase { }

    [Function("getPlacementTime", "uint256")]
    public class GetPlacementTimeFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "landId", 1)]
        public virtual BigInteger LandId { get; set; }
        [Parameter("uint256", "x", 2)]
        public virtual BigInteger X { get; set; }
        [Parameter("uint256", "y", 3)]
        public virtual BigInteger Y { get; set; }
    }

    public partial class GetRotationFunction : GetRotationFunctionBase { }

    [Function("getRotation", "bool")]
    public class GetRotationFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "landId", 1)]
        public virtual BigInteger LandId { get; set; }
        [Parameter("uint256", "x", 2)]
        public virtual BigInteger X { get; set; }
        [Parameter("uint256", "y", 3)]
        public virtual BigInteger Y { get; set; }
    }

    public partial class GetTablesOfChairsFunction : GetTablesOfChairsFunctionBase { }

    [Function("getTablesOfChairs", "uint256[3]")]
    public class GetTablesOfChairsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "landId", 1)]
        public virtual BigInteger LandId { get; set; }
        [Parameter("uint256", "x", 2)]
        public virtual BigInteger X { get; set; }
        [Parameter("uint256", "y", 3)]
        public virtual BigInteger Y { get; set; }
    }

    public partial class GetTotalEarnedFunction : GetTotalEarnedFunctionBase { }

    [Function("getTotalEarned", typeof(GetTotalEarnedOutputDTO))]
    public class GetTotalEarnedFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "landId", 1)]
        public virtual BigInteger LandId { get; set; }
    }

    public partial class SupportsInterfaceFunction : SupportsInterfaceFunctionBase { }

    [Function("supportsInterface", "bool")]
    public class SupportsInterfaceFunctionBase : FunctionMessage
    {
        [Parameter("bytes4", "interfaceId", 1)]
        public virtual byte[] InterfaceId { get; set; }
    }

    public partial class SliceOutofboundsError : SliceOutofboundsErrorBase { }

    [Error("Slice_OutOfBounds")]
    public class SliceOutofboundsErrorBase : IErrorDTO
    {
        [Parameter("bytes", "data", 1)]
        public virtual byte[] Data { get; set; }
        [Parameter("uint256", "start", 2)]
        public virtual BigInteger Start { get; set; }
        [Parameter("uint256", "end", 3)]
        public virtual BigInteger End { get; set; }
    }

    public partial class MsgSenderOutputDTO : MsgSenderOutputDTOBase { }

    [FunctionOutput]
    public class MsgSenderOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "sender", 1)]
        public virtual string Sender { get; set; }
    }

    public partial class MsgValueOutputDTO : MsgValueOutputDTOBase { }

    [FunctionOutput]
    public class MsgValueOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "value", 1)]
        public virtual BigInteger Value { get; set; }
    }

    public partial class WorldOutputDTO : WorldOutputDTOBase { }

    [FunctionOutput]
    public class WorldOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GetActiveTablesOutputDTO : GetActiveTablesOutputDTOBase { }

    [FunctionOutput]
    public class GetActiveTablesOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetChairsOfTablesOutputDTO : GetChairsOfTablesOutputDTOBase { }

    [FunctionOutput]
    public class GetChairsOfTablesOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256[3]", "", 1)]
        public virtual List<BigInteger> ReturnValue1 { get; set; }
    }

    public partial class GetLandItemsOutputDTO : GetLandItemsOutputDTOBase { }

    [FunctionOutput]
    public class GetLandItemsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple[]", "landItems", 1)]
        public virtual List<LandItemDTO> LandItems { get; set; }
    }

    public partial class GetLandItems3dOutputDTO : GetLandItems3dOutputDTOBase { }

    [FunctionOutput]
    public class GetLandItems3dOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple[][][]", "land3d", 1)]
        public virtual List<List<List<LandItemDTO>>> Land3d { get; set; }
    }

    public partial class GetLandItems3dPagedOutputDTO : GetLandItems3dPagedOutputDTOBase { }

    [FunctionOutput]
    public class GetLandItems3dPagedOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple[][][]", "pagedLand3d", 1)]
        public virtual List<List<List<LandItemDTO>>> PagedLand3d { get; set; }
    }

    public partial class GetLandsTotalEarnedOutputDTO : GetLandsTotalEarnedOutputDTOBase { }

    [FunctionOutput]
    public class GetLandsTotalEarnedOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple[]", "playerTotalEarned", 1)]
        public virtual List<PlayerTotalEarnedDTO> PlayerTotalEarned { get; set; }
    }

    public partial class GetPlacementTimeOutputDTO : GetPlacementTimeOutputDTOBase { }

    [FunctionOutput]
    public class GetPlacementTimeOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetRotationOutputDTO : GetRotationOutputDTOBase { }

    [FunctionOutput]
    public class GetRotationOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class GetTablesOfChairsOutputDTO : GetTablesOfChairsOutputDTOBase { }

    [FunctionOutput]
    public class GetTablesOfChairsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256[3]", "", 1)]
        public virtual List<BigInteger> ReturnValue1 { get; set; }
    }

    public partial class GetTotalEarnedOutputDTO : GetTotalEarnedOutputDTOBase { }

    [FunctionOutput]
    public class GetTotalEarnedOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "playerTotalEarned", 1)]
        public virtual PlayerTotalEarnedDTO PlayerTotalEarned { get; set; }
    }

    public partial class SupportsInterfaceOutputDTO : SupportsInterfaceOutputDTOBase { }

    [FunctionOutput]
    public class SupportsInterfaceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }
}
