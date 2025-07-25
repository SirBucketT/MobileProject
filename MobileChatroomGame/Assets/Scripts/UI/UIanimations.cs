/*
 * This script will manage UI animations at start up of the game for the main menu.
 * The script also manages the main menu sub-menues.
 */

using UnityEngine;
using DG.Tweening;

public class UiAnimations : MonoBehaviour
{
    [SerializeField] GameObject gameLogo, newGameButton, continueGameButton, accountAndSettingsButton;

    static Vector3 _animationStartPosVector;
    
    [Header("Animation properties")]
    
    private int animStartPos = 0;
    [SerializeField] float animEndPos;
    [SerializeField] float animDuration;

    [Header("Sub-menu items")] 
    [SerializeField] UiState uiState;
    [SerializeField] GameObject settingsMenu, play;
    [SerializeField] float animSubmenuEndPos;

    void Awake()
    {
        settingsMenu.SetActive(false);
        play.SetActive(false);
        
        uiState.onSettingsOpen.AddListener(OpenSettings);
        uiState.onSubmenuClose.AddListener(CloseSubmenu);
    }
    
    void OnDestroy()
    {
        if (uiState != null)
        {
            uiState.onSettingsOpen.RemoveListener(OpenSettings);
            uiState.onSubmenuClose.RemoveListener(CloseSubmenu);
        }
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

        settingsMenu.transform.DOScale(animSubmenuEndPos, animDuration).SetEase(Ease.OutBack);
    }

    public void OpenPlay()
    {
        play.SetActive(true);
        play.transform.localScale = _animationStartPosVector;

        play.transform.DOScale(animSubmenuEndPos, animDuration).SetEase(Ease.OutBack);
    }

    public void CloseSubmenu()
    {
        if (settingsMenu != null && settingsMenu.activeSelf)
        {
            settingsMenu.transform.DOScale(animStartPos, animDuration).SetEase(Ease.OutBack)
                .OnComplete(() => settingsMenu.transform.localScale = _animationStartPosVector)
                .OnComplete(() => settingsMenu.SetActive(false));
        } else if (play != null && play.activeSelf)
        {
            play.transform.DOScale(animStartPos, animDuration).SetEase(Ease.OutBack)
                .OnComplete(() => play.transform.localScale = _animationStartPosVector)
                .OnComplete(() => play.SetActive(false));
        }
    }
}
