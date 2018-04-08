using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour {
	[SerializeField] 
	private int _damage;
	[SerializeField]
	private int _explosionRadius;
	[SerializeField]
	private GameObject _explosion_effect;
	void Explode(){
        //Returns all objects in a radius and a position as the center
        Collider[] objectsInRadius = Physics.OverlapSphere(transform.position, _explosionRadius);
        foreach (var collider in objectsInRadius)
        {   
            //If the thing that I collided with is an enemy
            if(collider.tag == "Player")
            {
                //Damage that object
                //Damage(collider.transform);
				GameObject deathParticle = Instantiate(_explosion_effect,transform.position, transform.rotation);
				Destroy(deathParticle,1f);
				Destroy(gameObject);
            }
        }

    }

	void Update(){
		Collider[] objectsInRadius = Physics.OverlapSphere(transform.position, _explosionRadius);
		if(objectsInRadius.Length > 0){
			Explode();
		}
	}
	private void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,_explosionRadius);
	}

	void Damage(Transform enemyToDamage){
        Enemy e = enemyToDamage.GetComponent<Enemy>();
        if(e != null){
            e.TakeDamage(_damage);
        }
        
    }
}
