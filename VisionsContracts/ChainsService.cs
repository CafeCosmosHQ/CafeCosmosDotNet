using System;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.HostWallet;
using static System.Net.WebRequestMethods;

namespace VisionsContracts
{
    public class ChainsService
    {
        public const long CHIADO = 10200;
        public const long BASE_SEPOLIA = 84532;
        public const long LOCAHOST = 31337;
        public const long NITRO_TESTNET = 6826714;
        public const long GARNET_HOLESKY = 17069;
        public const long REDSTONE = 690;

        public static AddEthereumChainParameter GetAddEthereumChainParameter(long chainId)
        {
            switch (chainId)
            {
                case CHIADO:
                    return new AddEthereumChainParameter
                    {
                        ChainId = new HexBigInteger(CHIADO),
                        ChainName = "Gnosis Chiado Testnet",
                        NativeCurrency = new NativeCurrency()
                        {
                            Decimals = 18,
                            Name = "XDAI",
                            Symbol = "XDAI"
                        },
                        RpcUrls = new List<string> { "https://rpc.chiadochain.net" },
                        BlockExplorerUrls = new List<string> { "https://gnosis-chiado.blockscout.com/" },

                    };

                case BASE_SEPOLIA:
                    return new AddEthereumChainParameter
                    {
                        ChainId = new HexBigInteger(BASE_SEPOLIA),
                        ChainName = "Base Sepolia Testnet",
                        NativeCurrency = new NativeCurrency()
                        {
                            Decimals = 18,
                            Name = "ETH",
                            Symbol = "ETH"
                        },
                        RpcUrls = new List<string> { "https://sepolia.base.org" },
                        BlockExplorerUrls = new List<string> { "https://sepolia-explorer.base.org/" },

                    };

                case NITRO_TESTNET:
                    return new AddEthereumChainParameter
                    {
                        ChainId = new HexBigInteger(NITRO_TESTNET),
                        ChainName = "CafeCosmos Nitro",
                        NativeCurrency = new NativeCurrency()
                        {
                            Decimals = 18,
                            Name = "ETH",
                            Symbol = "ETH"
                        },
                        RpcUrls = new List<string> { "https://cafecosmos-nitro.rpc.caldera.xyz/http" },
                        BlockExplorerUrls = new List<string> { "https://cafecosmos-nitro.explorer.caldera.xyz/" },

                    };

                case GARNET_HOLESKY:

                    return new AddEthereumChainParameter
                    {
                        ChainId = new HexBigInteger(GARNET_HOLESKY),
                        ChainName = "Garnet Holesky",
                        NativeCurrency = new NativeCurrency()
                        {
                            Decimals = 18,
                            Name = "ETH",
                            Symbol = "ETH"
                        },
                        RpcUrls = new List<string> { "https://rpc.garnetchain.com" },
                        BlockExplorerUrls = new List<string> { "https://explorer.garnetchain.com/" }
                    };

                case REDSTONE:

                    return new AddEthereumChainParameter
                    {
                        ChainId = new HexBigInteger(REDSTONE),
                        ChainName = "Redstone",
                        NativeCurrency = new NativeCurrency()
                        {
                            Decimals = 18,
                            Name = "ETH",
                            Symbol = "ETH"
                        },
                        RpcUrls = new List<string> { "https://rpc.redstonechain.com" },
                        BlockExplorerUrls = new List<string> { "https://explorer.redstone.xyz" }
                    };

                case LOCAHOST:

                    return new AddEthereumChainParameter
                    {
                        ChainId = new HexBigInteger(LOCAHOST),
                        ChainName = "Localhost",
                        NativeCurrency = new NativeCurrency()
                        {
                            Decimals = 18,
                            Name = "ETH",
                            Symbol = "ETH"
                        },
                        RpcUrls = new List<string> { "http://localhost:8545" },
                    };
            }

            throw new Exception("ChainId not found");

        }


        public static SwitchEthereumChainParameter GetSwithcEthereumChainParameter(long chainId)
        {
            switch (chainId)
            {
                case CHIADO:
                    return new SwitchEthereumChainParameter
                    {
                        ChainId = new HexBigInteger(CHIADO),
                    };

                case LOCAHOST:

                    return new SwitchEthereumChainParameter
                    {
                        ChainId = new HexBigInteger(LOCAHOST),
                    };
            }

            throw new Exception("ChainId not found");

        }
    }
}