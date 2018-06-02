using System.Collections.Generic;
using Ditch.Core;

namespace Ditch.BitShares.Tests
{
    public class UserInfo
    {
        private List<byte[]> _privateKeys;

        public string Login { get; set; } = string.Empty;

        public string Wif { get; set; } = string.Empty;

        public List<byte[]> PrivateKeys => _privateKeys ?? (_privateKeys = new List<byte[]> { Base58.DecodePrivateWif(Wif) });

        public bool IsNsfw { get; set; } = false;

        public bool IsLowRated { get; set; } = false;
    }
}