﻿using Ditch.Helpers;
using Newtonsoft.Json;

namespace Ditch.Operations.Post
{
    [JsonObject(MemberSerialization.OptIn)]
    public class CustomJsonOperation : BaseOperation
    {
        private string[] _requiredAuths;
        private string[] _requiredPostingAuths;

        public override string TypeName => "custom_json";
        public override OperationType Type => OperationType.CustomJson;

        [SerializeHelper.MessageOrder(20)]
        [JsonProperty("required_auths")]
        public string[] RequiredAuths
        {
            get => _requiredAuths ?? (_requiredAuths = new string[0]);
            set => _requiredAuths = value;
        }

        [SerializeHelper.MessageOrder(30)]
        [JsonProperty("required_posting_auths")]
        public string[] RequiredPostingAuths
        {
            get => _requiredPostingAuths ?? (_requiredPostingAuths = new string[0]);
            set => _requiredPostingAuths = value;
        }
        
        [SerializeHelper.MessageOrder(40)]
        [JsonProperty("id")]
        public string Id { get; }

        [SerializeHelper.MessageOrder(50)]
        [JsonProperty("json")]
        public string Json { get; }

        public CustomJsonOperation(string id, string json)
        {
            Id = id;
            Json = json;
        }
    }
}