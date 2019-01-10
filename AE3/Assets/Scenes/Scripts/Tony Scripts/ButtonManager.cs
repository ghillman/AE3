using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    private float RayCastDown;

    private Animator Animated;


    public void Jump(Rigidbody2D Player)
    {
        //draw raycast
        Debug.DrawLine(Player.transform.position, Player.transform.position + new Vector3(0, RayCastDown, 0), Color.blue);
        //if raycast hits ground allow player to jump
        if (Physics2D.Linecast(Player.transform.position, transform.position + new Vector3(0, RayCastDown, 0), 1 << LayerMask.NameToLayer("Ground")))
        {
            Player.velocity = new Vector2(0, FindObjectOfType<PlayerMovement>().JumpHeight * Time.deltaTime);
            //play animations
            FindObjectOfType<PlayerMovement>().JumpParticals.SetActive(false);
            FindObjectOfType<PlayerMovement>().JumpParticals.SetActive(true);
        }
    }

    private bool Moving = false;

    public void Left(PlayerMovement Player)
    {
        if (!Moving)
        {
            Player.PlayerRigid.velocity = new Vector2(0, Player.PlayerRigid.velocity.y);
            //move the player
            Player.PlayerRigid.velocity = new Vector2((Player.MoveSpeed * -1) * Player.myTime, Player.PlayerRigid.velocity.y);
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
            Moving = true;
        }
        else
        {
            Player.PlayerRigid.velocity = new Vector2(0, Player.PlayerRigid.velocity.y);
            Moving = false;
        }

    }

    public void Right(PlayerMovement Player)
    {
        if (!Moving)
        {
            //move the player
            Player.PlayerRigid.velocity = new Vector2((Player.MoveSpeed * 1) * Player.myTime, Player.PlayerRigid.velocity.y);
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
            Moving = true;
        }
        else
        {
            Player.PlayerRigid.velocity = new Vector2(0, Player.PlayerRigid.velocity.y);
            Moving = false;
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
