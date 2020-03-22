using System.Collections;
using models;
using UnityEngine;
using utils;

namespace service.server_connectors
{
    public static class UserConnector
    {
        private static readonly NetClient Client = NetClient.GetInstance();

        public static string Register(User user)
        {
            var sendMessage = JsonUtility.ToJson(new Message<User>("Register", user));
            var receivedMessage = JsonUtility.FromJson<Message<string>>(SendAndReceiveMessage(sendMessage));
            
            switch (receivedMessage.command)
            {
                case "SignUpResult":
                    return "Success";
                case "ErrorResult":
                    return receivedMessage.argument;
            }

            return "Upps! Smth went wrong.";
        }

        public static string LogIn(User user)
        {
            var message = new Message<User>("Login", user);

            var sendMessage = JsonUtility.ToJson(message);

            var receivedMessage = JsonUtility.FromJson<Message<string>>(SendAndReceiveMessage(sendMessage));

            if (receivedMessage.command == "LogInResult")
                return user.login;
            return "false";
        }

        public static void Disconnect()
        {
            var message = new Message<string>("CloseConnection", "");

            var sendMessage = JsonUtility.ToJson(message);
            SendAndReceiveMessage(sendMessage);
        }

        private static string SendAndReceiveMessage(string sendMessage)
        {
            Client.SendMessage(sendMessage);

            var result = Client.GetMessage();

            return result;
        }
    }
}