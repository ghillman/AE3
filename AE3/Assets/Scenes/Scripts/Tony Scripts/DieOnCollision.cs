using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//If the object this is attached to collides with anything, destroy THIS object
public class DieOnCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
    }
}
