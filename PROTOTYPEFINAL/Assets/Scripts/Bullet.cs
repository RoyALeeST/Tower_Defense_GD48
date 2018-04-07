using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;
    private Vector3 dir;
    private float distanceThisFrame;
    [SerializeField]
    private float speed = 15f;
    public float explosionRadius = 0;
    public int damage = 50;

    [SerializeField]
    private GameObject impactEffectParticle;
    private GameObject referenceToParticle;
    public void Seek(Transform _target)
    {
        target = _target;
    }
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (target == null)
        {
            Destroy(gameObject);
            //Destroy sometimes takes bit of time before it executes, so we have to return in order to exit the function before it continues with a non 
            //destroyed object
            return;
        }
        dir = target.position - transform.position;
        //Distance that we are gonna move this particular frame 
        distanceThisFrame = speed * Time.deltaTime;

        //id dir.magnitude (distance to ur target) is less or equal to the distance that we have to move this frame
        //Then we hited the target
        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
	}

    private void HitTarget()
    {
        referenceToParticle = Instantiate(impactEffectParticle, transform.position, transform.rotation);
        Destroy(referenceToParticle,1f);
        if(explosionRadius > 0 ){
            Explode();
        }else{
            Damage(target);
        }
        
        Destroy(gameObject);
        //Debug.Log("Destroyed Bulelt");
    }

    void Explode(){
        //Returns all objects in a radius and a position as the center
        Collider[] objectsInRadius = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (var collider in objectsInRadius)
        {   
            //If the thing that I collided with is an enemy
            if(collider.tag == "Enemy")
            {
                //Damage that object
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemyToDamage){
        Enemy e = enemyToDamage.GetComponent<Enemy>();
        if(e != null){
            e.TakeDamage(damage);
        }
        
    }

    /// Callback to draw gizmos only if the object is selected.
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,explosionRadius);
    }
}
