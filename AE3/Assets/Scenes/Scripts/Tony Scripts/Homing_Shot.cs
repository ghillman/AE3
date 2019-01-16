using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing_Shot : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody2D player;


    [HideInInspector]
    public float speed;

    private Rigidbody2D rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    //follow player
    private void FixedUpdate()
    {
        if (player.transform.position.x < transform.position.x)
            rigid.velocity = new Vector2(-speed * Time.deltaTime, rigid.velocity.y);
        else
            rigid.velocity = new Vector2(speed * Time.deltaTime, rigid.velocity.y);

        if (player.transform.position.y < transform.position.y)
            rigid.velocity = new Vector2(rigid.velocity.x, -speed * Time.deltaTime);
        else
            rigid.velocity = new Vector2(rigid.velocity.x, speed * Time.deltaTime);
    }

}
