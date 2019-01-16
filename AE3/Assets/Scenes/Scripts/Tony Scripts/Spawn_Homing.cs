using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Homing : MonoBehaviour
{
    public Homing_Shot shot;
    public Rigidbody2D target;

    public float speed;

    public float delay;
    private float countdown;

    private void Start()
    {
        countdown = delay;
    }

    private void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown < 0)
        {
            //set target
            shot.player = target;
            //set speed
            shot.speed = speed;
            //spawn object
            Instantiate(shot);
            //reset countdown
            countdown = delay;
        }
    }

}
