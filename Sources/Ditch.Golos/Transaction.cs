using System;
using System.Collections.Generic;
using System.Linq;
using Ditch.Core.Helpers;
using Ditch.Golos.Helpers;
using Ditch.Golos.Operations.Post;
using Newtonsoft.Json;

namespace Ditch.Golos
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Transaction
    {
        public const string OperationName = "broadcast_transaction";

        [SerializeHelper.MessageOrder(0)]
        public byte[] ChainId { get; set; } = new byte[0]; //64

        [SerializeHelper.MessageOrder(1)]
        [JsonProperty("ref_block_num")]
        public UInt16 RefBlockNum { get; set; }

        [SerializeHelper.MessageOrder(2)]
        [JsonProperty("ref_block_prefix")]
        public UInt32 RefBlockPrefix { get; set; }

        [SerializeHelper.MessageOrder(3)]
        [JsonProperty("expiration")]
        public DateTime Expiration { get; set; }

        [SerializeHelper.MessageOrder(4)]
        public BaseOperation[] BaseOperations { get; set; }

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

        [SerializeHelper.MessageOrder(5)]
        public string ExtensionsStr { get; set; } = string.Empty;

        [JsonProperty("extensions")]
        public List<byte[]> Extensions { get; set; } = new List<byte[]>();

        public List<byte[]> Signatures { get; set; } = new List<byte[]>();

        [JsonProperty("signatures")]
        public string[] SignaturesStr => Signatures.Select(Hex.ToString).ToArray();
    }
}