using Ditch.EOS.Models;
using Newtonsoft.Json;

namespace Ditch.EOS.Tests.Models
{
    /// <summary>
    /// transfer
    /// 
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Transfer
    {

        /// <summary>
        /// API name: from
        /// 
        /// </summary>
        /// <returns>API type: account_name</returns>
        [JsonProperty("from")]
        public string From { get; set; }

        /// <summary>
        /// API name: to
        /// 
        /// </summary>
        /// <returns>API type: account_name</returns>
        [JsonProperty("to")]
        public string To { get; set; }

        /// <summary>
        /// API name: quantity
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("amount")]
        public Asset Amount { get; set; }
    }
}
