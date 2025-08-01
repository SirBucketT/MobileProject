using UnityEngine;

public class lvlEnabler : MonoBehaviour
{
    bool isLvl2Enabled;
    bool isLvl3Enabled;

    void Start()
    {
        isLvl2Enabled = false;
        isLvl3Enabled = false;
    }
    
    void SendLvlUnlock()
    {
        new UnlockedLevelsMessage{IsLevel2Unlocked = isLvl2Enabled, 
            IsLevel3Unlocked = isLvl3Enabled}.InvokeExtension();
    }

    public void EnableLvl2()
    {
        isLvl2Enabled = !isLvl2Enabled;
        SendLvlUnlock();
    }

    public void EnableLvl3()
    {
        isLvl3Enabled = !isLvl3Enabled;
        SendLvlUnlock();
    }
}
