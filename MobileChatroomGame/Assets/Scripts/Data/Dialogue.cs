using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueSO", menuName = "GameData/LevelData/DialogueSO")]
public class Dialogue : ScriptableObject{
	public int dialogueID;

	[TextArea]
	public string dialogueText;

	public List<Response> responsesList;
}
