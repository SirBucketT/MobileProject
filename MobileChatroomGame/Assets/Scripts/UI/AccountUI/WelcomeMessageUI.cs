using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class WelcomeMessageUI : MonoBehaviour
{
    [SerializeField] TMP_Text welcomeMessageText;

    void Start()
    {
        welcomeMessageText.text = string.Empty;
    }
    
    void OnEnable()
    {
        Broker.Subscribe<LoginMessage>(OnLoginReceived);
    }

    void OnDisable()
    {
        Broker.Unsubscribe<LoginMessage>(OnLoginReceived);
    }

    void OnLoginReceived(LoginMessage obj)
    {
        if (obj.OnLogin)
        {
            welcomeMessageText.text = $"Welcome, {FirebaseAuthManager.Instance.user.DisplayName}!";
        }
    }
}
