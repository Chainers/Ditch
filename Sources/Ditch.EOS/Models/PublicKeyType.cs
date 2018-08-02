namespace Ditch.EOS.Models
{
    public class PublicKeyType : PublicKey
    {
        public PublicKeyType() { }

        public PublicKeyType(string value) : base(value) { }

        public PublicKeyType(byte[] data) : base(data) { }
    }
}