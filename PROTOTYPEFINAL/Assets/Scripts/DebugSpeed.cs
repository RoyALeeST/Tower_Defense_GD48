using UnityEngine;

public class DebugSpeed : MonoBehaviour
{

	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			Time.timeScale = 1;
		}
		if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			Time.timeScale = 2;
		}
		if(Input.GetKeyDown(KeyCode.Alpha4))
		{
			Time.timeScale = 4;
		}
	}
}
