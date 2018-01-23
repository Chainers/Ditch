using System.Collections.Generic;
using Ditch.Core.Helpers;

namespace Ditch.Golos.Tests
{
    public class UserInfo
    {
        private List<byte[]> _postingKeys;

        public string Login { get; set; } = string.Empty;

        public string PostingWif { get; set; } = string.Empty;

        public string ActiveWif { get; set; } = string.Empty;

        public List<byte[]> PostingKeys => _postingKeys ?? (_postingKeys = new List<byte[]> { Base58.TryGetBytes(PostingWif) });

        public List<byte[]> ActiveKeys => _postingKeys ?? (_postingKeys = new List<byte[]> { Base58.TryGetBytes(ActiveWif) });

        public bool IsNsfw { get; set; } = false;

        public bool IsLowRated { get; set; } = false;
    }
}