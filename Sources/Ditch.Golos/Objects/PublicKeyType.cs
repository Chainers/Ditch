using Ditch.Core.Helpers;
using Ditch.Golos.Helpers;
using Newtonsoft.Json;

namespace Ditch.Golos.Objects
{
    [JsonConverter(typeof(ToStringConverter))]
    public partial class PublicKeyType : IComplexString
    {
        public const string AddressPrefix = "GLS";

        private string _value;

        [MessageOrder(1)]
        public byte[] Data => ToBytes();


        public PublicKeyType() { }

        public PublicKeyType(string value)
        {
            _value = value;
        }

        
        public void InitFromString(string value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value;
        }

        private byte[] ToBytes()
        {
            if (!_value.StartsWith(AddressPrefix))
                return new byte[0];

            var buf = _value.Remove(0, 3);
            var s = Base58.Decode(buf);
            var dec = Base58.CutLastBytes(s, 4);
            return dec;
        }
    }
}