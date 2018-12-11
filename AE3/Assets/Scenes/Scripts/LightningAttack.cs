using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningAttack : MonoBehaviour {
    private bool Strike;
    public float LightningTime;
    public float Rechargetime;
    public GameObject Particle;
    public GameObject Ani;
    // Use this for initialization
    void Start () {
        LightningTime = 0;
        Ani = GameObject.FindGameObjectWithTag("Lightning");
        
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Strike == false)
            {
                Strike = true;
                Particle.SetActive(true);

            }
        }
        if (Strike)
        {
            LightningStrike();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.localScale = new Vector2(-2, 2);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.localScale = new Vector2(2, 2);
        }

    }
    void LightningStrike()
    {
        Rechargetime += Time.deltaTime;
        if (Rechargetime >= 1)
        {
            Ani.GetComponent<SpriteRenderer>().enabled = true;
            Ani.GetComponent<BoxCollider2D>().enabled = true;
            Ani.GetComponent<Animator>().SetBool("Lightning", true);

            LightningTime += Time.deltaTime;
            if (LightningTime >= 0.5f)
            {
                Ani.GetComponent<SpriteRenderer>().enabled = false;
                Ani.GetComponent<BoxCollider2D>().enabled = false;
                Ani.GetComponent<Animator>().SetBool("Lightning", false);
                Particle.SetActive(false);
                Strike = false;
                LightningTime = 0;
                Rechargetime = 0;
            }
        }
    }
}
