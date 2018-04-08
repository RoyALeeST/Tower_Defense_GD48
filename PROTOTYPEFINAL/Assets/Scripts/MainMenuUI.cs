using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour {

	public void loadGameScene(){
		SceneManager.LoadScene("MainLevel");
	}

}
