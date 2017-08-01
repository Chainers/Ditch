namespace Ditch.Errors
{
    public class SystemError : ErrorInfo
    {
        public new ErrorCodes Code { get; set; }

        public SystemError(ErrorCodes errorCodes)
        {
            Code = errorCodes;
        }
    }
}