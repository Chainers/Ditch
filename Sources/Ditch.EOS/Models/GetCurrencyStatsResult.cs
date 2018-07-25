using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// get_currency_stats_result
    /// plugins\chain_plugin\include\eosio\chain_plugin\chain_plugin.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetCurrencyStatsResult
    {

        /// <summary>
        /// API name: supply
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("supply")]
        public string Supply { get; set; }

        /// <summary>
        /// API name: max_supply
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("max_supply")]
        public string MaxSupply { get; set; }

        /// <summary>
        /// API name: issuer
        /// 
        /// </summary>
        /// <returns>API type: account_name</returns>
        [JsonProperty("issuer")]
        public AccountName Issuer { get; set; }
    }
}