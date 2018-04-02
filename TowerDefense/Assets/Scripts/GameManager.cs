 using UnityEngine;

public class GameManager : MonoBehaviour {
	public static bool gameIsOver;
	public GameObject gameOver_UI;

	// Use this for initialization
	void Start () {
		gameIsOver = false; // needs to be started here else it would be true across all scenes
	}
	
	// Update is called once per frame
	void Update () {
		if(gameIsOver)
		{
			return;
		}

	if(Input.GetKeyDown("e"))
	{
		EndGame();
	}

		if(PlayerStats.lives <= 0){
			EndGame();
		}
	}

	private void EndGame(){
		gameIsOver = true;
		gameOver_UI.SetActive(true);
		Debug.Log("Game Over");
	}
}
