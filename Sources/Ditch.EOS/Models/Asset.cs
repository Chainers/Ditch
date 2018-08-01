using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    [JsonConverter(typeof(CustomJsonConverter))]
    [JsonObject(MemberSerialization.OptIn)]
    public class Asset : ICustomJson
    {
        public string Value { get; set; }

        public Asset() { }

        public Asset(string value)
        {
            Value = value;
        }


        #region ICustomJson

        public void ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            Value = reader.Value.ToString();
        }

        public void WriteJson(JsonWriter writer, JsonSerializer serializer)
        {
            writer.WriteValue(Value);
        }

        #endregion
    }
}