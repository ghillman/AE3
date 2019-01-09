using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eightLevel : MonoBehaviour {

    public GameObject Platform;
    public GameObject Enemy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Enemy.GetComponent<AttackScript>().Alive == false)
        {
            Platform.GetComponent<MovingPlatform>().first = true;
        }
	}
}
