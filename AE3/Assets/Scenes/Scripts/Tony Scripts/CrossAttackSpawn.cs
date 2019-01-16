using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossAttackSpawn : MonoBehaviour
{
    public CrossAttack Attack;

    public bool up = false;
    public bool right = false;

    public float speed;

    public float delay;
    private float countdown;

    private void Start()
    {
        countdown = delay;
    }

    private void Update()
    {
        //countdown
        countdown -= Time.deltaTime;
        if(countdown < 0)
        {
            //set direction
            if (up)
                Attack.up = true;
            else
                Attack.up = false;

            if (right)
                Attack.right = true;
            else
                Attack.right = false;
            //set speed
            Attack.speed = speed;
            //set position
            Attack.transform.position = transform.position;
            //fire
            Instantiate(Attack);
            //reset countdown
            countdown = delay;
        }
    }

}
