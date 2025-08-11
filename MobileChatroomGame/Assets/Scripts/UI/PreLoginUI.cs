/*
 * This script manages the current UI state of the login window shown to the user at the start of the game before the core User Interface
 * where the user can select levels and play game.
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PreLoginUI : MonoBehaviour
{
    
    [SerializeField] GameObject loginMenu, signupMenu;
    
    [SerializeField] UiAnimations UiAnimator;
    
    [SerializeField] TMP_InputField emailField, passwordField;
    [SerializeField] Button logInButton;

    void Start()
    {
        AccountPanelManager();
        
        logInButton.interactable = false;
        emailField.onValueChanged.AddListener(delegate { ValidateInputs(); });
        passwordField.onValueChanged.AddListener(delegate { ValidateInputs(); });
    }
   
    void ValidateInputs()
    {
        bool emailFilled = !string.IsNullOrEmpty(emailField.text), 
            passwordFilled = !string.IsNullOrEmpty(passwordField.text);
      
        logInButton.interactable = emailFilled && passwordFilled;
    }

    void AccountPanelManager()
    {
        loginMenu.SetActive(true);
        signupMenu.SetActive(false);
    }

    public void SignupMenuButton()
    {
        loginMenu.SetActive(false);
        signupMenu.SetActive(true);
    }

    public void ReturnToLoginMenu()
    {
        loginMenu.SetActive(true);
        signupMenu.SetActive(false);
    }

    public void UserLogInButton()
    {
        UiAnimator.MainMenuInit();
    }
    
}
