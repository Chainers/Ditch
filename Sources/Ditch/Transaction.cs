using System;
using System.Collections.Generic;
using System.Linq;
using Cryptography.ECDSA;
using Newtonsoft.Json;

namespace Ditch
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Transaction
    {
        public byte[] ChainId { get; set; } = new byte[0]; //64

        [JsonProperty("ref_block_num")]
        public UInt16 RefBlockNum { get; set; }

        [JsonProperty("ref_block_prefix")]
        public UInt32 RefBlockPrefix { get; set; }

        [JsonProperty("expiration")]
        public DateTime Expiration { get; set; }

        public BaseOperation[] BaseOperations { get; set; }

        [SerializeHelper.IgnoreForMessage]
        [JsonProperty("operations")]
        public object[][] Operations
        {
            get
            {
                var buf = new object[BaseOperations.Length][];
                for (var i = 0; i < BaseOperations.Length; i++)
                {
                    var op = BaseOperations[i];
                    buf[i] = new object[] { op.TypeName, op };
                }
                return buf;
            }
        }

        public string ExtensionsStr { get; set; } = string.Empty;

        [SerializeHelper.IgnoreForMessage]
        [JsonProperty("extensions")]
        public List<byte[]> Extensions { get; set; } = new List<byte[]>();

        [SerializeHelper.IgnoreForMessage]
        public List<byte[]> Signatures { get; set; } = new List<byte[]>();

        [SerializeHelper.IgnoreForMessage]
        [JsonProperty("signatures")]
        public string[] SignaturesStr { get { return Signatures.Select(i => Hex.ToString(i)).ToArray(); } }
    }
}