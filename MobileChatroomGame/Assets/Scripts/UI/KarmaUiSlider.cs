/*
 * This script manages the display of the UI elements of the karma meter. 
 */

using UnityEngine;
using UnityEngine.UI;

public class KarmaUiSlider : MonoBehaviour
{
    [SerializeField] Slider karmaSlider;
    [SerializeField] SoKarma karmaData;
    
    void Start()
    {
        karmaSlider.minValue = karmaData.MinKarma;
        karmaSlider.maxValue = karmaData.MaxKarma;
        karmaData.CurrentKarma = karmaData.MaxKarma / 2;
        
        karmaSlider.value = karmaData.CurrentKarma;
        karmaData.OnKarmaChanged += UpdateSlider;
    }

    void OnDestroy()
    {
        karmaData.OnKarmaChanged -= UpdateSlider;
    }

    private void UpdateSlider(float newKarma)
    {
        karmaSlider.value = newKarma;
        Debug.Log("Slider updating to: " + newKarma);
    }
}
