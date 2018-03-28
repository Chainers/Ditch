using System.Collections.Generic;
using System.Text;
using Ditch.Core.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Ditch.Golos.Models.Other
{
    [JsonConverter(typeof(MapConverter))]
    public class MapContainer<TKey, TValue> : List<KeyValuePair<TKey, TValue>>, IMap
    {
        public void Init(JsonReader reader)
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

        public string ToJson()
        {
            var sb = new StringBuilder("[");
            var isFirst = true;
            foreach (var item in this)
            {
                if (isFirst)
                    isFirst = false;
                else
                    sb.AppendLine(",");

                sb.Append("[");
                sb.Append(item.Key);
                sb.Append(",");
                sb.Append(JsonConvert.SerializeObject(item.Value));
                sb.Append("]");
            }
            sb.Append("]");

            return sb.ToString();
        }
    }
}