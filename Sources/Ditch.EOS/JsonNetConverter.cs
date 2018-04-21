using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Ditch.EOS
{
    public sealed class JsonNetConverter
    {
        private static readonly Encoding Encoding = new UTF8Encoding(false);
        private readonly JsonSerializer _serializer;

        public JsonNetConverter()
        {
            _serializer = new JsonSerializer();
            Configure(_serializer);
        }

        public string Serialize(object obj)
        {
            var output = new MemoryStream();
            using (var writer = new StreamWriter(output))
            {
                _serializer.Serialize(writer, obj);
            }

            return Encoding.GetString(output.ToArray());
        }

        public T Deserialize<T>(string s)
        {
            var input = new MemoryStream(Encoding.UTF8.GetBytes(s ?? ""));
            using (var reader = new StreamReader(input))
            {
                return _serializer.Deserialize<T>(new JsonTextReader(reader));
            }
        }

        private void Configure(JsonSerializer serializer)
        {
            serializer.ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };
            serializer.DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK";
        }
    }
}
