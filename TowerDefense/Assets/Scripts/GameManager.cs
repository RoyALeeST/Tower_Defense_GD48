using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	private bool gameEnded = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(gameEnded)
		{
			return;
		}
		if(PlayerStats.lives <= 0){
			EndGame();
		}
	}

	private void EndGame(){
		gameEnded = true;
		Debug.Log("Game Over");
	}
}
