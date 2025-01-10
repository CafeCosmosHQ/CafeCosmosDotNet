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

namespace VisionsContracts.SoftToken.ContractDefinition
{


    public partial class SoftTokenDeployment : SoftTokenDeploymentBase
    {
        public SoftTokenDeployment() : base(BYTECODE) { }
        public SoftTokenDeployment(string byteCode) : base(byteCode) { }
    }

    public class SoftTokenDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x6080604052346103675761120f803803806100198161036b565b9283398101906040818303126103675780516001600160401b0381116103675782610045918301610390565b60208201519092906001600160401b038111610367576100659201610390565b81516001600160401b03811161027a57600354600181811c9116801561035d575b602082101461025c57601f81116102fa575b50602092601f821160011461029957928192935f9261028e575b50508160011b915f199060031b1c1916176003555b80516001600160401b03811161027a57600454600181811c91168015610270575b602082101461025c57601f81116101f9575b50602091601f8211600114610199579181925f9261018e575b50508160011b915f199060031b1c1916176004555b600580546001600160a81b0319811633600881811b610100600160a81b0316929092179093556040519291901c6001600160a01b03167f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e05f80a3610e2d90816103e28239f35b015190505f80610113565b601f1982169260045f52805f20915f5b8581106101e1575083600195106101c9575b505050811b01600455610128565b01515f1960f88460031b161c191690555f80806101bb565b919260206001819286850151815501940192016101a9565b60045f527f8a35acfbc15ff81a39ae7d344fd709f28e8600b4aa8c65c6b64bfe7fe36bd19b601f830160051c81019160208410610252575b601f0160051c01905b81811061024757506100fa565b5f815560010161023a565b9091508190610231565b634e487b7160e01b5f52602260045260245ffd5b90607f16906100e8565b634e487b7160e01b5f52604160045260245ffd5b015190505f806100b2565b601f1982169360035f52805f20915f5b8681106102e257508360019596106102ca575b505050811b016003556100c7565b01515f1960f88460031b161c191690555f80806102bc565b919260206001819286850151815501940192016102a9565b60035f527fc2575a0e9e593c00f959f8c92f12db2869c3395a3b0502d05e2516446f71f85b601f830160051c81019160208410610353575b601f0160051c01905b8181106103485750610098565b5f815560010161033b565b9091508190610332565b90607f1690610086565b5f80fd5b6040519190601f01601f191682016001600160401b0381118382101761027a57604052565b81601f82011215610367578051906001600160401b03821161027a576103bf601f8301601f191660200161036b565b928284526020838301011161036757815f9260208093018386015e830101529056fe6080806040526004361015610012575f80fd5b5f3560e01c90816306fdde031461084557508063095ea7b31461081f57806318160ddd14610802578063205c28781461077e57806323b872dd146106c15780632e1a7d4d14610646578063313ce5671461062b57806339509351146105dd5780635c975abb146105bb57806370a0823114610584578063715018a6146105385780638da5cb5b1461050c57806395d89b41146103f1578063a457c2d71461034e578063a9059cbb1461031d578063d0e30db0146101fd578063dd62ed3e146101ad5763f2fde38b146100e2575f80fd5b346101a95760203660031901126101a9576100fb61093e565b610103610d3c565b6001600160a01b0381169081156101555760058054610100600160a81b03198116600893841b610100600160a81b031617909155901c6001600160a01b03165f516020610db85f395f51905f525f80a3005b60405162461bcd60e51b815260206004820152602660248201527f4f776e61626c653a206e6577206f776e657220697320746865207a65726f206160448201526564647265737360d01b6064820152608490fd5b5f80fd5b346101a95760403660031901126101a9576101c661093e565b6101ce610954565b6001600160a01b039182165f908152600160209081526040808320949093168252928352819020549051908152f35b5f3660031901126101a95733156102d85760ff6005541661028057610224346002546109ad565b600255335f525f60205260405f203481540190556040513481525f5f516020610dd85f395f51905f5260203393a36040513481527fe1fffcc4923d04b559f4d29a8bfc6cda04eb5b0d3c460751c2402c5c5cc9109c60203392a2005b60405162461bcd60e51b815260206004820152602a60248201527f45524332305061757361626c653a20746f6b656e207472616e736665722077686044820152691a5b19481c185d5cd95960b21b6064820152608490fd5b60405162461bcd60e51b815260206004820152601f60248201527f45524332303a206d696e7420746f20746865207a65726f2061646472657373006044820152606490fd5b346101a95760403660031901126101a95761034361033961093e565b6024359033610bcf565b602060405160018152f35b346101a95760403660031901126101a95761036761093e565b60243590335f52600160205260405f2060018060a01b0382165f5260205260405f20549180831061039e57610343920390336109ce565b60405162461bcd60e51b815260206004820152602560248201527f45524332303a2064656372656173656420616c6c6f77616e63652062656c6f77604482015264207a65726f60d81b6064820152608490fd5b346101a9575f3660031901126101a9576040515f6004548060011c90600181168015610502575b6020831081146104ee578285529081156104d2575060011461047c575b50819003601f01601f19168101906001600160401b038211818310176104685761046482918260405282610914565b0390f35b634e487b7160e01b5f52604160045260245ffd5b60045f9081529091507f8a35acfbc15ff81a39ae7d344fd709f28e8600b4aa8c65c6b64bfe7fe36bd19b5b8282106104bc57506020915082010182610435565b60018160209254838588010152019101906104a7565b90506020925060ff191682840152151560051b82010182610435565b634e487b7160e01b5f52602260045260245ffd5b91607f1691610418565b346101a9575f3660031901126101a95760055460405160089190911c6001600160a01b03168152602090f35b346101a9575f3660031901126101a957610550610d3c565b60058054610100600160a81b031981169091555f9060081c6001600160a01b03165f516020610db85f395f51905f528280a3005b346101a95760203660031901126101a9576001600160a01b036105a561093e565b165f525f602052602060405f2054604051908152f35b346101a9575f3660031901126101a957602060ff600554166040519015158152f35b346101a95760403660031901126101a9576103436105f961093e565b335f52600160205260405f2060018060a01b0382165f5260205261062460405f2060243590546109ad565b90336109ce565b346101a9575f3660031901126101a957602060405160128152f35b346101a95760203660031901126101a957600435335f525f6020526106718160405f2054101561096a565b61067b8133610ad2565b805f81156106b8575b5f80809381933390f1156106ad576040519081525f516020610d985f395f51905f5260203392a2005b6040513d5f823e3d90fd5b506108fc610684565b346101a95760603660031901126101a9576106da61093e565b6106e2610954565b6001600160a01b0382165f90815260016020818152604080842033855290915290912054926044359291840161071d575b6103439350610bcf565b8284106107395761073483610343950333836109ce565b610713565b60405162461bcd60e51b815260206004820152601d60248201527f45524332303a20696e73756666696369656e7420616c6c6f77616e63650000006044820152606490fd5b346101a95760403660031901126101a95761079761093e565b60243590335f525f6020526107b28260405f2054101561096a565b6107bc8233610ad2565b6001600160a01b0316905f818381156107f8575b5f92839283928392f1156106ad5760205f516020610d985f395f51905f5291604051908152a2005b6108fc92506107d0565b346101a9575f3660031901126101a9576020600254604051908152f35b346101a95760403660031901126101a95761034361083b61093e565b60243590336109ce565b346101a9575f3660031901126101a9575f6003548060011c9060018116801561090a575b6020831081146104ee578285529081156104d257506001146108b45750819003601f01601f19168101906001600160401b038211818310176104685761046482918260405282610914565b60035f9081529091507fc2575a0e9e593c00f959f8c92f12db2869c3395a3b0502d05e2516446f71f85b5b8282106108f457506020915082010182610435565b60018160209254838588010152019101906108df565b91607f1691610869565b602060409281835280519182918282860152018484015e5f828201840152601f01601f1916010190565b600435906001600160a01b03821682036101a957565b602435906001600160a01b03821682036101a957565b1561097157565b60405162461bcd60e51b8152602060048201526014602482015273496e73756666696369656e742062616c616e636560601b6044820152606490fd5b919082018092116109ba57565b634e487b7160e01b5f52601160045260245ffd5b6001600160a01b0316908115610a81576001600160a01b0316918215610a315760207f8c5be1e5ebec7d5bd14f71427d1e84f3dd0314c0f7b2291e5b200ac8c7c3b92591835f526001825260405f20855f5282528060405f2055604051908152a3565b60405162461bcd60e51b815260206004820152602260248201527f45524332303a20617070726f766520746f20746865207a65726f206164647265604482015261737360f01b6064820152608490fd5b60405162461bcd60e51b8152602060048201526024808201527f45524332303a20617070726f76652066726f6d20746865207a65726f206164646044820152637265737360e01b6064820152608490fd5b6001600160a01b03168015610b805760ff6005541661028057805f525f60205260405f205491808310610b30576020815f516020610dd85f395f51905f52925f958587528684520360408620558060025403600255604051908152a3565b60405162461bcd60e51b815260206004820152602260248201527f45524332303a206275726e20616d6f756e7420657863656564732062616c616e604482015261636560f01b6064820152608490fd5b60405162461bcd60e51b815260206004820152602160248201527f45524332303a206275726e2066726f6d20746865207a65726f206164647265736044820152607360f81b6064820152608490fd5b6001600160a01b0316908115610ce9576001600160a01b0316918215610c985760ff6005541661028057815f525f60205260405f2054818110610c4457815f516020610dd85f395f51905f5292602092855f525f84520360405f2055845f525f825260405f20818154019055604051908152a3565b60405162461bcd60e51b815260206004820152602660248201527f45524332303a207472616e7366657220616d6f756e7420657863656564732062604482015265616c616e636560d01b6064820152608490fd5b60405162461bcd60e51b815260206004820152602360248201527f45524332303a207472616e7366657220746f20746865207a65726f206164647260448201526265737360e81b6064820152608490fd5b60405162461bcd60e51b815260206004820152602560248201527f45524332303a207472616e736665722066726f6d20746865207a65726f206164604482015264647265737360d81b6064820152608490fd5b60055460081c6001600160a01b03163303610d5357565b606460405162461bcd60e51b815260206004820152602060248201527f4f776e61626c653a2063616c6c6572206973206e6f7420746865206f776e65726044820152fdfe7fcf532c15f0a6db0bd6d0e038bea71d30d808c7d98cb3bf7268a95bf5081b658be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e0ddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3efa2646970667358221220c678760c6f8da5ce1c3f8c6cd6782751dd897a70cf8a7672359f37c61772c48a64736f6c634300081c0033";
        public SoftTokenDeploymentBase() : base(BYTECODE) { }
        public SoftTokenDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("string", "name_", 1)]
        public virtual string Name { get; set; }
        [Parameter("string", "symbol_", 2)]
        public virtual string Symbol { get; set; }
    }

    public partial class AllowanceFunction : AllowanceFunctionBase { }

    [Function("allowance", "uint256")]
    public class AllowanceFunctionBase : FunctionMessage
    {
        [Parameter("address", "owner", 1)]
        public virtual string Owner { get; set; }
        [Parameter("address", "spender", 2)]
        public virtual string Spender { get; set; }
    }

    public partial class ApproveFunction : ApproveFunctionBase { }

    [Function("approve", "bool")]
    public class ApproveFunctionBase : FunctionMessage
    {
        [Parameter("address", "spender", 1)]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "amount", 2)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class BalanceOfFunction : BalanceOfFunctionBase { }

    [Function("balanceOf", "uint256")]
    public class BalanceOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
    }

    public partial class DecimalsFunction : DecimalsFunctionBase { }

    [Function("decimals", "uint8")]
    public class DecimalsFunctionBase : FunctionMessage
    {

    }

    public partial class DecreaseAllowanceFunction : DecreaseAllowanceFunctionBase { }

    [Function("decreaseAllowance", "bool")]
    public class DecreaseAllowanceFunctionBase : FunctionMessage
    {
        [Parameter("address", "spender", 1)]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "subtractedValue", 2)]
        public virtual BigInteger SubtractedValue { get; set; }
    }

    public partial class DepositFunction : DepositFunctionBase { }

    [Function("deposit")]
    public class DepositFunctionBase : FunctionMessage
    {

    }

    public partial class IncreaseAllowanceFunction : IncreaseAllowanceFunctionBase { }

    [Function("increaseAllowance", "bool")]
    public class IncreaseAllowanceFunctionBase : FunctionMessage
    {
        [Parameter("address", "spender", 1)]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "addedValue", 2)]
        public virtual BigInteger AddedValue { get; set; }
    }

    public partial class NameFunction : NameFunctionBase { }

    [Function("name", "string")]
    public class NameFunctionBase : FunctionMessage
    {

    }

    public partial class OwnerFunction : OwnerFunctionBase { }

    [Function("owner", "address")]
    public class OwnerFunctionBase : FunctionMessage
    {

    }

    public partial class PausedFunction : PausedFunctionBase { }

    [Function("paused", "bool")]
    public class PausedFunctionBase : FunctionMessage
    {

    }

    public partial class RenounceOwnershipFunction : RenounceOwnershipFunctionBase { }

    [Function("renounceOwnership")]
    public class RenounceOwnershipFunctionBase : FunctionMessage
    {

    }

    public partial class SymbolFunction : SymbolFunctionBase { }

    [Function("symbol", "string")]
    public class SymbolFunctionBase : FunctionMessage
    {

    }

    public partial class TotalSupplyFunction : TotalSupplyFunctionBase { }

    [Function("totalSupply", "uint256")]
    public class TotalSupplyFunctionBase : FunctionMessage
    {

    }

    public partial class TransferFunction : TransferFunctionBase { }

    [Function("transfer", "bool")]
    public class TransferFunctionBase : FunctionMessage
    {
        [Parameter("address", "to", 1)]
        public virtual string To { get; set; }
        [Parameter("uint256", "amount", 2)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class TransferFromFunction : TransferFromFunctionBase { }

    [Function("transferFrom", "bool")]
    public class TransferFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "from", 1)]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2)]
        public virtual string To { get; set; }
        [Parameter("uint256", "amount", 3)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class TransferOwnershipFunction : TransferOwnershipFunctionBase { }

    [Function("transferOwnership")]
    public class TransferOwnershipFunctionBase : FunctionMessage
    {
        [Parameter("address", "newOwner", 1)]
        public virtual string NewOwner { get; set; }
    }

    public partial class WithdrawFunction : WithdrawFunctionBase { }

    [Function("withdraw")]
    public class WithdrawFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "wad", 1)]
        public virtual BigInteger Wad { get; set; }
    }

    public partial class WithdrawToFunction : WithdrawToFunctionBase { }

    [Function("withdrawTo")]
    public class WithdrawToFunctionBase : FunctionMessage
    {
        [Parameter("address", "to", 1)]
        public virtual string To { get; set; }
        [Parameter("uint256", "wad", 2)]
        public virtual BigInteger Wad { get; set; }
    }

    public partial class ApprovalEventDTO : ApprovalEventDTOBase { }

    [Event("Approval")]
    public class ApprovalEventDTOBase : IEventDTO
    {
        [Parameter("address", "owner", 1, true )]
        public virtual string Owner { get; set; }
        [Parameter("address", "spender", 2, true )]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "value", 3, false )]
        public virtual BigInteger Value { get; set; }
    }

    public partial class DepositEventDTO : DepositEventDTOBase { }

    [Event("Deposit")]
    public class DepositEventDTOBase : IEventDTO
    {
        [Parameter("address", "dst", 1, true )]
        public virtual string Dst { get; set; }
        [Parameter("uint256", "wad", 2, false )]
        public virtual BigInteger Wad { get; set; }
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

    public partial class PausedEventDTO : PausedEventDTOBase { }

    [Event("Paused")]
    public class PausedEventDTOBase : IEventDTO
    {
        [Parameter("address", "account", 1, false )]
        public virtual string Account { get; set; }
    }

    public partial class TransferEventDTO : TransferEventDTOBase { }

    [Event("Transfer")]
    public class TransferEventDTOBase : IEventDTO
    {
        [Parameter("address", "from", 1, true )]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2, true )]
        public virtual string To { get; set; }
        [Parameter("uint256", "value", 3, false )]
        public virtual BigInteger Value { get; set; }
    }

    public partial class UnpausedEventDTO : UnpausedEventDTOBase { }

    [Event("Unpaused")]
    public class UnpausedEventDTOBase : IEventDTO
    {
        [Parameter("address", "account", 1, false )]
        public virtual string Account { get; set; }
    }

    public partial class WithdrawalEventDTO : WithdrawalEventDTOBase { }

    [Event("Withdrawal")]
    public class WithdrawalEventDTOBase : IEventDTO
    {
        [Parameter("address", "src", 1, true )]
        public virtual string Src { get; set; }
        [Parameter("uint256", "wad", 2, false )]
        public virtual BigInteger Wad { get; set; }
    }

    public partial class AllowanceOutputDTO : AllowanceOutputDTOBase { }

    [FunctionOutput]
    public class AllowanceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class BalanceOfOutputDTO : BalanceOfOutputDTOBase { }

    [FunctionOutput]
    public class BalanceOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class DecimalsOutputDTO : DecimalsOutputDTOBase { }

    [FunctionOutput]
    public class DecimalsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }







    public partial class NameOutputDTO : NameOutputDTOBase { }

    [FunctionOutput]
    public class NameOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class OwnerOutputDTO : OwnerOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class PausedOutputDTO : PausedOutputDTOBase { }

    [FunctionOutput]
    public class PausedOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }



    public partial class SymbolOutputDTO : SymbolOutputDTOBase { }

    [FunctionOutput]
    public class SymbolOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class TotalSupplyOutputDTO : TotalSupplyOutputDTOBase { }

    [FunctionOutput]
    public class TotalSupplyOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }










}
