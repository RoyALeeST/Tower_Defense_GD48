using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

	BuildManager buildManager;
	public Color hoverColor;
	public Color notEnoughMoneyColor;

	private Renderer rend;
	private Color startColor;
	[Header("Optional")]
	public GameObject turret;
	public Vector3 positionOffset;
	
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;  
		buildManager = BuildManager._instance;
	}
	
	void OnMouseEnter(){
		//iF IM HOVERING ON TOP OF UI ELEMENT return;
		if(EventSystem.current.IsPointerOverGameObject())
		{
			return;
		}
		//If no turret is selected dont highlight the node
		if(!buildManager.CanBuild)
		{
			return;
		}

		if(buildManager.hasMoney)
		{
			rend.material.color = hoverColor;	
		}else{
			rend.material.color = notEnoughMoneyColor;	
		}
	}

	void OnMouseDown(){
		if(EventSystem.current.IsPointerOverGameObject()){
			return;
		}
		//If no turret is selected return
		if(!buildManager.CanBuild){
			return;
		}
		//If there's a turret on our node then print message
		if(turret != null){
			Debug.Log("Can't build here - TODO: Display on Screen");
			return;
		}
		buildManager.BuildTurretOn(this);
	}

		void OnMouseExit(){
			rend.material.color = startColor; 
		}

		public Vector3 GetBuildPosition(){
			return transform.position + positionOffset;
		}
	// Update is called once per frame
	void Update () {
	}
}
