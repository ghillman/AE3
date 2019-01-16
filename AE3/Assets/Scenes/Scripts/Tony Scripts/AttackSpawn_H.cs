using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpawn_H : MonoBehaviour
{
    public Attack_Horizontal attack;

    public float delay;
    private float countdown;

    public bool Right;

    public float speed;

    private void Start()
    {
        countdown = delay;
    }

    private void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown < 0)
        {
            attack.transform.position = transform.position;
            attack.speed = speed;

            if (Right)
                attack.Right = true;
            else
                attack.Right = false;

            Instantiate(attack);

            countdown = delay;
        }
    }


}
