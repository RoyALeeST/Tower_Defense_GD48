using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speed = 10f;
	private Transform target;
	private int wavepointIndex = 0;
	public int health = 100;
	public int moneyReward = 50;

	void Start()
	{
		target = Waypoints.points[0];
	}

	void Update()
	{
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * speed * Time.deltaTime,Space.World);

		if(Vector3.Distance(transform.position,target.position) <= 0.2f){
			GetNextWaypoint();
		}
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

	public void TakeDamage(int damage){
		health -= damage;
		if(health <= 0){
			Die();
		}
	}

	void Die(){
		PlayerStats.money += moneyReward;
		Destroy(gameObject);
	}

}
