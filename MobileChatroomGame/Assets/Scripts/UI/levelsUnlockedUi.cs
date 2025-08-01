/*
 * This script manages the enabling of playable levels on the level select screen depending on the currently unlocked levels.
 * Since level one will always be enabled by default I've opted to not have any declarations of it in here. 
 */

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelsUnlockedUi : MonoBehaviour
{
    [SerializeField] Button level2, level3;
    
    void OnEnable()
    {
        Broker.Subscribe<UnlockedLevelsMessage>(IsLevelUnlocked);
    }
    
    void OnDisable()
    {
        Broker.Unsubscribe<UnlockedLevelsMessage>(IsLevelUnlocked);
    }

    void IsLevelUnlocked(UnlockedLevelsMessage obj)
    {
        if (obj.IsLevel2Unlocked)
        {
            EnableLvl2();
        }
        if (obj.IsLevel3Unlocked)
        {
            EnableLvl3();
        }
    }
    
    /*
     * Make sure to remember removing the reverse bool for interactivity later and set them to true.
     * Reversing interactivity will only be for testing purposes  
     */

    void EnableLvl2()
    {
        //level2.interactable = true;
        level2.interactable = !level2.interactable;
    }

    void EnableLvl3()
    {
        //level3.interactable = true;
        level3.interactable = !level3.interactable;
    }
}
