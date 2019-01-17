using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Swiping : MonoBehaviour {
    private Vector2 StartPos;
    private Vector2 EndPos;
    public float MaxTime;
    public float StartTime;
    public float EndTime;
    private float SwipeDistance;
    private float SwipeTime;
    public float MinSwipe;
    private float BigAttackSize;

    public float BigAttackCharge;
    public float BigAttackCooldown;
    public float BigAttackTime;

    public SpawnImp Spawner;
    public Doom DoomActive;
    public GameObject BigAttack;
    public bool BigAttackBool;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                StartPos = touch.position;
              //  Debug.Log("touch Started");
                StartTime = Time.time;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                EndPos = touch.position;
                EndTime = Time.time;
               // Debug.Log("touch ended");
                SwipeDistance = (EndPos - StartPos).magnitude;
                SwipeTime = EndTime - StartTime;
                if (SwipeTime < MaxTime && SwipeDistance > MinSwipe)
                {
                    swipe();
                }
            }

            
        }
        if (BigAttackBool == true)
        {
            BigAttackFunck();
        }
    }
    void BigAttackFunck()
    {
        //Scales up the collider of the Big Attack
        Transform BigAttackCollider = BigAttack.transform.GetChild(0).transform;
        BigAttackSize += 0.1f;
        BigAttackCollider.localScale = new Vector2(BigAttackSize, BigAttackSize);

        BigAttackCharge += Time.deltaTime;
        if (BigAttackCharge >= BigAttackCooldown)
        {
            BigAttackBool = false;

            BigAttackCharge = 0;
        }
        if (BigAttackCharge >= BigAttackTime)
        {
            BigAttack.SetActive(false);
        }
    }
    void swipe()
    {
        Vector2 distance = EndPos - StartPos;
        if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
        {
            // Debug.Log("Sideways Swipe");
            if (PlayerState.Level > 2)
            {
                if (StartPos.y > EndPos.y)
                {
                    Debug.Log("Swipe Left");
                    DoomActive.direction = false;
                    DoomActive.active = true;

                }
                if (StartPos.y < EndPos.y)
                {
                    Debug.Log("Swipe Right");
                    DoomActive.direction = true;
                    DoomActive.active = true;
                }
            }
        }
        else if (Mathf.Abs(distance.y) > Mathf.Abs(distance.x))
        {
          //  Debug.Log("updown Swipe");
            if(StartPos.x > EndPos.x)
            {
                Debug.Log("Swipe Up");
                if (PlayerState.Level > 0)
                {
                    Spawner.active = true;
                }
            }
            if (StartPos.x < EndPos.x)
            {
                Debug.Log("Swipe Down");
                if (PlayerState.Level > 1)
                {
                    if (BigAttackBool == false)
                    {
                        BigAttackBool = true;
                        BigAttack.SetActive(true);
                        Transform BigAttackCollider = BigAttack.transform.GetChild(0).transform;
                        BigAttackSize = 0;
                        BigAttackCollider.localScale = new Vector2(BigAttackSize, BigAttackSize);
                    }
                } 
                }

            }

        }
    }
