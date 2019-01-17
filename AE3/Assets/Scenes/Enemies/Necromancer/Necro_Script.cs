using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Necro_Script : MonoBehaviour
{
    //get zombie
    public GameObject Zombie;
    //make zombie spawn here
    public Transform spawnPoint;
    //make sure the zombies can all be killed at the end
    //private GameObject[] zombiearray;
    //private int spaceInArray;                  //couldn't work out how to use destructors in c# without levelManager

    //countdown for zombies
    private float delay = 8f;
    private float countdown;

    //get ray object
    public GameObject DeathRay;
    public float SpeedOfRay;

    //DeathRay stuff
    public Transform Raystart;
    public float Raylength;

    //countdown for deathray
    private float DeathRayDelay = 15f;
    private float DeathRayCountdowm;

    //set countdowns
    private void Start()
    {
        countdown = delay;
        DeathRayCountdowm = DeathRayDelay;
    }

    // Update is called once per frame
    void Update ()
    {

        //set up the ray to check if the player is on the top floor

        //draw a small raycast if it hits anything, make the zombie go the other way
        RaycastHit2D hitInfo = Physics2D.Raycast(Raystart.transform.position, Raystart.transform.right, Raylength);
        Debug.DrawLine(Raystart.transform.position, Raystart.transform.position + new Vector3(Raylength, 0), Color.red);
        if (hitInfo)
        {
            //reset zombie summon cooldown
            countdown = delay;
            DeathRayCountdowm -= Time.deltaTime;
            if(DeathRayCountdowm < 0)
            { 
                Instantiate(DeathRay);
                DeathRayCountdowm = DeathRayDelay;
            }
        }
        //if the is no ray summon a zombie
        else
        {
            //reset deathray countdown
            DeathRayCountdowm = DeathRayDelay;   
            //after countdown spawn zombie at necromancer
            countdown -= Time.deltaTime;
            if (countdown < 0)
            {
                Zombie.transform.position = spawnPoint.transform.position;
                Instantiate(Zombie);
                //zombiearray[spaceInArray] = Zombie;
                //spaceInArray++;
                countdown = delay;
            }
        }
	}

}
