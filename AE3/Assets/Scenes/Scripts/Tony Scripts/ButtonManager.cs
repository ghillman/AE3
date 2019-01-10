using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    private float RayCastDown;
    public bool LeftButton;
    public bool RightButton;
    private Animator Animated;
    private bool MovingLeft = false;
    private bool MovingRight = false;
    private bool stopleft;
    private bool stopright;
    public Rigidbody2D PlayerRigid;
    public float MoveSpeed;
    void Moveleft()
    {
        if (LeftButton)
        {
            if (MovingLeft)
            {
                //move the player
                if (PlayerRigid.gameObject.GetComponent<PlayerMovement>().Hit == false)
                {
                    PlayerRigid.velocity = new Vector2(-MoveSpeed * Time.deltaTime, PlayerRigid.velocity.y);
                    Debug.Log("Hello");
                    Debug.Log(MoveSpeed);
                    stopleft = true;
                }
            }
            else if(stopleft && !MovingLeft)
            {
                PlayerRigid.velocity = new Vector2(0, PlayerRigid.velocity.y);
                Debug.Log("good bye");
                stopleft = false;
            }
        }
    }
    void MoveRight()
    {
        if (RightButton)
        {
            if (MovingRight)
            {
                if (PlayerRigid.gameObject.GetComponent<PlayerMovement>().Hit == false)
                {
                    //move the player
                    PlayerRigid.velocity = new Vector2(MoveSpeed * Time.deltaTime, PlayerRigid.velocity.y);
                    Debug.Log(MoveSpeed);
                    stopright = true;
                }
            }
            else if (stopright && !MovingRight)
            {
                PlayerRigid.velocity = new Vector2(0, PlayerRigid.velocity.y);
                stopright = false;
            }
        }
    }

    private void Update()
    {

        Moveleft();
        MoveRight();
        
    }
    public void Jump(Rigidbody2D Player)
    {
        //draw raycast
       
        //if raycast hits ground allow player to jump
        if (Physics2D.Linecast(Player.transform.position, transform.position + new Vector3(0, RayCastDown, 0), 1 << LayerMask.NameToLayer("Ground")))
        {
            Player.velocity = new Vector2(Player.velocity.x, FindObjectOfType<PlayerMovement>().JumpHeight * Time.deltaTime);
            //play animations
            FindObjectOfType<PlayerMovement>().JumpParticals.SetActive(false);
            FindObjectOfType<PlayerMovement>().JumpParticals.SetActive(true);
        }
        
    }

    public void Left(PlayerMovement Player)
    {
        if (!MovingLeft)
        {
            //play animation
            Player.Animated.SetFloat("Moving", 1);
            //flip sprites
            Player.GetComponent<SpriteRenderer>().flipX = true;
            Player.Balls.GetComponent<SpriteRenderer>().flipX = true;
            Player.Eyes.GetComponent<SpriteRenderer>().flipX = true;
            //move Eyes
            Player.Eyes.transform.position = new Vector2(Player.transform.position.x - 0.16f, Player.transform.position.y + 0.43f);
            //Rotates origins of attacks
            Player.BigAttack.transform.rotation = Quaternion.Euler(0, -90, 90);
            FindObjectOfType<LightningAttack>().transform.localScale = new Vector2(-2, 2);

            MovingLeft = true;
        }
        else
        {
           
            MovingLeft = false;
        }

    }

    public void Right(PlayerMovement Player)
    {
        if (!MovingRight)
        {
            //play animation
            Player.Animated.SetFloat("Moving", 1);
            //flip the sprites
            Player.GetComponent<SpriteRenderer>().flipX = false;
            Player.Balls.GetComponent<SpriteRenderer>().flipX = false;
            Player.Eyes.GetComponent<SpriteRenderer>().flipX = false;
            //move the eyes
            Player.Eyes.transform.position = new Vector2(Player.transform.position.x + 0.16f, Player.transform.position.y + 0.43f);
            //Rotates origins of attacks
            Player.BigAttack.transform.rotation = Quaternion.Euler(0, 90, 90);
            FindObjectOfType<LightningAttack>().transform.localScale = new Vector2(2, 2);

            MovingRight = true;
        }
        else
        {
            
            MovingRight = false;
        }

    }

    public void Lightning()
    {
        if (FindObjectOfType<LightningAttack>().Strike == false)
        {
            FindObjectOfType<LightningAttack>().Strike = true;
            FindObjectOfType<LightningAttack>().Particle.SetActive(true);
            FindObjectOfType<AudioManager>().Play("Lightning");
        }

        if (FindObjectOfType<LightningAttack>().Strike)
        {
            FindObjectOfType<LightningAttack>().Rechargetime += Time.deltaTime;
            if (FindObjectOfType<LightningAttack>().Rechargetime >= 1)
            {
                FindObjectOfType<LightningAttack>().GetComponent<SpriteRenderer>().enabled = true;
                FindObjectOfType<LightningAttack>().GetComponent<BoxCollider2D>().enabled = true;

                FindObjectOfType<LightningAttack>().GetComponent<Animator>().SetBool("Lightning", true);

                FindObjectOfType<LightningAttack>().LightningTime += Time.deltaTime;
                if (FindObjectOfType<LightningAttack>().LightningTime >= 0.5f)
                {
                    GetComponent<SpriteRenderer>().enabled = false;
                    GetComponent<BoxCollider2D>().enabled = false;

                    GetComponent<Animator>().SetBool("Lightning", false);
                    FindObjectOfType<LightningAttack>().Particle.SetActive(false);
                    FindObjectOfType<LightningAttack>().LightningTime = 0;
                    FindObjectOfType<LightningAttack>().Rechargetime = 0;
                }
            }
        }
    }

    public void BigAttack(PlayerMovement Player)
    {
        //displays attack and then disperses it
        if (Player.BigAttackBool == false)
        {
            //set bool to true, twice for some reason
            Player.BigAttackBool = true;
            Player.BigAttack.SetActive(true);
            //make a copy transform of the collidier on the child of big attack
            Transform BigAttackCollider = Player.BigAttack.transform.GetChild(0).transform;
            //make attack size 0
            Player.BigAttackSize = 0;
            //give copy a collider
            BigAttackCollider.localScale = new Vector2(Player.BigAttackSize, Player.BigAttackSize);
        }
    }
}
