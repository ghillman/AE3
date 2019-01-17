using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenidleScript : MonoBehaviour {

    public int NumberOfGhosts;
    private GameObject[] GhostArray;
    private bool Hit;
    public Sprite Dead;
	// Use this for initialization
	void Start () {
        Hit = false;
	}
	
	// Update is called once per frame
	void Update () {

        if(Hit)
        {
            GhostArray = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject Ghost in GhostArray)
            {
                Ghost.SetActive(false);

            }
        }


	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Lightning"))
        {
            Hit = true;
            GetComponent<SpriteRenderer>().sprite = Dead;
        }
    }
}
