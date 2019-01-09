using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour {
    private float randX;
    private float randY;
    public float bottomEnd;
    public float topEnd;
    // Use this for initialization
    void Start()
    {
        randX = Random.Range(-bottomEnd, topEnd);
        randY = Random.Range(bottomEnd, topEnd);
        randX = randX / 2;
        GetComponent<Rigidbody2D>().velocity = new Vector2(randX * Time.deltaTime, randY * Time.deltaTime);
    }
}
