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

namespace VisionsContracts.Land.Systems.LandTablesAndChairsContract.ContractDefinition
{


    public partial class LandTablesAndChairsContractDeployment : LandTablesAndChairsContractDeploymentBase
    {
        public LandTablesAndChairsContractDeployment() : base(BYTECODE) { }
        public LandTablesAndChairsContractDeployment(string byteCode) : base(byteCode) { }
    }

    public class LandTablesAndChairsContractDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x60808060405234601557612309908161001a8239f35b5f80fdfe60806040526004361015610011575f80fd5b5f3560e01c8063124964d91461003457639aa3d5cd1461002f575f80fd5b610166565b346101445761004236610148565b9161004f81949294610505565b1561006157509161005f92610650565b005b61006a90610528565b61007057005b61007b828483610df5565b90600160408301511461008a57005b6100e461005f9461009d84519460200190565b51946100c46100ad878787610e5d565b838151149081610136575b81610127575b50610545565b6100ce606061044d565b915f83525f60208401525f604084015284610eb3565b6101086100f1606061044d565b5f81525f60208201525f6040820152848484610f8a565b61012261011c6101178361103f565b6105c4565b8261105c565b61071a565b600191506040015114896100be565b6020810151841491506100b8565b5f80fd5b60809060031901126101445760043590602435906044359060643590565b346101445761017436610148565b919261017f84610505565b1561018e5761005f935061071a565b919261019990610528565b61019f57005b6101a8826110fd565b6101b18361111a565b906101bb836106ff565b10806103fb575b806103e3575b15610243575061022c9061005f936102036101e3606061044d565b6101ec846106ff565b815282602082015260016040820152828487610eb3565b61020c826106ff565b610216606061044d565b9283528160208401526001604084015284610f8a565b61023d6102388261103f565b6106ff565b9061105c565b811515806103c7575b806103a9575b1561027f575061022c9061005f9361027661026d606061044d565b6101ec846105c4565b61020c826105c4565b610288846106ff565b1080610394575b8061037d575b156102f95761005f9261022c916102cf6102af606061044d565b8281526102bb846106ff565b602082015260016040820152838387610eb3565b6102d8826106ff565b906102e3606061044d565b9281845260208401526001604084015284610f8a565b8215158061035c575b80610338575b61030e57005b61005f9261022c9161032f610323606061044d565b8281526102bb846105c4565b6102d8826105c4565b5061035561034f610348856105c4565b8385610e5d565b60400190565b5115610308565b5061037861037361036c856105c4565b8385611137565b610505565b610302565b5061038d61034f610348856106ff565b5115610295565b506103a461037361036c856106ff565b61028f565b506103c061034f856103ba856105c4565b86610e5d565b5115610252565b506103de610373856103d8856105c4565b86611137565b61024c565b506103f461034f856103ba856106ff565b51156101c8565b5061040c610373856103d8856106ff565b6101c2565b634e487b7160e01b5f52604160045260245ffd5b601f909101601f19168101906001600160401b0382119082101761044857604052565b610411565b9061045b6040519283610425565b565b6001600160401b0381116104485760051b60200190565b604080519091906104858382610425565b6001815291601f1901366020840137565b604051608091906104a78382610425565b6003815291601f1901366020840137565b634e487b7160e01b5f52603260045260245ffd5b8051600210156104dc5760600190565b6104b8565b8051600310156104dc5760800190565b80518210156104dc5760209160051b010190565b61050d610474565b8051156104dc576105229160208201526109e0565b60f81c90565b610530610474565b8051156104dc57610522916020820152610aba565b1561054c57565b60405162461bcd60e51b815260206004820152603660248201527f6368616972734f665461626c65732068617320646966666572656e7420636f6f604482015275393234b730ba32b9903337b9103a34329031b430b4b960511b6064820152608490fd5b634e487b7160e01b5f52601160045260245ffd5b5f198101919082116105d257565b6105b0565b919082039182116105d257565b156105eb57565b60405162461bcd60e51b815260206004820152603760248201527f7461626c65734f6643686169727320686173206120646966666572656e7420636044820152766f6f7264696e61746520666f7220746865207461626c6560481b6064820152608490fd5b9061065c838284610e5d565b600160408201511461066f575b50505050565b6106d9936100c46106cd9361068684519460200190565b51926106ad61069685878a610df5565b8381511490816106f1575b816106e2575b506105e4565b6106b7606061044d565b915f83525f60208401525f604084015287610f8a565b61023d6101178261103f565b5f808080610669565b6001915060400151145f6106a7565b6020810151841491506106a1565b90600182018092116105d257565b919082018092116105d257565b90610724826110fd565b61072d8361111a565b90610737836106ff565b1080610951575b80610939575b156107a8575061022c9061045b9361077f61075f606061044d565b610768846106ff565b815282602082015260016040820152828487610f8a565b610788826106ff565b610792606061044d565b9283528160208401526001604084015284610eb3565b81151580610923575b80610905575b156107e4575061022c9061045b936107db6107d2606061044d565b610768846105c4565b610788826105c4565b6107ed846106ff565b10806108f0575b806108d9575b1561085e5761045b9261022c91610834610814606061044d565b828152610820846106ff565b602082015260016040820152838387610f8a565b61083d826106ff565b90610848606061044d565b9281845260208401526001604084015284610eb3565b821515806108bf575b806108a1575b610877575b505050565b61045b9261022c9161089861088c606061044d565b828152610820846105c4565b61083d826105c4565b506108b861034f6108b1856105c4565b8385610df5565b511561086d565b506108d46108cf61036c856105c4565b610528565b610867565b506108e961034f6108b1856106ff565b51156107fa565b506109006108cf61036c856106ff565b6107f4565b5061091c61034f85610916856105c4565b86610df5565b51156107b7565b506109346108cf856103d8856105c4565b6107b1565b5061094a61034f85610916856106ff565b5115610744565b506109626108cf856103d8856106ff565b61073e565b90816020910312610144575190565b90602080835192838152019201905f5b8181106109935750505090565b8251845260209384019390920191600101610986565b906109ca60609360ff92979695978452608060208501526080840190610976565b951660408201520152565b6040513d5f823e3d90fd5b6001600160a01b036109f0611212565b16308103610a2c5750610a29906b033048000808080808090101609d1b90600390674974656d496e666f60401b613a3160f11b01611247565b90565b604051638c364d5960e01b815291602091839182908190610a77906b033048000808080808090101609d1b90600390674974656d496e666f60401b613a3160f11b01600486016109a9565b03915afa908115610ab5575f91610a8c575090565b610a29915060203d602011610aae575b610aa68183610425565b810190610967565b503d610a9c565b6109d5565b6001600160a01b03610aca611212565b16308103610b035750610a29906b033048000808080808090101609d1b90600490674974656d496e666f60401b613a3160f11b01611247565b604051638c364d5960e01b815291602091839182908190610a77906b033048000808080808090101609d1b90600490674974656d496e666f60401b613a3160f11b018286016109a9565b6001600160a01b03610b5d611212565b16308103610b915750610a29906b072848090101010008210101609d1b906002905f5160206122b45f395f51905f52611247565b604051638c364d5960e01b815291602091839182908190610a77906b072848090101010008210101609d1b906002905f5160206122b45f395f51905f52600486016109a9565b6001600160a01b03610be7611212565b16308103610c1a5750610a29906b072848090101010008210101609d1b905f905f5160206122b45f395f51905f52611247565b604051638c364d5960e01b815291602091839182908190610a77906b072848090101010008210101609d1b905f905f5160206122b45f395f51905f52600486016109a9565b6001600160a01b03610c6f611212565b16308103610ca35750610a29906b072848090101010008210101609d1b906001905f5160206122b45f395f51905f52611247565b604051638c364d5960e01b815291602091839182908190610a77906b072848090101010008210101609d1b906001905f5160206122b45f395f51905f52600486016109a9565b6001600160a01b03610cf9611212565b16308103610d295750610a2990630100800160d91b905f906713185b9910d95b1b60421b613a3160f11b01611247565b604051638c364d5960e01b815291602091839182908190610a7790630100800160d91b905f906713185b9910d95b1b60421b613a3160f11b01600486016109a9565b6001600160a01b03610d7b611212565b16308103610daf5750610a299067810500202020200160b81b905f90674c616e644974656d60401b613a3160f11b01611247565b604051638c364d5960e01b815291602091839182908190610a779067810500202020200160b81b905f90674c616e644974656d60401b613a3160f11b01600486016109a9565b90916060604051610e068282610425565b369037610e11610496565b918251156104dc5760208301528151600110156104dc57610e4b82610e5392610a29956040610e58960152610e45826104cc565b52611320565b8051906114e8565b61182c565b611538565b90916060604051610e6e8282610425565b369037610e79610496565b918251156104dc5760208301528151600110156104dc57610e4b82610e5392610a29956040610e58960152610ead826104cc565b526113c9565b929190610ebe610496565b938451156104dc5760208501528351600110156104dc5760408401528251600210156104dc57610efb91610ef6916060850152611563565b611589565b906001600160a01b03610f0c611212565b16308103610f30575061045b91906001905f5160206122945f395f51905f526118c6565b91823b15610144576040516377b7543160e11b8152925f928492839185918391610f6f91906001905f5160206122945f395f51905f52600486016115ec565b03925af18015610ab557610f805750565b5f61045b91610425565b929190610f95610496565b938451156104dc5760208501528351600110156104dc5760408401528251600210156104dc57610fcd91610ef6916060850152611563565b5f6001600160a01b03610fde611212565b1692308403610fff5761045b93505f5160206122945f395f51905f526118c6565b919050823b15610144576040516377b7543160e11b8152925f928492839185918391610f6f919084905f5160206122945f395f51905f52600486016115ec565b611047610474565b8051156104dc57610a29916020820152610b4d565b90611065610474565b918251156104dc5760208301526040519060208201526020815261108a604082610425565b6001600160a01b0361109a611212565b16913083036110ad5761045b9250611c18565b90823b15610144576110d8925f92836040518096819582946301c85d5760e51b84526004840161161f565b03925af18015610ab5576110e95750565b806110f75f61045b93610425565b806115e2565b611105610474565b8051156104dc57610a29916020820152610bd7565b611122610474565b8051156104dc57610a29916020820152610c5f565b9091806111438361111a565b1180611201575b806111cb575b1561118b5761116a61116382858561167b565b61ffff1690565b9283156111835761117d610a29946105c4565b926116c4565b505050505f90565b60405162461bcd60e51b81526020600482015260186024820152776765744974656d41743a204f7574206f6620626f756e647360401b6044820152606490fd5b506111d4610474565b8051156104dc576111fa826111f5610e53610e4b858860208b980152611454565b6104f1565b5111611150565b508261120c836110fd565b1161114a565b7f629a4c26e296b22a8e0856e9f6ecb2d1008d7e00081111962cd175fa7488e175546001600160a01b031680610a2957503390565b61126d916112579194939461175c565b9260ff808216601b0360031b84901c16926117ab565b9180602084101561129e575b5080548360031b1b9260200380921161129157505090565b600101549060031b1c1790565b601f84169360051c0190505f611279565b602081830312610144578051906001600160401b038211610144570181601f82011215610144578051906001600160401b03821161044857604051926112ff601f8401601f191660200185610425565b8284526020838301011161014457815f9260208093018386015e8301015290565b6001600160a01b03611330611212565b163081036113535750610a29906001905f5160206122945f395f51905f526117ea565b604051631e78897760e01b81525f5160206122945f395f51905f52600482015260606024820152915f91839182908190611391906064830190610976565b6001604483015203915afa908115610ab5575f916113ad575090565b610a2991503d805f833e6113c18183610425565b8101906112af565b6001600160a01b036113d9611212565b163081036113fb5750610a29905f905f5160206122945f395f51905f526117ea565b604051631e78897760e01b81525f5160206122945f395f51905f52600482015260606024820152915f91839182908190611439906064830190610976565b85604483015203915afa908115610ab5575f916113ad575090565b6001600160a01b03611464611212565b163081036114865750610a29905f905f5160206122b45f395f51905f526117ea565b604051631e78897760e01b81525f5160206122b45f395f51905f52600482015260606024820152915f91839182908190611439906064830190610976565b805180835260209291819084018484015e5f828201840152601f01601f1916010190565b805182116115035760200160801b9060018060801b03161790565b6040516323230fa360e01b8152606060048201529182916115289060648401906114c4565b905f602484015260448301520390fd5b604051611546606082610425565b60603682379060038151105f1461155b575090565b602091500190565b9061045b604051611575608082610425565b600381526020810190606036833793611887565b80518060051b90808204602014811517156105d25790604051926020840191601f19603f8287010116604052845260205f9101905b8381106115cc575050505090565b60206001819284518652019201920191906115be565b5f91031261014457565b9061160b610a29959360ff928452608060208501526080840190610976565b9316604082015260608184039101526114c4565b929161164e61166392674c616e64496e666f60401b613a3160f11b01865260a0602087015260a0860190610976565b906002604086015284820360608601526114c4565b9160806b072848090101010008210101609d1b910152565b9190611685610496565b928351156104dc5760208401528251600110156104dc5760408301528151600210156104dc57816116bd91606061ffff940152610ce9565b60f01c1690565b919290604051926116d660a085610425565b600484526116e4600461045d565b6020850190601f19013682378451156104dc57528251600110156104dc5760408301528151600210156104dc57610a29926060830152611723826104e1565b52610d6b565b60209181520160208251919201905f5b8181106117465750505090565b8251845260209384019390920191600101611739565b9061178361177591604051928391602083019586611729565b03601f198101835282610425565b5190207f86425bff6b57326c7859e89024fe4f238ca327a1ae4a230180dd2f0e88aaa7d91890565b5f915f915b60ff821683106117c05750505090565b9091926117d6848360ff91601b0360031b1c1690565b81018091116105d2579260010191906117b0565b9161180d90611807610a2993611801838288611c53565b95611fe0565b54611ca5565b9160405192601f19603f82860101166040528084526020840191612021565b6040805160206020600160801b0384168201810190925260016001607b1b03600584901c16808252909392909160809190911c9084015f5b8381106118715750505050565b6020600181928551855201920192019190611864565b60605b60208110156118af578015610872575f199060031b1c90818351169119905116179052565b8151835260209283019290910190601f190161188a565b9190916118d38382611fe0565b54926118df8385611ca5565b64ffffffffff8116969095906145cf60f11b6001600160f01b0319851601611bd05761191661190e89896105d7565b83519061070d565b8088141580988199611bb0575b50611b8c57611933908688612064565b9061193d856120dd565b915f5b8351811015611a1e5761196c61196761195983876104f1565b516001600160581b03191690565b611cf2565b61197c816010809160581c161490565b61198a575b50600101611940565b6119b26119b26119ac61199f6119be94611cf2565b6001600160601b03191690565b60601c90565b6001600160a01b031690565b90813b15610144575f898d9389838c8f8c6119f0916040519a8b9889978896630abd6b4560e31b885260048801611cff565b03925af1918215610ab557600192611a0a575b5090611981565b806110f75f611a1893610425565b5f611a03565b5096859098919884898c5f935f9060ff8d16905b8160ff841610611b635750505065ffffffffffff927ffe158a7adba34e256807c8a149028d3162918713c3838afc643ce9f96716ebfd9492611a7e928d60405196879616908d87611d4c565b0390a2611b52575b611a9a82611a95878688611c53565b612194565b5f5b8151811015611b4757611ab561196761195983856104f1565b611ac5816020809160581c161490565b611ad3575b50600101611a9c565b6119b26119b26119ac61199f611ae894611cf2565b90813b15610144575f878b9387838a611b198a8f6040519a8b9889978896636358453360e01b885260048801611cff565b03925af1918215610ab557600192611b33575b5090611aca565b806110f75f611b4193610425565b5f611b2c565b505050505050509050565b85611b5d8486611fe0565b55611a86565b94509490955060ff925060019150611b7b8685611ca5565b019401168c8b918a95948994611a32565b632994042d60e21b5f90815260045264ffffffffff8916602481905260445260645ffd5b9050611bc8611bbe8b611cdc565b64ffffffffff1690565b14155f611923565b8360405190611bf882611bea836020830160209181520190565b03601f198101845283610425565b611c146040519283926331b4668360e01b845260048401611cba565b0390fd5b61045b919065ffffffffffff611c3e60026b072848090101010008210101609d1b6117ab565b16905f5160206122b45f395f51905f52611df1565b611775611c8d7f3b4102da22e32d82fc925482184f16c09fd4281692720b87d124aef6da48a0f19493604051928391602083019586611729565b51902060f89190911b6001600160f81b031916181890565b60ff64ffffffffff92166028026038011c1690565b606090610a299392613a3160f11b8252602082015281604082015201906114c4565b64ffffffffff169064ffffffffff82116105d257565b6001600160581b03191690565b9294919360ff611d27610a29989664ffffffffff94875260e0602088015260e0870190610976565b961660408501525f606085015216608083015260a082015260c08184039101526114c4565b929365ffffffffffff610a29979560ff611d7764ffffffffff9599969960c0895260c0890190610976565b98166020870152166040850152166060830152608082015260a08184039101526114c4565b65ffffffffffff611db9610a299593606084526060840190610976565b9316602082015260408184039101526114c4565b9061160b610a29959365ffffffffffff928452608060208501526080840190610976565b92939291906001600160f01b03198316611bdd60f21b14611fbb57611e16818461175c565b93611e20846120dd565b90865f5b8351811015611ed257611e3d61196761195983876104f1565b611e4d816004809160581c161490565b611e5b575b50600101611e24565b611e739192506119b26119ac61199f6119b293611cf2565b90813b15610144575f868a9387838b611ea26040519889968795869463964f667d60e01b865260048601611dcd565b03925af1908115610ab5578992600192611ebe575b5090611e52565b806110f75f611ecc93610425565b5f611eb7565b50611f099196865f5160206122745f395f51905f5260405180611ef7868b8b84611d9c565b0390a265ffffffffffff8616906121a5565b5f5b8151811015611fb257611f2461196761195983856104f1565b611f34816008809160581c161490565b611f42575b50600101611f0b565b6119b26119b26119ac61199f611f5794611cf2565b90813b156101445760405163a8ba872160e01b8152915f908390818381611f848e8c8c8f60048601611dcd565b03925af1918215610ab557600192611f9e575b5090611f39565b806110f75f611fac93610425565b5f611f97565b50505050509050565b611fdb5f5160206122745f395f51905f5293949560405193849384611d9c565b0390a2565b90611ff961177591604051928391602083019586611729565b5190207f14e2fcc58e58e68ec7edc30c8d50dccc3ce2714a623ec81f46b6a63922d765691890565b905b602081101561204c578061203657505050565b5f199060031b1c90818351169119905416179052565b919060018160209254845201910191601f1901612023565b9064ffffffffff83116120ca5764ffffffffff8060ff66ffffffffffffff85168061208f8688611ca5565b90888281106120bd5790500301935b166028026038019416841b931b199166ffffffffffffff191617161790565b919092500390039361209e565b82637149a3c160e01b5f5260045260245ffd5b6120e5610474565b8051156104dc57602081019190915261214690610e4b61180d5f61180761212682866953746f7265486f6f6b7360301b66746273746f726560c81b01611c53565b946953746f7265486f6f6b7360301b66746273746f726560c81b01611fe0565b60158160801c9160018060801b031604604051916020830160208360051b8501016040528284525f5b83811061217d575050505090565b60206001601592855185520192019201919061216f565b61045b915f602082519201926121b2565b825161045b936020019290915b929190806121ff575b505b60208110156121e757806121d057505050565b5f1960039190911b1c825491518119169116179055565b909160016020918451815501920190601f19016121bd565b6020811015612257575b80156121bb5791926020839003905f19600384901b1c198460031b90811c908651901c9080198354169116178155818311156122505760010193019101601f19015f6121bb565b5050505050565b9261226e906122668560051c90565b0193601f1690565b61220956fe8c0b5119d4cec7b284c6b1b39252a03d1e2f2d7451a5895562524c113bb952be746200000000000000000000000000004c616e645461626c6573416e64436861746200000000000000000000000000004c616e64496e666f0000000000000000a2646970667358221220f68d89768688b94ec526005d15ab7a81a523592503ab1f201f16e965cdeb954964736f6c634300081c0033";
        public LandTablesAndChairsContractDeploymentBase() : base(BYTECODE) { }
        public LandTablesAndChairsContractDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class CheckPlaceTableOrChairFunction : CheckPlaceTableOrChairFunctionBase { }

    [Function("checkPlaceTableOrChair")]
    public class CheckPlaceTableOrChairFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "landId", 1)]
        public virtual BigInteger LandId { get; set; }
        [Parameter("uint256", "itemId", 2)]
        public virtual BigInteger ItemId { get; set; }
        [Parameter("uint256", "x", 3)]
        public virtual BigInteger X { get; set; }
        [Parameter("uint256", "y", 4)]
        public virtual BigInteger Y { get; set; }
    }

    public partial class CheckRemoveTableOrChairFunction : CheckRemoveTableOrChairFunctionBase { }

    [Function("checkRemoveTableOrChair")]
    public class CheckRemoveTableOrChairFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "landId", 1)]
        public virtual BigInteger LandId { get; set; }
        [Parameter("uint256", "itemId", 2)]
        public virtual BigInteger ItemId { get; set; }
        [Parameter("uint256", "x", 3)]
        public virtual BigInteger X { get; set; }
        [Parameter("uint256", "y", 4)]
        public virtual BigInteger Y { get; set; }
    }

    public partial class StoreSplicedynamicdataEventDTO : StoreSplicedynamicdataEventDTOBase { }

    [Event("Store_SpliceDynamicData")]
    public class StoreSplicedynamicdataEventDTOBase : IEventDTO
    {
        [Parameter("bytes32", "tableId", 1, true )]
        public virtual byte[] TableId { get; set; }
        [Parameter("bytes32[]", "keyTuple", 2, false )]
        public virtual List<byte[]> KeyTuple { get; set; }
        [Parameter("uint8", "dynamicFieldIndex", 3, false )]
        public virtual byte DynamicFieldIndex { get; set; }
        [Parameter("uint48", "start", 4, false )]
        public virtual ulong Start { get; set; }
        [Parameter("uint40", "deleteCount", 5, false )]
        public virtual ulong DeleteCount { get; set; }
        [Parameter("bytes32", "encodedLengths", 6, false )]
        public virtual byte[] EncodedLengths { get; set; }
        [Parameter("bytes", "data", 7, false )]
        public virtual byte[] Data { get; set; }
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

    public partial class EncodedlengthsInvalidlengthError : EncodedlengthsInvalidlengthErrorBase { }

    [Error("EncodedLengths_InvalidLength")]
    public class EncodedlengthsInvalidlengthErrorBase : IErrorDTO
    {
        [Parameter("uint256", "length", 1)]
        public virtual BigInteger Length { get; set; }
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

    public partial class StoreIndexoutofboundsError : StoreIndexoutofboundsErrorBase { }

    [Error("Store_IndexOutOfBounds")]
    public class StoreIndexoutofboundsErrorBase : IErrorDTO
    {
        [Parameter("uint256", "length", 1)]
        public virtual BigInteger Length { get; set; }
        [Parameter("uint256", "accessedIndex", 2)]
        public virtual BigInteger AccessedIndex { get; set; }
    }

    public partial class StoreInvalidresourcetypeError : StoreInvalidresourcetypeErrorBase { }

    [Error("Store_InvalidResourceType")]
    public class StoreInvalidresourcetypeErrorBase : IErrorDTO
    {
        [Parameter("bytes2", "expected", 1)]
        public virtual byte[] Expected { get; set; }
        [Parameter("bytes32", "resourceId", 2)]
        public virtual byte[] ResourceId { get; set; }
        [Parameter("string", "resourceIdString", 3)]
        public virtual string ResourceIdString { get; set; }
    }

    public partial class StoreInvalidspliceError : StoreInvalidspliceErrorBase { }

    [Error("Store_InvalidSplice")]
    public class StoreInvalidspliceErrorBase : IErrorDTO
    {
        [Parameter("uint40", "startWithinField", 1)]
        public virtual ulong StartWithinField { get; set; }
        [Parameter("uint40", "deleteCount", 2)]
        public virtual ulong DeleteCount { get; set; }
        [Parameter("uint40", "fieldLength", 3)]
        public virtual ulong FieldLength { get; set; }
    }




}
