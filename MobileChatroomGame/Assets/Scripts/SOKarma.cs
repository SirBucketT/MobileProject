using UnityEngine;

[CreateAssetMenu(fileName = "KarmaSO", menuName = "GameData/Data")]
public class SoKarma : ScriptableObject
{
    [SerializeField] float maxKarma;
    [SerializeField] float minKarma;
    [SerializeField] float currentKarma;
    
    public float MaxKarma => maxKarma;
    public float MinKarma => minKarma;

    public float CurrentKarma
    {
        get => currentKarma;
        set => currentKarma = Mathf.Clamp(value, minKarma, maxKarma);
    }
}
