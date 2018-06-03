using System.Collections.Generic;
using Ditch.Core;

namespace Ditch.Steem.Tests
{
    public class UserInfo
    {
        private List<byte[]> _postingKeys;
        private List<byte[]> _activeKeys;

        public string Login { get; set; } = string.Empty;

        public string PostingWif { get; set; } = string.Empty;

        public string ActiveWif { get; set; } = string.Empty;

        public List<byte[]> PostingKeys => _postingKeys ?? (_postingKeys = new List<byte[]> { Base58.DecodePrivateWif(PostingWif) });

        public List<byte[]> ActiveKeys => _activeKeys ?? (_activeKeys = new List<byte[]> { Base58.DecodePrivateWif(ActiveWif) });

        public bool IsNsfw { get; set; } = false;

        public bool IsLowRated { get; set; } = false;
    }
}