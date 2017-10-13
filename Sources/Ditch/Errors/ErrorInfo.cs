using System;
using Newtonsoft.Json;

namespace Ditch.Errors
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


        /// <summary>
        /// Default constructor of class
        /// </summary>
        protected ErrorInfo()
            : this(String.Empty)
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
}