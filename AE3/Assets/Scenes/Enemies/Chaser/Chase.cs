using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public BoxCollider2D start;
    public BoxCollider2D end;
    private bool goBack = false;
    public Transform RayStart;
    private bool backToStart = false;

    public Rigidbody2D player;
    private bool PlayerSpotted;

    private Rigidbody2D chaseRigid;
    public float speed;
    public float Raycast;

    private void Start()
    {
        chaseRigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(RayStart.transform.position, RayStart.transform.right);
        Debug.DrawLine(RayStart.transform.position, RayStart.transform.position + new Vector3(Raycast, 0), Color.red);

        if (hitInfo)
        {
            Debug.Log(hitInfo.transform.name);
            if (hitInfo.transform.name.Equals("Warlock"))
            {
                Debug.Log("I detect Warlock");
                chaseRigid.velocity = new Vector2(speed * Time.deltaTime, chaseRigid.velocity.y);
            }
        }
        //if chaser runs to end flip sprite and make it go back to start
        if (goBack)
        {
            chaseRigid.velocity = new Vector2(-speed * Time.deltaTime, chaseRigid.velocity.y);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //return back to start when end of path hit
        if (collision == end)   
        {
            goBack = true;
            //flip sprites
            if (GetComponent<SpriteRenderer>().flipX == false)
                GetComponent<SpriteRenderer>().flipX = true;

            else if(GetComponent<SpriteRenderer>().flipX == true)
                GetComponent<SpriteRenderer>().flipX = false;
        }
        //turn around wait for player
        if(collision == start)
        {
            goBack = false;
            //flip sprites
            if (GetComponent<SpriteRenderer>().flipX == false)
                GetComponent<SpriteRenderer>().flipX = true;
            else if(GetComponent<SpriteRenderer>().flipX == true)
                GetComponent<SpriteRenderer>().flipX = false;

            chaseRigid.velocity = new Vector2(0, Time.deltaTime);
        }

    }
}
