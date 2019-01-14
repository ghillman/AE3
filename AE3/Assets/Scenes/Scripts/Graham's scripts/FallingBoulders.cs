using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBoulders : MonoBehaviour {
    public GameObject Platform;
    public float FallTimer;
    private float _FallTimer;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        _FallTimer += Time.deltaTime;
        if (_FallTimer >= FallTimer)
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
