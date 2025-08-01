/*
 * This script manages the display of the UI elements of the karma meter. 
 */

using System;
using UnityEngine;
using UnityEngine.UI;

public class KarmaUiSlider : MonoBehaviour
{
    [SerializeField] Slider karmaSlider;
    [SerializeField] Image fillImage;

    [Header("Colors")]
    [SerializeField] Color lowColor = Color.red;
    [SerializeField] Color midColor = Color.blue;
    [SerializeField] Color highColor = Color.green;
    
    void OnEnable() {
        // Define the <typeOfMessage> to listen to. (Call a method when message is reveived.)
        Broker.Subscribe<KarmaMessage>(OnKarmaMessageReceived);
    }
    
    void OnDisable(){
        Broker.Unsubscribe<KarmaMessage>(OnKarmaMessageReceived);
    }

    void OnKarmaMessageReceived(KarmaMessage obj){
        karmaSlider.maxValue = obj.MaxKarma;
        karmaSlider.value = obj.Karma;

        float normalized = obj.Karma / obj.MaxKarma;
        float color;
        
        if (normalized < 0.25f)
        {
            color = normalized / 0.25f; 
            fillImage.color = Color.Lerp(lowColor, midColor, color);
        }
        else if (normalized < 0.75f)
        {
            fillImage.color = midColor;
        }
        else
        {
            color = (normalized - 0.75f) / 0.25f;
            fillImage.color = Color.Lerp(midColor, highColor, color);
        }
    }
}
