using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneScript : MonoBehaviour {

    public float Speed;
    private float _Speed;
    [HideInInspector]
    public bool Direction;
    public float angleSpeed;
    private float _Angle;
    
	// Use this for initialization
	void Start () {
        
        _Speed = Speed * Time.deltaTime;
        
        if (Direction)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-_Speed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            angleSpeed = angleSpeed * -1;
            GetComponent<Rigidbody2D>().velocity = new Vector2(_Speed, GetComponent<Rigidbody2D>().velocity.y);
        }
	}

    // Update is called once per frame
    private void Update()
    {
        _Angle += angleSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0, 0, _Angle);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }

}
