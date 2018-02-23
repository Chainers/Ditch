using Newtonsoft.Json;

namespace Ditch.Steem.Models.Args
{
    /// <summary>
    /// broadcast_transaction_synchronous_args
    /// libraries\plugins\apis\network_broadcast_api\include\steem\plugins\network_broadcast_api\network_broadcast_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class BroadcastTransactionSynchronousArgs : BroadcastTransactionArgs
    {
    }
}
