using System;
using models;
using service.server_connectors;
using UnityEngine;
using UnityEngine.UI;
using utils;

namespace UIBoxes
{
    public class LoginBox
    {
        public GameObject boxCanvas;

        private Button confirmLoginButton;
        private Button backButton;

        private Text loginText;
        private Text passwordText;
        
        private GameObject warningText;

        public LoginBox()
        {
            boxCanvas = GameObject.Find("UI_LoginBox");

            loginText = GameObject.Find("LoginField").transform.Find("Text").GetComponent<Text>();
            passwordText = GameObject.Find("PasswordField").transform.Find("Text").GetComponent<Text>();
            
            warningText = GameObject.Find("WarningText");
            warningText.SetActive(false);

            confirmLoginButton = GameObject.Find("ConfirmLoginButton").GetComponent<Button>();
            backButton = GameObject.Find("BackButton").GetComponent<Button>();

            confirmLoginButton.onClick.AddListener(TaskLogIn);
            backButton.onClick.AddListener(HideBox);

            HideBox();
        }

        private void TaskLogIn()
        {
            var login = loginText.text;
            var password = passwordText.text;

            var user = new User(login, password);

            var result = UserConnector.LogIn(user);

            if (result != "false")
            {
                MainMenuControls.OnLoggedIn(result);
                HideBox();
            }
            else
            {
                warningText.SetActive(true);
                passwordText.text = "";
            }
        }

        public void ShowBox()
        {
            boxCanvas.SetActive(true);

            loginText.text = "";
            passwordText.text = "";
        }

        public void HideBox()
        {
            boxCanvas.SetActive(false);
        }

        public bool IsBoxActive() => boxCanvas.activeSelf;
        
    }
}