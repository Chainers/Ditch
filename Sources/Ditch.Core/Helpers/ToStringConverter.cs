using Newtonsoft.Json;
using System;
using System.Linq;

namespace Ditch.Core.Helpers
{
    public class ToStringConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.GetInterfaces().Contains(typeof(IComplexString));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (CanConvert(objectType))
            {
                var value = reader.Value.ToString();
                var entity = (IComplexString)Activator.CreateInstance(objectType);
                entity.InitFromString(value);
                return entity;
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (CanConvert(value.GetType()))
            {
                var txt = ((IComplexString)value).ToString();
                writer.WriteValue(txt);
            }
        }

    }

    public interface IComplexString
    {
        void InitFromString(string value);

        string ToString();
    }
}
