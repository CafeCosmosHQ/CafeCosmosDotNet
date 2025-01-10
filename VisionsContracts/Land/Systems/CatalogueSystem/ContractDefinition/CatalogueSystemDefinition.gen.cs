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

namespace VisionsContracts.Land.Systems.CatalogueSystem.ContractDefinition
{


    public partial class CatalogueSystemDeployment : CatalogueSystemDeploymentBase
    {
        public CatalogueSystemDeployment() : base(BYTECODE) { }
        public CatalogueSystemDeployment(string byteCode) : base(byteCode) { }
    }

    public class CatalogueSystemDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x60808060405234601557612108908161001a8239f35b5f80fdfe60806040526004361015610011575f80fd5b5f3560e01c806301ffc9a7146100b4578063119df25f146100af57806331f22edc146100aa57806345ec9354146100a5578063628b0735146100a057806391c174891461009b578063a1a2c23114610096578063c56bfe1314610091578063e1af802c1461008c5763ec8b981014610087575f80fd5b6103f7565b6103dd565b6103b2565b610334565b610264565b6101d4565b6101b5565b610172565b610116565b346101085760203660031901126101085760043563ffffffff60e01b81168091036101085763b5dee12760e01b81149081156100f7575b50151560805260206080f35b6301ffc9a760e01b149050816100eb565b5f80fd5b5f91031261010857565b34610108575f3660031901126101085760206101306107c7565b6040516001600160a01b039091168152f35b9181601f84011215610108578235916001600160401b038311610108576020808501948460061b01011161010857565b34610108576020366003190112610108576004356001600160401b038111610108576101ad6101a76020923690600401610142565b9061056f565b604051908152f35b34610108575f366003190112610108576020604051601f193601358152f35b34610108576020366003190112610108576004356001600160401b03811161010857366023820112156101085760048101356001600160401b038111610108573660248260071b8401011161010857602461022f92016105d1565b005b9060406003198301126101085760043591602435906001600160401b0382116101085761026091600401610142565b9091565b346101085761027236610231565b61027d8392936109b2565b50610288818461056f565b61029183610e7e565b106102ce575f5b8181106102a157005b806102c86102ba6102b56001948689610445565b6104b1565b602081519101519086610a92565b01610298565b60405162461bcd60e51b815260206004820152603160248201525f5160206120b35f395f51905f52604482015270746f207075726368617365206974656d7360781b6064820152608490fd5b606090600319011261010857600435906024359060443590565b34610108576103423661031a565b9061034c836109b2565b50610358828285610799565b50156103675761022f92610a92565b60405162461bcd60e51b815260206004820152603060248201525f5160206120b35f395f51905f5260448201526f746f207075726368617365206974656d60801b6064820152608490fd5b34610108576103c96103c33661031a565b91610799565b604080519215158352602083019190915290f35b34610108575f366003190112610108576020610130610e9b565b346101085761041c61041461040b36610231565b9092919261056f565b918291610e7e565b60408051929091101582526020820192909252f35b634e487b7160e01b5f52603260045260245ffd5b91908110156104555760061b0190565b610431565b634e487b7160e01b5f52604160045260245ffd5b608081019081106001600160401b0382111761048957604052565b61045a565b601f909101601f19168101906001600160401b0382119082101761048957604052565b604081360312610108576040805191908201906001600160401b0382118383101761048957602091604052803583520135602082015290565b156104f157565b60405162461bcd60e51b815260206004820152601e60248201527f436174616c6f6775653a206974656d20646f6573206e6f7420657869737400006044820152606490fd5b634e487b7160e01b5f52601160045260245ffd5b8181029291811591840414171561055d57565b610536565b9190820180921161055d57565b91905f925f915b80831061058257505050565b9091936105bd6105966102b5878587610445565b6020806105a383516108a6565b6105b2604082015115156104ea565b01519101519061054a565b810180911161055d57936001019190610576565b9190604051926020840193616e7360f01b85525f60228201525f6030820152602081526105ff60408261048e565b519351936020811061070a575b506106156107c7565b9361063385600160801b600160f01b038316616e7360f01b17611629565b80156106fa575b1561064d575061064b92935061071f565b565b8490608081901b6001600160801b031916906106ba90601081901b6001600160901b031916806106eb5750610680610fb5565b925b806106da57506106ac610693610fb5565b6040519485936001600160f01b03191660208501610feb565b03601f19810183528261048e565b6106d660405192839263d787b73760e01b845260048401610cf7565b0390fd5b6106e66106ac91611661565b610693565b6106f490611661565b92610682565b506107058582611629565b61063a565b5f949194199060200360031b1b16925f61060c565b90915f5b83811015610793578060071b83019060808236031261010857604051916107498361046e565b8035808452602082013580602086015260606040840135938460408801520135928315158403610108576107878461078d9560606001990152151590565b926108fb565b01610723565b50915050565b906107c29260206107ac610414936108a6565b6107bb604082015115156104ea565b015161054a565b101591565b36603319013560601c9081156107d957565b339150565b60405190606082016001600160401b03811183821017610489576040525f6040838281528260208201520152565b6001600160401b0381116104895760051b60200190565b60408051909190610834838261048e565b6001815291601f1901366020840137565b6040519061085460208361048e565b5f808352366020840137565b60405160609190610871838261048e565b6002815291601f1901366020840137565b8051600210156104555760600190565b80518210156104555760209160051b010190565b6108ae6107de565b506108b7610823565b805115610455576108cc916020820152610bfe565b50506108d66107de565b906020810151906060604082015191015160f81c151560408401526020830152815290565b9290916040519260208401526040830152151560f81b60608201526041815261092560618261048e565b61092d610823565b918251156104555760208301526001600160a01b0361094a610e9b565b169130830361095d5761064b9250611021565b90823b1561010857610988925f928360405180968195829463298314fb60e01b845260048401610d1f565b03925af180156109ad576109995750565b806109a75f61064b9361048e565b8061010c565b610bf3565b6109c26109bd610845565b61108f565b60601c6109d0811515610d7a565b6040516331a9108f60e11b81526004810183905290602090829060249082905afa9081156109ad575f91610a63575b50610a086107c7565b916001600160a01b03808416908316149083908215610a51575b505015610a30575050600190565b6334a0e31960e21b5f526001600160a01b039081166004521660245260445ffd5b610a5c925083610df9565b825f610a22565b610a85915060203d602011610a8b575b610a7d818361048e565b810190610dda565b5f6109ff565b503d610a73565b919091610a9d610860565b805115610455578160208201528051600110156104555780846040610ac393015261116e565b91820180921161055d57610ad5610860565b908151156104555760208201528051600110156104555761064b92604082015260405191602083015260208252610b0d60408361048e565b6113a8565b6001600160401b03811161048957601f01601f191660200190565b81601f8201121561010857805190610b4482610b12565b92610b52604051948561048e565b8284526020838301011161010857815f9260208093018386015e8301015290565b916060838303126101085782516001600160401b0381116101085782610b9a918501610b2d565b92602081015192604082015160018060401b03811161010857610bbd9201610b2d565b90565b90602080835192838152019201905f5b818110610bdd5750505090565b8251845260209384019390920191600101610bd0565b6040513d5f823e3d90fd5b6001600160a01b03610c0e610e9b565b16308103610c405750610c39906541030020200160c81b905f5160206120535f395f51905f52610ee1565b9192909190565b60405163419b58fd60e01b81525f5160206120535f395f51905f5260048201526060602482015292915f91849182908190610c7f906064830190610bc0565b6541030020200160c81b604483015203915afa9081156109ad575f5f935f93610ca9575b50929190565b91935050610cc991503d805f833e610cc1818361048e565b810190610b73565b929092915f610ca3565b805180835260209291819084018484015e5f828201840152601f01601f1916010190565b90610d0f602091949394604084526040840190610cd3565b6001600160a01b03909416910152565b90610bbd92610d56610d64926f436174616c6f6775654974656d000000613a3160f11b01855260a0602086015260a0850190610bc0565b908382036040850152610cd3565b905f606082015260808183039101526060610cd3565b15610d8157565b60405162461bcd60e51b815260206004820152602b60248201527f4c69624c616e644163636573733a206c616e644e46547320616464726573732060448201526a063616e6e6f7420626520360ac1b6064820152608490fd5b9081602091031261010857516001600160a01b03811681036101085790565b919060405192610e0a60808561048e565b60038452610e18600361080c565b602085019190601f1901368337845115610455576001600160a01b03169052825160011015610455576040830152610bbd91610e7891610e6b91906001600160a01b0316610e6582610882565b526111f2565b6001600160f81b03191690565b60f81c90565b610e86610823565b80511561045557610bbd91602082015261127e565b7f629a4c26e296b22a8e0856e9f6ecb2d1008d7e00081111962cd175fa7488e175546001600160a01b031680610bbd57503390565b60ff1660ff811461055d5760010190565b91925f9260609260ff610ef88760f01c8385611472565b9660e01c1680610f0757505050565b9194509250610f168385611b25565b549366ffffffffffffff851693610f45610f2f86610b12565b95610f3d604051978861048e565b808752610b12565b602086019590601f19013687379491865f935b8560ff861610610f6a57505050505050565b610fad9181610fa2610fa793610f9b89610f85818b8b6114d7565b9560ff64ffffffffff92166028026038011c1690565b8094611516565b610562565b93610ed0565b928790610f58565b60405190610fc460408361048e565b60068252651e3937b7ba1f60d11b6020830152565b805191908290602001825e015f815290565b610bbd939260036110139260019461ffff60f01b168152601d60f91b60028201520190610fd9565b601d60f91b81520190610fd9565b61064b916060905f906110405f5160206120535f395f51905f526116c1565b935f5160206120535f395f51905f526117cc565b90816020910312610108575190565b9061108460609360ff92979695978452608060208501526080840190610bc0565b951660408201520152565b6001600160a01b0361109f610e9b565b163081036110df5750610bbd906d3702c00505050505050505050505608a1b906004906f436f6e66696741646472657373657300613a3160f11b01611a50565b604051638c364d5960e01b815291602091839182908190611130906d3702c00505050505050505050505608a1b906004906f436f6e66696741646472657373657300613a3160f11b01828601611063565b03915afa9081156109ad575f91611145575090565b610bbd915060203d602011611167575b61115f818361048e565b810190611054565b503d611155565b6001600160a01b0361117e610e9b565b163081036111af5750610bbd90630100080160dd1b905f9068496e76656e746f727960381b613a3160f11b01611a50565b604051638c364d5960e01b81529160209183918290819061113090630100080160dd1b905f9068496e76656e746f727960381b613a3160f11b0160048601611063565b6001600160a01b03611202610e9b565b163081036112375750610bbd90630101000160d81b905f906f4c616e645065726d697373696f6e7300613a3160f11b01611a50565b604051638c364d5960e01b81529160209183918290819061113090630101000160d81b905f906f4c616e645065726d697373696f6e7300613a3160f11b0160048601611063565b6001600160a01b0361128e610e9b565b163081036112c75750610bbd906b072848090101010008210101609d1b90600690674c616e64496e666f60401b613a3160f11b01611a50565b604051638c364d5960e01b815291602091839182908190611130906b072848090101010008210101609d1b90600690674c616e64496e666f60401b613a3160f11b0160048601611063565b6001600160a01b03611322610e9b565b1630810361135c5750610bbd90630101000160d81b905f906f5265736f757263654163636573730000661d189ddbdc9b1960ca1b01611a50565b604051638c364d5960e01b81529160209183918290819061113090630101000160d81b905f906f5265736f757263654163636573730000661d189ddbdc9b1960ca1b0160048601611063565b6001600160a01b036113b8610e9b565b16913083036113ea5761064b9250630100080160dd1b915f9068496e76656e746f727960381b613a3160f11b01611ab8565b823b15610108576040516301c85d5760e51b815268496e76656e746f727960381b613a3160f11b01600482015260a06024820152925f928492839185918391611454919061143c9060a4850190610bc0565b90846044850152600319848303016064850152610cd3565b630100080160dd1b608483015203925af180156109ad576109995750565b919091811561148d57610bbd9261148891611ad4565b611b02565b50505060405161149e60208261048e565b5f815290565b60209181520160208251919201905f5b8181106114c15750505090565b82518452602093840193909201916001016114b4565b6106ac6114fe5f5160206120735f395f51905f5294936040519283916020830195866114a4565b51902060f89190911b6001600160f81b031916181890565b905b6020811015611541578061152b57505050565b5f199060031b1c90818351169119905416179052565b919060018160209254845201910191601f1901611518565b9190806115a5575b505b602081101561158d578061157657505050565b5f1960039190911b1c825191548119169116179052565b919060018160209254845201910191601f1901611563565b602081101561160d575b801561156157929183602003908183105f14611600575f19600384901b1c5b81548660031b1b81865116911916178452818311156115f957600101920192601f199101015f611561565b5050505050565b5f19600383901b1c6115ce565b916116249061161c8460051c90565b0192601f1690565b6115af565b611631610860565b90815115610455576020820152805160011015610455576001600160a01b039091166040820152610e7890611312565b5f5b60108110611694575b6040516001600160801b031990921660208301526010825261168f60308361048e565b815290565b6001600160801b03198216600382901b1b6001600160f81b031916156116bc57600101611663565b61166c565b655461626c657360501b66746273746f726560c81b0181146117295760408051655461626c657360501b66746273746f726560c81b01602082019081528183019390935290815261171360608261048e565b5190205f5160206120135f395f51905f52185490565b506503001811010160cd1b90565b90610bbd949261175261176092608085526080850190610bc0565b908382036020850152610cd3565b9260408201526060818403910152610cd3565b6001600160581b03191690565b969594906117c7936117a660a096946117b4938b5260c060208c015260c08b0190610bc0565b9089820360408b0152610cd3565b9160608801528682036080880152610cd3565b930152565b9295949192916001600160f01b03198316611bdd60f21b14611a28576117f183611b53565b5f5b81518110156118d05761181f61181a61180c8385610892565b516001600160581b03191690565b611773565b61182f816001809160581c161490565b61183d575b506001016117f3565b61186561186561185f61185261187194611773565b6001600160601b03191690565b60601c90565b6001600160a01b031690565b90813b15610108575f878b9387838a6118a28a8f6040519a8b98899788966315c19b2760e21b885260048801611780565b03925af19182156109ad576001926118bc575b5090611834565b806109a75f6118ca9361048e565b5f6118b5565b50835f5160206120335f395f51905f52604051806118f18a8d8b8a85611737565b0390a261190d6119018486611ad4565b86516020880191611c29565b60e082901c60ff16806119d4575b505f5b81518110156119c95761193761181a61180c8385610892565b611947816002809160581c161490565b611955575b5060010161191e565b61186561186561185f61185261196a94611773565b90813b15610108575f878b9387838a61199b8a8f6040519a8b9889978896635b28cdaf60e01b885260048801611780565b03925af19182156109ad576001926119b5575b509061194c565b806109a75f6119c39361048e565b5f6119ae565b505050505050509050565b886119df8587611b25565b555f602088015b85878c8560ff8616106119fd57505050505061191b565b83610fa260ff95611a1888610f8581600199611a1f996114d7565b8094611c29565b920116906119e6565b509093945f5160206120335f395f51905f5293611a4b9160405194859485611737565b0390a2565b611a7691611a6091949394611ad4565b9260ff808216601b0360031b84901c1692611d27565b91806020841015611aa7575b5080548360031b1b92602003809211611a9a57505090565b600101549060031b1c1790565b601f84169360051c0190505f611a82565b91611acd65ffffffffffff9161064b96611d27565b1691611dcf565b90611aed6106ac916040519283916020830195866114a4565b5190205f5160206120135f395f51905f521890565b610bbd9060405192601f19603f82860101166040528084525f6020850192611559565b90611b3e6106ac916040519283916020830195866114a4565b5190205f5160206120935f395f51905f521890565b611b5b610823565b908151156104555781611c10916020610bbd940152611c0a5f5160206120735f395f51905f526040516020810190611bb1816106ac876953746f7265486f6f6b7360301b66746273746f726560c81b01866114a4565b519020604051911892602082019190611bea9082906106ac906953746f7265486f6f6b7360301b66746273746f726560c81b01866114a4565b5190205f5160206120935f395f51905f52185460381c64ffffffffff1690565b90611b02565b80516001600160801b0316602090910160801b17611f93565b91905b6020811015611c555780611c3f57505050565b5f199060031b1c90818354169119905116179055565b909160016020918451815501920190601f1901611c2c565b92919080611cba575b505b6020811015611ca25780611c8b57505050565b5f1960039190911b1c825491518119169116179055565b909160016020918451815501920190601f1901611c78565b6020811015611d0b575b8015611c765791926020839003905f19600384901b1c198460031b90811c908651901c9080198354169116178155818311156115f95760010193019101601f19015f611c76565b92611d2290611d1a8560051c90565b0193601f1690565b611cc4565b5f915f915b60ff82168310611d3c5750505090565b909192611d52848360ff91601b0360031b1c1690565b810180911161055d57926001019190611d2c565b65ffffffffffff611d83610bbd9593606084526060840190610bc0565b931660208201526040818403910152610cd3565b90611dbb610bbd959365ffffffffffff928452608060208501526080840190610bc0565b931660408201526060818403910152610cd3565b92939291906001600160f01b03198316611bdd60f21b14611f7357611df48184611ad4565b93611dfe84611b53565b90865f5b8351811015611e9c57611e1b61181a61180c8387610892565b611e2b816004809160581c161490565b611e39575b50600101611e02565b60601c9150813b15610108575f868a9387838b611e6c6040519889968795869463964f667d60e01b865260048601611d97565b03925af19081156109ad578992600192611e88575b5090611e30565b806109a75f611e969361048e565b5f611e81565b50611ed39196865f516020611ff35f395f51905f5260405180611ec1868b8b84611d66565b0390a265ffffffffffff861690611fe1565b5f5b8151811015611f6a57611eee61181a61180c8385610892565b611efe816008809160581c161490565b611f0c575b50600101611ed5565b60601c90813b156101085760405163a8ba872160e01b8152915f908390818381611f3c8e8c8c8f60048601611d97565b03925af19182156109ad57600192611f56575b5090611f03565b806109a75f611f649361048e565b5f611f4f565b50505050509050565b611a4b5f516020611ff35f395f51905f5293949560405193849384611d66565b60158160801c9160018060801b031604604051916020830160208360051b8501016040528284525f5b838110611fca575050505090565b602060016015928551855201920192019190611fbc565b825161064b93602001929091611c6d56fe8c0b5119d4cec7b284c6b1b39252a03d1e2f2d7451a5895562524c113bb952be86425bff6b57326c7859e89024fe4f238ca327a1ae4a230180dd2f0e88aaa7d98dbb3a9672eebfd3773e72dd9c102393436816d832c7ba9e1e1ac8fcadcac7a974620000000000000000000000000000436174616c6f6775654974656d0000003b4102da22e32d82fc925482184f16c09fd4281692720b87d124aef6da48a0f114e2fcc58e58e68ec7edc30c8d50dccc3ce2714a623ec81f46b6a63922d76569436174616c6f6775653a20696e73756666696369656e742062616c616e636520a2646970667358221220e025120ad5851d2ea86087a0cd05cf6426eceeccc4e9e6c993c03e594bc55e0464736f6c634300081c0033";
        public CatalogueSystemDeploymentBase() : base(BYTECODE) { }
        public CatalogueSystemDeploymentBase(string byteCode) : base(byteCode) { }

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

    public partial class GetTotalCostFunction : GetTotalCostFunctionBase { }

    [Function("getTotalCost", "uint256")]
    public class GetTotalCostFunctionBase : FunctionMessage
    {
        [Parameter("tuple[]", "items", 1)]
        public virtual List<CatalogueItemPurchaseDTO> Items { get; set; }
    }

    public partial class GetTotalCostAndSufficientBalanceToPurchaseItemFunction : GetTotalCostAndSufficientBalanceToPurchaseItemFunctionBase { }

    [Function("getTotalCostAndSufficientBalanceToPurchaseItem", typeof(GetTotalCostAndSufficientBalanceToPurchaseItemOutputDTO))]
    public class GetTotalCostAndSufficientBalanceToPurchaseItemFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "landId", 1)]
        public virtual BigInteger LandId { get; set; }
        [Parameter("uint256", "itemId", 2)]
        public virtual BigInteger ItemId { get; set; }
        [Parameter("uint256", "quantity", 3)]
        public virtual BigInteger Quantity { get; set; }
    }

    public partial class GetTotalCostAndSufficientBalanceToPurchaseItemsFunction : GetTotalCostAndSufficientBalanceToPurchaseItemsFunctionBase { }

    [Function("getTotalCostAndSufficientBalanceToPurchaseItems", typeof(GetTotalCostAndSufficientBalanceToPurchaseItemsOutputDTO))]
    public class GetTotalCostAndSufficientBalanceToPurchaseItemsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "landId", 1)]
        public virtual BigInteger LandId { get; set; }
        [Parameter("tuple[]", "items", 2)]
        public virtual List<CatalogueItemPurchaseDTO> Items { get; set; }
    }

    public partial class PurchaseCatalogueItemFunction : PurchaseCatalogueItemFunctionBase { }

    [Function("purchaseCatalogueItem")]
    public class PurchaseCatalogueItemFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "landId", 1)]
        public virtual BigInteger LandId { get; set; }
        [Parameter("uint256", "itemId", 2)]
        public virtual BigInteger ItemId { get; set; }
        [Parameter("uint256", "quantity", 3)]
        public virtual BigInteger Quantity { get; set; }
    }

    public partial class PurchaseCatalogueItemsFunction : PurchaseCatalogueItemsFunctionBase { }

    [Function("purchaseCatalogueItems")]
    public class PurchaseCatalogueItemsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "landId", 1)]
        public virtual BigInteger LandId { get; set; }
        [Parameter("tuple[]", "items", 2)]
        public virtual List<CatalogueItemPurchaseDTO> Items { get; set; }
    }

    public partial class SupportsInterfaceFunction : SupportsInterfaceFunctionBase { }

    [Function("supportsInterface", "bool")]
    public class SupportsInterfaceFunctionBase : FunctionMessage
    {
        [Parameter("bytes4", "interfaceId", 1)]
        public virtual byte[] InterfaceId { get; set; }
    }

    public partial class UpsertCatalogueItemsFunction : UpsertCatalogueItemsFunctionBase { }

    [Function("upsertCatalogueItems")]
    public class UpsertCatalogueItemsFunctionBase : FunctionMessage
    {
        [Parameter("tuple[]", "items", 1)]
        public virtual List<CatalogueItemDTO> Items { get; set; }
    }

    public partial class StoreSetrecordEventDTO : StoreSetrecordEventDTOBase { }

    [Event("Store_SetRecord")]
    public class StoreSetrecordEventDTOBase : IEventDTO
    {
        [Parameter("bytes32", "tableId", 1, true )]
        public virtual byte[] TableId { get; set; }
        [Parameter("bytes32[]", "keyTuple", 2, false )]
        public virtual List<byte[]> KeyTuple { get; set; }
        [Parameter("bytes", "staticData", 3, false )]
        public virtual byte[] StaticData { get; set; }
        [Parameter("bytes32", "encodedLengths", 4, false )]
        public virtual byte[] EncodedLengths { get; set; }
        [Parameter("bytes", "dynamicData", 5, false )]
        public virtual byte[] DynamicData { get; set; }
    }

    public partial class StoreSplicestaticdataEventDTO : StoreSplicestaticdataEventDTOBase { }

    [Event("Store_SpliceStaticData")]
    public class StoreSplicestaticdataEventDTOBase : IEventDTO
    {
        [Parameter("bytes32", "tableId", 1, true )]
        public virtual byte[] TableId { get; set; }
        [Parameter("bytes32[]", "keyTuple", 2, false )]
        public virtual List<byte[]> KeyTuple { get; set; }
        [Parameter("uint48", "start", 3, false )]
        public virtual ulong Start { get; set; }
        [Parameter("bytes", "data", 4, false )]
        public virtual byte[] Data { get; set; }
    }

    public partial class AccessByNoOperatorError : AccessByNoOperatorErrorBase { }

    [Error("AccessByNoOperator")]
    public class AccessByNoOperatorErrorBase : IErrorDTO
    {
        [Parameter("address", "owner", 1)]
        public virtual string Owner { get; set; }
        [Parameter("address", "caller", 2)]
        public virtual string Caller { get; set; }
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

    public partial class WorldAccessdeniedError : WorldAccessdeniedErrorBase { }

    [Error("World_AccessDenied")]
    public class WorldAccessdeniedErrorBase : IErrorDTO
    {
        [Parameter("string", "resource", 1)]
        public virtual string Resource { get; set; }
        [Parameter("address", "caller", 2)]
        public virtual string Caller { get; set; }
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

    public partial class GetTotalCostOutputDTO : GetTotalCostOutputDTOBase { }

    [FunctionOutput]
    public class GetTotalCostOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "totalCost", 1)]
        public virtual BigInteger TotalCost { get; set; }
    }

    public partial class GetTotalCostAndSufficientBalanceToPurchaseItemOutputDTO : GetTotalCostAndSufficientBalanceToPurchaseItemOutputDTOBase { }

    [FunctionOutput]
    public class GetTotalCostAndSufficientBalanceToPurchaseItemOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "sufficient", 1)]
        public virtual bool Sufficient { get; set; }
        [Parameter("uint256", "totalCost", 2)]
        public virtual BigInteger TotalCost { get; set; }
    }

    public partial class GetTotalCostAndSufficientBalanceToPurchaseItemsOutputDTO : GetTotalCostAndSufficientBalanceToPurchaseItemsOutputDTOBase { }

    [FunctionOutput]
    public class GetTotalCostAndSufficientBalanceToPurchaseItemsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "sufficient", 1)]
        public virtual bool Sufficient { get; set; }
        [Parameter("uint256", "totalCost", 2)]
        public virtual BigInteger TotalCost { get; set; }
    }





    public partial class SupportsInterfaceOutputDTO : SupportsInterfaceOutputDTOBase { }

    [FunctionOutput]
    public class SupportsInterfaceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }


}
