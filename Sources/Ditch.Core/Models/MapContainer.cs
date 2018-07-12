using System;
using System.Collections.Generic;
using System.IO;
using Ditch.Core.Converters;
using Ditch.Core.Interfaces;
using Newtonsoft.Json;

namespace Ditch.Core.Models
{
    [JsonConverter(typeof(CustomJsonConverter))]
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
            if (reader.TokenType != JsonToken.StartArray)
                throw new InvalidCastException(reader.TokenType.ToString());
            reader.Read();

            while (reader.TokenType != JsonToken.EndArray)
            {
                if (reader.TokenType != JsonToken.StartArray)
                    throw new InvalidCastException(reader.TokenType.ToString());
                reader.Read();

                var key = serializer.Deserialize<TKey>(reader);
                reader.Read();
                var value = serializer.Deserialize<TValue>(reader);
                Add(new KeyValuePair<TKey, TValue>(key, value));
                reader.Read();
                reader.Read();
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