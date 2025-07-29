/*
 * Scriptable object managing the data for the Karma system in the game.
 * The script is using an event to send out the current karma level inside the game that the UI slider has a subscriber to. 
 */

using System;
using UnityEngine;

[CreateAssetMenu(fileName = "KarmaSO", menuName = "GameData/Data")]
public class SoKarma : ScriptableObject
{
    [SerializeField] float maxKarma;
    public float minKarma = 0;
    [SerializeField] float currentKarma;
    
    public event Action<float> OnKarmaChanged;
    
    public float MaxKarma => maxKarma;
    public float MinKarma => minKarma;
    
    public float CurrentKarma
    {
        get => currentKarma;
        set
        {
            if (!Mathf.Approximately(currentKarma, value))
            {
                currentKarma = value;
                OnKarmaChanged?.Invoke(currentKarma);
            }
        }
    }

}
