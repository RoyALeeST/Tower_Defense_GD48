using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalFlock : MonoBehaviour 
{
	public GameObject flockPrefab;
	public static int SpawnArea = 25;

	static int numFlock = 250;
	public static GameObject [] allFlock = new GameObject [numFlock];

	public static Vector3 goalPos = Vector3.zero;


	// Use this for initialization
	void Start () 
	{
		for ( int i = 0; i<numFlock; i++)
		{
			Vector3 pos = new Vector3 ( Random.Range(-SpawnArea,SpawnArea),Random.Range(-SpawnArea,SpawnArea),Random.Range(-SpawnArea,SpawnArea));
			allFlock[i] = (GameObject) Instantiate(flockPrefab,pos,Quaternion.identity);
		}
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Random.Range(0,1000)<50)
		{
			goalPos = new Vector3( Random.Range(-SpawnArea,SpawnArea),Random.Range(-SpawnArea,SpawnArea),Random.Range(-SpawnArea,SpawnArea));
		}
		
		
	}
}
