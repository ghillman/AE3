using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour {
    public float ArrowSpeed;
    public bool LeftRight;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (LeftRight)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(ArrowSpeed * Time.deltaTime, 0);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-ArrowSpeed * Time.deltaTime, 0);
           // transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }


}
