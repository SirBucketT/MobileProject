using UnityEngine;

public class KarmaManager : MonoBehaviour
{
    [SerializeField] SoKarma karmaData;

    public void Start()
    {
        ResetKarma();
    }

    public void ResetKarma()
    {
        karmaData.CurrentKarma = karmaData.MaxKarma / 2;
    }
    
    public void IncreaseKarma(float amount)
    {
        karmaData.CurrentKarma += amount;
    }

    public void DecreaseKarma(float amount)
    {
        karmaData.CurrentKarma -= amount;
    }
}