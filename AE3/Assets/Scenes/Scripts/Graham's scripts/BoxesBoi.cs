using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxesBoi : MonoBehaviour
{
    public float BoxHealth;
    private float _damage;
    public bool Alive;
    private float waitTime;
    private bool vibrate;
    public ParticleSystem Particals;

    // Use this for initialization
    void Start()
    {
        waitTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (vibrate)
        {
            transform.position = new Vector2(transform.position.x + 0.0001f, transform.position.y);
            vibrate = false;
        }
        else
        {
            transform.position = new Vector2(transform.position.x - 0.0001f, transform.position.y);
            vibrate = true;
        }
        if (!Alive)
        {
            waitTime += Time.deltaTime;
            if (waitTime >= 1.5f)
            {
                Destroy(gameObject);
            }
        }

    }

    void healthCalculation()
    {
        BoxHealth = BoxHealth - _damage;
        Particals.Play();
        Debug.Log(BoxHealth);
        if (BoxHealth <= 0)
        {
            Alive = false;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D Target)
    {

        if (Alive)
        {
            Debug.Log("hello");
            if (Target.gameObject.CompareTag("Lightning"))
            {
                _damage = 1;
                healthCalculation();
            }
            else if (Target.gameObject.CompareTag("BigAttack"))
            {
                _damage = 10;
                healthCalculation();
            }
            else if (Target.gameObject.CompareTag("Firebolt"))
            {
                _damage = 1;
                healthCalculation();
            }
        }
    }
}
    

