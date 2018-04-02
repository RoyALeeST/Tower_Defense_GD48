using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject nagent;

	void Start ()
    {
        Invoke("SpawnAgent", 2);
	}
	
    void SpawnAgent()
    {
        GameObject na = (GameObject)Instantiate(nagent, this.transform.position, Quaternion.identity);
        Invoke("SpawnAgent", Random.Range(2, 5));
    }

}
