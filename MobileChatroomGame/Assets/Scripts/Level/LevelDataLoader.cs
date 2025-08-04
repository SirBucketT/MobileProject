using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataLoader : MonoBehaviour
{
    [SerializeField] List<LevelData> levelData;

    private int currentLevel;
    public static LevelDataLoader Instance { get; private set; }

    private void Awake ()
    {
        Instance = this;
    }

    public LevelData GetCurrenntLevelData()
    {
        if(currentLevel >= levelData.Count) return null;

        return levelData[currentLevel];
    }
}
