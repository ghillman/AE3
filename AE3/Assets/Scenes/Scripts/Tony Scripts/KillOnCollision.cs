using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//An object with this script will deactivate anything it touches
public class KillOnCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
    }
}
