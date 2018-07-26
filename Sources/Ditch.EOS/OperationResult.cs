using System;

namespace Ditch.EOS
{
    public class OperationResult
    {
        public bool IsError => Error != null;

        public Exception Error { get; set; }

        public string RawRequest { get; set; }

        public string RawResponse { get; set; }


        public OperationResult()
        {
        }

        public OperationResult(Exception error)
        {
            Error = error;
        }
    }

    public class OperationResult<T> : OperationResult
    {
        public T Result { get; set; }

        public OperationResult() { }

        public OperationResult(Exception error) : base(error) { }
    }
}