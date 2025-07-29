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
