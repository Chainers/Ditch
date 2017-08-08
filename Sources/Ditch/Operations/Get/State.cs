using Newtonsoft.Json;

namespace Ditch.Operations.Get
{
    [JsonObject(MemberSerialization.OptIn)]
    public class State
    {
        [JsonProperty("current_route")]
        public string CurrentRoute { get; set; }

        [JsonProperty("props")]
        public DynamicGlobalProperties Props { get; set; }

        [JsonProperty("category_idx")]
        public object CategoryIdx { get; set; }

        [JsonProperty("tag_idx")]
        public TagIdx TagIdx { get; set; }

        // map< string, tag_api_obj >
        [JsonProperty("tags")]
        public object Tags { get; set; } 
        
        // map< string, tag_api_obj >
        [JsonProperty("categories")]
        public object Categories { get; set; }

        //map< string, discussion >
        /// <summary>
        ///  map from account/slug to full nested discussion
        /// </summary>
        [JsonProperty("content")]
        public Content Content { get; set; }

        //map< string, extended_account >
        [JsonProperty("accounts")]
        public object Accounts { get; set; }

        //vector< account_name_type >
        /// <summary>
        /// The list of miners who are queued to produce work
        /// </summary>
        [JsonProperty("pow_queue")]
        public object[] PowQueue { get; set; }

        //map< string, witness_api_obj >
        [JsonProperty("witnesses")]
        public object Witnesses { get; set; }

        //map<string, discussion_index>
        /// <summary>
        /// is the global discussion index
        /// </summary>
        [JsonProperty("discussion_idx")]
        public object DiscussionIdx { get; set; }

        [JsonProperty("witness_schedule")]
        public WitnessSchedule WitnessSchedule { get; set; }

        //price 
        [JsonProperty("feed_price")]
        public object FeedPrice { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        // optional< market > 
        [JsonProperty("market_data")]
        public object MarketData { get; set; }
    }
}
