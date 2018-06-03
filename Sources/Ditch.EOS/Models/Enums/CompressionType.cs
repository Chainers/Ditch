using System.ComponentModel;
using Newtonsoft.Json;

namespace Ditch.EOS.Models.Enums
{
    /// <summary>
    /// compression_type
    /// libraries\chain\include\eosio\chain\transaction.hpp
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
    public enum CompressionType
    {

        /// <summary>
        /// API name: none
        /// 0
        /// </summary>
        None,

        /// <summary>
        /// API name: zlib
        /// 1
        /// </summary>
        Zlib
    }
}
