using System;
using Newtonsoft.Json;

namespace Ditch.Steem.Models
{
    /// <summary>
    /// Iformation about error
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ErrorInfo
    {
        /// <summary>
        /// ResponseError message
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("code")]
        public long Code { get; set; }


        public override string ToString()
        {
            return $"{base.ToString()}. Code: '{Code}'. Message: '{Message}'";
        }


        /// <inheritdoc />
        /// <summary>
        /// Default constructor of class
        /// </summary>
        protected ErrorInfo()
            : this(string.Empty)
        {
        }

        /// <summary>
        /// Constructor of class
        /// </summary>
        /// <param name="message">ResponseError message</param>
        protected ErrorInfo(string message)
        {
            Message = message;
        }

        /// <summary>
        /// Constructor of class
        /// </summary>
        /// <param name="code">ResponseError code</param>
        /// <param name="message">ResponseError message</param>
        protected ErrorInfo(long code, string message)
        {
            Code = code;
            Message = message;
        }
    }

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