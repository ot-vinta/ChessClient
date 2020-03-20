using System;
using System.Net.Sockets;
using System.Text;

namespace utils
{
    class NetClient
    {
        private readonly NetworkStream m_Stream;

        private static NetClient _instance;
        private const string Address = "https://chess-strange-server.herokuapp.com";
        private const int Port = 9116;

        private NetClient()
        {
            try
            {
                var client = new TcpClient();
                client.Connect(Address, Port);

                m_Stream = client.GetStream();
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
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

            m_Stream.Write(sendData, 0, sendData.Length);
        }

        public string GetMessage()
        {
            var getData = new byte[4096];
            var builder = new StringBuilder();
            do
            {
                var bytes = m_Stream.Read(getData, 0, getData.Length);
                builder.Append(Encoding.UTF8.GetString(getData, 0, bytes));
            }
            while (m_Stream.DataAvailable);

            return builder.ToString();
        }
    }
}
