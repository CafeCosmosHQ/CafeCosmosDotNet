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

namespace VisionsContracts.Vesting.ContractDefinition
{


    public partial class VestingDeployment : VestingDeploymentBase
    {
        public VestingDeployment() : base(BYTECODE) { }
        public VestingDeployment(string byteCode) : base(byteCode) { }
    }

    public class VestingDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x60e03461013c57601f6108e138819003918201601f19168301916001600160401b038311848410176101405780849260809460405283398101031261013c5761004781610154565b9061005460208201610154565b9061006d606061006660408401610168565b9201610168565b916001600160a01b038116156100e45760805260a05260c052600280546001600160a01b0319166001600160a01b0392909216919091179055604051610764908161017d82396080518181816101d001526103a1015260a05181818160a001526105cf015260c0518181816103e201526106000152f35b60405162461bcd60e51b815260206004820152602a60248201527f56657374696e6757616c6c65743a2062656e6566696369617279206973207a65604482015269726f206164647265737360b01b6064820152608490fd5b5f80fd5b634e487b7160e01b5f52604160045260245ffd5b51906001600160a01b038216820361013c57565b51906001600160401b038216820361013c5756fe608080604052600436101561001c575b50361561001a575f80fd5b005b5f3560e01c9081630fb5a6b4146103d05750806338af3eed1461038c578063632ba89214610364578063810ec23b1461032b57806386d1a69f1461014957806396132521146101215780639852595c146100fe578063a3f8eace146100d35763be9a65551461008b575f61000f565b346100cf575f3660031901126100cf576040517f00000000000000000000000000000000000000000000000000000000000000006001600160401b03168152602090f35b5f80fd5b346100cf5760203660031901126100cf5760206100f66100f1610411565b61058b565b604051908152f35b346100cf5760203660031901126100cf5760206100f661011c610411565b610564565b346100cf575f3660031901126100cf576002546020906100f6906001600160a01b0316610564565b346100cf575f3660031901126100cf576002546001600160a01b031661016e8161058b565b815f52600160205260405f2061018582825461044a565b9055817fc0e523490dd523c33b1878c9eb14ff46991e3f5b2cd33710918618f2a39cba1b6020604051848152a25f8060405192602084019063a9059cbb60e01b825260018060a01b037f0000000000000000000000000000000000000000000000000000000000000000166024860152604485015260448452610209606485610427565b60405193610218604086610427565b602085527f5361666545524332303a206c6f772d6c6576656c2063616c6c206661696c65646020860152519082865af13d1561031e573d906001600160401b03821161030a5760405161028994909261027b601f8201601f191660200185610427565b83523d5f602085013e61067a565b80518061029257005b81602091810103126100cf57602001518015908115036100cf576102b257005b60405162461bcd60e51b815260206004820152602a60248201527f5361666545524332303a204552433230206f7065726174696f6e20646964206e6044820152691bdd081cdd58d8d9595960b21b6064820152608490fd5b634e487b7160e01b5f52604160045260245ffd5b916102899260609161067a565b346100cf5760403660031901126100cf57610344610411565b602435906001600160401b03821682036100cf576020916100f69161046b565b346100cf575f3660031901126100cf576002546040516001600160a01b039091168152602090f35b346100cf575f3660031901126100cf576040517f00000000000000000000000000000000000000000000000000000000000000006001600160a01b03168152602090f35b346100cf575f3660031901126100cf577f00000000000000000000000000000000000000000000000000000000000000006001600160401b03168152602090f35b600435906001600160a01b03821682036100cf57565b601f909101601f19168101906001600160401b0382119082101761030a57604052565b9190820180921161045757565b634e487b7160e01b5f52601160045260245ffd5b6040516370a0823160e01b81523060048201526001600160a01b03919091169190602081602481865afa801561052a57610535575b50815f5260016020526040516370a0823160e01b8152306004820152602081602481865afa90811561052a575f916104f6575b506104ee906104f3935f52600160205260405f20549061044a565b6105c1565b90565b90506020813d602011610522575b8161051160209383610427565b810103126100cf57516104f36104d3565b3d9150610504565b6040513d5f823e3d90fd5b6020813d60201161055c575b8161054e60209383610427565b810103126100cf57516104a0565b3d9150610541565b6001600160a01b03165f9081526001602052604090205490565b9190820391821161045757565b6104f3906105a2426001600160401b03168261046b565b6001600160a01b039091165f908152600160205260409020549061057e565b6001600160401b03918216917f000000000000000000000000000000000000000000000000000000000000000016808310156105fe575050505f90565b7f00000000000000000000000000000000000000000000000000000000000000006001600160401b031692610633848361044a565b811115610641575050905090565b9061064b9161057e565b90818102918183041490151715610457578115610666570490565b634e487b7160e01b5f52601260045260245ffd5b919290156106dc575081511561068e575090565b3b156106975790565b60405162461bcd60e51b815260206004820152601d60248201527f416464726573733a2063616c6c20746f206e6f6e2d636f6e74726163740000006044820152606490fd5b8251909150156106ef5750805190602001fd5b604460209160405192839162461bcd60e51b83528160048401528051918291826024860152018484015e5f828201840152601f01601f19168101030190fdfea264697066735822122002bfa8138cdc97448c50c3c2d2884e2d35e289b09d71fbca68a379a81ba021e964736f6c634300081c0033";
        public VestingDeploymentBase() : base(BYTECODE) { }
        public VestingDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "_softToken", 1)]
        public virtual string SoftToken { get; set; }
        [Parameter("address", "redistributor", 2)]
        public virtual string Redistributor { get; set; }
        [Parameter("uint64", "startTimestamp", 3)]
        public virtual ulong StartTimestamp { get; set; }
        [Parameter("uint64", "durationSeconds", 4)]
        public virtual ulong DurationSeconds { get; set; }
    }

    public partial class BeneficiaryFunction : BeneficiaryFunctionBase { }

    [Function("beneficiary", "address")]
    public class BeneficiaryFunctionBase : FunctionMessage
    {

    }

    public partial class DurationFunction : DurationFunctionBase { }

    [Function("duration", "uint256")]
    public class DurationFunctionBase : FunctionMessage
    {

    }

    public partial class ReleasableFunction : ReleasableFunctionBase { }

    [Function("releasable", "uint256")]
    public class ReleasableFunctionBase : FunctionMessage
    {
        [Parameter("address", "token", 1)]
        public virtual string Token { get; set; }
    }

    public partial class ReleaseFunction : ReleaseFunctionBase { }

    [Function("release")]
    public class ReleaseFunctionBase : FunctionMessage
    {

    }

    public partial class ReleasedFunction : ReleasedFunctionBase { }

    [Function("released", "uint256")]
    public class ReleasedFunctionBase : FunctionMessage
    {

    }

    public partial class Released1Function : Released1FunctionBase { }

    [Function("released", "uint256")]
    public class Released1FunctionBase : FunctionMessage
    {
        [Parameter("address", "token", 1)]
        public virtual string Token { get; set; }
    }

    public partial class SoftTokenFunction : SoftTokenFunctionBase { }

    [Function("softToken", "address")]
    public class SoftTokenFunctionBase : FunctionMessage
    {

    }

    public partial class StartFunction : StartFunctionBase { }

    [Function("start", "uint256")]
    public class StartFunctionBase : FunctionMessage
    {

    }

    public partial class VestedAmountFunction : VestedAmountFunctionBase { }

    [Function("vestedAmount", "uint256")]
    public class VestedAmountFunctionBase : FunctionMessage
    {
        [Parameter("address", "token", 1)]
        public virtual string Token { get; set; }
        [Parameter("uint64", "timestamp", 2)]
        public virtual ulong Timestamp { get; set; }
    }

    public partial class ERC20ReleasedEventDTO : ERC20ReleasedEventDTOBase { }

    [Event("ERC20Released")]
    public class ERC20ReleasedEventDTOBase : IEventDTO
    {
        [Parameter("address", "token", 1, true )]
        public virtual string Token { get; set; }
        [Parameter("uint256", "amount", 2, false )]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class BeneficiaryOutputDTO : BeneficiaryOutputDTOBase { }

    [FunctionOutput]
    public class BeneficiaryOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class DurationOutputDTO : DurationOutputDTOBase { }

    [FunctionOutput]
    public class DurationOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class ReleasableOutputDTO : ReleasableOutputDTOBase { }

    [FunctionOutput]
    public class ReleasableOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class ReleasedOutputDTO : ReleasedOutputDTOBase { }

    [FunctionOutput]
    public class ReleasedOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class Released1OutputDTO : Released1OutputDTOBase { }

    [FunctionOutput]
    public class Released1OutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class SoftTokenOutputDTO : SoftTokenOutputDTOBase { }

    [FunctionOutput]
    public class SoftTokenOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class StartOutputDTO : StartOutputDTOBase { }

    [FunctionOutput]
    public class StartOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class VestedAmountOutputDTO : VestedAmountOutputDTOBase { }

    [FunctionOutput]
    public class VestedAmountOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }
}
