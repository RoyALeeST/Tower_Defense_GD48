using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour {
	public float speed = 0.5f;
	float rotationSpeed = 4.0f;
	Vector3 averageHeading; // rules of floak
	Vector3 averagePosition; //rules of floak
	float neighbourDistance = 3.0f; // rules of floak: max distance to floak

	bool turning = false; 

	void Start () 
	{
		speed = Random.Range (0.5f,1);
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if ( Vector3.Distance (transform.position, Vector3.zero)>= GlobalFlock.SpawnArea)
		{
			turning = true;
		}
		else 
		turning = false;

		if(turning)
		{
			Vector3 direction = Vector3.zero - transform.position;
			transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(direction),rotationSpeed*Time.deltaTime);
			speed = Random.Range(0.5f,1);
		}
		else
		{
		if(Random.Range(0,5)<1) // increase second value if they floak too much
		ApplyRules();
		}
		

		transform.Translate(0,0,Time.deltaTime*speed);
	}

	void ApplyRules () // programming for the rules of floak
	{
		GameObject[] gos; //game objec is a gos
		gos = GlobalFlock.allFlock;
		Vector3 vcenter = Vector3.zero; // move to the center
		Vector3 vavoid = Vector3.zero; // avoid bumping into others

		float gSpeed =0.1f;

		Vector3 goalPos = GlobalFlock.goalPos;

		float dist;

		int groupsize =0; // who is in that distance is part of the group

		foreach(GameObject go in gos)
		{
			if(go!=this.gameObject)
			{
				dist = Vector3.Distance(go.transform.position, this.transform.position);
				if(dist <= neighbourDistance)
				{
					vcenter += go.transform.position; // they add all  the center of all the items
					groupsize++; // make bigger the group

					if(dist<1.0f) // if all are really close they gonna change the distance and separating 
					{
						vavoid=vavoid+(this.transform.position - go.transform.position);
					}
					Flock anotherFlock = go.GetComponent<Flock>(); //grab the flock script on every one part of the group
					gSpeed = gSpeed + anotherFlock.speed;
				}
			}
		}

		if(groupsize>0)// if we are in a group
		{
			vcenter = vcenter/groupsize + (goalPos - this.transform.position); //calculate the average center of the group
			speed = gSpeed/groupsize; // and the average speed 

			Vector3 direction = (vcenter+vavoid) - transform.position; // give the direction to turn into

			if(direction != Vector3.zero) // if the direction is dif than 0 they are going to rotate
			transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(direction),rotationSpeed*Time.deltaTime);


		}


	}
}
