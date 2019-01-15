﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSevenTeenCameraAssignment : MonoBehaviour {
    public GameObject CameraScript;
    public GameObject Player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            CameraScript.GetComponent<Camera>().Follow = gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CameraScript.GetComponent<Camera>().Follow = Player;
        }
    }
}
