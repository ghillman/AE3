using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderPlatform : MonoBehaviour {

    // Use this for initialization
    public bool Fall; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            Fall = true;
    }
}
