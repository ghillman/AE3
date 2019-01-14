using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    public float moveSpeed;

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2((moveSpeed * Time.deltaTime) * -1, GetComponent<Rigidbody2D>().velocity.y);
    }

}
