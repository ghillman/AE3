using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue_Behaviour : MonoBehaviour
{
    [HideInInspector]
    public bool Hit = false;
    [HideInInspector]
    public bool IsPossessed = false;
    public GameObject Demon; //The glowing eyes prefab
    private bool DemonRevealed = false;

    private float delay = 5;
    private float countdown;

    public Transform Raystart;
    public float Raycast;


    private void Start()
    {
        if (IsPossessed)
        {
            countdown = delay;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //fire Raycast
        RaycastHit2D Hitinfo = Physics2D.Raycast(Raystart.transform.position, Raystart.transform.right,Raycast);
        Debug.DrawLine(Raystart.transform.position, Raystart.transform.position + new Vector3(Raycast, 0), Color.red);
        
        if(Hitinfo)
        {
            //check if raycast hits warlock
            if(Hitinfo.transform.name.Equals("Warlock"))
            {
                Debug.Log(Hitinfo.transform.name);
                //check if lightning is struck near the statue
                if (FindObjectOfType<LightningAttack>().Strike == true)
                    Hit = true;
                
                //if the demon is possessed, after 5 seconds instantiate the prefab with the glowing eyes
                if(IsPossessed && !DemonRevealed)
                {
                    countdown -= Time.deltaTime;
                    if (countdown < 0)
                    {
                        Demon.transform.position = transform.position;
                        Instantiate(Demon);
                        DemonRevealed = true;
                    }
                }
            }
        }
    }
}
