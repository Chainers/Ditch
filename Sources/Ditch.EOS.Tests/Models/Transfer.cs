using Ditch.EOS.Models;
using Newtonsoft.Json;

namespace Ditch.EOS.Tests.Models
{
    /// <summary>
    /// transfer
    /// 
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class Transfer
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
        public Asset Quantity { get; set; }

        /// <summary>
        /// API name: memo
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        //[JsonProperty("memo")]
        //public string Memo { get; set; }
    }
}
