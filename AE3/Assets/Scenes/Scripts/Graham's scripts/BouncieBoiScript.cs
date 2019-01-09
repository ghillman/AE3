using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncieBoiScript : MonoBehaviour {
    private float BounceStrangth;
    private Rigidbody2D ColRigid;
    public ParticleSystem Particale;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ColRigid = collision.gameObject.GetComponent<Rigidbody2D>();
        BounceStrangth = ((-ColRigid.velocity.y/10) -ColRigid.velocity.y) + 6;
        Debug.Log(BounceStrangth);
        Particale.Play();
        ColRigid.velocity = new Vector2(ColRigid.velocity.x, BounceStrangth);
    }
}
