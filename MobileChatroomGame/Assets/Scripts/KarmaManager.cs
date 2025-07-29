using UnityEngine;

public class KarmaManager : MonoBehaviour
{
    [SerializeField] SoKarma karmaData;

    private void Start()
    {
        Debug.Log("Current Karma: " + karmaData.CurrentKarma);
    }

    public void IncreaseKarma(float amount)
    {
        karmaData.CurrentKarma += amount;
        Debug.Log("New Karma: " + karmaData.CurrentKarma);
    }
}