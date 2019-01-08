using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//script for knocking back player and dealing damage toe them
public class PlayerDamage : MonoBehaviour {

    private int health;
    private int _Damage;
    private string enemy;
    public float knockback;
    public bool dead;

    // Use this for initialization
    void Start () {

        health = PlayerState.PlayerHealth;
        dead = false;

	}
    private void Update()
    {
       if (dead)
        {
           
            Scene level = SceneManager.GetActiveScene();
            PlayerState.PlayerHealth = 4;
            SceneManager.LoadScene(level.buildIndex);
        }

    }
    //Knocksback and deals damage to player depending on enemy it collided with
    private void OnCollisionEnter2D(Collision2D Target)
    {
        if (Target.gameObject.CompareTag("Enemy"))
        {
           
            gameObject.GetComponent<PlayerMovement>().Hit = true;
            float newknockback = knockback * Time.deltaTime;
            //works out what enemy player collided with and dels damage accordingly
            enemy = Target.gameObject.GetComponent<EnemyAttack>().enemyType;
            if (Target.gameObject.GetComponent<EnemyAttack>().enemyType == "Goblin")
            {
                _Damage = 1;
                
            }
            if (Target.gameObject.GetComponent<EnemyAttack>().enemyType == "Dummy")
            {
                _Damage = 0;

            }
            if (Target.gameObject.GetComponent<EnemyAttack>().enemyType == "AirBomb")
            {
                _Damage = 5;

            }
            if (Target.gameObject.GetComponent<EnemyAttack>().enemyType == "Cloud")
            {
                _Damage = 2;

            }
            if (Target.gameObject.GetComponent<EnemyAttack>().enemyType == "FireCloud")
            {
                _Damage = 2;

            }
            

            if (Target.gameObject.transform.position.x < transform.position.x)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = 
                new Vector2(newknockback, newknockback);
            }
           else
            {
                gameObject.GetComponent<Rigidbody2D>().velocity =
                new Vector2(-newknockback, newknockback);
            }
            PlayerState.PlayerHealth -= _Damage;
            Debug.Log(PlayerState.PlayerHealth);
            
        }
        if (PlayerState.PlayerHealth <= 0)
        {
            dead = true;
        }

    }
    private void OnTriggerEnter2D(Collider2D Target)
    {
        if(Target.gameObject.CompareTag("Enemy"))
        {
            if (Target.gameObject.GetComponent<EnemyAttack>().enemyType == "FireBall")
            {
                _Damage = 2;

            }
            PlayerState.PlayerHealth -= _Damage;
            Debug.Log(PlayerState.PlayerHealth);
        }
        if (Target.gameObject.CompareTag("Hazzard"))
        {
            PlayerState.PlayerHealth = 0;
        }
        if (PlayerState.PlayerHealth <= 0)
        {
            dead = true;
        }
    }




}
