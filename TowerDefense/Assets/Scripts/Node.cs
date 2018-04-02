using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

	BuildManager buildManager;
	public Color hoverColor;
	public Color notEnoughMoneyColor;

	private Renderer rend;
	private Color startColor;

	[HideInInspector]
	public GameObject turret;
	[HideInInspector]
	public bool isUpgraded = false;
	[HideInInspector]
	public TurretBlueprint turretBlueprint;
	public Vector3 positionOffset;
	
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;  
		buildManager = BuildManager._instance;
	}
	
	//On Hover 
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

	//On click
	void OnMouseDown(){

		if(EventSystem.current.IsPointerOverGameObject()){
			return;
		}
		//If there's a turret on our node then select the cliked node
		if(turret != null){
			buildManager.SelectNode(this);
			return;
		}

		//If no turret is selected return
		//We only want to do this if there is no turret on the node
		if(!buildManager.CanBuild){
			return;
		}
		//Create turret
		BuildTurret(buildManager.GetTurretToBuild());
	}

	//On hover off
	void OnMouseExit(){
		rend.material.color = startColor; 
	}

	//Buit turret on the selected Node position
	void BuildTurret(TurretBlueprint blueprint)
	{ 
		//If not enough money
		if(PlayerStats.money < blueprint.costOfTurret)
		{
			Debug.Log("Insuficient Money!!");
			return;
		}

		//Build Turret
		GameObject _turret = Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
		turret = _turret;
		PlayerStats.money -= blueprint.costOfTurret;

		turretBlueprint = blueprint;
		GameObject referenceToParticle = Instantiate(buildManager.purchaseTowerParticle	 , transform.position, Quaternion.identity);
		Destroy(referenceToParticle,1f);
		//Debug.Log("Turret build! Money left: " + PlayerStats.money);
	}

	//returns the position at the top of the node 0.5 is the offset
	public Vector3 GetBuildPosition(){
		return transform.position + positionOffset;
	}

	public void sellTurret(){
		PlayerStats.money += turretBlueprint.GetSellAmount();
		//-=----------- IMPORTANT -------------//
		//TODO => Spawn a selling  effect-> just uncomment this and drag and dropthe particle on the inspector
		// GameObject referenceToParticle = Instantiate(buildManager.sellTowerParticle	 , transform.position, Quaternion.identity);
		// Destroy(referenceToParticle,1f);
		Destroy(turret);
		turretBlueprint = null;
	}

	public void UpgradeTurret(){
		//If not enough money
		if(PlayerStats.money < turretBlueprint.upgradeCost)
		{
			Debug.Log("Insuficient Money to upgrade!!");
			return;
		}

		Destroy(turret); //Destroy the old turret
		//Build Upgraded Turret
		GameObject _turret = Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
		turret = _turret;
		PlayerStats.money -= turretBlueprint.upgradeCost;
		
		GameObject referenceToParticle = Instantiate(buildManager.purchaseTowerParticle	 , transform.position, Quaternion.identity);
		Destroy(referenceToParticle,1f);

		isUpgraded = true;
		Debug.Log("Turret Upgraded");
	}

}
