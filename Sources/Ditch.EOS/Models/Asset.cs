using System;
using System.Globalization;
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

        public double ToDouble()
        {
            var value = ToDoubleString();
            return double.Parse(value, CultureInfo.InvariantCulture);
        }

        public double ToDouble(CultureInfo cultureInfo)
        {
            var value = ToDoubleString();
            return double.Parse(value, cultureInfo);
        }

        public string ToDoubleString()
        {
            var kv = Value.Split(' ');
            if (kv.Length != 2)
                throw new InvalidCastException();

            return kv[0];
        }

        public string Currency()
        {
            var kv = Value.Split(' ');
            if (kv.Length != 2)
                throw new InvalidCastException();

            return kv[1];
        }

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