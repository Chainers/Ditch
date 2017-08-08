using System;
using Newtonsoft.Json;

namespace Ditch.Errors
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ResponseError : ErrorInfo
    {
        [JsonProperty("data")]
        public DataError Data { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class DataError : ErrorInfo
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("stack")]
        public DataStackError[] Stack { get; set; }
    }

    public class DataStackError
    {
        [JsonProperty("context")]
        public DataStackContextError Context { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("data")]
        public object Data { get; set; }
    }

    public class DataStackContextError
    {
        [JsonProperty("level")]
        public string Level { get; set; }

        [JsonProperty("file")]
        public string File { get; set; }

        [JsonProperty("line")]
        public long Line { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("hostname")]
        public string HostName { get; set; }

        [JsonProperty("thread_name")]
        public string ThreadName { get; set; }

        [JsonProperty("timestamp")]
        public DateTime TimeStamp { get; set; }
    }
}