using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script for spawning attacks
public class AttackSpawn : MonoBehaviour
{
    public Attack_Directions AttackToSpawn;

    public float delay;//how long it should take for the object to instantiate again
    private float countdown;

    public float SpeedOfAttack;

    public bool up;

    private void Start()
    {
        countdown = delay;
    }

    private void Update()
    {
        //do countdown
        countdown -= Time.deltaTime;
        //at the end of countdown: fire attack and reset countdown
        if (countdown < 0)
        {
            //set position of attack at spawn position
            AttackToSpawn.transform.position = transform.position;
            //Set speed of attack
            AttackToSpawn.speed = SpeedOfAttack;

            if (up)
                AttackToSpawn.up = true;
            else
                AttackToSpawn.up = false;

            //spawn attack
            Instantiate(AttackToSpawn);

            //reset countdown
            countdown = delay;
        }

    }

}
