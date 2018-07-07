using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /// <summary>
    /// blind_receipt
    /// libraries\wallet\include\graphene\wallet\wallet.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class BlindReceipt
    {

        /// <summary>
        /// API name: date
        /// 
        /// </summary>
        /// <returns>API type: time_point</returns>
        [JsonProperty("date")]
        public object Date { get; set; }

        /// <summary>
        /// API name: from_key
        /// 
        /// </summary>
        /// <returns>API type: public_key_type</returns>
        [JsonProperty("from_key")]
        public PublicKeyType FromKey { get; set; }

        /// <summary>
        /// API name: from_label
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("from_label")]
        public string FromLabel { get; set; }

        /// <summary>
        /// API name: to_key
        /// 
        /// </summary>
        /// <returns>API type: public_key_type</returns>
        [JsonProperty("to_key")]
        public PublicKeyType ToKey { get; set; }

        /// <summary>
        /// API name: to_label
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("to_label")]
        public string ToLabel { get; set; }

        /// <summary>
        /// API name: amount
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("amount")]
        public object Amount { get; set; }

        /// <summary>
        /// API name: memo
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("memo")]
        public string Memo { get; set; }

        /// <summary>
        /// API name: control_authority
        /// 
        /// </summary>
        /// <returns>API type: authority</returns>
        [JsonProperty("control_authority")]
        public Authority ControlAuthority { get; set; }

        /// <summary>
        /// API name: data
        /// 
        /// </summary>
        /// <returns>API type: stealth_confirmation::memo_data</returns>
        [JsonProperty("data")]
        public object Data { get; set; }

        /// <summary>
        /// API name: used
        /// = false;
        /// </summary>
        /// <returns>API type: bool</returns>
        [JsonProperty("used")]
        public bool Used { get; set; }

        /// <summary>
        /// API name: conf
        /// 
        /// </summary>
        /// <returns>API type: stealth_confirmation</returns>
        [JsonProperty("conf")]
        public StealthConfirmation Conf { get; set; }
    }
}
