using Ditch.Steem.Models.Objects;
using Newtonsoft.Json;

namespace Ditch.Steem.Models.Return
{
    /// <summary>
    /// list_sbd_conversion_requests_return
    /// libraries\plugins\apis\database_api\include\steem\plugins\database_api\database_api_args.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ListSbdConversionRequestsReturn
    {

        /// <summary>
        /// API name: requests
        /// 
        /// </summary>
        /// <returns>API type: api_convert_request_object</returns>
        [JsonProperty("requests")]
        public ApiConvertRequestObject[] Requests {get; set;}
    }
}
