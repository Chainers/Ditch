using System;
using System.Linq;
using Newtonsoft.Json;

namespace Ditch.Core.Converters
{
    public class MapConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.GetInterfaces().Contains(typeof(IMap));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (CanConvert(objectType))
            {
                var entity = (IMap)Activator.CreateInstance(objectType);
                entity.Init(reader);
                return entity;
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (CanConvert(value.GetType()))
            {
                var json = ((IMap)value).ToJson();
                writer.WriteRaw(json);
            }
        }

    }

    public interface IMap
    {
        void Init(JsonReader reader);

        string ToJson();
    }
}
