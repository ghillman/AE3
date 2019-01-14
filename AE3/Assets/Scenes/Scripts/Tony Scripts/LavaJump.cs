using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaJump : MonoBehaviour
{
    public float MoveSpeed;
    //time waiting in the lava and time jumping up out of it
    public float WaitTime;
    //Time lava goes up before dropping back down
    public float JumpTime;

    private bool falling = true;
    private bool Waited = false;

    private void FixedUpdate()
    {
        //lava has collided with something 
        if(!falling)
            StartCoroutine(Wait());
    }

    //lava collides with floor
    private void OnCollisionEnter2D(Collision2D collision)
    {
        falling = false;
    }

    IEnumerator Wait()
    {
        //wait in the lava for a bit
        if (!Waited)
        {
            for (int i = 0; i < WaitTime; i++)
                yield return new WaitForSeconds(WaitTime);
            Waited = true;
        }
        //jump in the air for JumpTime
        else
        {
            for (int i = 0; i < JumpTime; i++)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, MoveSpeed * Time.deltaTime);
                yield return new WaitForSeconds(JumpTime);
            }
            
            falling = true;
            Waited = false;
        }
    }
}
