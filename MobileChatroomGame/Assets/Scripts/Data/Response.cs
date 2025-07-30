using UnityEngine;

[CreateAssetMenu(fileName = "ResponseSO", menuName = "GameData/LevelData/Dialogue/ResponseSO")]

public class Response : ScriptableObject{
	public string responseText;

	public int responseValue;
}
