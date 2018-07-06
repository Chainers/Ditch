using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// get_smt_next_identifier_return
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class GetSmtNextIdentifierReturn
    {

        /// <summary>
        /// API name: nais
        /// 
        /// </summary>
        /// <returns>API type: asset_symbol_type</returns>
        [JsonProperty("nais")]
        public AssetSymbolType[] Nais {get; set;}
    }
}
