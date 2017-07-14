using Ditch.Helpers;

namespace Ditch
{
    public static class GlobalSettings
    {
        public delegate void SettingsChangedDelegate();
        public static event SettingsChangedDelegate SettingsChanged;
        private static ChainInfo _chainInfo;


        internal static ChainInfo ChainInfo
        {
            get => _chainInfo ?? (_chainInfo = ChainManager.GetChainInfo(KnownChains.Steem));
            set
            {
                _chainInfo = value;
                SettingsChanged?.Invoke();
            }
        }

        public static string Login { get; set; }

        public static byte[] Key { get; set; }

        public static void Init(string login, string wif, KnownChains chain)
        {
            Init(login, wif, ChainManager.GetChainInfo(chain));
        }

        public static void Init(string login, string wif, ChainInfo chainInfo)
        {
            Init(login, wif);
            ChainInfo = chainInfo;
        }

        public static void Init(string login, string wif)
        {
            Login = login;
            Key = Base58.GetBytes(wif);
        }
    }
}
