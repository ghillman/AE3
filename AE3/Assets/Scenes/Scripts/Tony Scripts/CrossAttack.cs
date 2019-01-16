using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossAttack : MonoBehaviour
{
    private Rigidbody2D rigid;

    [HideInInspector]
    public bool right;
    [HideInInspector]
    public bool up;

    [HideInInspector]
    public float speed;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (up)
            rigid.velocity = new Vector2(rigid.velocity.x, speed * Time.deltaTime);
        else
            rigid.velocity = new Vector2(rigid.velocity.x, -speed * Time.deltaTime);

        if (right)
            rigid.velocity = new Vector2(speed * Time.deltaTime, rigid.velocity.y);
        else
            rigid.velocity = new Vector2(-speed * Time.deltaTime, rigid.velocity.y);
    }

}
