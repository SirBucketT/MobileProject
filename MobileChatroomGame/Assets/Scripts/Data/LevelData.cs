using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "GameData/LevelDataSO")]
public class LevelData : ScriptableObject{
    public string levelId;

    public string levelName;

    public float levelKarma;

    public List<Dialogue> levelDialogueList;
}
