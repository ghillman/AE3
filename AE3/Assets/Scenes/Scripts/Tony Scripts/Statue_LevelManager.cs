using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Statue_LevelManager : MonoBehaviour
{
    //get statues
    public Statue_Behaviour[] Statues; 
    private int possessed;

    //get portal
    public GameObject Portal;
    public Transform SpawnPortal;
    private bool IsPortal = false;

	// Use this for initialization
	void Start ()
    {
        //possess a random statue, tell that statue it's been possessed
        possessed = Random.Range(0, Statues.Length);
        Statues[possessed].IsPossessed = true;
        Debug.Log("Statue" + possessed + "Is Possessed");
	}

    private void Update()
    {
        //go through all statues and check if they're hit
        for(int i = 0; i < Statues.Length; i++)
        {
            //if an unpossessed statue is hit, kill the player
            if(Statues[i].Hit && Statues[i].IsPossessed == false)
            {
                //kill Player/lose a life
                //restart level
                Debug.Log("Dead");
                Statues[i].Hit = false;
            }
            //if possessed statue is hit, get rid of all statues and open the portal
            if (Statues[possessed].Hit)
            {
                for (int j = 0; j < Statues.Length; j++)
                {
                    Statues[j].gameObject.SetActive(false);
                }
                if (!IsPortal)
                {
                    Portal.transform.position = SpawnPortal.transform.position;
                    Instantiate(Portal);
                    IsPortal = true;
                }
            }
        }
        
    }

}
