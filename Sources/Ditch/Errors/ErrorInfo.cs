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
        private string _message;
        private long _code;

        /// <summary>
        /// ResponseError message
        /// </summary>
        [JsonProperty("message")]
        public virtual string Message
        {
            get => _message;
            set => _message = value;
        }

        [JsonProperty("code")]
        public virtual long Code
        {
            get => _code;
            set => _code = value;
        }


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
            _message = message;
        }

        /// <summary>
        /// Constructor of class
        /// </summary>
        /// <param name="code">ResponseError code</param>
        /// <param name="message">ResponseError message</param>
        protected ErrorInfo(long code, string message)
        {
            _code = code;
            _message = message;
        }
    }
}