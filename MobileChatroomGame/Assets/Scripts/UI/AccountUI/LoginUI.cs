using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginUI : MonoBehaviour
{
    [SerializeField] GameObject loginPanel, signupPanel;
    [SerializeField] Button logInButton, signupButton;
    
    [SerializeField] TMP_InputField emailInputField;
    [SerializeField] TMP_InputField passwordInputField;
    [SerializeField] TMP_Text LoginMessageText;
    
    void Start()
    {
        logInButton.interactable = false;
        emailInputField.onValueChanged.AddListener(delegate { ValidateInputsForLogin(); });
        passwordInputField.onValueChanged.AddListener(delegate { ValidateInputsForLogin(); });
        LoginMessageText.text = "Please enter your email and password";
    }
    
    
    //Method managing the signing in of the user
    public void SignIn_OnClick()
    {
        FirebaseAuthManager.Instance.Login(emailInputField.text, passwordInputField.text);
    }
    
    void ValidateInputsForLogin()
    {
        bool emailFilled = !string.IsNullOrEmpty(emailInputField.text), 
            passwordFilled = !string.IsNullOrEmpty(passwordInputField.text);
      
        logInButton.interactable = emailFilled && passwordFilled;
        
        if (!emailFilled && !passwordFilled)
        {
            LoginMessageText.text = "Please enter your email and password.";
        }
        else if (!emailFilled)
        {
            LoginMessageText.text = "Please enter your email.";
        }
        else if (!passwordFilled)
        {
            LoginMessageText.text = "Please enter your password.";
        }
        else
        {
            LoginMessageText.text = String.Empty;
        }
    }
    
    public void SignupMenuButton()
    {
        loginPanel.SetActive(false);
        signupPanel.SetActive(true);
    }
}
