using System.IO;
using Ditch.Core.Interfaces;
using Newtonsoft.Json;

namespace Ditch.Golos.Models
{
    /// <summary>
    /// operation_wrapper
    /// libraries\protocol\include\golos\protocol\operations.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class OperationWrapper : ICustomSerializer
    {

        /// <summary>
        /// API name: op
        /// 
        /// </summary>
        /// <returns>API type: operation</returns>
        [JsonProperty("op")]
        public Operation Op { get; set; }

        #region ICustomSerializer

        public void Serializer(Stream stream, IMessageSerializer serializeHelper)
        {
            serializeHelper.AddToMessageStream(stream, Op.GetType(), Op);
        }

        #endregion
    }
}
