using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doom : MonoBehaviour {
    public GameObject _Doom;
    private Rigidbody2D DoomRigid;
    public float Speed;
    public bool direction;
    public float cooldown;
    public bool active;
	// Use this for initialization
	void Start () {

        cooldown = 0;

	}
	
	// Update is called once per frame
	void Update () {
		if (cooldown >= 0)
        {
            cooldown -= Time.deltaTime;
        }
        if(active)
        {
            if (cooldown <= 0)
            {
                _Doom.GetComponent<CircleCollider2D>().enabled = true;
                cooldown = 20;
                _Doom.AddComponent<Rigidbody2D>();
                DoomRigid = _Doom.GetComponent<Rigidbody2D>();
                DoomRigid.gravityScale = 0;
                if (direction)
                {
                    DoomRigid.velocity = new Vector2(Speed, 0);
                }
                else
                {
                    DoomRigid.velocity = new Vector2(-Speed, 0);
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D Target)
    {
        if(Target.gameObject.CompareTag ("Enemy"))
        {
            DoomRigid.velocity = new Vector2(0, 0);
            _Doom.transform.localPosition = new Vector3(0, 0, 0);
            _Doom.GetComponent<CircleCollider2D>().enabled = false;
            Destroy(_Doom.GetComponent<Rigidbody2D>());
        }
        if (Target.gameObject.CompareTag("Ground"))
        {
            DoomRigid.velocity = new Vector2(0, 0);
            _Doom.transform.localPosition = new Vector3(0, 0, 0);
            _Doom.GetComponent<CircleCollider2D>().enabled = false;
            Destroy(_Doom.GetComponent<Rigidbody2D>());
        }
    }
}
