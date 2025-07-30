using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KarmaNumberDisplay : MonoBehaviour{

	[SerializeField] TMP_Text text;
	void OnEnable() {
		Broker.Subscribe<KarmaMessage>(OnKarmaMessageReceived);
	}
    
	void OnDisable(){
		Broker.Unsubscribe<KarmaMessage>(OnKarmaMessageReceived);
	}
	void OnKarmaMessageReceived(KarmaMessage obj){
		text.text = obj.Karma.ToString("#.##");
	}
}
