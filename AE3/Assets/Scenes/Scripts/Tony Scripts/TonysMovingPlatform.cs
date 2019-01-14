using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TonysMovingPlatform : MonoBehaviour
{
    public float MoveSpeed;
    private bool MovingRight = true;


    //used for physics operations
    private void FixedUpdate()
    {
        if (MovingRight)
            GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed * Time.deltaTime, GetComponent<Rigidbody2D>().velocity.y);
        else
            GetComponent<Rigidbody2D>().velocity = new Vector2((MoveSpeed * Time.deltaTime) * -1, GetComponent<Rigidbody2D>().velocity.y);
    }

    //If platform hits
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (MovingRight)
            MovingRight = false;
        else
            MovingRight = true;
    }

}
