using Ditch.EOS.Errors;

namespace Ditch.EOS
{
    public class OperationResult
    {
        public bool IsError => Error != null;

        public ErrorBase Error { get; set; }

        public string RawRequest { get; set; }

        public string RawResponse { get; set; }


        public OperationResult()
        {
        }

        public OperationResult(ErrorBase error)
        {
            Error = error;
        }
    }

    public class OperationResult<T> : OperationResult
    {
        public T Result { get; set; }

        public OperationResult() { }

        public OperationResult(ErrorBase error) : base(error) { }
    }
}