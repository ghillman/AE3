using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
    public GameObject Follow;
    public float CameraYAdjustment;
    public float Speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Follow)
        {
            Vector3 Pos = transform.position;
            Pos.x = Mathf.Lerp(transform.position.x, Follow.transform.position.x, Speed * Time.deltaTime);
            Pos.y = Mathf.Lerp(transform.position.y - CameraYAdjustment, Follow.transform.position.y, Speed * Time.deltaTime);

            Pos.y += CameraYAdjustment;
            transform.position = Pos;
        }
                

	}
}
