using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderScript : MonoBehaviour {
    public Vector2 _Cooldown;
    public GameObject Up;
    public GameObject Middle;
    public GameObject Down;
    public  float Cooldown;
    private bool GenerateCooldown;
	// Use this for initialization
	void Start () {
        Cooldown = Random.Range(_Cooldown.x, _Cooldown.y);
    }
	
	// Update is called once per frame
	void Update () {
        if (GenerateCooldown)
        {
            Cooldown = Random.Range(_Cooldown.x, _Cooldown.y);
            GenerateCooldown = false;
        }
        if (Cooldown >= 0)
        {
            Cooldown -= Time.deltaTime;
        }
        if(Cooldown <= 0)
        {
            GenerateCooldown = true;
            Instantiate(Up, transform.position, Quaternion.identity);
            Instantiate(Down, transform.position, Quaternion.identity);
            Instantiate(Middle, transform.position, Quaternion.identity);
        }

    }

}
