using System;
using UnityEngine;

public class KarmaManager : MonoBehaviour
{
    [SerializeField] SoKarma karmaData;
    
    public bool isKarmaDepleated;
    public bool isKarmaMaxed;
    

    public void Start()
    {
        isKarmaDepleated = false;
        isKarmaMaxed = false;
        ResetKarma();
    }

    public void ResetKarma()
    {
        karmaData.CurrentKarma = karmaData.MaxKarma / 2;
    }
    
    public void IncreaseKarma(float amount)
    {
        karmaData.CurrentKarma += amount;
        
        if (karmaData.CurrentKarma <= karmaData.MinKarma)
        {
            karmaData.CurrentKarma = karmaData.MinKarma;
        }
    }

    public void DecreaseKarma(float amount)
    {
        karmaData.CurrentKarma -= amount;
        
        if (karmaData.CurrentKarma >= karmaData.MaxKarma)
        {
            karmaData.CurrentKarma = karmaData.MaxKarma;
        }
    }
}