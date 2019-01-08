using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScrimp : MonoBehaviour {

    private bool spawned;
    public GameObject Item;
	// Use this for initialization
	void Start () {

        spawned = false;     
        
	}

    // Update is called once per frame	
    private void OnTriggerStay2D(Collider2D Target)
    {
        if (Target.gameObject.CompareTag("Player"))
        {
            if (!spawned)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Instantiate(Item, transform.position, Quaternion.identity);
                }
            }
        }
    }

}
