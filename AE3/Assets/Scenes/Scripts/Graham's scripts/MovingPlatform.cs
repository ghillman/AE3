using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public bool first;
    public bool second;
    public bool third;
    public bool Last;

    public bool firstDirection;

    
    public float ThirdPlatformCurvature;
    private float _ThirdPlatformCurvature;

    private float Timer;
    public float moveTime;
    public float moveSpeed;
   

    [SerializeField]
    Transform rotationPoint;
    [SerializeField]
    public float rotationRadius;
    float posX, posY, angle = 0f;

    // Use this for initialization
    void Start () {
        Timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Timer += Time.deltaTime;
		if(first)
        {
            if (firstDirection)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + (moveSpeed * Time.deltaTime));
                if (Timer >= moveTime)
                {
                    firstDirection = false;
                    Timer = 0;
                }
            }
            else if (!firstDirection)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - (moveSpeed * Time.deltaTime));
                if (Timer >= moveTime)
                {
                    firstDirection = true;
                    Timer = 0;
                }
            }
        }
        else if(second)
        {

            if (firstDirection)
            {
                transform.position = new Vector2(transform.position.x + (moveSpeed * Time.deltaTime), transform.position.y);
                if (Timer >= moveTime)
                {
                    firstDirection = false;
                    Timer = 0;
                }
            }
            else if (!firstDirection)
            {
                transform.position = new Vector2(transform.position.x - (moveSpeed * Time.deltaTime), transform.position.y);
                if (Timer >= moveTime)
                {
                    firstDirection = true;
                    Timer = 0;
                }
            }
        }
        else if (third)
        {
            if (firstDirection)
            {
                
            }
            else if (!firstDirection)
            {
               
            }
        }
        else if (Last)
        {
            if (firstDirection)
            {
                posX = rotationPoint.position.x + Mathf.Cos(angle) * rotationRadius;
                posY = rotationPoint.position.y + Mathf.Sin(angle) * rotationRadius;
                transform.position = new Vector2(posX, posY);
                angle = angle + Time.deltaTime * moveSpeed;

                if (angle >= 360f)
                {
                    angle = 0f;
                }
            }
            else
            {
                posX = rotationPoint.position.x + Mathf.Cos(angle) * -rotationRadius;
                posY = rotationPoint.position.y + Mathf.Sin(angle) * -rotationRadius;
                transform.position = new Vector2(posX, posY);
                angle = angle + Time.deltaTime * moveSpeed;

                if (angle >= 360f)
                {
                    angle = 0f;
                }
            }

        }
	}
}
