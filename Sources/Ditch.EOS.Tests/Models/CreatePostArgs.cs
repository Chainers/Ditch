using Newtonsoft.Json;

namespace Ditch.EOS.Tests.Models
{
    public class CreatePostArgs
    {
        [JsonProperty("url_photo")]
        public string UrlPhoto { get; set; }

        [JsonProperty("hash_photo")]
        public string IpfsHashPhoto { get; set; }

        //[JsonProperty("parent_post")]
        //public UInt64 ParentPost { get; set; }

        [JsonProperty("creator")]
        public string AccountCreator { get; set; }
    }

    //public class CreatePostArgs
    //{
    //    [JsonProperty("url_photo")]
    //    public string UrlPhoto { get; set; }

    //    [JsonProperty("ipfs_hash_photo")]
    //    public string IpfsHashPhoto { get; set; }

    //    [JsonProperty("parent_post")]
    //    public UInt64 ParentPost { get; set; }

    //    [JsonProperty("account_creator")]
    //    public string AccountCreator { get; set; }
    //}
}