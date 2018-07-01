using System;
using Cryptography.ECDSA;

namespace Ditch.EOS
{
    public class Base58 : Core.Base58
    {
        public static string EncodeSig(byte[] source)
        {
            var buf = AddLastBytes(source, 2);
            buf[source.Length] = 0x4b; //K
            buf[source.Length + 1] = 0x31; //1
            var checksum = Ripemd160Manager.GetHash(buf);

            buf = AddLastBytes(source, CheckSumSizeInBytes);
            Array.Copy(checksum, 0, buf, source.Length, CheckSumSizeInBytes);
            return "SIG_K1_" + Encode(buf);
        }
    }
}
