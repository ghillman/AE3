using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody2D PlayerRigid;
    public GameObject Player;
    public GameObject Balls; //objects floating above player
    public GameObject Eyes;   
    public GameObject JumpParticals;
    public GameObject BigAttack;

    public float MoveSpeed;
    public float YDistance;
    [HideInInspector]
    public float myTime;
    [HideInInspector]
    public float BigAttackCharge = 0;

    public bool Hit; //changed in PlayerDamage script
    public float HitCounter;
   
    public float JumpHeight;
    [HideInInspector]
    public bool BigAttackBool;
    public float RayCastDown;
    public float BigAttackCooldown;
    public float BigAttackSize;
    public float BigAttackTime; //this is just 0
    [HideInInspector]
    public Animator Animated;
    
    // Use this for initialization
    void Start() {

        Animated = GetComponent<Animator>();        
        BigAttackCharge = 0;
        Hit = false;
        HitCounter = 0;
    }

    void Update() {
        if (Hit)
        {
            HitCounter += Time.deltaTime;
            if (HitCounter >= 0.5)
            {
                Hit = false;
                HitCounter = 0;
            }
        }
        myTime = Time.deltaTime;
        Movement();
        
        if (BigAttackBool == true)
        {
            BigAttackFunck();
        }
      
        
            Debug.DrawLine(transform.position, transform.position + new Vector3(0, RayCastDown, 0), Color.blue);
    }
    void BigAttackFunck()
    {
        //Scales up the collider of the Big Attack
        Transform BigAttackCollider = BigAttack.transform.GetChild(0).transform;
        BigAttackSize += 0.1f;
        BigAttackCollider.localScale = new Vector2(BigAttackSize, BigAttackSize);

        BigAttackCharge += Time.deltaTime;
        if (BigAttackCharge >= BigAttackCooldown)
        {
            BigAttackBool = false;
            
            BigAttackCharge = 0;
        }
        if (BigAttackCharge >= BigAttackTime)
        {
            BigAttack.SetActive(false);
        }
    }
        
    
    void Movement()
    {
        //Big Attack
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //displays attack and then disperses it
            if (BigAttackBool == false)
            {
                BigAttackBool = true;
                BigAttack.SetActive(true);
                Transform BigAttackCollider = BigAttack.transform.GetChild(0).transform;
                BigAttackSize = 0;
                BigAttackCollider.localScale = new Vector2(BigAttackSize, BigAttackSize);
            }
        }
        //Jump  
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics2D.Linecast(transform.position, transform.position + new Vector3(0, RayCastDown, 0), 1 << LayerMask.NameToLayer("Ground")))
            {
                PlayerRigid.velocity = new Vector2(0, JumpHeight * Time.deltaTime);                           
                JumpParticals.SetActive(false);              
                JumpParticals.SetActive(true);
            }
        }
        //side to side Movement
        if (Hit == false)
        {
            //if (Input.GetKeyUp(KeyCode.A))
            //{
            //    PlayerRigid.velocity = new Vector2(0, PlayerRigid.velocity.y);
            //    Animated.SetFloat("Moving", 0);
            //}
            //if (Input.GetKeyUp(KeyCode.D))
            //{
            //    PlayerRigid.velocity = new Vector2(0, PlayerRigid.velocity.y);
            //    Animated.SetFloat("Moving", 0);
            //}
            //if (Input.GetKey(KeyCode.A))
            //{
            //    PlayerRigid.velocity = new Vector2((MoveSpeed * -1) * myTime, PlayerRigid.velocity.y);
            //    Animated.SetFloat("Moving", 1);
            //    Player.GetComponent<SpriteRenderer>().flipX = true;
            //    Balls.GetComponent<SpriteRenderer>().flipX = true;
            //    Eyes.GetComponent<SpriteRenderer>().flipX = true;
            //    Eyes.transform.position = new Vector2(Player.transform.position.x - 0.16f, Player.transform.position.y + 0.43f);
            //    //Rotates origin of attack
            //    BigAttack.transform.rotation = Quaternion.Euler(0, -90, 90);


            //}
            //if (Input.GetKey(KeyCode.D))
            //{
            //    PlayerRigid.velocity = new Vector2((MoveSpeed) * myTime, PlayerRigid.velocity.y);
            //    Animated.SetFloat("Moving", 1);
            //    Player.GetComponent<SpriteRenderer>().flipX = false;
            //    Balls.GetComponent<SpriteRenderer>().flipX = false;
            //    Eyes.transform.position = new Vector2(Player.transform.position.x + 0.16f, Player.transform.position.y + 0.43f);
            //    BigAttack.transform.rotation = Quaternion.Euler(0, 90, 90);


            //}
        }
    }
    


}
