using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownwardDart : MonoBehaviour {

    public float MoveSpeed;
    private float _MoveSpeed;
    private Rigidbody2D Rigid;
    private Vector2 MoveVector;
    public float _Lifetime;
    
    // Use this for initialization
    void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
        _MoveSpeed = MoveSpeed * Time.deltaTime;
        MoveVector = new Vector2(-_MoveSpeed / 2, -_MoveSpeed / 2);
    }

    // Update is called once per frame
    void Update()
    {
        _Lifetime -= Time.deltaTime;
        if (_Lifetime <= 0)
        {
            Destroy(gameObject);
        }
        
        Rigid.velocity = MoveVector;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Platform"))
        {
            Destroy(gameObject);
        }
    }
}
