using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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
    
    
    //Method managing the sign in of the user
    public void SignIn_OnClick()
    {
        FirebaseAuthManager.Instance.Login(emailInputField.text, passwordInputField.text);
    }
    
    
    /* ---------------- ---------------- ValidateInputsForLogin-------- ----------------
     *      local client side check if email and password is entered into the login input field 
     *      Checks if email is a valid email address.
     *      Manages the display of UI error text messages depending on if
     *
     *
     *          *Email is valid
     *          *Email is filled
     *          *password is filled
     *          *if password or email is empty
     *
     * 
     * If all conditions above are filled and correct it enables login button.
     */
    
    
    void ValidateInputsForLogin()
    {
        bool emailFilled = !string.IsNullOrEmpty(emailInputField.text), 
            passwordFilled = !string.IsNullOrEmpty(passwordInputField.text);
        
        bool emailValid = false;
        
        if (emailFilled)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            emailValid = Regex.IsMatch(emailInputField.text, pattern, RegexOptions.IgnoreCase);
        }
      
        logInButton.interactable = emailFilled && passwordFilled && emailValid;

        
        if (!emailFilled && !passwordFilled)
        {
            LoginMessageText.text = "Please enter your email and password.";
        }
        else if (!emailFilled)
        {
            LoginMessageText.text = "Please enter your email.";
        }
        else if (!emailValid)
        {
            LoginMessageText.text = "Please enter a valid email address.";
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
