namespace Ditch.Core.JsonRpc
{
    public interface IJsonRpcRequest
    {
        int Id { get; }

        string Message { get; }
    }
}
