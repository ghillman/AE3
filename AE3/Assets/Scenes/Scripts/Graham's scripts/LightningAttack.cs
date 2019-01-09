using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningAttack : MonoBehaviour {
    private bool Strike;
    public float LightningTime;
    public float Rechargetime;
    public GameObject Particle;
    //public GameObject Ani;

    private BoxCollider2D Box;

    // Use this for initialization
    void Start () {
        LightningTime = 0;
        
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Strike == false)
            {
                Strike = true;
                Particle.SetActive(true);
                FindObjectOfType<AudioManager>().Play("Lightning");

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
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;
            
            GetComponent<Animator>().SetBool("Lightning", true);

            LightningTime += Time.deltaTime;
            if (LightningTime >= 0.5f)
            {
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
                
                GetComponent<Animator>().SetBool("Lightning", false);
                Particle.SetActive(false);
                Strike = false;
                LightningTime = 0;
                Rechargetime = 0;
            }
        }
    }
}
