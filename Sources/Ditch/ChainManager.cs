using System.Collections.Generic;
using Cryptography.ECDSA;

namespace Ditch
{
    public class ChainManager
    {
        public enum KnownChains
        {
            Steem,
            Golos,
            Test
        }


        private static readonly Dictionary<KnownChains, ChainInfo> ChainInfoDic;

        static ChainManager()
        {
            ChainInfoDic = new Dictionary<KnownChains, ChainInfo>
            {
                {
                    KnownChains.Steem, new ChainInfo
                    {
                        ChainId = Hex.HexToBytes("0000000000000000000000000000000000000000000000000000000000000000"),
                        Prefix = "STM",
                        SteemSymbol = "STEEM",
                        SbdSymbol = "SBD",
                        VestsSymbol = "VESTS",
                        Url = "wss://steemd.steemit.com"
                    }
                },
                {
                    KnownChains.Golos, new ChainInfo
                    {
                        ChainId = Hex.HexToBytes("782a3039b478c839e4cb0c941ff4eaeb7df40bdd68bd441afd444b9da763de12"),
                        Prefix = "GLS",
                        SteemSymbol = "GOLOS",
                        SbdSymbol = "GBG",
                        VestsSymbol = "GESTS",
                        Url = "wss://ws.golos.io"
                    }
                },
                {
                    KnownChains.Test, new ChainInfo
                    {
                        ChainId = Hex.HexToBytes("18dcf0a285365fc58b71f18b3d3fec954aa0c141c44e4e5cb4cf777b9eab274e"),
                        Prefix = "TST",
                        SteemSymbol = "CORE",
                        SbdSymbol = "TEST",
                        VestsSymbol = "CESTS",
                        Url = "wss://localhost"
                    }
                }
            };

        }


        public static ChainInfo GetChainInfo(KnownChains chain)
        {
            if (ChainInfoDic.ContainsKey(chain))
                return ChainInfoDic[chain];
            return null;
        }
    }
}