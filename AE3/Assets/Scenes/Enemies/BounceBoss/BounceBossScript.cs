using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBossScript : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpHeight;
    private float RayCastDown = -0.8f;
    public float bounceTime;
    private bool Bounced = false;
    private bool MovingRight = true;

    //used for physics operations
    private void FixedUpdate()
    {
        StartCoroutine(Bounce());
        if (MovingRight)
            GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed * Time.deltaTime, GetComponent<Rigidbody2D>().velocity.y);
        else
            GetComponent<Rigidbody2D>().velocity = new Vector2((MoveSpeed * Time.deltaTime) * -1, GetComponent<Rigidbody2D>().velocity.y);
    }

    IEnumerator Bounce()
    {
        if (!Bounced)
        {
            GetComponent<Animator>().SetBool("LoadBounce", true);
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight * Time.deltaTime);
            yield return new WaitForSeconds(bounceTime);
            Bounced = true;
        }
        else
        {          
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, (JumpHeight * Time.deltaTime) * -1);
            yield return new WaitForSeconds(bounceTime);
            Bounced = false;
            GetComponent<Animator>().SetBool("LoadBounce", false);
        }
    }

    //If platform hits
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        { }
        else
        {
            if (MovingRight)
                MovingRight = false;
            else
                MovingRight = true;
        }
    }
}
