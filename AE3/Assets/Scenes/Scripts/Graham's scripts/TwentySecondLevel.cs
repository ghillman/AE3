using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwentySecondLevel : MonoBehaviour {
    public GameObject Door;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GetComponent<AttackScript>().Alive == false)
        {
            Door.GetComponent<EdgeCollider2D>().enabled = false;
        }
	}
}
