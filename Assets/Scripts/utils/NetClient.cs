using System;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace utils
{
    class NetClient
    {
        private static NetClient _instance;
        private static readonly Uri ServerUri = new Uri("ws://chess-strange-server.herokuapp.com/");
        private static readonly CancellationTokenSource Cts = new CancellationTokenSource();
        private readonly ClientWebSocket _client;

        private NetClient()
        {
            try
            {
                _client = new ClientWebSocket();
                _client.ConnectAsync(ServerUri, Cts.Token);
            }
            catch (SocketException e)
            {
                Debug.Log("SocketException: " + e);
            }
        }

        public static NetClient GetInstance()
        {
            if (_instance != null)
                return _instance;

            _instance = new NetClient();
            return _instance;
        }

        public void SendMessage(string text)
        {
            var sendData = Encoding.UTF8.GetBytes(text);
            var sendBuffer = new ArraySegment<byte>(sendData);
            
            if (_client.State == WebSocketState.Open)
                _client.SendAsync(
                    sendBuffer, 
                    WebSocketMessageType.Text,
                    true, 
                    Cts.Token);
        }

        public string GetMessage()
        {
            ArraySegment<byte> receiveData = new ArraySegment<byte>(new byte[4096]);

            Task<WebSocketReceiveResult> result = _client.ReceiveAsync(receiveData, Cts.Token);
            
            return Encoding.UTF8.GetString(receiveData.Array, 0, result.Result.Count);
        }
    }
}