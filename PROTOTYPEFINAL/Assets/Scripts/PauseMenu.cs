using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
	public GameObject pauseUI;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
		{
			TogglePauseMenu();
		}
	}

	public void TogglePauseMenu()
	{
		//activeSelf return the current status of the UI (activated or not)
		//with the NOR operand we toggle between the contrary of the current value
		 pauseUI.SetActive(!pauseUI.activeSelf);

		//If pause menu is enables
		 if(pauseUI.activeSelf)
		 {
			Time.timeScale = 0f;
			//Time.fixedDeltaTime used for slowmotion or speed motion
		 }else{
			Time.timeScale = 1f; 
		 }
	}

	public void Retry(){
		Time.timeScale = 1f;
		//When reloading a scene Unity doesnt reload Time.timescale
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void LoadMainMenu(){
		Debug.Log("Go to Menu");
	}
}
