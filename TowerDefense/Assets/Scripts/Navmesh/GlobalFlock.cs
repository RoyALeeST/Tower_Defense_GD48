using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalFlock : MonoBehaviour {
    public GameObject flockPrefab;
    public static int Size = 5;
    static int numFlock = 10;
    public static GameObject[] allFlock = new GameObject[numFlock];
	void Start ()
    {
        for (int i = 0; i < numFlock; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-Size, Size), Random.Range(-Size, Size), Random.Range(-Size, Size));
            allFlock[i] = (GameObject)Instantiate(flockPrefab, pos, Quaternion.identity);
        }
		
	}
	

	void Update () {
		
	}
}
