using System;
using Newtonsoft.Json;

namespace Ditch.Golos.Models.Objects
{
    /// <summary>
    /// convert_request_object
    /// libraries\chain\include\golos\chain\steem_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class ConvertRequestObject
    {

        // bdType : id_type
        [JsonProperty("id")]
        public object Id { get; set; }

        // bdType : account_name_type
        [JsonProperty("owner")]
        public string Owner { get; set; }

        // bdType : uint32_t | = 0; 
        /// <summary>
        /// id set by owner,the owner,requestid pair must be unique
        /// </summary>
        [JsonProperty("requestid")]
        public UInt32 Requestid { get; set; }

        // bdType : asset
        [JsonProperty("amount")]
        public Asset Amount { get; set; }

        
        [JsonProperty("conversion_date")]
        public DateTime ConversionDate {get; set;}
    }
}
