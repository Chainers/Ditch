using Newtonsoft.Json;

namespace Ditch.EOS.Tests.Apis
{
    public class CreatePostArgs
    {
        [JsonProperty("url_photo")]
        public string UrlPhoto { get; set; }

        [JsonProperty("hash_photo")]
        public string IpfsHashPhoto { get; set; }
        
        [JsonProperty("creator")]
        public string AccountCreator { get; set; }
    }
}