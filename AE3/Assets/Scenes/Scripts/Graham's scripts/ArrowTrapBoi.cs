using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrapBoi : MonoBehaviour {
    public GameObject Arrow;
    public float SpawnPoint;
    private Vector2 ArrowSpawn;
    public bool LeftRight;
	// Use this for initialization
	void Start () {
        ArrowSpawn = new Vector2(transform.position.x, transform.position.y + SpawnPoint);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Fire() 
    {
        if(LeftRight)
        {
            Arrow.GetComponent<ArrowScript>().LeftRight = true;
        }
        else
        {
            Arrow.GetComponent<ArrowScript>().LeftRight = false;
        }
        Instantiate(Arrow, ArrowSpawn, Quaternion.identity);
    }
}
