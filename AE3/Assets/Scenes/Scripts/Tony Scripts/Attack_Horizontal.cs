using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class Attack_Horizontal : MonoBehaviour
{
    [HideInInspector]
    public float speed;

    [HideInInspector]
    public bool Right;

    private Rigidbody2D rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Right)
            rigid.velocity = new Vector2(speed * Time.deltaTime, rigid.velocity.y);
        else
            rigid.velocity = new Vector2(-speed * Time.deltaTime, rigid.velocity.y);

    }

}
