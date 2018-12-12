using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnImp : MonoBehaviour {
    public GameObject Imp;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(Imp, transform.position, Quaternion.identity);
            GetComponent<SpawnImp>().enabled = false;
        }

	}
}
