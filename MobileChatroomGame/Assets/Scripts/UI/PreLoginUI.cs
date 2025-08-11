/*
 * This script manages the current UI state of the login window shown to the user at the start of the game before the core User Interface
 * where the user can select levels and play game.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreLoginUI : MonoBehaviour
{
    
    [SerializeField] GameObject loginMenu, signupMenu;
    
    [SerializeField] UiAnimations UiAnimator;

    void Start()
    {
        AccountPanelManager();
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
