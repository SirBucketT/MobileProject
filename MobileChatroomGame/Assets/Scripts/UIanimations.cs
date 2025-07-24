/*
 * This script will manage UI animations at start up of the game for the main menu.
 */

using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;

public class UIanimations : MonoBehaviour
{
    [SerializeField] GameObject gameLogo, newGameButton, continueGameButton, accountAndSettingsButton, subMenues;
    
    Vector3 _animationStartPosVector;
    
    [Header("Animation properties")]
    
    [SerializeField] int animStartPos;
    [SerializeField] float animEndPos;
    [SerializeField] float animDuration;

    void Awake()
    {
        subMenues.SetActive(false);
    }
    
    void Start()
    {
        _animationStartPosVector.x = animStartPos;
        _animationStartPosVector.y = animStartPos;
        _animationStartPosVector.z = animStartPos;
        
        gameLogo.transform.localScale = _animationStartPosVector;
        newGameButton.transform.localScale = _animationStartPosVector;
        continueGameButton.transform.localScale = _animationStartPosVector;
        accountAndSettingsButton.transform.localScale = _animationStartPosVector;
        
        gameLogo.transform.DOScale(1f, animDuration).SetEase(Ease.OutBack);
        newGameButton.transform.DOScale(1f, animDuration).SetEase(Ease.OutBack);
        continueGameButton.transform.DOScale(1f, animDuration).SetEase(Ease.OutBack);
        accountAndSettingsButton.transform.DOScale(1f, animDuration).SetEase(Ease.OutBack);
    }
    
    public void OpenSettings(){}
    public void CloseSettings(){}
}
