using System;
using UnityEngine;

public class KarmaManager : MonoBehaviour
{
    [SerializeField] LevelData levelData;
    

    public void Start() {

        levelData.levelKarma = levelData.levelMaxKarma / 2;
        SendUpdateKarmaMessage();
    }
    
    public void IncreaseKarma(float amount)
    {
        levelData.levelKarma += amount;
        
        if (levelData.levelKarma <= 0)
        {
            levelData.levelKarma = levelData.levelMaxKarma;
        }
        SendUpdateKarmaMessage();
    }

    public void DecreaseKarma(float amount)
    {
        levelData.levelKarma -= amount;
        
        if (levelData.levelKarma >= levelData.levelMaxKarma)
        {
            levelData.levelKarma = levelData.levelMaxKarma;
        }
        SendUpdateKarmaMessage();
    }

    void SendUpdateKarmaMessage(){
        // Send Karma Message to all scripts that are listening.
        // {beween brackets is your payload.}
        new KarmaMessage {Karma = levelData.levelKarma, 
            MaxKarma = levelData.levelMaxKarma}.InvokeExtension();
    }
}