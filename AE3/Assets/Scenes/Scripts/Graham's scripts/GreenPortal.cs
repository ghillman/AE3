using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPortal : MonoBehaviour {
    public Transform NewPosition;
    public bool active;
    private float timer;
	// Use this for initialization
	void Start () {
        active = true;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
	}
    private void OnTriggerEnter2D(Collider2D Target)
    {
        if (active)
        {
            if (Target.gameObject.CompareTag("Player"))
            {
                timer = 0;
                Target.gameObject.transform.position = NewPosition.position;
                active = false;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D Target)
    {
        if (!active)
        {
            if (timer >= 1)
            {
                if (Target.gameObject.CompareTag("Player"))
                {
                    active = true;
                    timer = 0;
                }
            }
        }
    }
}
