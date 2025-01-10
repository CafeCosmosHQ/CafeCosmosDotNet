using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using VisionsContracts.Land.Systems.GuildSystem.ContractDefinition;

namespace VisionsContracts.Land.Systems.GuildSystem
{
    public partial class GuildSystemService: GuildSystemServiceBase
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.IWeb3 web3, GuildSystemDeployment guildSystemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<GuildSystemDeployment>().SendRequestAndWaitForReceiptAsync(guildSystemDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.IWeb3 web3, GuildSystemDeployment guildSystemDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<GuildSystemDeployment>().SendRequestAsync(guildSystemDeployment);
        }

        public static async Task<GuildSystemService> DeployContractAndGetServiceAsync(Nethereum.Web3.IWeb3 web3, GuildSystemDeployment guildSystemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, guildSystemDeployment, cancellationTokenSource);
            return new GuildSystemService(web3, receipt.ContractAddress);
        }

        public GuildSystemService(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
        {
        }

    }


    public partial class GuildSystemServiceBase: ContractWeb3ServiceBase
    {

        public GuildSystemServiceBase(Nethereum.Web3.IWeb3 web3, string contractAddress) : base(web3, contractAddress)
        {
        }

        public Task<string> MsgSenderQueryAsync(MsgSenderFunction msgSenderFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MsgSenderFunction, string>(msgSenderFunction, blockParameter);
        }

        
        public virtual Task<string> MsgSenderQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MsgSenderFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> MsgValueQueryAsync(MsgValueFunction msgValueFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MsgValueFunction, BigInteger>(msgValueFunction, blockParameter);
        }

        
        public virtual Task<BigInteger> MsgValueQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MsgValueFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> WorldQueryAsync(WorldFunction worldFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<WorldFunction, string>(worldFunction, blockParameter);
        }

        
        public virtual Task<string> WorldQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<WorldFunction, string>(null, blockParameter);
        }

        public virtual Task<string> AcceptGuildInvitationRequestAsync(AcceptGuildInvitationFunction acceptGuildInvitationFunction)
        {
             return ContractHandler.SendRequestAsync(acceptGuildInvitationFunction);
        }

        public virtual Task<TransactionReceipt> AcceptGuildInvitationRequestAndWaitForReceiptAsync(AcceptGuildInvitationFunction acceptGuildInvitationFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(acceptGuildInvitationFunction, cancellationToken);
        }

        public virtual Task<string> AcceptGuildInvitationRequestAsync(BigInteger landId, uint guildId)
        {
            var acceptGuildInvitationFunction = new AcceptGuildInvitationFunction();
                acceptGuildInvitationFunction.LandId = landId;
                acceptGuildInvitationFunction.GuildId = guildId;
            
             return ContractHandler.SendRequestAsync(acceptGuildInvitationFunction);
        }

        public virtual Task<TransactionReceipt> AcceptGuildInvitationRequestAndWaitForReceiptAsync(BigInteger landId, uint guildId, CancellationTokenSource cancellationToken = null)
        {
            var acceptGuildInvitationFunction = new AcceptGuildInvitationFunction();
                acceptGuildInvitationFunction.LandId = landId;
                acceptGuildInvitationFunction.GuildId = guildId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(acceptGuildInvitationFunction, cancellationToken);
        }

        public virtual Task<string> ClaimGuildAdminRequestAsync(ClaimGuildAdminFunction claimGuildAdminFunction)
        {
             return ContractHandler.SendRequestAsync(claimGuildAdminFunction);
        }

        public virtual Task<TransactionReceipt> ClaimGuildAdminRequestAndWaitForReceiptAsync(ClaimGuildAdminFunction claimGuildAdminFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(claimGuildAdminFunction, cancellationToken);
        }

        public virtual Task<string> ClaimGuildAdminRequestAsync(BigInteger landId)
        {
            var claimGuildAdminFunction = new ClaimGuildAdminFunction();
                claimGuildAdminFunction.LandId = landId;
            
             return ContractHandler.SendRequestAsync(claimGuildAdminFunction);
        }

        public virtual Task<TransactionReceipt> ClaimGuildAdminRequestAndWaitForReceiptAsync(BigInteger landId, CancellationTokenSource cancellationToken = null)
        {
            var claimGuildAdminFunction = new ClaimGuildAdminFunction();
                claimGuildAdminFunction.LandId = landId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(claimGuildAdminFunction, cancellationToken);
        }

        public virtual Task<string> CreateGuildRequestAsync(CreateGuildFunction createGuildFunction)
        {
             return ContractHandler.SendRequestAsync(createGuildFunction);
        }

        public virtual Task<TransactionReceipt> CreateGuildRequestAndWaitForReceiptAsync(CreateGuildFunction createGuildFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createGuildFunction, cancellationToken);
        }

        public virtual Task<string> CreateGuildRequestAsync(BigInteger landId, string guildName)
        {
            var createGuildFunction = new CreateGuildFunction();
                createGuildFunction.LandId = landId;
                createGuildFunction.GuildName = guildName;
            
             return ContractHandler.SendRequestAsync(createGuildFunction);
        }

        public virtual Task<TransactionReceipt> CreateGuildRequestAndWaitForReceiptAsync(BigInteger landId, string guildName, CancellationTokenSource cancellationToken = null)
        {
            var createGuildFunction = new CreateGuildFunction();
                createGuildFunction.LandId = landId;
                createGuildFunction.GuildName = guildName;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createGuildFunction, cancellationToken);
        }

        public virtual Task<string> ExitGuildRequestAsync(ExitGuildFunction exitGuildFunction)
        {
             return ContractHandler.SendRequestAsync(exitGuildFunction);
        }

        public virtual Task<TransactionReceipt> ExitGuildRequestAndWaitForReceiptAsync(ExitGuildFunction exitGuildFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(exitGuildFunction, cancellationToken);
        }

        public virtual Task<string> ExitGuildRequestAsync(BigInteger landId)
        {
            var exitGuildFunction = new ExitGuildFunction();
                exitGuildFunction.LandId = landId;
            
             return ContractHandler.SendRequestAsync(exitGuildFunction);
        }

        public virtual Task<TransactionReceipt> ExitGuildRequestAndWaitForReceiptAsync(BigInteger landId, CancellationTokenSource cancellationToken = null)
        {
            var exitGuildFunction = new ExitGuildFunction();
                exitGuildFunction.LandId = landId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(exitGuildFunction, cancellationToken);
        }

        public virtual Task<GetAllGuildsOutputDTO> GetAllGuildsQueryAsync(GetAllGuildsFunction getAllGuildsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetAllGuildsFunction, GetAllGuildsOutputDTO>(getAllGuildsFunction, blockParameter);
        }

        public virtual Task<GetAllGuildsOutputDTO> GetAllGuildsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetAllGuildsFunction, GetAllGuildsOutputDTO>(null, blockParameter);
        }

        public Task<uint> GetGuildIdByNameQueryAsync(GetGuildIdByNameFunction getGuildIdByNameFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetGuildIdByNameFunction, uint>(getGuildIdByNameFunction, blockParameter);
        }

        
        public virtual Task<uint> GetGuildIdByNameQueryAsync(string guildName, BlockParameter blockParameter = null)
        {
            var getGuildIdByNameFunction = new GetGuildIdByNameFunction();
                getGuildIdByNameFunction.GuildName = guildName;
            
            return ContractHandler.QueryAsync<GetGuildIdByNameFunction, uint>(getGuildIdByNameFunction, blockParameter);
        }

        public Task<byte[]> GetGuildNameHashQueryAsync(GetGuildNameHashFunction getGuildNameHashFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetGuildNameHashFunction, byte[]>(getGuildNameHashFunction, blockParameter);
        }

        
        public virtual Task<byte[]> GetGuildNameHashQueryAsync(string guildName, BlockParameter blockParameter = null)
        {
            var getGuildNameHashFunction = new GetGuildNameHashFunction();
                getGuildNameHashFunction.GuildName = guildName;
            
            return ContractHandler.QueryAsync<GetGuildNameHashFunction, byte[]>(getGuildNameHashFunction, blockParameter);
        }

        public Task<bool> GuildNameHasValidCharactersQueryAsync(GuildNameHasValidCharactersFunction guildNameHasValidCharactersFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GuildNameHasValidCharactersFunction, bool>(guildNameHasValidCharactersFunction, blockParameter);
        }

        
        public virtual Task<bool> GuildNameHasValidCharactersQueryAsync(string guildName, BlockParameter blockParameter = null)
        {
            var guildNameHasValidCharactersFunction = new GuildNameHasValidCharactersFunction();
                guildNameHasValidCharactersFunction.GuildName = guildName;
            
            return ContractHandler.QueryAsync<GuildNameHasValidCharactersFunction, bool>(guildNameHasValidCharactersFunction, blockParameter);
        }

        public Task<bool> GuildNameInUseQueryAsync(GuildNameInUseFunction guildNameInUseFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GuildNameInUseFunction, bool>(guildNameInUseFunction, blockParameter);
        }

        
        public virtual Task<bool> GuildNameInUseQueryAsync(string guildName, BlockParameter blockParameter = null)
        {
            var guildNameInUseFunction = new GuildNameInUseFunction();
                guildNameInUseFunction.GuildName = guildName;
            
            return ContractHandler.QueryAsync<GuildNameInUseFunction, bool>(guildNameInUseFunction, blockParameter);
        }

        public virtual Task<string> InviteToGuildRequestAsync(InviteToGuildFunction inviteToGuildFunction)
        {
             return ContractHandler.SendRequestAsync(inviteToGuildFunction);
        }

        public virtual Task<TransactionReceipt> InviteToGuildRequestAndWaitForReceiptAsync(InviteToGuildFunction inviteToGuildFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(inviteToGuildFunction, cancellationToken);
        }

        public virtual Task<string> InviteToGuildRequestAsync(BigInteger landId, BigInteger invitedLandId)
        {
            var inviteToGuildFunction = new InviteToGuildFunction();
                inviteToGuildFunction.LandId = landId;
                inviteToGuildFunction.InvitedLandId = invitedLandId;
            
             return ContractHandler.SendRequestAsync(inviteToGuildFunction);
        }

        public virtual Task<TransactionReceipt> InviteToGuildRequestAndWaitForReceiptAsync(BigInteger landId, BigInteger invitedLandId, CancellationTokenSource cancellationToken = null)
        {
            var inviteToGuildFunction = new InviteToGuildFunction();
                inviteToGuildFunction.LandId = landId;
                inviteToGuildFunction.InvitedLandId = invitedLandId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(inviteToGuildFunction, cancellationToken);
        }

        public virtual Task<string> KickFromGuildRequestAsync(KickFromGuildFunction kickFromGuildFunction)
        {
             return ContractHandler.SendRequestAsync(kickFromGuildFunction);
        }

        public virtual Task<TransactionReceipt> KickFromGuildRequestAndWaitForReceiptAsync(KickFromGuildFunction kickFromGuildFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(kickFromGuildFunction, cancellationToken);
        }

        public virtual Task<string> KickFromGuildRequestAsync(BigInteger landId, BigInteger kickedLandId)
        {
            var kickFromGuildFunction = new KickFromGuildFunction();
                kickFromGuildFunction.LandId = landId;
                kickFromGuildFunction.KickedLandId = kickedLandId;
            
             return ContractHandler.SendRequestAsync(kickFromGuildFunction);
        }

        public virtual Task<TransactionReceipt> KickFromGuildRequestAndWaitForReceiptAsync(BigInteger landId, BigInteger kickedLandId, CancellationTokenSource cancellationToken = null)
        {
            var kickFromGuildFunction = new KickFromGuildFunction();
                kickFromGuildFunction.LandId = landId;
                kickFromGuildFunction.KickedLandId = kickedLandId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(kickFromGuildFunction, cancellationToken);
        }

        public virtual Task<string> SetNewGuildAdminRequestAsync(SetNewGuildAdminFunction setNewGuildAdminFunction)
        {
             return ContractHandler.SendRequestAsync(setNewGuildAdminFunction);
        }

        public virtual Task<TransactionReceipt> SetNewGuildAdminRequestAndWaitForReceiptAsync(SetNewGuildAdminFunction setNewGuildAdminFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setNewGuildAdminFunction, cancellationToken);
        }

        public virtual Task<string> SetNewGuildAdminRequestAsync(BigInteger landId, BigInteger newAdminId)
        {
            var setNewGuildAdminFunction = new SetNewGuildAdminFunction();
                setNewGuildAdminFunction.LandId = landId;
                setNewGuildAdminFunction.NewAdminId = newAdminId;
            
             return ContractHandler.SendRequestAsync(setNewGuildAdminFunction);
        }

        public virtual Task<TransactionReceipt> SetNewGuildAdminRequestAndWaitForReceiptAsync(BigInteger landId, BigInteger newAdminId, CancellationTokenSource cancellationToken = null)
        {
            var setNewGuildAdminFunction = new SetNewGuildAdminFunction();
                setNewGuildAdminFunction.LandId = landId;
                setNewGuildAdminFunction.NewAdminId = newAdminId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setNewGuildAdminFunction, cancellationToken);
        }

        public Task<bool> SupportsInterfaceQueryAsync(SupportsInterfaceFunction supportsInterfaceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SupportsInterfaceFunction, bool>(supportsInterfaceFunction, blockParameter);
        }

        
        public virtual Task<bool> SupportsInterfaceQueryAsync(byte[] interfaceId, BlockParameter blockParameter = null)
        {
            var supportsInterfaceFunction = new SupportsInterfaceFunction();
                supportsInterfaceFunction.InterfaceId = interfaceId;
            
            return ContractHandler.QueryAsync<SupportsInterfaceFunction, bool>(supportsInterfaceFunction, blockParameter);
        }

        public override List<Type> GetAllFunctionTypes()
        {
            return new List<Type>
            {
                typeof(MsgSenderFunction),
                typeof(MsgValueFunction),
                typeof(WorldFunction),
                typeof(AcceptGuildInvitationFunction),
                typeof(ClaimGuildAdminFunction),
                typeof(CreateGuildFunction),
                typeof(ExitGuildFunction),
                typeof(GetAllGuildsFunction),
                typeof(GetGuildIdByNameFunction),
                typeof(GetGuildNameHashFunction),
                typeof(GuildNameHasValidCharactersFunction),
                typeof(GuildNameInUseFunction),
                typeof(InviteToGuildFunction),
                typeof(KickFromGuildFunction),
                typeof(SetNewGuildAdminFunction),
                typeof(SupportsInterfaceFunction)
            };
        }

        public override List<Type> GetAllEventTypes()
        {
            return new List<Type>
            {
                typeof(GuildAdminChangedEventDTO),
                typeof(GuildCreatedEventDTO),
                typeof(GuildMemberAddedEventDTO),
                typeof(GuildMemberRemovedEventDTO),
                typeof(StoreDeleterecordEventDTO),
                typeof(StoreSplicedynamicdataEventDTO),
                typeof(StoreSplicestaticdataEventDTO)
            };
        }

        public override List<Type> GetAllErrorTypes()
        {
            return new List<Type>
            {
                typeof(AccessByNoOperatorError),
                typeof(EncodedlengthsInvalidlengthError),
                typeof(SliceOutofboundsError),
                typeof(StoreIndexoutofboundsError),
                typeof(StoreInvalidresourcetypeError),
                typeof(StoreInvalidspliceError)
            };
        }
    }
}
