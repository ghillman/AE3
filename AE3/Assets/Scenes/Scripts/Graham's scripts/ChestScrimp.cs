using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScrimp : MonoBehaviour {

    private bool spawned;
    public GameObject Item;
    public GameObject Player;
    public SpriteRenderer Alert;
	// Use this for initialization
	void Start () {

        spawned = false;     
        
	}
    void Update()
    {
        if (Player.GetComponent<PlayerMovement>().Interacted == true && Player.GetComponent<PlayerMovement>().Interacting == true && spawned == false)
        {
            Instantiate(Item, transform.position, Quaternion.identity);
            spawned = true;
            Player.GetComponent<PlayerMovement>().Interacted = false;
            Alert.enabled = false;
            
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && spawned == false)
        {
            Alert.enabled = true;
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            Alert.enabled = false;
        }

    }

    // Update is called once per frame	

}
