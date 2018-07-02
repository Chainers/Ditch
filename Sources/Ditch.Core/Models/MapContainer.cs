using System.Collections.Generic;
using System.IO;
using Ditch.Core.Converters;
using Ditch.Core.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Ditch.Core.Models
{
    [JsonConverter(typeof(CustomConverter))]
    public class MapContainer<TKey, TValue> : List<KeyValuePair<TKey, TValue>>, ICustomJson, ICustomSerializer
    {
        #region ICustomSerializer

        public void Serializer(Stream stream, IMessageSerializer serializeHelper)
        {
            var length = (byte)Count;
            serializeHelper.AddToMessageStream(stream, typeof(byte), length);
            var kType = typeof(TKey);
            var vType = typeof(TValue);

            foreach (var item in this)
            {
                serializeHelper.AddToMessageStream(stream, kType, item.Key);
                serializeHelper.AddToMessageStream(stream, vType, item.Value);
            }
        }

        #endregion
        
        #region ICustomJson

        public void ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var array = JArray.Load(reader);

            foreach (var jToken in array)
            {
                var item = (JArray)jToken;
                var id = item[0].ToObject<TKey>();
                var value = item[1].ToObject<TValue>();
                Add(new KeyValuePair<TKey, TValue>(id, value));
            }
        }

        public void WriteJson(JsonWriter writer, JsonSerializer serializer)
        {
            writer.WriteStartArray();

            foreach (var item in this)
            {
                writer.WriteStartArray();
                serializer.Serialize(writer, item.Key, typeof(TKey));
                serializer.Serialize(writer, item.Value, typeof(TValue));
                writer.WriteEndArray();
            }

            writer.WriteEndArray();
        }

        #endregion
    }
}