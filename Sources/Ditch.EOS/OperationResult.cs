using System;

namespace Ditch.EOS
{
    public class OperationResult
    {
        public bool IsError => Exception != null;

        public Exception Exception { get; set; }

        public string RawRequest { get; set; }

        public string RawResponse { get; set; }


        public OperationResult()
        {
        }

        public OperationResult(Exception exception)
        {
            Exception = exception;
        }

        public OperationResult(OperationResult operationResult)
        {
            Exception = operationResult.Exception;
            RawRequest = operationResult.RawRequest;
            RawResponse = operationResult.RawResponse;
        }
    }

    public class OperationResult<T> : OperationResult
    {
        public T Result { get; set; } = default(T);

        public OperationResult() { }

        public OperationResult(Exception exception)
            : base(exception) { }

        public OperationResult(OperationResult operationResult)
            : base(operationResult) { }
    }
}