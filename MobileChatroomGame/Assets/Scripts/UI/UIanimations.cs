/*
 * This script will manage UI animations at start up of the game for the main menu.
 * The script also manages the main menu sub-menues and their current animation state.
 */

using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;
using ChatRoom.UI;

public class UiAnimations : MonoBehaviour
{
    [SerializeField] GameObject gameLogo, continueGameButton, accountAndSettingsButton;
    [SerializeField] RectTransform playRect, settingsRect;

    static Vector3 _animationStartPosVector;
    
    [SerializeField] Vector3 playStartPosVector, settingsStartPosVector;

    private int animStartPos = 0;
    [SerializeField] float animEndPos; //scale property for the end scaling size of the animation. 
    [SerializeField] float animDuration; //animation duration in seconds

    [Header("Sub-menu items")] 
    [SerializeField] UiState uiState;
    [SerializeField] GameObject settingsMenu, play;
    [SerializeField] float animSubmenuEndPos;

    [SerializeField] Vector2 ClosePlayEndPos, CloseSettingsEndPos;

    void OnEnable()
    {
        Broker.Subscribe<UiUpdateMessage>(OnUiUpdateReceived);
    }

    void OnUiUpdateReceived(UiUpdateMessage obj)
    {
        if (obj.OnSettingsOpen)
        {
            OpenSettings();
        }

        if (obj.OnPlayStarter)
        {
            OpenPlay();
        }

        if (obj.OnSubmenuClose)
        {
            CloseSubmenu();
        }
    }

    void OnDisable()
    {
        Broker.Unsubscribe<UiUpdateMessage>(OnUiUpdateReceived);
    }
    
    void Awake()
    {
        settingsMenu.SetActive(false);
        play.SetActive(false);
    }
    
    void Start()
    {
        _animationStartPosVector.x = animStartPos;
        _animationStartPosVector.y = animStartPos;
        _animationStartPosVector.z = animStartPos;
        
        gameLogo.transform.localScale = _animationStartPosVector;
        continueGameButton.transform.localScale = _animationStartPosVector;
        accountAndSettingsButton.transform.localScale = _animationStartPosVector;
        
        gameLogo.transform.DOScale(1f, animDuration).SetEase(Ease.OutBack);
        continueGameButton.transform.DOScale(1f, animDuration).SetEase(Ease.OutBack);
        accountAndSettingsButton.transform.DOScale(1f, animDuration).SetEase(Ease.OutBack);
    }

/*
 * Submenu animations
 */

    public void OpenSettings()
    {
        settingsMenu.SetActive(true);
        
        settingsRect.anchoredPosition = settingsStartPosVector;
        settingsRect.localScale = Vector3.zero;
        
       settingsRect.DOAnchorPos(Vector2.zero, animDuration);
       settingsRect.DOScale(animSubmenuEndPos, animDuration).SetEase(Ease.OutBack);
    }

    public void OpenPlay()
    {
        play.SetActive(true);

        new OnLevelStartData().InvokeExtension();

        playRect.anchoredPosition = playStartPosVector;
        playRect.localScale = Vector3.zero;
        
        playRect.DOAnchorPos(Vector2.zero, animDuration);
        playRect.DOScale(animSubmenuEndPos, animDuration).SetEase(Ease.OutBack);
    }

    public void CloseSubmenu()
    {
        if (settingsMenu.activeSelf)
        {
            settingsRect.DOAnchorPos(CloseSettingsEndPos, animDuration).SetEase(Ease.InQuad);
            settingsRect.DOScale(Vector3.zero, animDuration).SetEase(Ease.InBack)
                .OnComplete(() => settingsMenu.SetActive(false));
        } else if (play.activeSelf)
        {
            playRect.DOAnchorPos(ClosePlayEndPos, animDuration).SetEase(Ease.InQuad);
            playRect.DOScale(Vector3.zero, animDuration).SetEase(Ease.InBack)
                .OnComplete(() => play.SetActive(false));
        }
    }
}
