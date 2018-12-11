using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour {
    private float Timer;
    public float EndTime;
    private bool PortalActive;
	// Use this for initialization
	void Start () {
        Timer = 0;
        PortalActive = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(PortalActive)
        {
            Timer += Time.deltaTime;
            if(Timer >= EndTime)
            {
                Debug.Log("NextLevel!");
            }
        }

	}
    private void OnTriggerEnter2D(Collider2D Target)
    {
        if (Target.gameObject.CompareTag("Player"))
        {
            PortalActive = true;
        }
    }
}
