using System;
using System.IO;
using Ditch.Core.Converters;
using Ditch.Core.Interfaces;
using Newtonsoft.Json;

namespace Ditch.Core.Models
{
    [JsonConverter(typeof(CustomConverter))]
    public class TimePoint : ICustomSerializer, ICustomJson
    {
        public DateTime Value { get; set; }


        public TimePoint() { }

        public TimePoint(DateTime value)
        {
            Value = value;
        }


        public static implicit operator DateTime(TimePoint d)
        {
            return d.Value;
        }

        public static implicit operator TimePoint(DateTime d)
        {
            return new TimePoint(d);
        }


        #region ICustomJson

        public void ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            Value = serializer.Deserialize<DateTime>(reader);
        }

        public void WriteJson(JsonWriter writer, JsonSerializer serializer)
        {
            writer.WriteValue(Value.ToString("s"));
        }

        #endregion

        #region ICustomSerializer

        public void Serializer(Stream stream, IMessageSerializer serializeHelper)
        {
            var buf = BitConverter.GetBytes((UInt64)(Value.Ticks / 10000 - 62135596800000)); // 01.01.1970
            stream.Write(buf, 0, buf.Length);
        }

        #endregion
    }
}