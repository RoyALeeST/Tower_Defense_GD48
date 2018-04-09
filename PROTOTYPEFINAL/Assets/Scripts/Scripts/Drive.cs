using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour {
    [Header("General")]
 	public float speed = 10.0F;
    public float rotationSpeed = 100.0F;
    public float jumpSpeed = 8.0f;

    [Header("Skills")]
    [SerializeField]
    private GameObject _wall;
    private float wallDuration = 3;
    [SerializeField]
    private GameObject _mine;

    void Update() {

        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if(Input.GetKeyDown(KeyCode.Space)){
            SummonWall();
        }

        if(Input.GetKeyDown(KeyCode.C)){
            PlaceMine();
        }
	}

    void SummonWall(){
        GameObject wall = Instantiate(_wall, transform.position + (transform.forward * 3), transform.rotation);
        Destroy(_wall, wallDuration);
    }

    void PlaceMine(){
        GameObject mine = Instantiate(_mine, transform.position, transform.rotation);
    }

}
