using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelThirteenDoor : MonoBehaviour {

    public EdgeCollider2D Door;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GetComponent<AttackScript>().Alive == false)
        {
            Door.enabled = false;
        }
	}
}
