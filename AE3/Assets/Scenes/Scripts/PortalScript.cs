using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour {
    private float Timer;
    public float EndTime;
    private bool PortalActive;
	// Use this for initialization
	void Start () {
        Timer = 0;
        PortalActive = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(PortalActive)
        {
            
            Timer += Time.deltaTime;
            if(Timer >= EndTime)
            {
                PlayerState.Level++;
                Debug.Log("NextLevel!");
                SceneManager.LoadScene(LevelSelector());
            }
        }

	}
    private void OnTriggerEnter2D(Collider2D Target)
    {
        if (Target.gameObject.CompareTag("Player"))
        {
            PortalActive = true;
        }
    }
    public string LevelSelector()
    {

        int Level = PlayerState.Level;
        string Levelname = "NoLevel";
        switch(Level)
        {
            case 1:
                {
                    Levelname = "Level_1";
                    break;
                }
            case 2:
                {
                    Levelname = "Level_2";
                    break;
                }
            case 3:
                {
                    Levelname = "Level_3";
                    break;
                }
            case 4:
                {
                    Levelname = "Level_4";
                    break;
                }
            case 5:
                {
                    Levelname = "Level_5";
                    break;
                }
            case 6:
                {
                    Levelname = "Level_6";
                    break;
                }
            case 7:
                {
                    Levelname = "Level_7";
                    break;
                }
            case 8:
                {
                    Levelname = "Level_8";
                    break;
                }
            case 9:
                {
                    Levelname = "Level_9";
                    break;
                }
            case 10:
                {
                    Levelname = "Level_10";
                    break;
                }
            case 11:
                {
                    Levelname = "Level_11";
                    break;
                }
            case 12:
                {
                    Levelname = "Level_12";
                    break;
                }

        }
        return Levelname;

    }
}
