using Newtonsoft.Json;
using System;
using System.Linq;

namespace Ditch.Core.Helpers
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
                var buf = new object[3];
                buf[0] = reader.ReadAsString();
                buf[1] = (byte)reader.ReadAsInt32();
                buf[2] = reader.ReadAsString();
                reader.Read(); //end;
                var entity = (IComplexArray)Activator.CreateInstance(objectType);
                entity.InitFromArray(buf);
                return entity;
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (CanConvert(value.GetType()))
            {
                var buf = ((IComplexArray)value).ToArray();
                writer.WriteRawValue($"[\"{buf[0]}\",{buf[1]},\"{buf[2]}\"]");
            }
        }
    }

    public interface IComplexArray
    {
        void InitFromArray(object[] value);

        object[] ToArray();
    }
}
