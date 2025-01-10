using Nethereum.RPC.Eth.DTOs;
using System.Numerics;
using System.Threading.Tasks;

using VisionsContracts.SoftToken;
using Nethereum.Web3;
using Nethereum.Contracts;
using VisionsContracts.PlayerBalancePurchasing.Exceptions;

namespace VisionsContracts.PlayerBalancePurchasing
{
    public class PlayerBalancePurchasingService
    {
        public IWeb3 Web3 { get; }
        public string PlayerAddress { get; }
        public string LandAddress { get; }
        public SoftTokenService SoftTokenService { get; }

        public PlayerBalancePurchasingService(IWeb3 web3, string playerAddress, string landAddress, SoftTokenService softTokenService)
        {
            Web3 = web3;
            PlayerAddress = playerAddress;
            LandAddress = landAddress;
            SoftTokenService = softTokenService;
        }

        public PlayerBalancePurchasingService(IWeb3 web3, string playerAddress, string landAddress, string tokenAddress)
        {
            Web3 = web3;
            PlayerAddress = playerAddress;
            LandAddress = landAddress;
            SoftTokenService = new SoftTokenService(web3, tokenAddress);
        }


        public async Task<PlayerBalances> GetPlayerBalancesAsync(BlockParameter blockParameter = null)
        {
            if (blockParameter == null)
            {
                blockParameter = BlockParameter.CreateLatest();
            }

            var balanceToken = await SoftTokenService.BalanceOfQueryAsync(PlayerAddress, blockParameter);

            var balance = await Web3.Eth.GetBalance.SendRequestAsync(PlayerAddress, blockParameter);

            return new PlayerBalances() { TokenBalance = balanceToken, Balance = balance };
        }

        public async Task<bool> HasGotEnoughBalanceAsync(BigInteger amount, bool useToken = false)
        {
            var playerBalances = await GetPlayerBalancesAsync();
            return HasGotEnoughBalance(amount, playerBalances, useToken);
        }

        private bool HasGotEnoughBalance(BigInteger amount, PlayerBalances playerBalances, bool useToken = false)
        {
            if (useToken)
            {
                return playerBalances.TokenBalance >= amount;
            }
            else
            {
                return playerBalances.Balance >= amount;
            }
        }

        public async Task<TFunctionMessage> ValidateBalanceApproveAndBuildPurchaseRequestAsync<TFunctionMessage>(BigInteger amount, bool useToken = false) where TFunctionMessage : FunctionMessage, new()
        {
            return await ValidateBalanceApproveAndBuildPurchaseRequestAsync(amount, new TFunctionMessage(), useToken);
        }

        public async Task<TFunctionMessage> ValidateBalanceApproveAndBuildPurchaseRequestAsync<TFunctionMessage>(BigInteger amount, TFunctionMessage message, bool useToken = false) where TFunctionMessage : FunctionMessage, new()
        {
            var playerBalances = await GetPlayerBalancesAsync();

            if (!HasGotEnoughBalance(amount, playerBalances, useToken))
            {
                if (useToken)
                {
                    throw new InsufficientTokenBalanceToPurchaseException(playerBalances.TokenBalance, amount);
                }
                else
                {
                    throw new InsufficientBalanceToPurchaseException(playerBalances.Balance, amount);
                }
            }
            if (useToken)
            {
                await SoftTokenService.ApproveRequestAndWaitForReceiptAsync(LandAddress, amount);
            }
            else
            {
                message.AmountToSend = amount;
            }

            return message;
        }

    }
}
