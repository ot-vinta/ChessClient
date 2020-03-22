using System.Collections;
using models;
using service;
using service.server_connectors;
using UnityEngine;
using UnityEngine.UI;
using utils;

public class TestConnection : MonoBehaviour
{
    private GameObject _mSignInButton;
    private GameObject _mSignUpButton;
    private GameObject _mQuitButton;

    private GameObject _mLoginField;
    private GameObject _mPasswordField;

    private GameObject _mResponseText;

    private GameObject _network;

    void Start()
    {
        StartCoroutine(nameof(ConnectToServer));
        _mLoginField = GameObject.Find("LoginField");
        _mPasswordField = GameObject.Find("PasswordField");

        _mSignInButton = GameObject.Find("SignInButton");
        _mSignUpButton = GameObject.Find("SignUpButton");
        _mQuitButton = GameObject.Find("QuitButton");

        _mResponseText = GameObject.Find("ResponseText");

        _mSignInButton.GetComponent<Button>().onClick.AddListener(TaskLogIn);
        _mSignUpButton.GetComponent<Button>().onClick.AddListener(TaskSignUp);
        _mQuitButton.GetComponent<Button>().onClick.AddListener(TaskCloseApp);
        
        _network = GameObject.Find("Network");
    }

    private IEnumerator ConnectToServer()
    {
        NetClient.GetInstance();
        yield return null;
    }

    private void TaskLogIn()
    {
        var result = _network.GetComponent<UserConnector>().LogIn(InitUser());

        if (result == "true")
            _mResponseText.GetComponent<Text>().text =
                "Hello, " + _mLoginField.transform.Find("Text").GetComponent<Text>().text;
        else
            _mResponseText.GetComponent<Text>().text = "Wrong login or password.";
    }

    private void TaskRegister()
    {
        var result = _network.GetComponent<UserConnector>().Register(InitUser());
        _mResponseText.GetComponent<Text>().text = result;
    }

    private void TaskCloseApp()
    {
        _network.GetComponent<UserConnector>().Disconnect();
        
        Application.Quit();
    }
    
    private User InitUser()
    {
        var login    = _mLoginField.transform.Find("Text").GetComponent<Text>().text;
        var password = _mPasswordField.transform.Find("Text").GetComponent<Text>().text;
                
        var user = new User(login, password);
        return user;
    }
}
