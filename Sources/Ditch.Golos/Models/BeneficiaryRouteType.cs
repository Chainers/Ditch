using Newtonsoft.Json;

namespace Ditch.Golos.Models
{
    /// <summary>
    /// beneficiary_route_type
    /// libraries\protocol\include\golos\protocol\steem_operations.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class BeneficiaryRouteType
    {

        /// <summary>
        /// API name: account
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("account")]
        public string Account {get; set;}

        /// <summary>
        /// API name: weight
        /// 
        /// </summary>
        /// <returns>API type: uint16_t</returns>
        [JsonProperty("weight")]
        public ushort Weight {get; set;}
    }
}
