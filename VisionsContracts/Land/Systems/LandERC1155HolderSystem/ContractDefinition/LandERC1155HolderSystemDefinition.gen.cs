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

namespace VisionsContracts.Land.Systems.LandERC1155HolderSystem.ContractDefinition
{


    public partial class LandERC1155HolderSystemDeployment : LandERC1155HolderSystemDeploymentBase
    {
        public LandERC1155HolderSystemDeployment() : base(BYTECODE) { }
        public LandERC1155HolderSystemDeployment(string byteCode) : base(byteCode) { }
    }

    public class LandERC1155HolderSystemDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x608080604052346015576103de908161001a8239f35b5f80fdfe6080806040526004361015610012575f80fd5b5f3560e01c90816301ffc9a7146101d357508063119df25f1461019757806345ec935414610178578063bc197c81146100e3578063e1af802c146100b75763f23a6e611461005e575f80fd5b346100b35760a03660031901126100b357610077610258565b5061008061026e565b506084356001600160401b0381116100b3576100a090369060040161031f565b5060405163f23a6e6160e01b8152602090f35b5f80fd5b346100b3575f3660031901126100b35760206100d1610370565b6040516001600160a01b039091168152f35b346100b35760a03660031901126100b3576100fc610258565b5061010561026e565b506044356001600160401b0381116100b3576101259036906004016102bd565b506064356001600160401b0381116100b3576101459036906004016102bd565b506084356001600160401b0381116100b35761016590369060040161031f565b5060405163bc197c8160e01b8152602090f35b346100b3575f3660031901126100b3576020604051601f193601358152f35b346100b3575f3660031901126100b35736603319013560601c80156101cc575b6040516001600160a01b039091168152602090f35b50336101b7565b346100b35760203660031901126100b3576004359063ffffffff60e01b82168092036100b357602091630271189760e51b8114908115610247575b811561021c575b5015158152f35b63b5dee12760e01b811491508115610236575b5083610215565b6301ffc9a760e01b1490508361022f565b630168425160e71b8114915061020e565b600435906001600160a01b03821682036100b357565b602435906001600160a01b03821682036100b357565b6040519190601f01601f191682016001600160401b038111838210176102a957604052565b634e487b7160e01b5f52604160045260245ffd5b9080601f830112156100b3578135916001600160401b0383116102a9578260051b906020806102ed818501610284565b8096815201928201019283116100b357602001905b82821061030f5750505090565b8135815260209182019101610302565b81601f820112156100b3578035906001600160401b0382116102a95761034e601f8301601f1916602001610284565b92828452602083830101116100b357815f926020809301838601378301015290565b7f629a4c26e296b22a8e0856e9f6ecb2d1008d7e00081111962cd175fa7488e175546001600160a01b0316806103a557503390565b9056fea264697066735822122013d10b8418b5161dcb9040898396de3790d43d31746601a4c27049637499083564736f6c634300081c0033";
        public LandERC1155HolderSystemDeploymentBase() : base(BYTECODE) { }
        public LandERC1155HolderSystemDeploymentBase(string byteCode) : base(byteCode) { }

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

    public partial class OnERC1155BatchReceivedFunction : OnERC1155BatchReceivedFunctionBase { }

    [Function("onERC1155BatchReceived", "bytes4")]
    public class OnERC1155BatchReceivedFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
        [Parameter("address", "", 2)]
        public virtual string ReturnValue2 { get; set; }
        [Parameter("uint256[]", "", 3)]
        public virtual List<BigInteger> ReturnValue3 { get; set; }
        [Parameter("uint256[]", "", 4)]
        public virtual List<BigInteger> ReturnValue4 { get; set; }
        [Parameter("bytes", "", 5)]
        public virtual byte[] ReturnValue5 { get; set; }
    }

    public partial class OnERC1155ReceivedFunction : OnERC1155ReceivedFunctionBase { }

    [Function("onERC1155Received", "bytes4")]
    public class OnERC1155ReceivedFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
        [Parameter("address", "", 2)]
        public virtual string ReturnValue2 { get; set; }
        [Parameter("uint256", "", 3)]
        public virtual BigInteger ReturnValue3 { get; set; }
        [Parameter("uint256", "", 4)]
        public virtual BigInteger ReturnValue4 { get; set; }
        [Parameter("bytes", "", 5)]
        public virtual byte[] ReturnValue5 { get; set; }
    }

    public partial class SupportsInterfaceFunction : SupportsInterfaceFunctionBase { }

    [Function("supportsInterface", "bool")]
    public class SupportsInterfaceFunctionBase : FunctionMessage
    {
        [Parameter("bytes4", "interfaceId", 1)]
        public virtual byte[] InterfaceId { get; set; }
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





    public partial class SupportsInterfaceOutputDTO : SupportsInterfaceOutputDTOBase { }

    [FunctionOutput]
    public class SupportsInterfaceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }
}
