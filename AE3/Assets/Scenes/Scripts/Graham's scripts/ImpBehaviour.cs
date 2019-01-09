using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpBehaviour : MonoBehaviour {

    public Rigidbody2D ImpRigid;
    private Rigidbody2D fireboltRigid;
    public float MoveSpeed;
    private float _MoveSpeed;
    public GameObject Warlock;
    public float FollowDistance;
    
    public float RayCastDown;
    public float RayCastSide;
    private float _ImpJumpSpeed;
    public float ImpJumpSpeed;
    public float AgroDistance;
    public GameObject Firebolt;
    public float BoltSpeed;
    private float _BoltSpeed;
    private float castTimer;
	// Use this for initialization
	void Start () {


        Warlock = GameObject.FindGameObjectWithTag("Player");
        castTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {

        Debug.DrawLine(transform.position, transform.position + new Vector3(0, RayCastDown, 0), Color.blue);

        Debug.DrawLine(transform.position, transform.position + new Vector3(RayCastSide, 0, 0), Color.red);

        Debug.DrawLine(transform.position, transform.position + new Vector3(-RayCastSide, 0, 0), Color.yellow);

        _MoveSpeed = MoveSpeed * Time.deltaTime;
        _ImpJumpSpeed = ImpJumpSpeed * Time.deltaTime;
        _BoltSpeed = BoltSpeed * Time.deltaTime;
        
            
            if (PlayerLocation() > FollowDistance)
            {
                MoveLeft();
            }
            else if (PlayerLocation() < -FollowDistance)
            {
                MoveRight();
            }
            else
            {
                ImpRigid.velocity = new Vector2(0, ImpRigid.velocity.y);
            }
        
        if (Physics2D.Linecast(transform.position, transform.position + new Vector3(0, RayCastDown, 0), 1 << LayerMask.NameToLayer("Ground")))
        {

            if (Physics2D.Linecast(transform.position, transform.position + new Vector3(RayCastSide, 0, 0), 1 << LayerMask.NameToLayer("Ground")))
            {
                ImpRigid.velocity = new Vector2(ImpRigid.velocity.x, _ImpJumpSpeed);
            }
            else if (Physics2D.Linecast(transform.position, transform.position + new Vector3(-RayCastSide, 0, 0), 1 << LayerMask.NameToLayer("Ground")))
            {
                ImpRigid.velocity = new Vector2(ImpRigid.velocity.x, _ImpJumpSpeed);
            }
        }

        
    }
    private void FixedUpdate()
    {
        RaycastHit2D Target =
        Physics2D.Raycast(transform.position, new Vector3(AgroDistance, 0, 0), AgroDistance, 1 << LayerMask.NameToLayer("Enemy"));

        RaycastHit2D Target2 =
        Physics2D.Raycast(transform.position, new Vector3(-AgroDistance, 0, 0), AgroDistance, 1 << LayerMask.NameToLayer("Enemy"));

        Debug.DrawRay(transform.position + new Vector3(0, 0, 0), new Vector3(AgroDistance, 0, 0), Color.cyan);
        Debug.DrawRay(transform.position + new Vector3(0, 0, 0), new Vector3(-AgroDistance, 0, 0), Color.white);



        if (Target.collider != null)
        {

            if (Target.collider.gameObject.CompareTag("Enemy"))
            {
                
               // Debug.Log("Hello0");                            
                castTimer += Time.deltaTime;
                if (castTimer >= 2)
                {
                    if (Target.collider.gameObject.transform.position.x > transform.position.x)
                    {
                       // Debug.Log("Hello1");
                        Firebolt.AddComponent<Rigidbody2D>();
                        fireboltRigid = Firebolt.GetComponent<Rigidbody2D>();
                        fireboltRigid.gravityScale = 0;
                        Firebolt.GetComponent<Rigidbody2D>().velocity = new Vector2(_BoltSpeed, Firebolt.GetComponent<Rigidbody2D>().velocity.y);
                    }
                    else
                    {
                        //Debug.Log("Hello2");
                        Firebolt.AddComponent<Rigidbody2D>();
                        fireboltRigid = Firebolt.GetComponent<Rigidbody2D>();
                        fireboltRigid.gravityScale = 0;
                        Firebolt.GetComponent<Rigidbody2D>().velocity = new Vector2(-_BoltSpeed, Firebolt.GetComponent<Rigidbody2D>().velocity.y);
                    }
                    

                    castTimer = 0f;
                }
                
            }
            

        }
        else if (Target2.collider != null)
        {
            if (Target2.collider.gameObject.CompareTag("Enemy"))
            {

                // Debug.Log("Hello0");                            
                castTimer += Time.deltaTime;
                if (castTimer >= 2)
                {
                    if (Target2.collider.gameObject.transform.position.x > transform.position.x)
                    {
                        // Debug.Log("Hello1");
                        Firebolt.AddComponent<Rigidbody2D>();
                        fireboltRigid = Firebolt.GetComponent<Rigidbody2D>();
                        fireboltRigid.gravityScale = 0;
                        Firebolt.GetComponent<Rigidbody2D>().velocity = new Vector2(_BoltSpeed, Firebolt.GetComponent<Rigidbody2D>().velocity.y);
                    }
                    else
                    {
                        //Debug.Log("Hello2");
                        Firebolt.AddComponent<Rigidbody2D>();
                        fireboltRigid = Firebolt.GetComponent<Rigidbody2D>();
                        fireboltRigid.gravityScale = 0;
                        Firebolt.GetComponent<Rigidbody2D>().velocity = new Vector2(-_BoltSpeed, Firebolt.GetComponent<Rigidbody2D>().velocity.y);
                    }


                    castTimer = 0f;
                }

            }
        }
        else
        {
            
            castTimer = 0;
        }


    }
    private float PlayerLocation()
    {
        float Difference;

        Difference =
        Warlock.transform.position.x - gameObject.transform.position.x;

        return Difference;
    }
    private void MoveLeft()
    {
        ImpRigid.velocity = new Vector2 (_MoveSpeed, ImpRigid.velocity.y);
    }
    private void MoveRight()
    {
        ImpRigid.velocity = new Vector2(-_MoveSpeed, ImpRigid.velocity.y);
    }
}
