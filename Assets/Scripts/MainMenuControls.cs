using System.Collections;
using System.Collections.Generic;
using models;
using service.server_connectors;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuControls : MonoBehaviour
{
    private GameObject _newGameButton;
    private GameObject _loadGameButton;
    private GameObject _loginButton;
    private GameObject _registerButton;

    private GameObject _responseText;


    // Start is called before the first frame update
    void Start()
    {
        _newGameButton = GameObject.Find("NewGameButton");
        _loadGameButton = GameObject.Find("LoadGameButton");
        _loginButton = GameObject.Find("LoginButton");
        _registerButton = GameObject.Find("RegisterButton");
        
        _responseText = GameObject.Find("ResponseText");
        
        _newGameButton.GetComponent<Button>().onClick.AddListener(TaskNewGame);
        _newGameButton.GetComponent<Button>().enabled = false;
        
        _loadGameButton.GetComponent<Button>().onClick.AddListener(TaskLoadGame);
        _loadGameButton.GetComponent<Button>().enabled = false;
        
        _loginButton.GetComponent<Button>().onClick.AddListener(TaskLogin);
        _registerButton.GetComponent<Button>().onClick.AddListener(TaskRegister);
    }

    private void TaskNewGame()
    {
        
    }

    private void TaskLoadGame()
    {
        
    }

    private void TaskLogin()
    {
        var result = UserConnector.LogIn(InitUser());

        if (result == "true")
            _responseText.GetComponent<Text>().text =
                "Hello, " + _loginField.transform.Find("Text").GetComponent<Text>().text;
        else
            _responseText.GetComponent<Text>().text = "Wrong login or password.";
    }

    private void TaskRegister()
    {
        var result = UserConnector.SignUp(InitUser());
        _responseText.GetComponent<Text>().text = result;
    }
    
    private User InitUser()
    {
        var login    = _loginField.transform.Find("Text").GetComponent<Text>().text;
        var password = _passwordField.transform.Find("Text").GetComponent<Text>().text;
                
        var user = new User(login, password);
        return user;
    }
}
