namespace Ditch.Operations
{
    public enum Api
    {
        DefaultApi = 0,
        LoginApi = 1,
        AccountByKeyApi = 2,
        NetworkBroadcastApi = 3,
        FollowApi = 5,
        MarketHistoryApi = 6,
    }

    public class ApiNames
    {
        public const string DatabaseApi = "database_api";
        public const string AccountByKeyApi = "account_by_key_api";
        public const string NetworkBroadcastApi = "network_broadcast_api";
    }
}