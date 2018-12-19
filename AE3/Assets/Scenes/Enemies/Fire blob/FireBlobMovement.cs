using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBlobMovement : MonoBehaviour {

    public Rigidbody2D BlobRigid;
    public GameObject Ember;
    public GameObject Flames;
    public float Speed;
    private float _Speed;
    public bool LeftRight;
    public float AgroDistance;
    public float JumpLimit;
    public float Spawntimer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<AttackScript>().Alive == true)
        {
            Flames.SetActive(true);
            _Speed = Speed * Time.deltaTime;
            if (Spawntimer < 2)
            {
                Spawntimer += Time.deltaTime;
            }
            if (LeftRight)
            {

                BlobRigid.velocity = new Vector2(_Speed, BlobRigid.velocity.y);
                Debug.DrawRay(transform.position + new Vector3(0, 0, 0), new Vector3(AgroDistance, 0, 0), Color.red);
                RaycastHit2D Target =
                Physics2D.Raycast(transform.position, new Vector3(AgroDistance, 0, 0), AgroDistance, 1 << LayerMask.NameToLayer("Player"));
                if (Target.collider != null)
                {
                    if (Target.collider.gameObject.CompareTag("Player"))
                    {
                        EmberSpawn();
                    }
                }
            }
            else
            {
                BlobRigid.velocity = new Vector2(-_Speed, BlobRigid.velocity.y);
                Debug.DrawRay(transform.position + new Vector3(0, 0, 0), new Vector3(-AgroDistance, 0, 0), Color.red);
                RaycastHit2D Target =
                Physics2D.Raycast(transform.position, new Vector3(-AgroDistance, 0, 0), AgroDistance, 1 << LayerMask.NameToLayer("Player"));
                if (Target.collider != null)
                {
                    if (Target.collider.gameObject.CompareTag("Player"))
                    {
                        EmberSpawn();
                        
                    }
                }
            }


            Debug.DrawLine(transform.position, transform.position + new Vector3(0, -JumpLimit, 0), Color.blue);
        }
        else
        {
            gameObject.tag = ("Dead");
            Flames.SetActive(false);

        }
      


    }
    public bool EmberSpawn()
    {
        if (Spawntimer >= 2)
        {
            Spawntimer = 0;
            Instantiate(Ember, transform.position, Quaternion.identity);
            return LeftRight;
        }
        return LeftRight;
    }
    private void OnTriggerEnter2D(Collider2D Target)
    {
        if(Target.gameObject.CompareTag("Node"))
        {
            if(LeftRight)
            {
                LeftRight = false;
            }
            else if(!LeftRight) 
            {
                LeftRight = true;
            }
        }
    }
}
