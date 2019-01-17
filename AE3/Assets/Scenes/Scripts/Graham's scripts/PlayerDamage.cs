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
    private bool Hit;
    public bool dead;
    private float HitTime;
    // Use this for initialization
    void Start () {

        health = PlayerState.PlayerHealth;
        dead = false;
        Hit = false;
	}
    private void Update()
    {
        if(Hit)
        {
            HitTime += Time.deltaTime;
            if(HitTime >= 0.5)
            {
                Hit = false;
                HitTime = 0;
            }
        }
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
                _Damage = 2;

            }
            if (Target.gameObject.GetComponent<EnemyAttack>().enemyType == "Cloud")
            {
                _Damage = 1;

            }
            if (Target.gameObject.GetComponent<EnemyAttack>().enemyType == "FireCloud")
            {
                _Damage = 2;

            }
            if (Target.gameObject.GetComponent<EnemyAttack>().enemyType == "Ember")
            {
                _Damage = Random.Range(1, 2);

            }
            if (Target.gameObject.GetComponent<EnemyAttack>().enemyType == "Spider")
            {
                _Damage = 1;

            }
            if (Target.gameObject.GetComponent<EnemyAttack>().enemyType == "Dart")
            {
                _Damage = Random.Range(1,3);

            }
            if (Target.gameObject.GetComponent<EnemyAttack>().enemyType == "Arrow")
            {
                _Damage = 3;

            }
            if (Target.gameObject.GetComponent<EnemyAttack>().enemyType == "Ghost")
            {
                _Damage = 1;

            }
            if (Target.gameObject.GetComponent<EnemyAttack>().enemyType == "Cross_Bomber")
            {
                _Damage = 1;
            }
            if(Target.gameObject.GetComponent<EnemyAttack>().enemyType == "Cross_Bomber_Projectile")
            {
                _Damage = 2;
            }
            if (Target.gameObject.GetComponent<EnemyAttack>().enemyType == "X_Bomber")
            {
                _Damage = 1;
            }
            if (Target.gameObject.GetComponent<EnemyAttack>().enemyType == "x_BomberProjectile")
            {
                _Damage = 2;
            }
            if (Target.gameObject.GetComponent<EnemyAttack>().enemyType == "Nocto")
            {
                _Damage = 1;
            }

            if (Target.gameObject.transform.position.x < transform.position.x)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = 
                new Vector2(newknockback, newknockback);
            }
            if (Target.gameObject.GetComponent<EnemyAttack>().enemyType == "Homing_Shot")
            {
                _Damage = 3;
            }
            if (Target.gameObject.GetComponent<EnemyAttack>().enemyType == "Zombie")
            {
                _Damage = 3;
            }
            if (Target.gameObject.GetComponent<EnemyAttack>().enemyType == "Chaser")
            {
                _Damage = Random.Range(2, 3);
            }
            if (Target.gameObject.GetComponent<EnemyAttack>().enemyType == "Bonce_Boss")
            {
                _Damage = 1;
            }
            if (Target.gameObject.GetComponent<EnemyAttack>().enemyType == "Fireball")
            {
                _Damage = 5; //dead!!!
            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().velocity =
                new Vector2(-newknockback, newknockback);
            }
            PlayerState.PlayerHealth -= _Damage;
            Debug.Log(PlayerState.PlayerHealth);
            _Damage = 0;
            
        }
        if (PlayerState.PlayerHealth <= 0)
        {
            dead = true;
        }

    }
    private void OnTriggerEnter2D(Collider2D Target)
    {
        if (!Hit)
        { 
            if (Target.gameObject.CompareTag("Enemy"))
            {
                        
                Hit = true;
                gameObject.GetComponent<PlayerMovement>().Hit = true;
                float newknockback = knockback * Time.deltaTime;
                if (Target.gameObject.GetComponent<EnemyAttack>().enemyType == "Ember")
                {
                    _Damage = Random.Range(1, 2); ;

                }
                if (Target.gameObject.GetComponent<EnemyAttack>().enemyType == "Dart")
                {
                    _Damage = Random.Range(1, 3);

                }
                if (Target.gameObject.GetComponent<EnemyAttack>().enemyType == "Arrow")
                {
                    _Damage = 3;

                }
                if (Target.gameObject.GetComponent<EnemyAttack>().enemyType == "Ghost")
                {
                    _Damage = 1;

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
            }
            PlayerState.PlayerHealth -= _Damage;
            Debug.Log(PlayerState.PlayerHealth);
            _Damage = 0;
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
