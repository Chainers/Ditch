using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Ditch.Core.Interfaces;
using Ditch.Core.JsonRpc;
using Newtonsoft.Json;

namespace Ditch.Core
{
    [Obsolete("Not implemented yet")]
    class SocketManager : IConnectionManager
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;
        private Socket Socket;

        public bool IsConnected { get; }


        public SocketManager(JsonSerializerSettings jsonSerializerSettings)
        {
            _jsonSerializerSettings = jsonSerializerSettings;
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }


        public string ConnectTo(string url, CancellationToken token)
        {
            if (Socket != null && Socket.Connected)
                return string.Empty;

            var endpoints = ResolveUri(url);
            foreach (var endpoint in endpoints)
            {
                try
                {
                    var tempSocket = new Socket(endpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    tempSocket.Connect(endpoint);
                    Socket = tempSocket;
                    return url;
                }
                catch (Exception ex)
                {
                }
            }
            return string.Empty;
        }

        public string ConnectTo(IEnumerable<string> urls, CancellationToken token)
        {
            foreach (var url in urls)
            {
                var connectedTo = ConnectTo(url, token);
                if (!string.IsNullOrEmpty(connectedTo))
                    return connectedTo;
            }
            return string.Empty;
        }

        public void Disconnect()
        {
            if (Socket == null)
                return;

            if (!Socket.Connected)
                return;

            try
            {
                Socket.Shutdown(SocketShutdown.Both);
            }
            catch
            {
            }

            try
            {
                Socket.Close();
            }
            catch
            {
            }
        }

        public JsonRpcResponse Execute(IJsonRpcRequest jsonRpc, CancellationToken token)
        {
            SendData(Socket, jsonRpc.Message);
            var responce = ReceiveData(Socket);
            var prop = JsonRpcResponse.FromString(responce, _jsonSerializerSettings);
            return prop;
        }

        public JsonRpcResponse<T> Execute<T>(IJsonRpcRequest jsonRpc, CancellationToken token)
        {
            var response = Execute(jsonRpc, token);
            return response.ToTyped<T>(_jsonSerializerSettings);
        }


        private IEnumerable<EndPoint> ResolveUri(string url)
        {
            var uri = new Uri(url);
            var entry = Dns.GetHostEntry(uri.Host);
            foreach (var address in entry.AddressList)
                yield return new IPEndPoint(address, uri.Port);
        }

        private static void SendData(Socket client, byte[] data, int offset, int length)
        {
            var sent = 0;
            var thisSent = 0;

            while ((length - sent) > 0)
            {
                thisSent = client.Send(data, offset + sent, length - sent, SocketFlags.None);
                sent += thisSent;
            }
        }

        private static void SendData(Socket client, string jsonRpc)
        {
            var data = Encoding.UTF8.GetBytes(jsonRpc);
            SendData(client, data, 0, data.Length);
        }

        private static string ReceiveData(Socket socket)
        {
            // получаем ответ
            var data = new byte[1024]; // буфер для ответа
            var builder = new StringBuilder();
            var bytes = 0; // количество полученных байт

            do
            {
                bytes = socket.Receive(data, data.Length, 0);
                builder.Append(Encoding.UTF8.GetString(data, 0, bytes));
            }
            while (socket.Available > 0);
            return builder.ToString();
        }
    }
}
