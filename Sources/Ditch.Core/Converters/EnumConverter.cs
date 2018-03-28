using System;
using System.Text;
using Newtonsoft.Json;

namespace Ditch.Core.Converters
{
    public class EnumConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            value = FromJson(value);
            return Enum.Parse(objectType, value);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var txt = value.ToString();
            txt = ToJson(txt);
            writer.WriteValue(txt);
        }

        public override bool CanConvert(Type objectType)
        {
            return false;
        }

        public static string FromJson(string value)
        {
            var sb = new StringBuilder();
            var isUp = true;
            for (var i = 0; i < value.Length; i++)
            {
                var ch = value[i];
                if (ch == '_')
                {
                    isUp = true;
                    continue;
                }

                if (isUp)
                {
                    ch = char.ToUpper(ch);
                    isUp = false;
                }

                sb.Append(ch);
            }
            return sb.ToString();
        }

        public static string ToJson(string value)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < value.Length; i++)
            {
                var ch = value[i];
                if (char.IsUpper(ch))
                {
                    if (i > 0)
                        sb.Append('_');
                    ch = char.ToLower(ch);
                }
                sb.Append(ch);

            }
            return sb.ToString();
        }
    }
}
