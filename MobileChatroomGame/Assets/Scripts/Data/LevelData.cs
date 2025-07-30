using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData {
    public string LevelId { get; set; }
    
    public string LevelName { get; set; }
    
    public float LevelKarma { get; set; }
    
    public List<Dialogue> LevelDialogueList {get; set;}
}
