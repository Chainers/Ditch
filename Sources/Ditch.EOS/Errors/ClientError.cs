namespace Ditch.EOS.Errors
{
    public sealed class ClientError : ErrorBase
    {
        public ClientError(LocalizationKeys key) : base(key) { }
    }
}