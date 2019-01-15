using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {
    public Sprite Red;
    public Sprite Yellow;
    public Sprite Blue;
    public Sprite Green;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lightning"))
        {
            if(GetComponent<SpriteRenderer>().sprite == Red)
            {
                GetComponent<SpriteRenderer>().sprite = Yellow;
            }
            else if(GetComponent<SpriteRenderer>().sprite == Yellow)
            {
                GetComponent<SpriteRenderer>().sprite = Blue;
            }
            else if (GetComponent<SpriteRenderer>().sprite == Blue)
            {
                GetComponent<SpriteRenderer>().sprite = Green;
            }
            else if (GetComponent<SpriteRenderer>().sprite == Green)
            {
                GetComponent<SpriteRenderer>().sprite = Red;
            }
        }
    }

}
