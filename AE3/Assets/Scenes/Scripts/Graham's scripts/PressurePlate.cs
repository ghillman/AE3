using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {

    public GameObject turret;
    public float ArrowsPerSecond;
    private float _Arrows;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D Target)
    {
        if(Target.gameObject.CompareTag("Player"))
        {
            turret.GetComponent<ArrowTrapBoi>().Fire();
        }
    }
    private void OnCollisionStay2D(Collision2D Target)
    {
        if (Target.gameObject.CompareTag("Player"))
        {
            _Arrows += Time.deltaTime;
            if(_Arrows >= ArrowsPerSecond)
            {
                turret.GetComponent<ArrowTrapBoi>().Fire();
                _Arrows = 0;
            }
        }
    }

}
