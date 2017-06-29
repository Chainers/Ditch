using Ditch.Helpers;
using Newtonsoft.Json;

namespace Ditch.Operations
{
    [JsonObject(MemberSerialization.OptIn)]
    internal class CustomJsonOperation : BaseOperation
    {
        private readonly string _id;
        private readonly string _json;
        private string[] _requiredAuths;
        private string[] _requiredPostingAuths;

        [SerializeHelper.IgnoreForMessage]
        public override string TypeName => "custom_json";
        public override OperationType Type => OperationType.CustomJson;

        [JsonProperty("required_auths")]
        public virtual string[] RequiredAuths
        {
            get => _requiredAuths ?? (_requiredAuths = new string[0]);
            set => _requiredAuths = value;
        }

        [JsonProperty("required_posting_auths")]
        public virtual string[] RequiredPostingAuths
        {
            get => _requiredPostingAuths ?? (_requiredPostingAuths = new string[0]);
            set => _requiredPostingAuths = value;
        }

        [JsonProperty("id")]
        public string Id => _id;

        [JsonProperty("json")]
        public string Json => _json;

        public CustomJsonOperation(string id, string json)
        {
            _id = id;
            _json = json;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="what">"blog","posts" or "blog" or "posts" or "" = (unfollow).</param>
        /// <returns></returns>
        public static CustomJsonOperation Follow(string name, string what)
        {
            return new CustomJsonOperation("follow", $"[\"follow\", {{\"follower\": \"{GlobalSettings.Login}\", \"following\": \"{name}\", \"what\": [\"{what}\"]}}]");
        }
    }
}