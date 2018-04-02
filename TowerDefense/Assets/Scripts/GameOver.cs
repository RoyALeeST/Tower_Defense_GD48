using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public Text roundsText;

	void OnEnable(){
		Time.timeScale = 0;
		roundsText.text = PlayerStats.rounds.ToString();
	}

	//Retry level
	public void RetryLevel(){
		Time.timeScale = 1;
		//Load again the current active scene passing his index as argument
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		//SceneManager.LoadScene("MainScene");
	}

	//Return to main menu
	public void goBackTo_MainMenu(){
		Debug.Log("Go to menu");
	}
}
