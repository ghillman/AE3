using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyBehaviour : MonoBehaviour {
    public float Health;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Health <= 0)
        {
            Destroy(transform.gameObject);
        }

	}

    public void healthCalculation(int damage)
    {

        Health -= damage;

    }


}
