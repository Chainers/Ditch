using System;
using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.Golos.Models
{
    /// <summary>
    /// convert_request_object
    /// libraries\chain\include\golos\chain\steem_objects.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ConvertRequestObject
    {

        /// <summary>
        /// API name: id
        /// 
        /// </summary>
        /// <returns>API type: id_type</returns>
        [JsonProperty("id")]
        public object Id { get; set; }

        /// <summary>
        /// API name: owner
        /// 
        /// </summary>
        /// <returns>API type: account_name_type</returns>
        [JsonProperty("owner")]
        public string Owner { get; set; }

        /// <summary>
        /// API name: requestid
        /// = 0; ///&lt; id set by owner, the owner,requestid pair must be unique
        /// </summary>
        /// <returns>API type: uint32_t</returns>
        [JsonProperty("requestid")]
        public UInt32 Requestid {get; set;}

        /// <summary>
        /// API name: amount
        /// 
        /// </summary>
        /// <returns>API type: asset</returns>
        [JsonProperty("amount")]
        public Asset Amount { get; set; }

        /// <summary>
        /// API name: conversion_date
        /// at this time the feed_history_median_price * amount
        /// </summary>
        /// <returns>API type: time_point_sec</returns>
        [JsonProperty("conversion_date")]
        public TimePointSec ConversionDate {get; set;}
    }
}
