using System;
using System.Linq;
using Newtonsoft.Json;

namespace Ditch.Core.Converters
{
    public class ToArrayConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.GetInterfaces().Contains(typeof(IComplexArray));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (CanConvert(objectType))
            {
                var entity = (IComplexArray)Activator.CreateInstance(objectType);
                entity.ReadJson(reader, serializer);
                return entity;
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (CanConvert(value.GetType()))
            {
                ((IComplexArray)value).WriteJson(writer, serializer);
            }
        }
    }

    public interface IComplexArray
    {
        void ReadJson(JsonReader reader, JsonSerializer serializer);

        void WriteJson(JsonWriter write, JsonSerializer serializer);
    }
}
