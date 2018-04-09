using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class LivesUI : MonoBehaviour {

	public Text livesText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerStats.lives < 2){
			livesText.text =  PlayerStats.lives.ToString() + " Live";
		}else{
			livesText.text =  PlayerStats.lives.ToString() + " Lives";
		}
	}
}
