using models;
using service.server_connectors;
using UnityEngine;
using UnityEngine.UI;

namespace UIBoxes
{
    public class RegisterBox
    {
        public GameObject boxCanvas;

        private Button confirmRegisterButton;
        private Button backButton;

        private Text loginText;
        private Text passwordText;
        
        private GameObject warningText;

        public RegisterBox()
        {
            boxCanvas = GameObject.Find("UI_RegisterBox");

            loginText = GameObject.Find("LoginField").transform.Find("Text").GetComponent<Text>();
            passwordText = GameObject.Find("PasswordField").transform.Find("Text").GetComponent<Text>();
            
            warningText = GameObject.Find("WarningText");
            warningText.SetActive(false);

            confirmRegisterButton = GameObject.Find("ConfirmRegisterButton").GetComponent<Button>();
            backButton = GameObject.Find("BackButton").GetComponent<Button>();

            confirmRegisterButton.onClick.AddListener(TaskRegister);
            backButton.onClick.AddListener(HideBox);

            HideBox();
        }

        private void TaskRegister()
        {
            var login = loginText.text;
            var password = passwordText.text;

            var user = new User(login, password);

            var result = UserConnector.Register(user);

            if (result == "Success")
            {
                MainMenuControls.OnLoggedIn(login);
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