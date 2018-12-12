using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsainCloudRotorMovement : MonoBehaviour {

    public Rigidbody2D Rotor;
    public bool LeftRight;
    public float MoveSpeed;
    private float _MoveSpeed;
	// Use this for initialization
	void Start () {
        LeftRight = false;
    }
	
	// Update is called once per frame
	void Update () {
        _MoveSpeed = MoveSpeed * Time.deltaTime;
        if (LeftRight)
        {
            Rotor.velocity = new Vector2(_MoveSpeed, 0);
        }
        else
        {
            Rotor.velocity = new Vector2(-_MoveSpeed, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D Target)
    {
        if (gameObject.CompareTag("Rotor"))
        {
            if (Target.gameObject.CompareTag("Point"))
            {
                LeftRight = true;
            }
            else if (Target.gameObject.CompareTag("Point2"))
            {
                LeftRight = false;
            }

        }
    }
}
