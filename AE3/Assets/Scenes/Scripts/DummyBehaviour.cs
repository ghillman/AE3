using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyBehaviour : MonoBehaviour {


    public float Health;
    private bool vibrate;    


	void Update () {
        if (vibrate == true)
        {
            transform.position = new Vector2(transform.position.x + 0.0001f, transform.position.y);
            vibrate = false;
        }
        else
        {
            transform.position = new Vector2(transform.position .x - 0.0001f, transform.position.y);
            vibrate = true;
        }        
	}
}
