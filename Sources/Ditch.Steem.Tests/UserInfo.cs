using System.Collections.Generic;
using Ditch.Core.Helpers;

namespace Ditch.Steem.Tests
{
    public class UserInfo
    {
        private List<byte[]> _postingKeys;

        public string Login { get; set; } = string.Empty;

        public string Wif { get; set; } = string.Empty;

        public List<byte[]> PostingKeys => _postingKeys ?? (_postingKeys = new List<byte[]> { Base58.TryGetBytes(Wif) });

        public bool IsNsfw { get; set; } = false;

        public bool IsLowRated { get; set; } = false;
    }
}