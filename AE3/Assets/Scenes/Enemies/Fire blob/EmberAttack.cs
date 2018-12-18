using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmberAttack : MonoBehaviour {

    public Rigidbody2D EmberRigid;
    private GameObject Fireblob;
    public float Speed;
    private float _Speed;
    private bool AssignedParent;
	// Use this for initialization
	void Start () {
        Fireblob = GameObject.Find("Fireblob");
        AssignedParent = true;
	}
	
	// Update is called once per frame
	void Update () {
        _Speed = Speed * Time.deltaTime;

        if (AssignedParent)
        {
            gameObject.transform.SetParent(Fireblob.transform);

            if (GetComponentInParent<FireBlobMovement>().EmberSpawn() == true)
            {
                EmberRigid.velocity = new Vector2(_Speed, 0);
            }
            else if (GetComponentInParent<FireBlobMovement>().EmberSpawn() == false)
            {
                EmberRigid.velocity = new Vector2(-_Speed, 0);
            }
            AssignedParent = false;

        }
	}
    private void OnTriggerEnter2D(Collider2D Target)
    {
        if (Target.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
