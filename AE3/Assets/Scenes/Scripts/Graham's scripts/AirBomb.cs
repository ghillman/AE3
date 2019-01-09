using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBomb : MonoBehaviour {

    public float Speed;
    private float _Speed;
    
    private int MoveDirection;
    public Rigidbody2D BombRigid;
    private bool Shot;
    private float ActiveTime;
    	// Use this for initialization
	void Start () {
        
        MoveDirection = Random.Range(0, 3);
        ActiveTime = 0;
        Shot = true;
      
    }
	
	// Update is called once per frame
	void Update () {
        _Speed = Speed * Time.deltaTime;
        if (Shot == true)
        {
            if (MoveDirection == 1)
            {
                BombRigid.velocity = new Vector2(_Speed, _Speed);
            }
            if (MoveDirection == 2)
            {
                BombRigid.velocity = new Vector2(-_Speed, _Speed);
            }
            if(MoveDirection == 3)
            {
                BombRigid.velocity = new Vector2(BombRigid.velocity.x, _Speed);
            }
            Shot = false;
        }
        if (ActiveTime >= 7)
        {
            Destroy(gameObject);
        }


    }
    private void OnTriggerEnter2D(Collider2D Target)
    {
        if(Target.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        if (Target.gameObject.CompareTag("Imp"))
        {
            Destroy(gameObject);
        }
    }
}
