using models;
using UnityEngine;
using utils;

namespace service.server_connectors
{
    public static class UserConnector
    {
        
        public static string SignUp(User user)
        {
            var message = new Message<User>("SignUp", user);

            var response = JsonUtility.FromJson<Message<string>>(SendAndReceiveMessage(message));
            Debug.Log(response);

            switch (response.command)
            {
                case "SignUpResult":
                    return "Success!";
                case "ErrorResult":
                    return response.argument;
            }

            return "Upps! Smth went wrong.";
        }

        public static string LogIn(User user)
        {
            var message = new Message<User>("SignIn", user);
            
            var response = JsonUtility.FromJson<Message<string>>(SendAndReceiveMessage(message));
            Debug.Log(response.command + " ||| " + response.argument);

            if (response.command == "LogInResult")
                return response.argument;
            return "false";
        }

        public static void Disconnect()
        {
            var message = new Message<string>("CloseConnection", "");
            
            var response = SendAndReceiveMessage(message);
            Debug.Log(response);
        }

        private static string SendAndReceiveMessage<T>(Message<T> message)
        {
            var jsonString = JsonUtility.ToJson(message);
            
            Debug.Log(jsonString);

            var client = NetClient.GetInstance();
            client.SendMessage(jsonString);

            return client.GetMessage();
        }
    }
}