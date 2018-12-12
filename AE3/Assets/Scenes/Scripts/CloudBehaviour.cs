using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehaviour : MonoBehaviour {

    public float RotationSpeed;
    public float MoveSpeed;
    private float _MoveSpeed;
    private float angle;
    private bool LeftRight;
	// Use this for initialization
	void Start () {
        LeftRight = false;
	}
	
	// Update is called once per frame
	void Update () {

        _MoveSpeed = MoveSpeed * Time.deltaTime;
        angle += (RotationSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 0, angle);
        
        if(LeftRight)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(_MoveSpeed, 0);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-_MoveSpeed, 0);
        }
	}
    private void OnTriggerEnter2D(Collider2D Target)
    {
        if(gameObject.CompareTag("Rotor"))
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
