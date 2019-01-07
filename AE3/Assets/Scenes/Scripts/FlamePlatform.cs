using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamePlatform : MonoBehaviour {

    public float Flame;

	// Use this for initialization
	void Start () {
        
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

        Flame += Time.deltaTime;
        if(Flame >= 1)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;
            if(Flame >= 2)
            {
                Flame = 0;
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
            }
        }
	}
}
