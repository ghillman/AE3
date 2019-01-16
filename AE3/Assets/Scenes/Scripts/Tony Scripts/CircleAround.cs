using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script rotates the object around the gameObject passed into it
public class CircleAround : MonoBehaviour
{
    public GameObject ThingToCircle;
    public float speed;
    private bool ClockWise; //used for switching directions

    private void FixedUpdate()
    {
        Orbit();
    }

    //rotation function
    private void Orbit()
    {
        if (ClockWise)
        {
            transform.RotateAround(ThingToCircle.transform.position, Vector3.forward, speed * Time.deltaTime);//(object,direction,speed)
            //counteract rotation of THIS object on the Z axis. i.e stop the sprite spinning round
            transform.Rotate(0, 0, -speed * Time.deltaTime);
        }
        else
        {
            transform.RotateAround(ThingToCircle.transform.position, Vector3.forward, -speed * Time.deltaTime);
            transform.Rotate(0, 0, speed * Time.deltaTime);
        }
    }


    //change directions on collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ClockWise)
            ClockWise = false;
        else
            ClockWise = true;
    }

}
