using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour {
    public Rigidbody2D GoblinRigid;
    private bool leftandright;
    public float GoblinMoveSpeed;
    public float GoblinJump;
    private bool Alive;
    public float RayCastDown;
    public float RayCastSide;
    // Use this for initialization
    void Start () {
        leftandright = true;
        
    }

    // Update is called once per frame
    void Update () {
        float GoblinSpeed;
        float GoblinJumpSpeed;
        float SideCast = RayCastSide / 2;
        Debug.DrawLine(transform.position, transform.position + new Vector3(0, RayCastDown, 0), Color.blue);

        Debug.DrawLine(transform.position,transform.position + new Vector3(RayCastSide, 0, 0), Color.red);

        Debug.DrawLine(transform.position, transform.position + new Vector3(-RayCastSide, 0, 0), Color.yellow);

        //Alive = GetComponent<AttackScript>().Alive;
        GoblinSpeed = GoblinMoveSpeed * Time.deltaTime;
        GoblinJumpSpeed = GoblinJump * Time.deltaTime;
        if (GetComponent<AttackScript>().Alive == true)
        {
            gameObject.tag = "Enemy";
            if (leftandright)
            {
                GoblinRigid.velocity = new Vector2(GoblinSpeed, GoblinRigid.velocity.y);
                
            }
            else
            {
                GoblinRigid.velocity = new Vector2(-GoblinSpeed, GoblinRigid.velocity.y);             
            }
            if (Physics2D.Linecast(transform.position, transform.position + new Vector3(0, RayCastDown, 0), 1 << LayerMask.NameToLayer("Ground")))
            {
               
              if(Physics2D.Linecast(transform.position, transform.position + new Vector3(RayCastSide, 0, 0), 1 << LayerMask.NameToLayer("Ground")))
              {
                    GoblinRigid.velocity = new Vector2(GoblinRigid.velocity.x, GoblinJumpSpeed);
                }
              else if (Physics2D.Linecast(transform.position, transform.position + new Vector3(-RayCastSide, 0, 0), 1 << LayerMask.NameToLayer("Ground")))
              {
                    GoblinRigid.velocity = new Vector2(GoblinRigid.velocity.x, GoblinJumpSpeed);
                }
            }
                
        }
        else
        {
            gameObject.tag = "Dead";
        }
	}
    void OnTriggerEnter2D(Collider2D Target)
    {
        
        if(Target.gameObject.CompareTag("Node"))
        {
           
            if(leftandright)
            {
                
                leftandright = false;
            }
            else
            {
                
                leftandright = true;
            }
        }
    }
}

