using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Touch this put a thing in the rigid body so that when the thing is touched to other thing dissapears
public class Switch : MonoBehaviour
{
    public Rigidbody2D door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        door.gameObject.SetActive(false);
    }

}
