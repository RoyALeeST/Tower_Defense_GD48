using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {


	//Singleton
	public static BuildManager _instance;
	private TurretBlueprint turretToBuild;
	public GameObject standardTurretPrefab;
	public GameObject rocketTurretPrefab;
	public bool CanBuild{ get { return turretToBuild != null;}} // true if turret is selected
	public bool hasMoney{ get { return PlayerStats.money >= turretToBuild.costOfTurret;}} // true if sufficient money
	[SerializeField]
    private GameObject purchaseTowerParticle;
	void Awake(){
		//SINGLETON INSTANCE
		if(_instance == null){
			_instance = this;
			return;
		}
		Debug.Log("More than one build manager in scene");
	}

	public void SelectTurretToBuild(TurretBlueprint turret){
		turretToBuild = turret;
	}

	public void BuildTurretOn(Node node){
		if(PlayerStats.money < turretToBuild.costOfTurret){
			Debug.Log("Insuficient Money!!");
			return;
		}
		GameObject turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
		node.turret = turret;
		PlayerStats.money -= turretToBuild.costOfTurret;
		GameObject referenceToParticle = Instantiate(purchaseTowerParticle, node.transform.position, Quaternion.identity);
        Destroy(referenceToParticle,1f);
		Debug.Log("Turret build! Money left: " + PlayerStats.money);
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
