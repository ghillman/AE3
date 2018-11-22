using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody2D PlayerRigid;
    public GameObject View;
    public GameObject Player;
    public GameObject Balls;
    public GameObject Eyes;
    public float MoveSpeed;
    public float YDistance;
    private float myTime;
    public float LightningTime;
    public float Rechargetime;
    public float JumpHeight;
    private bool Strike;
    
    private Animator Animated;

    private DummyBehaviour dummy;

    GameObject Ani;


    // Use this for initialization
    void Start() {

        Animated = GetComponent<Animator>();
        LightningTime = 0;

        Ani = GameObject.FindGameObjectWithTag("Lightning");
        Ani.SetActive(false);

    }

    // Update is called once per frame
    void Update() {
        
        myTime = Time.deltaTime;
        Movement();
        if (Strike)
        {
            LightningStrike();           
        }
        View.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + YDistance, View.transform.position.z);


    }
    private void OnTriggerEnter2D(Collider2D Target)
    {
        if (Target.CompareTag("Enemy"))
        {
            Target.GetComponent<DummyBehaviour>().healthCalculation(1);
        }
    }
    void LightningStrike()
    {
        Rechargetime += Time.deltaTime;
        if (Rechargetime >= 1)
        {            
            Ani.SetActive(true);
            Ani.GetComponent<Animator>().SetBool("Lightning", true);
            
            LightningTime += Time.deltaTime;
            if (LightningTime >= 0.5f)
            {               
                Ani.SetActive(false);                
                Ani.GetComponent<Animator>().SetBool("Lightning", false);                
                Strike = false;
              
                LightningTime = 0;
                Rechargetime = 0;
            }
        }
    }
    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Strike == false)
            {
                
                Strike = true;
            }
        }      
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerRigid.velocity = new Vector2(0, JumpHeight * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            PlayerRigid.velocity = new Vector2(0, PlayerRigid.velocity.y);
            Animated.SetFloat("Moving", 0);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            PlayerRigid.velocity = new Vector2(0, PlayerRigid.velocity.y);
            Animated.SetFloat("Moving", 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            PlayerRigid.velocity = new Vector2((MoveSpeed * -1) * myTime, PlayerRigid.velocity.y);
            Animated.SetFloat("Moving", 1);
            Player.GetComponent<SpriteRenderer>().flipX = true;
            Balls.GetComponent<SpriteRenderer>().flipX = true;
            Eyes.GetComponent<SpriteRenderer>().flipX = true;
            Eyes.transform.position = new Vector2(Player.transform.position.x -0.16f, Player.transform.position.y + 0.43f);
            
            Ani.transform.localScale = new Vector3(-2, 2);
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            PlayerRigid.velocity = new Vector2((MoveSpeed) * myTime, PlayerRigid.velocity.y);
            Animated.SetFloat("Moving", 1);
            Player.GetComponent<SpriteRenderer>().flipX = false;
            Balls.GetComponent<SpriteRenderer>().flipX = false;
            Eyes.transform.position = new Vector2(Player.transform.position.x + 0.16f, Player.transform.position.y + 0.43f);
            
            Ani.transform.localScale = new Vector3(2, 2);
            
        }
        
    }


}
