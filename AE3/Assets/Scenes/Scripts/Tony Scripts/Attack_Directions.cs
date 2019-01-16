using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script fires an attack from a spawn. All Variables are set via the AttackSpawn script
public class Attack_Directions : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody2D rigid; //rigid bodies
    //directions
    [HideInInspector]
    public bool vertical;
    [HideInInspector]
    public bool horizontal;
    [HideInInspector]
    public bool up = false;
    [HideInInspector]
    public bool right;

    [HideInInspector]
    public float speed;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (vertical)
        {
            if (up)
                rigid.velocity = new Vector2(rigid.velocity.x, speed * Time.deltaTime);
            else
                rigid.velocity = new Vector2(rigid.velocity.x, -speed * Time.deltaTime);
        }

    }
}
