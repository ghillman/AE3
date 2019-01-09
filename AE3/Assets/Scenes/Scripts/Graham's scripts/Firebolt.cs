using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firebolt : MonoBehaviour {

    private Rigidbody2D boltRigid;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        boltRigid = gameObject.GetComponent<Rigidbody2D>();
	}
    private void OnTriggerEnter2D(Collider2D Target)
    {
        
        if(Target.gameObject.CompareTag("Enemy"))
        {
            Destroy(boltRigid);
            transform.localPosition= new Vector2 ( 0, 0);
        }
        if (Target.gameObject.CompareTag("Ground"))
        {
            Destroy(boltRigid);
            transform.localPosition = new Vector2(0, 0);
        }
    }
}
