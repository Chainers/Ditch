using Ditch.Helpers;

namespace Ditch
{
    public static class GlobalSettings
    {
        public delegate void SettingsChangedDelegate();
        public static event SettingsChangedDelegate SettingsChanged;

        public static bool IsInited { get; set; }

        public static ChainInfo ChainInfo { get; set; }

        public static string Login { get; set; }

        public static byte[] Key { get; set; }


        public static void Init(string login, string wif, ChainInfo chainInfo)
        {
            ChainInfo = chainInfo;
            Login = login;
            Key = Base58.GetBytes(wif);

            SettingsChanged?.Invoke();
            IsInited = true;
        }

        public static void Init(string login, string wif, KnownChains chain)
        {
            Init(login, wif, ChainManager.GetChainInfo(chain));
        }
    }
}