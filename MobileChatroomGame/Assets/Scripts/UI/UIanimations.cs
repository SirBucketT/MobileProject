/*
 * This script will manage UI animations at start up of the game for the main menu.
 * The script also manages the main menues sub-menues.
 */

using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;

public class UIanimations : MonoBehaviour
{
    [SerializeField] GameObject gameLogo, newGameButton, continueGameButton, accountAndSettingsButton, subMenues;

    static Vector3 _animationStartPosVector;
    
    [Header("Animation properties")]
    
    private int animStartPos = 0;
    [SerializeField] float animEndPos;
    [SerializeField] float animDuration;
    
    [Header("Submenu animations")]
    [SerializeField] GameObject settingsMenu;

    void Awake()
    {
        settingsMenu.SetActive(false);
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

/*
 * Submenu animations
 */

    public void OpenSettings()
    {
        settingsMenu.SetActive(true);
        settingsMenu.transform.localScale = _animationStartPosVector;

        settingsMenu.transform.DOScale(1f, animDuration).SetEase(Ease.OutBack);
    }

    public void CloseSettings()
    { 
        settingsMenu.transform.DOScale(0f, animDuration).SetEase(Ease.OutBack);
        //settingsMenu.transform.localScale = _animationStartPosVector;

        settingsMenu.SetActive(false);
    }
}
