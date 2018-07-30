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

        public OperationResult(OperationResult operationResult)
        {
            Error = operationResult.Error;
            RawRequest = operationResult.RawRequest;
            RawResponse = operationResult.RawResponse;
        }
    }

    public class OperationResult<T> : OperationResult
    {
        public T Result { get; set; } = default(T);

        public OperationResult() { }

        public OperationResult(OperationResult operationResult)
            : base(operationResult) { }
    }
}