
using System.Collections.Generic;

namespace Ditch.EOS.Models
{
    public class CreateTransactionArgs
    {
        public Action[] Actions { get; set; }
        
        public List<byte[]> PrivateKeys { get; set; }
    }
}