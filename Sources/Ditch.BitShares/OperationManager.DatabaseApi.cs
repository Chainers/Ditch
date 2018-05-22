using System.Threading;
using Ditch.Core.JsonRpc;

namespace Ditch.BitShares
{

    public partial class OperationManager
    {
        public JsonRpcResponse<T> GetConfig<T>(CancellationToken token)
        {
            return CustomGetRequest<T>(KnownApiNames.DatabaseApi, "get_config", token);
        }
    }
}
