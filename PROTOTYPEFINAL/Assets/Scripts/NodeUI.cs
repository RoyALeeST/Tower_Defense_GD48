using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {

	private Node target;
	public GameObject ui;
	public Text upgradeCostText;
	public Text sellAmountText;
	public Button upgradeButton;


	public void SetTarget(Node _target){
		 target = _target;
		 transform.position = target.GetBuildPosition();
		 sellAmountText.text = "$" + target.turretBlueprint.GetSellAmount();
		if(!target.isUpgraded){
			
			upgradeCostText.text = "$" + target.turretBlueprint.costOfTurret;
			upgradeButton.interactable = true;
		}else{
			upgradeCostText.text = "Max lvl";
			upgradeButton.interactable = false;
		}

		 ui.SetActive(true);
	}

	public void Hide(){
		ui.SetActive(false);
	}

	public void Sell(){
		target.sellTurret();
		 //After selling we want to deselect all nodes that 
		 //we have selected so the UI disappears
		BuildManager._instance.DeselectNode();
	}

	public void Upgrade(){
		target.UpgradeTurret();
		//After selling we want to deselect all nodes that 
		//we have selected so the UI disappears
		BuildManager._instance.DeselectNode();
	}
}
