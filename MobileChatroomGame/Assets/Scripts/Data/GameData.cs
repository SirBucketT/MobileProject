using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "GameDataSO")]
public class GameData : ScriptableObject{
	[SerializeField] LevelData[] levelDataList;
}
