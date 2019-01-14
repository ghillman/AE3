using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script deactivates anything that collides with the object it is atatched to
public class deactivate : MonoBehaviour
{

    [HideInInspector]
    public bool touched = false;
    //deactivate an object if it touches this
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SetActive(false);
        touched = true;
    }

}
