using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpDamage : MonoBehaviour {
    public int ImpHealth;
    public float ImpStaytime;
    public float AgroDistance;
    // Use this for initialization
    void Start () {

        AgroDistance = GetComponent<ImpBehaviour>().AgroDistance;
	}
	
	// Update is called once per frame
	void Update () {

        ImpStaytime += Time.deltaTime;
        if (ImpHealth <= 0)
        {
            GameObject Warlock = GameObject.FindGameObjectWithTag("Player");
            Warlock.GetComponent<SpawnImp>().enabled = true;
            Destroy(gameObject);
        }
        if(ImpStaytime >= 25)
        {
            GameObject Warlock = GameObject.FindGameObjectWithTag("Player");
            Warlock.GetComponent<SpawnImp>().enabled = true;
            Destroy(gameObject);
        }
        RaycastHit2D Target =
        Physics2D.Raycast(transform.position, new Vector3(AgroDistance, 0, 0), AgroDistance, 1 << LayerMask.NameToLayer("Enemy"));

        RaycastHit2D Target2 =
        Physics2D.Raycast(transform.position, new Vector3(-AgroDistance, 0, 0), AgroDistance, 1 << LayerMask.NameToLayer("Enemy"));
        if (Target.collider != null)
        {
            if (Target.collider.gameObject.CompareTag("Enemy"))
            {
                ImpStaytime = 0;
            }
        }
        if (Target2.collider != null)
        {
            if (Target2.collider.gameObject.CompareTag("Enemy"))
            {
                ImpStaytime = 0;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D Target)
    {
        if (Target.gameObject.CompareTag("Enemy"))
        {
            ImpHealth -= 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D Target)
    {
        if (Target.gameObject.CompareTag("Enemy"))
        {
            ImpHealth -= 1;
        }
    }
}
