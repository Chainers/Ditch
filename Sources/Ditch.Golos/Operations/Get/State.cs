using Newtonsoft.Json;

namespace Ditch.Golos.Operations.Get
{
    /// <summary>
    /// state
    /// golos-0.16.3\libraries\app\include\steemit\app\state.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class State
    {

        // bdType : string
        [JsonProperty("current_route")]
        public string CurrentRoute { get; set; }

        // bdType : dynamic_global_property_api_obj
        [JsonProperty("props")]
        public DynamicGlobalPropertyApiObj Props { get; set; }

        // bdType : category_index
        [JsonProperty("category_idx")]
        public object CategoryIdx { get; set; }

        // bdType : tag_index
        [JsonProperty("tag_idx")]
        public object TagIdx { get; set; }

        // bdType : map<string,discussion_index>
        /// <summary>
        /// is the global discussion index
        /// </summary>
        [JsonProperty("discussion_idx")]
        public object DiscussionIdx { get; set; }

        // bdType : map<string,category_api_obj>
        [JsonProperty("categories")]
        public object Categories { get; set; }

        // bdType : map<string,tag_api_obj>
        [JsonProperty("tags")]
        public object Tags { get; set; }

        // bdType : map<string,discussion>
        /// <summary>
        ///  map from account/slug to full nested discussion
        /// </summary>
        [JsonProperty("content")]
        public object Content { get; set; }

        // bdType : map<string,extended_account>
        [JsonProperty("accounts")]
        public object Accounts { get; set; }

        // bdType : vector<account_name_type>
        /// <summary>
        /// The list of miners who are queued to produce work
        /// </summary>
        [JsonProperty("pow_queue")]
        public string[] PowQueue { get; set; }

        // bdType : map<string,witness_api_obj>
        [JsonProperty("witnesses")]
        public object Witnesses { get; set; }

        // bdType : witness_schedule_api_obj
        [JsonProperty("witness_schedule")]
        public WitnessScheduleApiObj WitnessSchedule { get; set; }

        // bdType : price
        [JsonProperty("feed_price")]
        public Price FeedPrice { get; set; }

        // bdType : string
        [JsonProperty("error")]
        public string Error { get; set; }

        // bdType : optional<market>
        [JsonProperty("market_data")]
        public object MarketData { get; set; }
    }
}
