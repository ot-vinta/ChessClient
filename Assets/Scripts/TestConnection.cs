using models;
using service;
using UnityEngine;
using UnityEngine.UI;

public class TestConnection : MonoBehaviour
{
    private GameObject m_SignInButton;
    private GameObject m_SignUpButton;
    private GameObject m_QuitButton;

    private GameObject m_LoginField;
    private GameObject m_PasswordField;

    private GameObject m_ResponseText;

    void Start()
    {
        m_LoginField    = GameObject.Find("LoginField");
        m_PasswordField = GameObject.Find("PasswordField");
        
        m_SignInButton = GameObject.Find("SignInButton");
        m_SignUpButton = GameObject.Find("SignUpButton");
        m_QuitButton   = GameObject.Find("QuitButton");
        
        m_ResponseText = GameObject.Find("ResponseText");
        
        m_SignInButton.GetComponent<Button>().onClick.AddListener(TaskLogIn);
        m_SignUpButton.GetComponent<Button>().onClick.AddListener(TaskSignUp);
        m_QuitButton.GetComponent<Button>().onClick.AddListener(TaskCloseApp);
    }

    private void TaskLogIn()
    {
        var result = UserConnector.LogIn(InitUser());

        if (result == "true")
            m_ResponseText.GetComponent<Text>().text =
                "Hello, " + m_LoginField.transform.Find("Text").GetComponent<Text>().text;
        else
            m_ResponseText.GetComponent<Text>().text = "Wrong login or password.";
    }

    private void TaskSignUp()
    {
        var result = UserConnector.SignUp(InitUser());
        m_ResponseText.GetComponent<Text>().text = result;
    }

    private static void TaskCloseApp()
    {
        UserConnector.Disconnect();
        
        Application.Quit();
    }
    
    private User InitUser()
    {
        var login    = m_LoginField.transform.Find("Text").GetComponent<Text>().text;
        var password = m_PasswordField.transform.Find("Text").GetComponent<Text>().text;
                
        var user = new User(login, password);
        return user;
    }
}
