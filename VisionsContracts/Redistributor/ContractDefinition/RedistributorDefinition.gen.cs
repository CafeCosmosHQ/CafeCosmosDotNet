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

namespace VisionsContracts.Redistributor.ContractDefinition
{


    public partial class RedistributorDeployment : RedistributorDeploymentBase
    {
        public RedistributorDeployment() : base(BYTECODE) { }
        public RedistributorDeployment(string byteCode) : base(byteCode) { }
    }

    public class RedistributorDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x6080346100e357601f61187038819003918201601f19168301916001600160401b038311848410176100e75780849260409485528339810103126100e357610052602061004b836100fb565b92016100fb565b5f8054336001600160a01b0319821681178355604051949290916001600160a01b0316907f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e09080a3670de0b6b3a7640000600355600180546001600160a01b039283166001600160a01b03199182161782556002805494909316931692909217905560095561176090816101108239f35b5f80fd5b634e487b7160e01b5f52604160045260245ffd5b51906001600160a01b03821682036100e35756fe6080806040526004361015610012575f80fd5b5f3560e01c908163068bcd8d14610ad0575080631e5b287414610a8c5780632b217c2a14610a3857806332318c5514610a205780636f9d9f71146109cb578063715018a61461098757806372a3833f146107a85780637573bd491461076b578063792a26a71461070d5780637c6f51271461069a578063851991e8146106035780638da5cb5b146105dc578063c9abf5b1146105b2578063caaf02771461055b578063d0b2d7c814610474578063d519e7cb146102f7578063e343788814610211578063e5253105146101db578063f2fde38b146101245763fc0c546a146100f8575f80fd5b34610120575f366003190112610120576001546040516001600160a01b039091168152602090f35b5f80fd5b34610120576020366003190112610120576004356001600160a01b038116908190036101205761015261162c565b8015610187575f80546001600160a01b03198116831782556001600160a01b0316905f5160206116eb5f395f51905f529080a3005b60405162461bcd60e51b815260206004820152602660248201527f4f776e61626c653a206e6577206f776e657220697320746865207a65726f206160448201526564647265737360d01b6064820152608490fd5b346101205760206102096101ee36610b65565b9061020460018060a01b03600254163314611311565b611473565b604051908152f35b346101205761021f36610b65565b9061023560018060a01b03600254163314611311565b5f52600a60205260405f20549061024d821515610db3565b815f52600860205260ff600260405f20015416156102b257816040917f0a7d587acc3bafe631c58ed4a25eda1e905acfb47594d1b86b332ae63df22594935f5260086020526001835f20016102a3828254610e87565b905582519182526020820152a1005b60405162461bcd60e51b815260206004820152601f60248201527f52656469737472696275746f723a20506f6f6c20697320696e616374697665006044820152606490fd5b346101205760603660031901126101205760443560243560043582151583036101205761032261162c565b61032f6006548310610e09565b805f52600a60205260405f205461041e57600954915f19831461040a57610381600191828501600955845f52600860205261037c86600260405f20019060ff801983541691151516179055565b610cab565b500192835491600160401b8310156103f6576103cf846103b78560209860015f51602061170b5f395f51905f5298018155610e72565b90919082549060031b91821b915f19901b1916179055565b5f818152600a865260409081902085905580519182529115156020820152a1604051908152f35b634e487b7160e01b5f52604160045260245ffd5b634e487b7160e01b5f52601160045260245ffd5b60405162461bcd60e51b815260206004820152602860248201527f52656469737472696275746f723a204964656e74696669657220616c726561646044820152677920696e2075736560c01b6064820152608490fd5b34610120575f3660031901126101205760065461049081610c0e565b9061049e6040519283610b96565b80825260065f9081526020830191907ff652222313e28459528d920b65115c16c04f3efc82aaedc97be59f3f377c0d3f835b83831061053d57848660405191829160208301906020845251809152604083019060408160051b85010192915f905b82821061050e57505050500390f35b9193600191939550602061052d8192603f198a82030186528851610c49565b96019201920185949391926104ff565b6003602060019261054d8561129d565b8152019201920191906104d0565b34610120576020366003190112610120576004356006548110156101205761058290610cab565b50610591600282549201610d13565b906105ae6040519283928352604060208401526040830190610c25565b0390f35b34610120576020366003190112610120576004355f52600a602052602060405f2054604051908152f35b34610120575f366003190112610120575f546040516001600160a01b039091168152602090f35b34610120576040366003190112610120576004356024358015158103610120577f4dead1fce0fa766568e157517933316aa53a71a1eda5ab1c0e540084394364e19161064d61162c565b805f52600a60205260405f2054610665811515610db3565b5f52600860205261068882600260405f20019060ff801983541691151516179055565b604080519182529115156020820152a1005b34610120576106a836610b65565b906106be60018060a01b03600254163314611311565b5f52600a60205260405f20546106d5811515610db3565b805f5260086020526106f0600160405f200154831115611379565b5f526008602052610709600160405f2001918254610e65565b9055005b34610120576020366003190112610120576105ae61075761075160043560606040805161073981610b7b565b5f8152826020820152015261037c6006548210610e09565b5061129d565b604051918291602083526020830190610c49565b34610120576040366003190112610120576024356001600160401b038111610120576102096107a06020923690600401610bb9565b60043561102a565b34610120576020366003190112610120576004356001600160401b03811161012057366023820112156101205780600401356107e381610c0e565b916107f16040519384610b96565b8183526024602084019260051b820101903682116101205760248101925b8284106108a5578461081f61162c565b5f5b81518110156108a35761084e6108378284611016565b515160206108458486611016565b5101519061102a565b915f925b604061085e8484611016565b510151518410156108985760018461088f83610889849860406108818a8a611016565b510151611016565b516113c4565b50019350610852565b509150600101610821565b005b83356001600160401b0381116101205782016060602319823603011261012057604051906108d282610b7b565b6024810135825260448101356001600160401b038111610120576108fc9060243691840101610bb9565b602083015260648101356001600160401b03811161012057602491010136601f820112156101205780359061093082610c0e565b9161093e6040519384610b96565b80835260208084019160051b8301019136831161012057602001905b82821061097757505050604082015281526020938401930161080f565b813581526020918201910161095a565b34610120575f3660031901126101205761099f61162c565b5f80546001600160a01b0319811682556001600160a01b03165f5160206116eb5f395f51905f528280a3005b34610120576020366003190112610120576004356001600160401b038111610120576020806109ff81933690600401610bb9565b604051928184925191829101835e8101600781520301902054604051908152f35b34610120575f366003190112610120576108a3610e94565b3461012057610a88610a4936610b65565b9190610a5361162c565b610a606006548210610e09565b610a8083610a7b600454610a7385610cab565b505490610e65565b610e87565b600455610cab565b5055005b34610120576020366003190112610120576004356001600160a01b0381169081900361012057610aba61162c565b600280546001600160a01b031916919091179055005b3461012057602036600319011261012057604081610aee5f93610b7b565b82815282602082015201526004355f52600a60205260405f2054610b13811515610db3565b5f526008602052606060405f20604051610b2c81610b7b565b815491828252604060ff600260018401549360208601948552015416920191151582526040519283525160208301525115156040820152f35b6040906003190112610120576004359060243590565b606081019081106001600160401b038211176103f657604052565b601f909101601f19168101906001600160401b038211908210176103f657604052565b81601f82011215610120578035906001600160401b0382116103f65760405192610bed601f8401601f191660200185610b96565b8284526020838301011161012057815f926020809301838601378301015290565b6001600160401b0381116103f65760051b60200190565b805180835260209291819084018484015e5f828201840152601f01601f1916010190565b91906060810190835181526020840151916060602083015282518091526020608083019301905f5b818110610c95575050506040610c9293940151906040818403910152610c25565b90565b8251855260209485019490920191600101610c71565b600654811015610cc75760065f52600360205f20910201905f90565b634e487b7160e01b5f52603260045260245ffd5b90600182811c92168015610d09575b6020831014610cf557565b634e487b7160e01b5f52602260045260245ffd5b91607f1691610cea565b9060405191825f825492610d2684610cdb565b8084529360018116908115610d915750600114610d4d575b50610d4b92500383610b96565b565b90505f9291925260205f20905f915b818310610d75575050906020610d4b928201015f610d3e565b6020919350806001915483858901015201910190918492610d5c565b905060209250610d4b94915060ff191682840152151560051b8201015f610d3e565b15610dba57565b60405162461bcd60e51b815260206004820152602160248201527f52656469737472696275746f723a20496e76616c6964206964656e74696669656044820152603960f91b6064820152608490fd5b15610e1057565b60405162461bcd60e51b815260206004820152602760248201527f52656469737472696275746f723a20496e76616c69642073756273656374696f6044820152660dc40d2dcc8caf60cb1b6064820152608490fd5b9190820391821161040a57565b8054821015610cc7575f5260205f2001905f90565b9190820180921161040a57565b6001546040516370a0823160e01b815230600482015290602090829060249082906001600160a01b03165afa801561100b575f90610fd7575b610edb915060055490610e65565b908115610fd357905f905b600654821015610fcf57600354808202828104820361040a57610f0884610cab565b5054908282029180830484149015171561040a5781810291818304149015171561040a5781610f44610f5d93610f44610f499460045490611683565b611683565b6001610f5485610cab565b50015490611683565b905f5b6001610f6b85610cab565b500154811015610fc15780610f8d60019283610f8688610cab565b5001610e72565b90549060031b1c5f52600860205260405f20610faa858254610e87565b9055610fb884600554610e87565b60055501610f60565b506001909201919050610ee6565b5050565b9050565b506020813d602011611003575b81610ff160209383610b96565b8101031261012057610edb9051610ecd565b3d9150610fe4565b6040513d5f823e3d90fd5b8051821015610cc75760209160051b010190565b91909161103561162c565b600654906020604051946110498287610b96565b5f86525f36813760405161105c81610b7b565b8381528281019687526040810196828852856040518581865180838901835e8101600781520301902055600160401b8610156103f657600186016006556110a286610cab565b929092611274575182555180519060018301906001600160401b0383116103f657600160401b83116103f65785908254848455808510611259575b5001905f52845f205f5b8381106112475750505050600201955195865160018060401b0381116103f6576111118254610cdb565b601f811161120e575b5083601f82116001146111985790806111879493925f5160206116cb5f395f51905f5298999a5f9261118d575b50508160011b915f199060031b1c19161790555b61116784600454610e87565b600455604051938493878552840152606060408401526060830190610c25565b0390a190565b015190505f80611147565b601f19821698835f52855f20995f5b8181106111f757509960019284926111879796955f5160206116cb5f395f51905f529b9c9d106111df575b505050811b01905561115b565b01515f1960f88460031b161c191690555f80806111d2565b838301518c556001909b019a9287019287016111a7565b61123790835f52855f20601f840160051c81019187851061123d575b601f0160051c0190611287565b5f61111a565b909150819061122a565b825182820155918601916001016110e7565b61126e90845f5285845f209182019101611287565b5f6110dd565b634e487b7160e01b5f525f60045260245ffd5b818110611292575050565b5f8155600101611287565b906040516112aa81610b7b565b809280548252600181016040519081602082549182815201915f5260205f20905f5b8181106112fb57505050604092826112eb6112f6946002940382610b96565b602086015201610d13565b910152565b82548452602090930192600192830192016112cc565b1561131857565b60405162461bcd60e51b815260206004820152603360248201527f6f6e6c7920746865206c616e6420636f6e747261637420697320616c6c6f776560448201527219081d1bc81b585ad9481d1a1a5cc818d85b1b606a1b6064820152608490fd5b1561138057565b606460405162461bcd60e51b815260206004820152602060248201527f52656469737472696275746f723a206e6f7420656e6f756768207368617265736044820152fd5b6113cc61162c565b6113d96006548310610e09565b805f52600a60205260405f205461041e57600954915f19831461040a57611420600191828501600955845f526008602052600260405f20018360ff19825416179055610cab565b500180549091600160401b8210156103f657611456846103b7845f51602061170b5f395f51905f52966001604097018155610e72565b805f52600a60205283825f2055815190815260016020820152a190565b805f52600a60205260405f205461148b811515610db3565b805f5260086020526114a6600160405f200154841115611379565b5f52600860205260405f20805480156115de576003549081810290808204830361040a578286029186830484148715171561040a5782810292818404149015171561040a576115199261151261150a6001870192610f4481610f4486548099611683565b978894610e65565b9055610e65565b905561152782600554610e65565b60055560015460025460405163a9059cbb60e01b81526001600160a01b0391821660048201526024810185905291602091839160449183915f91165af1801561100b576115a3575b5060407fd66662c0ded9e58fd31d5e44944bcfd07ffc15e6927ecc1382e7941cb7bd24c4918151908152836020820152a190565b6020813d6020116115d6575b816115bc60209383610b96565b81010312610120575180151581036101205750604061156f565b3d91506115af565b50907fcaf5f45fc87df65538430cccff9e81fe7177a47dd858211de3bf7ecd4298a4a29260016060930190611614818354610e65565b80925560405192835260208301526040820152a15f90565b5f546001600160a01b0316330361163f57565b606460405162461bcd60e51b815260206004820152602060248201527f4f776e61626c653a2063616c6c6572206973206e6f7420746865206f776e65726044820152fd5b811561168d570490565b60405162461bcd60e51b815260206004820152601560248201527463616e6e6f7420646976696465206279207a65726f60581b6044820152606490fdfe4302d41f6580bcb0788a606dc9bcaf2d212d4bde7014627a7d7e301549417b338be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e0148dad472be1db232e0c0acc0f84036556b12529b9c6cf5d139731c60fea3489a26469706673582212200581d201bf5e34d4050f9b2b673f9db976a086dd06ac33e76b73c68843477d4764736f6c634300081c0033";
        public RedistributorDeploymentBase() : base(BYTECODE) { }
        public RedistributorDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "_token", 1)]
        public virtual string Token { get; set; }
        [Parameter("address", "_land", 2)]
        public virtual string Land { get; set; }
    }

    public partial class BurnSharesFunction : BurnSharesFunctionBase { }

    [Function("burnShares")]
    public class BurnSharesFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_identifier", 1)]
        public virtual BigInteger Identifier { get; set; }
        [Parameter("uint256", "shares", 2)]
        public virtual BigInteger Shares { get; set; }
    }

    public partial class CreatePoolFunction : CreatePoolFunctionBase { }

    [Function("createPool", "uint256")]
    public class CreatePoolFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_identifier", 1)]
        public virtual BigInteger Identifier { get; set; }
        [Parameter("uint256", "subsectionIndex", 2)]
        public virtual BigInteger SubsectionIndex { get; set; }
        [Parameter("bool", "_isActive", 3)]
        public virtual bool IsActive { get; set; }
    }

    public partial class CreateSubSectionFunction : CreateSubSectionFunctionBase { }

    [Function("createSubSection", "uint256")]
    public class CreateSubSectionFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_masterShares", 1)]
        public virtual BigInteger MasterShares { get; set; }
        [Parameter("string", "_name", 2)]
        public virtual string Name { get; set; }
    }

    public partial class CreateSubSectionsFunction : CreateSubSectionsFunctionBase { }

    [Function("createSubSections")]
    public class CreateSubSectionsFunctionBase : FunctionMessage
    {
        [Parameter("tuple[]", "subsections", 1)]
        public virtual List<SubSectionCreation> Subsections { get; set; }
    }

    public partial class GetPoolFunction : GetPoolFunctionBase { }

    [Function("getPool", typeof(GetPoolOutputDTO))]
    public class GetPoolFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_identifier", 1)]
        public virtual BigInteger Identifier { get; set; }
    }

    public partial class GetSubSectionFunction : GetSubSectionFunctionBase { }

    [Function("getSubSection", typeof(GetSubSectionOutputDTO))]
    public class GetSubSectionFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "subsectionIndex", 1)]
        public virtual BigInteger SubsectionIndex { get; set; }
    }

    public partial class GetSubSectionsFunction : GetSubSectionsFunctionBase { }

    [Function("getSubSections", typeof(GetSubSectionsOutputDTO))]
    public class GetSubSectionsFunctionBase : FunctionMessage
    {

    }

    public partial class IdentifierToPoolIdFunction : IdentifierToPoolIdFunctionBase { }

    [Function("identifierToPoolId", "uint256")]
    public class IdentifierToPoolIdFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class MintSharesFunction : MintSharesFunctionBase { }

    [Function("mintShares")]
    public class MintSharesFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_identifier", 1)]
        public virtual BigInteger Identifier { get; set; }
        [Parameter("uint256", "shares", 2)]
        public virtual BigInteger Shares { get; set; }
    }

    public partial class OwnerFunction : OwnerFunctionBase { }

    [Function("owner", "address")]
    public class OwnerFunctionBase : FunctionMessage
    {

    }

    public partial class RedistributeFundsFunction : RedistributeFundsFunctionBase { }

    [Function("redistributeFunds")]
    public class RedistributeFundsFunctionBase : FunctionMessage
    {

    }

    public partial class RenounceOwnershipFunction : RenounceOwnershipFunctionBase { }

    [Function("renounceOwnership")]
    public class RenounceOwnershipFunctionBase : FunctionMessage
    {

    }

    public partial class SetLandAddressFunction : SetLandAddressFunctionBase { }

    [Function("setLandAddress")]
    public class SetLandAddressFunctionBase : FunctionMessage
    {
        [Parameter("address", "_land", 1)]
        public virtual string Land { get; set; }
    }

    public partial class SetPoolActivityFunction : SetPoolActivityFunctionBase { }

    [Function("setPoolActivity")]
    public class SetPoolActivityFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_identifier", 1)]
        public virtual BigInteger Identifier { get; set; }
        [Parameter("bool", "_isActive", 2)]
        public virtual bool IsActive { get; set; }
    }

    public partial class SetSubSectionMasterSharesFunction : SetSubSectionMasterSharesFunctionBase { }

    [Function("setSubSectionMasterShares")]
    public class SetSubSectionMasterSharesFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "subsectionIndex", 1)]
        public virtual BigInteger SubsectionIndex { get; set; }
        [Parameter("uint256", "_masterShares", 2)]
        public virtual BigInteger MasterShares { get; set; }
    }

    public partial class SubSectionsFunction : SubSectionsFunctionBase { }

    [Function("subSections", typeof(SubSectionsOutputDTO))]
    public class SubSectionsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class SubsectionNameToIndexFunction : SubsectionNameToIndexFunctionBase { }

    [Function("subsectionNameToIndex", "uint256")]
    public class SubsectionNameToIndexFunctionBase : FunctionMessage
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class TokenFunction : TokenFunctionBase { }

    [Function("token", "address")]
    public class TokenFunctionBase : FunctionMessage
    {

    }

    public partial class TransferOwnershipFunction : TransferOwnershipFunctionBase { }

    [Function("transferOwnership")]
    public class TransferOwnershipFunctionBase : FunctionMessage
    {
        [Parameter("address", "newOwner", 1)]
        public virtual string NewOwner { get; set; }
    }

    public partial class WithdrawFundsFunction : WithdrawFundsFunctionBase { }

    [Function("withdrawFunds", "uint256")]
    public class WithdrawFundsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_identifier", 1)]
        public virtual BigInteger Identifier { get; set; }
        [Parameter("uint256", "shares", 2)]
        public virtual BigInteger Shares { get; set; }
    }

    public partial class EmptyWithdrawalEventDTO : EmptyWithdrawalEventDTOBase { }

    [Event("EmptyWithdrawal")]
    public class EmptyWithdrawalEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "poolId", 1, false )]
        public virtual BigInteger PoolId { get; set; }
        [Parameter("uint256", "shares", 2, false )]
        public virtual BigInteger Shares { get; set; }
        [Parameter("uint256", "totalShares", 3, false )]
        public virtual BigInteger TotalShares { get; set; }
    }

    public partial class FundsWithdrawnEventDTO : FundsWithdrawnEventDTOBase { }

    [Event("FundsWithdrawn")]
    public class FundsWithdrawnEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "poolId", 1, false )]
        public virtual BigInteger PoolId { get; set; }
        [Parameter("uint256", "amount", 2, false )]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class OwnershipTransferredEventDTO : OwnershipTransferredEventDTOBase { }

    [Event("OwnershipTransferred")]
    public class OwnershipTransferredEventDTOBase : IEventDTO
    {
        [Parameter("address", "previousOwner", 1, true )]
        public virtual string PreviousOwner { get; set; }
        [Parameter("address", "newOwner", 2, true )]
        public virtual string NewOwner { get; set; }
    }

    public partial class PoolActivityChangedEventDTO : PoolActivityChangedEventDTOBase { }

    [Event("PoolActivityChanged")]
    public class PoolActivityChangedEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "_identifier", 1, false )]
        public virtual BigInteger Identifier { get; set; }
        [Parameter("bool", "isActive", 2, false )]
        public virtual bool IsActive { get; set; }
    }

    public partial class PoolCreatedEventDTO : PoolCreatedEventDTOBase { }

    [Event("PoolCreated")]
    public class PoolCreatedEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "poolId", 1, false )]
        public virtual BigInteger PoolId { get; set; }
        [Parameter("bool", "_isActive", 2, false )]
        public virtual bool IsActive { get; set; }
    }

    public partial class SharesMintedEventDTO : SharesMintedEventDTOBase { }

    [Event("SharesMinted")]
    public class SharesMintedEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "poolId", 1, false )]
        public virtual BigInteger PoolId { get; set; }
        [Parameter("uint256", "shares", 2, false )]
        public virtual BigInteger Shares { get; set; }
    }

    public partial class SubSectionCreatedEventDTO : SubSectionCreatedEventDTOBase { }

    [Event("SubSectionCreated")]
    public class SubSectionCreatedEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "subsectionIndex", 1, false )]
        public virtual BigInteger SubsectionIndex { get; set; }
        [Parameter("uint256", "masterShares", 2, false )]
        public virtual BigInteger MasterShares { get; set; }
        [Parameter("string", "name", 3, false )]
        public virtual string Name { get; set; }
    }









    public partial class GetPoolOutputDTO : GetPoolOutputDTOBase { }

    [FunctionOutput]
    public class GetPoolOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "pool", 1)]
        public virtual Pool Pool { get; set; }
    }

    public partial class GetSubSectionOutputDTO : GetSubSectionOutputDTOBase { }

    [FunctionOutput]
    public class GetSubSectionOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "subsection", 1)]
        public virtual SubSection Subsection { get; set; }
    }

    public partial class GetSubSectionsOutputDTO : GetSubSectionsOutputDTOBase { }

    [FunctionOutput]
    public class GetSubSectionsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple[]", "", 1)]
        public virtual List<SubSection> ReturnValue1 { get; set; }
    }

    public partial class IdentifierToPoolIdOutputDTO : IdentifierToPoolIdOutputDTOBase { }

    [FunctionOutput]
    public class IdentifierToPoolIdOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class OwnerOutputDTO : OwnerOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }











    public partial class SubSectionsOutputDTO : SubSectionsOutputDTOBase { }

    [FunctionOutput]
    public class SubSectionsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "masterShares", 1)]
        public virtual BigInteger MasterShares { get; set; }
        [Parameter("string", "name", 2)]
        public virtual string Name { get; set; }
    }

    public partial class SubsectionNameToIndexOutputDTO : SubsectionNameToIndexOutputDTOBase { }

    [FunctionOutput]
    public class SubsectionNameToIndexOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class TokenOutputDTO : TokenOutputDTOBase { }

    [FunctionOutput]
    public class TokenOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }




}
