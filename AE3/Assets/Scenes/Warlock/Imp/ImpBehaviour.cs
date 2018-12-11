using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpBehaviour : MonoBehaviour {

    public Rigidbody2D ImpRigid;
    public float MoveSpeed;
    private float _MoveSpeed;
    public GameObject Warlock;
    public float FollowDistance;
    private bool Contact;
    public float RayCastDown;
    public float RayCastSide;
    private float _ImpJumpSpeed;
    public float ImpJumpSpeed;
    public float AgroDistance;
    public GameObject Firebolt;
    public float BoltSpeed;
    private float _BoltSpeed;
	// Use this for initialization
	void Start () {

        transform.position = Warlock.transform.position;
        Contact = false;
	}
	
	// Update is called once per frame
	void Update () {

        Debug.DrawLine(transform.position, transform.position + new Vector3(0, RayCastDown, 0), Color.blue);

        Debug.DrawLine(transform.position, transform.position + new Vector3(RayCastSide, 0, 0), Color.red);

        Debug.DrawLine(transform.position, transform.position + new Vector3(-RayCastSide, 0, 0), Color.yellow);

        _MoveSpeed = MoveSpeed * Time.deltaTime;
        _ImpJumpSpeed = ImpJumpSpeed * Time.deltaTime;
        _BoltSpeed = BoltSpeed * Time.deltaTime;
        if (Contact == false)
            {
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

        RaycastHit2D Target =
        Physics2D.Raycast(transform.position - new Vector3(AgroDistance, 0, 0), transform.position + new Vector3(AgroDistance, 0, 0));

        Debug.DrawLine(transform.position - new Vector3(AgroDistance, 0, 0), transform.position + new Vector3(AgroDistance, 0,0), Color.blue);


        if (Target.collider != null)
        {
            if (Target.collider.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("Hello0");
                Firebolt.AddComponent<Rigidbody2D>();
                if (Target.collider.gameObject.transform.position.x > transform.position.x)
                {
                    Debug.Log("Hello1");
                    Firebolt.GetComponent<Rigidbody2D>().velocity = new Vector2(_BoltSpeed, Firebolt.GetComponent<Rigidbody2D>().velocity.y);
                }
                else
                {
                    Debug.Log("Hello2");
                    Firebolt.GetComponent<Rigidbody2D>().velocity = new Vector2(-_BoltSpeed, Firebolt.GetComponent<Rigidbody2D>().velocity.y);
                }
            }
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
