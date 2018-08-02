using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// get_currency_stats_params
    /// plugins\chain_plugin\include\eosio\chain_plugin\chain_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetCurrencyStatsParams
    {

        /// <summary>
        /// API name: code
        /// 
        /// </summary>
        /// <returns>API type: name</returns>
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }

        /// <summary>
        /// API name: symbol
        /// 
        /// </summary>
        /// <returns>API type: string</returns>
        [JsonProperty("symbol", NullValueHandling = NullValueHandling.Ignore)]
        public string Symbol { get; set; }
    }
}