using System.Collections;
using models;
using UnityEngine;
using utils;

namespace service.server_connectors
{
    public class UserConnector : MonoBehaviour
    {
        private string sendMessage;
        private Message<string> receivedMessage;

        private NetClient _client;

        void Start()
        {
            _client = NetClient.GetInstance();
        }

        public string Register(User user)
        {
            var message = new Message<User>("Register", user);

            sendMessage = JsonUtility.ToJson(message);

            StartCoroutine(nameof(SendAndReceiveMessage));
            Debug.Log(receivedMessage);

            switch (receivedMessage.command)
            {
                case "SignUpResult":
                    return "Success!";
                case "ErrorResult":
                    return receivedMessage.argument;
            }

            return "Upps! Smth went wrong.";
        }

        public string LogIn(User user)
        {
            var message = new Message<User>("Login", user);

            sendMessage = JsonUtility.ToJson(message);

            StartCoroutine(nameof(SendAndReceiveMessage));

            if (receivedMessage.command == "LogInResult")
                return receivedMessage.argument;
            return "false";
        }

        public void Disconnect()
        {
            var message = new Message<string>("CloseConnection", "");

            sendMessage = JsonUtility.ToJson(message);

            StartCoroutine(nameof(SendAndReceiveMessage));
            Debug.Log(receivedMessage);
        }

        private IEnumerator SendAndReceiveMessage()
        {
            _client.SendMessage(sendMessage);

            var result = _client.GetMessage();

            receivedMessage = JsonUtility.FromJson<Message<string>>(result);

            yield return null;
        }
    }
}