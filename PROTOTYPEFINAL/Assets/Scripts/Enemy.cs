using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float startSpeed = 10f;
	[HideInInspector]
	public float speed;
	public float health = 100;
	public int moneyReward = 50;
	[SerializeField]
	private GameObject deathEffectPrticles;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		speed = startSpeed;
	}

	public void TakeDamage(float damage){
		health -= damage;
		if(health <= 0){
			Die();
		}
	}

	//Receives a value between 0 and 1.n 0 means that no slow effect is happening and 1 that we want to stop it completly
	public void Slow(float slowRatio){
		speed = startSpeed * (1f -slowRatio);
	}

	void Die(){
		PlayerStats.money += moneyReward;
		GameObject deathEffect = Instantiate(deathEffectPrticles, transform.position,Quaternion.identity);
		Destroy(deathEffect,2f);
		Destroy(gameObject);
	}

}
