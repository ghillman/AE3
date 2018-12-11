using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalFader : MonoBehaviour {
    
    private Vector2 Shrinker;
	// Use this for initialization
	void Start () {
        Shrinker = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        Shrinker.x -= Time.deltaTime/10;
        Shrinker.y = Shrinker.x;
        transform.localScale = Shrinker;

        
	}
}
