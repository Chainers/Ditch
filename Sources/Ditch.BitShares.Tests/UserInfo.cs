using System.Collections.Generic;
using Ditch.Core;

namespace Ditch.BitShares.Tests
{
    public class UserInfo
    {
        private List<byte[]> _activeKeys;
        private List<byte[]> _ownerKeys;

        public string Login { get; set; } = string.Empty;

        public string ActiveWif { get; set; } = string.Empty;

        public string OwnerWif { get; set; } = string.Empty;

        public List<byte[]> ActiveKeys => _activeKeys ?? (_activeKeys = new List<byte[]> { Base58.DecodePrivateWif(ActiveWif) });

        public List<byte[]> OwnerKeys => _ownerKeys ?? (_ownerKeys = new List<byte[]> { Base58.DecodePrivateWif(OwnerWif) });

        public bool IsNsfw { get; set; } = false;

        public bool IsLowRated { get; set; } = false;
    }
}