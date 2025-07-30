using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData {
    public string PlayerID { get; set; }
    
    public string PlayerName { get; set; }
    
    public float TotalKarma { get; set; }
    
    public List<LevelData> CompletedLevelData { get; set; }
}
