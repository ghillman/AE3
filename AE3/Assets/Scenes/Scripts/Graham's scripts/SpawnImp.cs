using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnImp : MonoBehaviour {
    public GameObject Imp;
    private float timer;
    private float _Time;
    private bool timerbool;

    [HideInInspector]
    public bool active;
    private void Start()
    {
        _Time = 30;
        timer = 0;
    }
    private void Update()
    {
        if (active)
        {
            if (timer != 0)
            {
                active = false;
                timerbool = false;
                Instantiate(Imp, transform.position, Quaternion.identity);
                GetComponent<SpawnImp>().enabled = false;
            }
        }
        if (!timerbool)
        {
            timer += Time.deltaTime;
            if (timer >= _Time)
            {
                timer = 0;
                timerbool = true;
                active = true;
            }
        }
        
    }
    public void spawn()
    {
        
    }
    
       
}	
      

            

	
    

