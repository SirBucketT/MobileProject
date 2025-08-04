using UnityEngine;

[CreateAssetMenu(fileName = "ResponseSO", menuName = "GameData/LevelData/Dialogue/ResponseSO")]

public class Response : ScriptableObject{
	[TextArea]
	public string responseText;

	public int responseValue;
}
