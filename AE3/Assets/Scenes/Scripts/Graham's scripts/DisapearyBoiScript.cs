using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisapearyBoiScript : MonoBehaviour {

    public Sprite Spector;
    public Sprite Solid;
    public float ChangeTime;
    public bool Set;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        ChangeTime += Time.deltaTime;
        if (ChangeTime >= 1)
        {
            if (Set)
            {
                Set = false;
                Toggle();
            }
            else
            {
                Set = true;
                Toggle();
            }
            ChangeTime = 0;
        }
        

	}
    void Toggle()
    {
        if(Set)
        {
            GetComponent<SpriteRenderer>().sprite = Spector;
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<SpriteRenderer>().sprite = Solid;
        }
    }
}
