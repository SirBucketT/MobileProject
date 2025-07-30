/*
 * This script manages the display of the UI elements of the karma meter. 
 */

using System;
using UnityEngine;
using UnityEngine.UI;

public class KarmaUiSlider : MonoBehaviour
{
    [SerializeField] public Slider karmaSlider;
    
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
    }
}
