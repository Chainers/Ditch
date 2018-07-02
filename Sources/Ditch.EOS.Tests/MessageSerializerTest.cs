using System;
using System.IO;
using System.Linq;
using Cryptography.ECDSA;
using Ditch.Core;
using Ditch.EOS.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Ditch.EOS.Tests
{
    public class MessageSerializerTest
    {
        [Test]
        public void Test()
        {
            var serializer = new MessageSerializer();

            var transaction = JsonConvert.DeserializeObject<SignedTransaction>("{\"signatures\":[],\"context_free_data\":[],\"context_free_actions\":[],\"actions\":[{\"account\":\"currency\",\"name\":\"createpost\",\"authorization\":[{\"actor\":\"currency\",\"permission\":\"active\"}],\"data\":\"01000000000000000000001e4d75af460a746573745f315f75726c0b746573745f315f68617368\"}],\"transaction_extensions\":[],\"expiration\":\"2018-06-21T14:26:34\",\"ref_block_num\":56265,\"ref_block_prefix\":2694524551,\"max_net_usage_words\":0,\"max_cpu_usage_ms\":0,\"delay_sec\":0}");
            var chainId = Hex.HexToBytes("cf057bbfb72640471fd910bcb67639c22df9f92470936cddc1ade0e2f2e7dc4f");

            byte[] msg;
            using (var ms = new MemoryStream())
            {
                ms.Write(chainId, 0, chainId.Length);
                serializer.Serialize<SignedTransaction>(ms, transaction);
                if (transaction.ContextFreeData.Any())
                {
                    throw new NotImplementedException("ContextFreeData");
                }
                else
                {
                    ms.Write(new byte[32], 0, 32);
                }
                msg = ms.ToArray();
            }


            var hex = Hex.ToString(msg);
            Console.WriteLine(hex);

            Assert.IsTrue(hex.Equals("cf057bbfb72640471fd910bcb67639c22df9f92470936cddc1ade0e2f2e7dc4f9ab52b5bc9db872e9ba000000000010000001e4d75af460040c6b4aa6cd445010000001e4d75af4600000000a8ed32322701000000000000000000001e4d75af460a746573745f315f75726c0b746573745f315f68617368000000000000000000000000000000000000000000000000000000000000000000"));
        }
    }
}
