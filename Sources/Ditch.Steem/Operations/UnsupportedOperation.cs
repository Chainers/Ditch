using System;
using Ditch.Core.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Ditch.Steem.Operations
{
    [JsonConverter(typeof(CustomConverter))]
    [JsonObject(MemberSerialization.OptIn)]
    public class UnsupportedOperation : BaseOperation, ICustomJson
    {
        public override OperationType Type { get; }

        public override string TypeName { get; }

        private JObject Value { get; set; }


        public UnsupportedOperation(string name, JObject value)
        {
            Value = value;
            TypeName = name;

            OperationType ot;
            if (Enum.TryParse(name.Replace("_", ""), out ot))
            {
                Type = ot;
            }
        }


        #region ICustomJson

        public void ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            Value = serializer.Deserialize<JObject>(reader);
        }

        public void WriteJson(JsonWriter writer, JsonSerializer serializer)
        {
            serializer.Serialize(writer, Value);
        }

        #endregion

    }
}