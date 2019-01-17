using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ladder_Script : MonoBehaviour
{
    //buttons
    public GameObject up;
    [HideInInspector]
    public bool ascending = false;
    public GameObject Down;
    [HideInInspector]
    public bool Descending = false;
    //Raycast
    public float CastLength;
    public Transform CastBegin;
    //Player
    private Rigidbody2D PlayerR;
    private float Speed;


    //get the player and their movement speed
    private void Start()
    {
        PlayerR = FindObjectOfType<PlayerMovement>().GetComponent<Rigidbody2D>();
        Speed = FindObjectOfType<PlayerMovement>().MoveSpeed;
    }


    //cast a ray if the player is hit by the ray set their velocity to zero and activate the buttons
    //if the ray doesnt detect anything, put the player back to normal and get rid of the buttons
    private void Update()
    {
        //cast Ray
        RaycastHit2D hitInfo = Physics2D.Raycast(CastBegin.transform.position, CastBegin.transform.up,CastLength);
        Debug.DrawLine(CastBegin.transform.position, CastBegin.transform.position + new Vector3(0, CastLength), Color.red);

        if (hitInfo)
        {
            Debug.Log(hitInfo.transform.name);
            //Ray hits player
            if (hitInfo.transform.name.Equals("Warlock"))
            {
                //buttons activate
                up.SetActive(true);
                Down.SetActive(true);
                //move player if they press the up or down arrow
                if (ascending)
                    PlayerR.velocity = new Vector2(PlayerR.velocity.x, Speed * Time.deltaTime);

                if (Descending)
                    PlayerR.velocity = new Vector2(PlayerR.velocity.x, -Speed * Time.deltaTime);
                //stop the player if they are not pressing the arrows
                if (!ascending && !Descending)
                    PlayerR.velocity = new Vector2(PlayerR.velocity.x, 0);
            }
        }
        if(!hitInfo)
        {
            up.SetActive(false);
            Down.SetActive(false);
        }
    }


}
