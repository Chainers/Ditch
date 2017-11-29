using System;
using Ditch.Core;
using Newtonsoft.Json;

namespace Ditch.Golos.Operations.Get
{
    /// <summary>
    /// convert_request_object
    /// golos-0.16.3\libraries\chain\include\steemit\chain\steem_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ConvertRequestObject
    {

        // bdType : id_type
        [JsonProperty("id")]
        public object Id { get; set; }

        // bdType : account_name_type
        [JsonProperty("owner")]
        public object Owner { get; set; }

        // bdType : uint32_t | = 0; 
        /// <summary>
        /// id set by owner,the owner,requestid pair must be unique
        /// </summary>
        [JsonProperty("requestid")]
        public UInt32 Requestid { get; set; }

        // bdType : asset
        [JsonProperty("amount")]
        public Money Amount { get; set; }
    }
}
