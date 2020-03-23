using models;
using UnityEngine;
using utils;

namespace service.server_connectors
{
    public static class TokenConnector
    {
        private static readonly NetClient Client = NetClient.GetInstance();
        private static string _connectionToken = "";

        public static string SendToken()
        {
            var tokenFile = Resources.Load<TextAsset>("token");
            _connectionToken = tokenFile.text;

            var message = new Message<Token>
            (
                "Connect",
                new Token(_connectionToken)
                );

            var jsonMessage = JsonUtility.ToJson(message);
            
            Client.SendMessage(jsonMessage);

            var result = Client.GetMessage();

            return result;
        }
    }
}