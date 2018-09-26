using Cryptography.ECDSA;

namespace Ditch.Golos
{
    public class Config
    {
        public static byte[] ChainId { get; set; } = Hex.HexToBytes("782a3039b478c839e4cb0c941ff4eaeb7df40bdd68bd441afd444b9da763de12");
        public static string KeyPrefix { get; set; } ="GLS";

        public string[] ChainFieldName { get; set; } = { "STEEM_CHAIN_ID", "STEEMIT_CHAIN_ID" };
    }
}