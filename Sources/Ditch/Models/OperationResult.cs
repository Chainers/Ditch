using System.Collections.Generic;
using System.Linq;

namespace Ditch.Models
{
    public class OperationResult
    {
        public OperationResult()
        {
            Errors = new List<string>();
        }

        public bool IsError => Errors.Any();

        public List<string> Errors { get; set; }
    }

    public class OperationResult<T> : OperationResult
    {
        public T Result { get; set; }
    }
}