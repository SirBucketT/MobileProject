using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoginUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField emailInputField;
    [SerializeField] private TMP_InputField passwordInputField;

    public void SignIn_OnClick ()
    {
        // Validation steps for email and password
        // If email is empty or not of type email
        // If password is empty
        // If so,  we return from this method without calling firebase API and SHOW A PROMPT ON SCREEN WHICH TELLS USER WHAT WENT WRONG


        FirebaseAuthManager.Instance.Login(emailInputField.text, passwordInputField.text);
    }
}
