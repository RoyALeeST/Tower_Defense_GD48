using UnityEngine;

public class Shop : MonoBehaviour {
	public TurretBlueprint standardTurret;
	public TurretBlueprint missileLauncher;
	public TurretBlueprint laserBeamerTurret;

	BuildManager buildManager;
	private void Start() {
		buildManager = BuildManager._instance;
	}
	public void SelectStandardTurret(){
		//call the build manager SetTurretToBuild function and pass as an argument
		//the standardTurretPrefab 
		buildManager.SelectTurretToBuild(standardTurret);
		//Debug.Log("Turret Selected");
	}

	public void SelectRocketTurret(){
		buildManager.SelectTurretToBuild(missileLauncher);
		//Debug.Log("Rocket Turret Selected");
	}

		public void SelectLaserBeamer(){
		buildManager.SelectTurretToBuild(laserBeamerTurret);
		//Debug.Log("Laser Turret Selected");
	}
}
