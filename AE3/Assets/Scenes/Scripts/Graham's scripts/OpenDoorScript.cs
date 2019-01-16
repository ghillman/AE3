using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorScript : MonoBehaviour {

    public GameObject OtherDoor;
    public GameObject Player;
    public SpriteRenderer Arrow;
    private bool Traverse;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
        if(Traverse == true && Player.GetComponent<PlayerMovement>().Interacting == true && Player.GetComponent<PlayerMovement>().Interacted == true)
        {
            Player.gameObject.transform.position = OtherDoor.transform.position;
            Player.GetComponent<PlayerMovement>().Interacted = false;
        }

	}
    
    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.CompareTag("Player"))
        {
            if (Traverse == false)
            {
                Traverse = true;
                Arrow.enabled = true;
            }
           
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Traverse == true)
            {
                Traverse = false;
                Arrow.enabled = false;
            }

        }
    }

}
