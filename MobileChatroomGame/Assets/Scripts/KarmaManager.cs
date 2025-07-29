using UnityEngine;

public class KarmaManager : MonoBehaviour
{
    [SerializeField] SoKarma karmaData;
    [SerializeField] float karmaReply;

    private void Start()
    {
        Debug.Log("Current Karma: " + karmaData.CurrentKarma);
    }

    public void IncreaseKarma(float amount)
    {
        karmaData.CurrentKarma += amount;
        Debug.Log("New Karma: " + karmaData.CurrentKarma);
    }

    public void DecreaseKarma(float amount)
    {
        karmaData.CurrentKarma -= amount;
        Debug.Log("New Karma: " + karmaData.CurrentKarma);
    }

   /*
    * Remove later, just for testing purposes. 
    */
    
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            IncreaseKarma(karmaReply);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            DecreaseKarma(karmaReply);
        }
    }
}