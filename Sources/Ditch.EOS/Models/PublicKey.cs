using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// public_key
    /// contracts\eosiolib\public_key.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class PublicKey
    {

        /// <summary>
        /// API name: type
        /// 
        /// </summary>
        /// <returns>API type: unsigned_int</returns>
        [JsonProperty("type")]
        public uint Type {get; set;}

        /// <summary>
        /// API name: data
        /// 
        /// </summary>
        /// <returns>API type: char</returns>
        [JsonProperty("data")]
        public char[] Data {get; set;}
    }
}
