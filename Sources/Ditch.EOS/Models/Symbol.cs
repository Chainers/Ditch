using Ditch.Core.Converters;
using Newtonsoft.Json;

namespace Ditch.EOS.Models
{
    /// <summary>
    /// symbol
    /// libraries\chain\include\eosio\chain\symbol.hpp
    /// </summary>
    [JsonConverter(typeof(CustomJsonConverter))]
    [JsonObject(MemberSerialization.OptIn)]
    public class Symbol : ICustomJson
    {
        public string Value { get; set; }


        public override string ToString()
        {
            return Value;
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
