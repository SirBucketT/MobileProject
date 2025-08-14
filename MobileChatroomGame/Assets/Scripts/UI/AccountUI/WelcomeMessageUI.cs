using TMPro;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class WelcomeMessageUI : MonoBehaviour
{
    [SerializeField] TMP_Text welcomeMessageText;
    [SerializeField] RectTransform welcomeMessageContainer;
    [SerializeField] float animationDuration = 0.5f;
    
    Vector3 startPos = new Vector3(0, 15, 0);
    Vector3 endPos = new Vector3(0, -15, 0);

    void Start()
    {
        welcomeMessageContainer.GameObject().SetActive(false);
        welcomeMessageText.text = string.Empty;
    }
    
    void OnEnable()
    {
        Broker.Subscribe<accountStatusMessage>(OnLoginReceived);
    }

    void OnDisable()
    {
        Broker.Unsubscribe<accountStatusMessage>(OnLoginReceived);
    }

    void OnLoginReceived(accountStatusMessage obj)
    {
        if (obj.OnLogin)
        {
            welcomeMessageContainer.GameObject().SetActive(true);
            welcomeMessageText.text = $"Welcome, {FirebaseAuthManager.Instance.user.DisplayName}!";
            
            welcomeMessageContainer.anchoredPosition = startPos;
            welcomeMessageContainer.DOAnchorPos(endPos, animationDuration).SetEase(Ease.OutQuad);
        }
    }
}
