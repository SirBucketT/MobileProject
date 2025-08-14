using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SignUpUI : MonoBehaviour
{
    [SerializeField] TMP_InputField usernameInputField, emailInputField, passwordInputField, confirmPasswordInputField;
    
    [SerializeField] TMP_Text uiSignUpDisplayMessage;
    
    [SerializeField] GameObject loginMenu, signupMenu;
    [SerializeField] Button signupButton;
    
    private string signupMessage;

    void Start()
    {
        uiSignUpDisplayMessage.text = string.Empty;
        signupButton.interactable = false;
        emailInputField.onValueChanged.AddListener(delegate { ValidateInputsForSignup(); });
        passwordInputField.onValueChanged.AddListener(delegate { ValidateInputsForSignup(); });
        confirmPasswordInputField.onValueChanged.AddListener(delegate { ValidateInputsForSignup(); });
    }

    public void SignUp_OnClick()
    {
        FirebaseAuthManager.Instance.Register(usernameInputField.text, emailInputField.text, passwordInputField.text);
    }
    
    public void ReturnToLoginMenu()
    {
        loginMenu.SetActive(true);
        signupMenu.SetActive(false);
    }
    
    void ValidateInputsForSignup()
    {
        string email = emailInputField.text,
            password = passwordInputField.text,
            repeatPassword = confirmPasswordInputField.text;
        
        bool passwordNotEmpty = !string.IsNullOrEmpty(password),
            passwordsMatch = password == repeatPassword,
            emailNotEmpty = !string.IsNullOrEmpty(email);
        
        signupButton.interactable = emailNotEmpty && passwordNotEmpty && passwordsMatch;
    }
    
    void OnEnable()
    {
        Broker.Subscribe<accountStatusMessage>(OnSignUp);
    }

    void OnDisable()
    {
        Broker.Unsubscribe<accountStatusMessage>(OnSignUp);
    }

    private void OnSignUp(accountStatusMessage msg)
    {
        if (!string.IsNullOrEmpty(msg.AccountCreationMessage))
        {
            uiSignUpDisplayMessage.text = msg.AccountCreationMessage;
        }
    }
}
