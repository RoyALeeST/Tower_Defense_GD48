using UnityEngine;

public class BuildManager : MonoBehaviour {


	//Singleton
	public static BuildManager _instance;
	private TurretBlueprint turretToBuild;
	public bool CanBuild{ get { return turretToBuild != null;}} // true if turret is selected
	public bool hasMoney{ get { return PlayerStats.money >= turretToBuild.costOfTurret;}} // true if sufficient money

    public GameObject purchaseTowerParticle;
	public Node selectedNode;

	public NodeUI nodeUI;
	void Awake(){
		//SINGLETON INSTANCE
		if(_instance == null){
			_instance = this;
			return;
		}
		//sDebug.Log("More than one build manager in scene");
	}

	public void SelectTurretToBuild(TurretBlueprint turret){
		turretToBuild = turret;
		DeselectNode();
	}

	public void SelectNode(Node node){
		if(selectedNode == node){
			Debug.Log("Same node selected");
			DeselectNode();
			return;
		}

		Debug.Log("Different node selected");
		selectedNode = node;
		turretToBuild = null;
		nodeUI.SetTarget(node);
		//  Debug.Log(node);
		// Debug.Log(selectedNode);
	}

	public TurretBlueprint GetTurretToBuild(){
		return turretToBuild;
	}

	public void DeselectNode(){
		selectedNode = null;
		nodeUI.Hide();
	}
}
