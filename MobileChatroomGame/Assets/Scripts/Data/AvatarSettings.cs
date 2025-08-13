using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AvatarSettings", menuName = "GameData/LevelData/AvatarSettings")]
public class AvatarSettings : ScriptableObject
{
    [field: SerializeField] private List<Sprite> avatars;

    public Sprite GetAvatarIcon(UserType userType)
    {
        return avatars[(int)userType];
    }
}
public enum UserType
{
    Chloe, Drew, Ollie
}