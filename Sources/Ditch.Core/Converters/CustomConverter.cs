using System;
using System.Linq;
using Newtonsoft.Json;

namespace Ditch.Core.Converters
{
    public class CustomConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.GetInterfaces().Contains(typeof(ICustomJson));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (CanConvert(objectType))
            {
                var entity = (ICustomJson)Activator.CreateInstance(objectType);
                entity.ReadJson(reader, serializer);
                return entity;
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (CanConvert(value.GetType()))
            {
                ((ICustomJson)value).WriteJson(writer, serializer);
            }
        }
    }

    public interface ICustomJson
    {
        void ReadJson(JsonReader reader, JsonSerializer serializer);

        void WriteJson(JsonWriter writer, JsonSerializer serializer);
    }
}
