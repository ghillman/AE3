using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakyboiScript : MonoBehaviour {

    public float BreakTime;
    public bool Touched;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Touched)
        {
            BreakTime -= Time.deltaTime;
            if (BreakTime <= 0)
            {
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
            }
        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Touched = true;
        }
    }
}
