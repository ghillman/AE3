using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehaviour : MonoBehaviour {

    public float RotationSpeed;
    public GameObject Bomb;
    private float angle;
    public float SpawnTime;
    public Rigidbody2D Rotor;
	// Use this for initialization
	void Start () {
        SpawnTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<AttackScript>().Alive == true)
        {
            SpawnTime += Time.deltaTime;
            GetComponentInParent<InsainCloudRotorMovement>().enabled = true;
            angle += (RotationSpeed * Time.deltaTime);
            transform.parent.rotation = Quaternion.Euler(0, 0, angle);
            if(SpawnTime >= 5)
            {
                Instantiate(Bomb, transform.position, Quaternion.identity);
                Instantiate(Bomb, transform.position, Quaternion.identity);
                SpawnTime = 0;
            }
            
        }
        else
        {
            GetComponentInParent<InsainCloudRotorMovement>().enabled = false;
            gameObject.tag = "Dead";
            Rotor.velocity = new Vector2(0, 0);
        }

    }
   
}
