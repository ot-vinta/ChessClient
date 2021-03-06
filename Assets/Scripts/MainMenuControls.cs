﻿using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using models;
using service.server_connectors;
using TMPro;
using UIBoxes;
using UnityEngine;
using UnityEngine.UI;
using utils;

public class MainMenuControls : MonoBehaviour
{
    private static Button _newGameButton;
    private static Button _loadGameButton;
    private Button _loginButton;
    private Button _registerButton;

    private static GameObject _responseText;

    private GameObject _mainMenu;
    private LoginBox _loginDialog;
    private RegisterBox _registerDialog;
    private LoadBox _loadBox;

    void Start()
    {
        NetClient.GetInstance();
        StartCoroutine(nameof(WaitForStableConnection));
        
        _newGameButton  = GameObject.Find("NewGameButton").GetComponent<Button>();
        _loadGameButton = GameObject.Find("LoadGameButton").GetComponent<Button>();
        _loginButton    = GameObject.Find("LoginButton").GetComponent<Button>();
        _registerButton = GameObject.Find("RegisterButton").GetComponent<Button>();
        _responseText   = GameObject.Find("ResponseText");
        _mainMenu       = GameObject.Find("MainMenu");
        
        _loginDialog    = new LoginBox();
        _registerDialog = new RegisterBox();

        _newGameButton.onClick.AddListener(TaskNewGame);
        _newGameButton.enabled = false;
        _loadGameButton.onClick.AddListener(TaskLoadGame);
        _loadGameButton.enabled = false;

        _loginButton.onClick.AddListener(OnLoginClicked);
        _registerButton.onClick.AddListener(OnRegisterClicked);
    }

    private IEnumerator WaitForStableConnection()
    {
        _loadBox = new LoadBox();
        _loadBox.ShowBox();
        
        var result = TokenConnector.SendToken();
        
        while (result == "Not opened state")
        {
            result = TokenConnector.SendToken();
            
            yield return new WaitForSeconds(0.5f);
        }
        
        if (_loadBox != null)
        {
            _loadBox.HideBox();
            Destroy(_loadBox.BoxCanvas);
            _loadBox = null;
        } 
    }

    private void TaskNewGame()
    {
        
    }

    private void TaskLoadGame()
    {
        
    }

    private void OnLoginClicked()
    {
        _loginDialog.ShowBox();
    }
    
    private void OnRegisterClicked()
    {
        _registerDialog.ShowBox();
    }

    public static void OnLoggedIn(string login)
    {
        _responseText.GetComponent<Text>().text = "Hello, " + login + "!";

        _newGameButton.enabled = true;
        _loadGameButton.enabled = true;
    }
}
