using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	[SerializeField]
	private Transform target;   //Enemy target
    private Enemy targetEnemy;
    [Header("General")]
	public float range = 15f;   //Turret Range
    [Header("Use Bullets(Default)")]
    public float fireRate = 1f; //Fire rate
    private float fireCountdown = 0f; //Time between shoots
    public GameObject bulletPrefab; //Bullet to shoot



    [Header("Use Laser")]
    public bool useLaser = false;   //If true then the turrets shoots a laser instead of a bullet
    public LineRenderer lineRenderer;   //Line renderer for the lase effect
    public Light impactLight;
    public ParticleSystem impactEffect;
    public int damageOverTime = 30;
    public float slowPercentage = .5f;


    [Header("Unity setup fields")]
    public string enemyTag = "Enemy";   // Find enemies
    public Transform pathToRotate;  //Where will I rotate my head
    public float speed = 10f;  //How fast the torret will rotate

    public Transform firePoint; //Instantiate bullet from this point

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
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
	}

	// Update is called once per frame
	void Update () {
		if(target == null)
        {
            if(useLaser){

                if(lineRenderer.enabled){//If turret uses laser and the turret has no target then disable the line renderer
                    lineRenderer.enabled = false;
                    impactEffect.Stop();// Stop the particle playing if no target is in range
                    impactLight.enabled = false;
               }
            }
            return;
        }
			

        LockOnTarget();

        //If the turres shoots a laser instead of a bullet
        if(useLaser)
        {
            shootWithLaser();
        }
        else
        {
            if(fireCountdown < 0)
            {
                //Time to shoot
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
            }
	}

    void shootWithLaser()
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowPercentage);
        if(!lineRenderer.enabled)
        {
            lineRenderer.enabled = true; //Used for switching on and off of the line renderer
            impactEffect.Play();// Play the effect particle and keep it playing and stop from adding more particles,it's one plarticle looping
            impactLight.enabled = true;
        }
        //render between 2 positions first is starting point second is the end point
        lineRenderer.SetPosition(0, firePoint.position); //Start
        lineRenderer.SetPosition(1, target.position); // End

        //Prticle needs to follow the target while he moves

        Vector3 direction = firePoint.position - target.position; //Vector pointing in the direction of our laser is pointing
        impactEffect.transform.rotation = Quaternion.LookRotation(direction); //rotate until pointing tothe specicifed vector
        impactEffect.transform.position = target.position +direction.normalized;
    }

    void LockOnTarget(){
        //Direction of the vector between the enemy and the player
        Vector3 dir = target.position - transform.position;
        //Unity form of sotoring rotation
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        //Store in rotation the euler angles of the direction of the enemy
        //Lerp smooths the transitions
        Vector3 rotation = Quaternion.Lerp(pathToRotate.rotation, lookRotation, Time.deltaTime * speed).eulerAngles;
        //Rotate only on the y axis of the turret
        pathToRotate.rotation = Quaternion.Euler(0f,rotation.y,0f);
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
