using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public float panSpeed = 30f;
	public float panBorderThickness = 10f;//Space between the border of the screen and the limit of the area that will trigger the movement of the camera
	private bool doMovement = true;
	private float scroll; //value returned by the scroll of the mouse wheel
	public float scrollSpeed = 5f;
	[SerializeField]
	private float minY = 10f;
	[SerializeField]
	private float maxY = 80f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)) //Lock the movement of the camera with the esc key
		doMovement = !doMovement;

		if(!doMovement)
			return;

		#region Code when camera is positioned correctly LMAO
			// //Forward Movement
			// if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness){
			// 	transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
			// }

			// //Left movement
			// if(Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness){
			// 	transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
			// }

			// //Downward movement
			// if(Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness){
			// 	transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
			// }

			// //Right movement
			// if(Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness){
			// 	transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
			// }
		#endregion

		//My camera is positioned with a different rotation meaning that all the axis are missplaced
			//Forward Movement
			if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness){
				transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
			}

			//Left movement
			if(Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness){
				transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
			}

			//Downward movement
			if(Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness){
				transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
			}

			//Right movement
			if(Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness){
				transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
			}

			//Scrolling code for zooming in and out
			scroll = Input.GetAxis("Mouse ScrollWheel");
			Vector3 cameraPosition = transform.position;
			//Move up and down the camera
			cameraPosition.y -= scroll * 1000 *  scrollSpeed * Time.deltaTime; //1000 is a multiplier that increases the float number of the scroll Wheel (maximum value i got was 0.3f)
			cameraPosition.y = Mathf.Clamp(cameraPosition.y, minY,maxY);//Avoid infinite zoom in and zoom out
			//Moce the camera
			transform.position = cameraPosition;

	}
}
