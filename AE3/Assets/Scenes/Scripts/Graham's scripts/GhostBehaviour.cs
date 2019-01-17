using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehaviour : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GetComponent<AttackScript>().Alive == false)
        {
            GetComponent<MovingPlatform>().enabled = false;
            GetComponent<CapsuleCollider2D>().enabled = false;
            gameObject.tag = "Finish";
        }
	}
}
