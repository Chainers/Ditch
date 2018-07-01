using System.Collections.Generic;
using Ditch.Core;

namespace Ditch.EOS.Tests.Models
{
    public class UserInfo
    {
        private List<byte[]> _ownerKeys;
        private List<byte[]> _activeKeys;

        public string Login { get; set; } = string.Empty;

        public string PrivateOwnerWif { get; set; } = string.Empty;

        public string PublicOwnerWif { get; set; } = string.Empty;
        
        public string PrivateActiveWif { get; set; } = string.Empty;
        
        public string PublicActiveWif { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public List<byte[]> OwnerKeys => _ownerKeys ?? (_ownerKeys = new List<byte[]> { Base58.DecodePrivateWif(PrivateOwnerWif) });

        public List<byte[]> ActiveKeys => _activeKeys ?? (_activeKeys = new List<byte[]> { Base58.DecodePrivateWif(PrivateActiveWif) });

        public bool IsNsfw { get; set; } = false;

        public bool IsLowRated { get; set; } = false;

        public byte[] PrivateActiveKey => Base58.DecodePrivateWif(PrivateActiveWif);
    }
}