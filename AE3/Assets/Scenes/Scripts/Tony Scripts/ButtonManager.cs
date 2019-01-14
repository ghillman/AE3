using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    //----------------------------------------------------------------MOVEMENT-----------------------------------------------------------------------------------//

    //JUMPING
    private float RayCastDown = -0.8f;
    public void Jump(Rigidbody2D Player)
    {
        //Highlight button
        GetComponent<Image>().color = new Color(255, 255, 255, 255);
        //draw raycast
        Debug.DrawLine(Player.transform.position, Player.transform.position + new Vector3(0, RayCastDown, 0), Color.blue);
        //if raycast hits ground allow player to jump
        if (Physics2D.Linecast(Player.transform.position, Player.transform.position + new Vector3(0, RayCastDown, 0), 1 << LayerMask.NameToLayer("Ground")))
        {

            Player.velocity = new Vector2(Player.velocity.x, FindObjectOfType<PlayerMovement>().JumpHeight * Time.deltaTime);
            //play animations
            FindObjectOfType<PlayerMovement>().JumpParticals.SetActive(false);
            FindObjectOfType<PlayerMovement>().JumpParticals.SetActive(true);
        }

    }


    //LEFT
    private bool MovingLeft = false;
    //When button is held down
    public void Left(PlayerMovement Player)
    {
        if (!MovingLeft)
        {
            //highlight button
            GetComponent<Image>().color = new Color(255, 255, 255, 255);
            //play animation
            Player.Animated.SetFloat("Moving", 1);
            //flip sprites
            Player.GetComponent<SpriteRenderer>().flipX = true;
            Player.Balls.GetComponent<SpriteRenderer>().flipX = true;
            Player.Eyes.GetComponent<SpriteRenderer>().flipX = true;
            //re-locate Eyes
            Player.Eyes.transform.position = new Vector2(Player.transform.position.x - 0.16f, Player.transform.position.y + 0.43f);
            //Rotates origins of attacks
            Player.BigAttack.transform.rotation = Quaternion.Euler(0, -90, 90);
            FindObjectOfType<LightningAttack>().transform.localScale = new Vector2(-2, 2);
            MovingLeft = true;
        }
        //move player
        Player.PlayerRigid.velocity = new Vector2((Player.MoveSpeed * Time.deltaTime) * -1, Player.PlayerRigid.velocity.y);
    }

    //When left button is released
    public void LeftUp(PlayerMovement Player)
    {
        //take off highlight
        GetComponent<Image>().color = new Color(1, 1, 1, 0.66f);
        //stop player
        Player.PlayerRigid.velocity = new Vector2(0, Player.PlayerRigid.velocity.y);
        //stop animation
        Player.Animated.SetFloat("Moving", 0);
        MovingLeft = false;
    }

    //RIGHT
    private bool MovingRight = false;
    public void Right(PlayerMovement Player)
    {
        if (!MovingRight)
        {
            GetComponent<Image>().color = new Color(255, 255, 255, 255);
            //play animation
            Player.Animated.SetFloat("Moving", 1);
            //flip the sprites
            Player.GetComponent<SpriteRenderer>().flipX = false;
            Player.Balls.GetComponent<SpriteRenderer>().flipX = false;
            Player.Eyes.GetComponent<SpriteRenderer>().flipX = false;
            //re-locate eyes
            Player.Eyes.transform.position = new Vector2(Player.transform.position.x + 0.16f, Player.transform.position.y + 0.43f);
            //Rotates origins of attacks
            Player.BigAttack.transform.rotation = Quaternion.Euler(0, 90, 90);
            FindObjectOfType<LightningAttack>().transform.localScale = new Vector2(2, 2);
            MovingRight = true;
        }
        Player.PlayerRigid.velocity = new Vector2((Player.MoveSpeed * Time.deltaTime) * 1, Player.PlayerRigid.velocity.y);

    }

    //When Right button is released
    public void Rightup(PlayerMovement Player)
    {
        //take off highlight
        GetComponent<Image>().color = new Color(1, 1, 1, 0.66f);
        //stop player
        Player.PlayerRigid.velocity = new Vector2(0, Player.PlayerRigid.velocity.y);
        //stop animation
        Player.Animated.SetFloat("Moving", 0);
        MovingRight = false;
    }
    //-----------------------------------------------------------ATTACKS------------------------------------------------------------------------------//

    public void Lightning()
    {
        //Highlight button
        GetComponent<Image>().color = new Color(255, 255, 255, 255);
        if (FindObjectOfType<LightningAttack>().Strike == false)
        {
            FindObjectOfType<LightningAttack>().Strike = true;
            //display particle effect
            FindObjectOfType<LightningAttack>().Particle.SetActive(true);
            //sound effect
            FindObjectOfType<AudioManager>().Play("Lightning");
            //get the recharge time     
            FindObjectOfType<LightningAttack>().Rechargetime += Time.deltaTime;
            //recharge time greater than 1
            if (FindObjectOfType<LightningAttack>().Rechargetime >= 1)
            {
                //display lightning, give it a hit box, and play its' animation
                FindObjectOfType<LightningAttack>().GetComponent<SpriteRenderer>().enabled = true;
                FindObjectOfType<LightningAttack>().GetComponent<BoxCollider2D>().enabled = true;
                FindObjectOfType<LightningAttack>().GetComponent<Animator>().SetBool("Lightning", true);

                //At the end of the attack, disable everything to do with the lightning: Sprites, hitbox, etc
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


    //WE WANT THIS TO BE A SWIPE NOT A BUTTON, IT DOESN'T BELONG HERE
    //public void BigAttack(PlayerMovement Player)
    //{
    //    //displays attack and then disperses it
    //    if (Player.BigAttackBool == false)
    //    {
    //        //set bool to true, twice for some reason
    //        Player.BigAttackBool = true;
    //        Player.BigAttack.SetActive(true);
    //        //make a copy transform of the collidier on the child of big attack
    //        Transform BigAttackCollider = Player.BigAttack.transform.GetChild(0).transform;
    //        //make attack size 0
    //        Player.BigAttackSize = 0;
    //        //give copy a collider
    //        BigAttackCollider.localScale = new Vector2(Player.BigAttackSize, Player.BigAttackSize);
    //    }
    //}

    //-------------------------------------------------------------CHOICES----------------------------------//

    //player chooses yes
    public void PicksYes()
    {
        FindObjectOfType<CrazyTalk>().Responded = true;
        //get rid of buttons
        FindObjectOfType<CrazyTalk>().Yes.gameObject.SetActive(false);
        FindObjectOfType<CrazyTalk>().No.gameObject.SetActive(false);
        //Store that player selected yes
        FindObjectOfType<CrazyTalk>().Answer = true;
    }

    //player chooses No
    public void PicksNo()
    {
        FindObjectOfType<CrazyTalk>().Responded = true;
        //get rid of buttons
        FindObjectOfType<CrazyTalk>().Yes.gameObject.SetActive(false);
        FindObjectOfType<CrazyTalk>().No.gameObject.SetActive(false);
        //Store that player selected No
        FindObjectOfType<CrazyTalk>().Answer = false;
    }

}
