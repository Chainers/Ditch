using Ditch.Steem.Models.Other;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Return
{
    /// <summary>
    /// get_transaction_return
    /// libraries\plugins\apis\account_history_api\include\steem\plugins\account_history_api\account_history_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetTransactionReturn : AnnotatedSignedTransaction
    {
    }
}
