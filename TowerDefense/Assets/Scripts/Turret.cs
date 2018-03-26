using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	[SerializeField]
	private Transform target;
    [Header("Attributes")]
	public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Unity setup fields")]
    public string enemyTag = "Enemy";
    public Transform pathToRotate;
    public float speed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;

	// Use this for initialization
	void Start () {
		InvokeRepeating("UpdateTarget",0f,0.5f);
	}
	
	//Search trough all objects tagged as enemies,  picks the closes one
	//check if in range, and select it as the new target
	void UpdateTarget(){
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;
		foreach (GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if(distanceToEnemy < shortestDistance){
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

		if(nearestEnemy != null && shortestDistance <= range){
			target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
	}
	// Update is called once per frame
	void Update () {
		if(target == null)
			return;

        //Direction of the vector between the enemy and the player
        Vector3 dir = target.position - transform.position;
        //Unity form of sotoring rotation
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        //Store in rotation the euler angles of the direction of the enemy
        //Lerp smooths the transitions
        Vector3 rotation = Quaternion.Lerp(pathToRotate.rotation, lookRotation, Time.deltaTime * speed).eulerAngles;
        //Rotate only on the y axis of the turret
        pathToRotate.rotation = Quaternion.Euler(0f,rotation.y,0f);

        if(fireCountdown < 0)
        {
            //Time to shoot
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
	}

    private void Shoot()
    {
        //Instantiate the bullet into a variable so we can call his methods
        GameObject bulletGO = Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
            bullet.Seek(target);
    }

    void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);	
	}
}
