using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour {
    public int damage;
    private int _damage;
    public int Health;
    public Sprite Dead;
    public Animator Hit;
    public ParticleSystem Particle;
    public float DoomTime;
    public bool DoomActive;
    public bool Alive;
    private Rigidbody2D rigid;
    void Start() {
        _damage = damage;
        Alive = true;
    }
    void Update()
    {
        if (Alive)
        {
            DeadOrAlive();
            DoomTimer();
        }
        else
        {
            rigid = GetComponent<Rigidbody2D>();
            rigid.velocity = new Vector2(0, rigid.velocity.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D Target)
    {
        if (Alive)
        {
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
            else if (Target.gameObject.CompareTag("Doom"))
            {
                DoomActive = true;
                healthCalculation();
            }
        }
        

    }
    private void DoomTimer()
    {
        if (DoomActive == true)
        {
            DoomTime -= Time.deltaTime;
            if (DoomTime <= 0)
            {
                Health = 0;
            }
        }
    }
    void DeadOrAlive()
    {
        if (Health <= 0f)
        {
            transform.GetComponent<SpriteRenderer>().sprite = Dead;

            transform.GetComponent<CapsuleCollider2D>().enabled = false;
            transform.GetComponent<BoxCollider2D>().enabled = true;
            Alive = false;
        }
        
    }
        
    private void healthCalculation()
    {
            
            Health -= _damage;
            Particle.Play();
        if (Health > 0)
        {
           // Hit.SetTrigger("Hit");
        }
    }
}
