using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //It shows the class in the inspector when creating a TurretBlueprint object inside that object 
public class TurretBlueprint {
	public GameObject prefab;
	public int costOfTurret;
	public int upgradeCost;
	public GameObject upgradedPrefab;
	//TODO => ARRAY OF OBJECTS OR LIST THAT CONTAIN EACH VERSION OF THE 
	//UPGRADED VERSION OF THE TURRET

}
