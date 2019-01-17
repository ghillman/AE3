using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieWalk : MonoBehaviour
{
    //zombie movement speed
    public float speed;
    //direction of zombie
    private bool goingLeft = true;
    //zombie sprite
    private SpriteRenderer sprite;
    //zombie rigidbody
    private Rigidbody2D ZRigid;

    //Raycast stuff
    public Transform Raystart;
    public Transform RaystartFlip;
    public float Raylength;

    //get the components of stuff
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        ZRigid = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        if (goingLeft)
        {
            //draw a small raycast if it hits anything, make the zombie go the other way
            RaycastHit2D hitInfo = Physics2D.Raycast(Raystart.transform.position, Raystart.transform.right, Raylength);
            Debug.DrawLine(Raystart.transform.position, Raystart.transform.position + new Vector3(Raylength, 0), Color.red);
            if (hitInfo)
            {
                sprite.flipX = true;
                goingLeft = false;
            }
        }
        else if(!goingLeft)
        {
            //draw a small raycast if it hits anything, make the zombie go the other way
            RaycastHit2D hitInfo = Physics2D.Raycast(RaystartFlip.transform.position, RaystartFlip.transform.right, Raylength);
            Debug.DrawLine(RaystartFlip.transform.position, RaystartFlip.transform.position + new Vector3(Raylength, 0), Color.red);
            if(hitInfo)
            {
                sprite.flipX = false;
                goingLeft = true;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        //Zombie go left
        if (goingLeft)
            ZRigid.velocity = new Vector2(-speed * Time.deltaTime, ZRigid.velocity.y);
        //zombie go right
        else if (!goingLeft)
            ZRigid.velocity = new Vector2(speed * Time.deltaTime, ZRigid.velocity.y);       
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }
}
