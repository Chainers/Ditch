using Newtonsoft.Json;

namespace Ditch.BitShares.Models
{
    /**
     *  @brief adds a signature to a transaction
     */

    /// <summary>
    /// signed_transaction
    /// libraries\chain\include\graphene\chain\protocol\transaction.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public partial class SignedTransaction : Transaction
    {
        private object[][] _operations;

        [JsonProperty("operations")]
        public object[][] Operations
        {
            get
            {
                if (_operations != null)
                    return _operations;

                if (BaseOperations == null)
                    return new object[0][];

                var buf = new object[BaseOperations.Length][];
                for (var i = 0; i < BaseOperations.Length; i++)
                {
                    var op = BaseOperations[i];
                    buf[i] = new object[] { op.TypeName, op };
                }
                return buf;
            }
            set => _operations = value; //TODO: need cast from objects to some operations
        }

        /// <summary>
        /// API name: signatures
        /// 
        /// </summary>
        /// <returns>API type: signature_type</returns>
        [JsonProperty("signatures")]
        public string[] Signatures { get; set; } = new string[0];
    }
}
