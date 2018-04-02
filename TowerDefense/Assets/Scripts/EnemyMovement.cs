using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {
	private Transform target;
	private int wavepointIndex = 0;
	private Enemy enemy;

	void Start()
	{
		enemy = GetComponent<Enemy>();
		target = Waypoints.points[0];
	}

	void Update()
	{
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * enemy.speed * Time.deltaTime,Space.World);

		if(Vector3.Distance(transform.position,target.position) <= 0.2f){
			GetNextWaypoint();
		}

		//It has to be at the bottom because at this point in the code we already moved towards the next waypoint
		enemy.speed = enemy.startSpeed; //Reset the speed at the end if laser stopped slowing the enemy
	}

    private void GetNextWaypoint()
    {
		if(wavepointIndex >= Waypoints.points.Length -1){
			EndPath();
			return;
		}
        wavepointIndex++;
		target = Waypoints.points[wavepointIndex];
    }

	void EndPath()
	{	
		PlayerStats.lives--;
		Destroy(gameObject);
	}
}
