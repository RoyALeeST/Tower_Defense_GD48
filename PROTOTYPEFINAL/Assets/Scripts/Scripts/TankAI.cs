using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAI : MonoBehaviour {
	Animator anim;
    public Drive player;
    public GameObject bullet;
	public GameObject turret;
	public int EnemyType;

    public GameObject GetPlayer()
    {
        return player.gameObject;
    }

    void Fire()
	{
		GameObject bullet_instance = Instantiate(bullet, turret.transform.position, turret.transform.rotation);
		Destroy(bullet_instance,1.0f);

	}
	public void StopFiring()
	{
		CancelInvoke("Fire");
	}

	public void StartFiring()
	{
		InvokeRepeating("Fire",0.5f,0.5f);
	}
	private void Start()
	{
		anim =GetComponent<Animator>();
        player = GameManager.player;

    }
	private void Update()
	{
		anim.SetFloat("distance", Vector3.Distance(transform.position,player.transform.position));

	}
}
