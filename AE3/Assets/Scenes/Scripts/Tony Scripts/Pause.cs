//https://www.youtube.com/watch?v=JivuXdrIHK0&list=PLPV2KyIb3jR4JsOygkHOd2q0CFoslwZOZ&index=3 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//This script goes on the canvas
public class Pause : MonoBehaviour
{
    public static bool GamePaused = false;

    //get pause menu
    public GameObject PauseMenu;
    //get start menu
    public GameObject StartMenu;

	// Update is called once per frame
	void Update ()
    {
        //check for start menu
        if (!StartMenu)
        {
            if (GamePaused)
            {
                //bring up pause menu
                PauseMenu.SetActive(true);
                //stop time (didn't think it'd be this simple)
                Time.timeScale = 0f;
            }
            else
            {
                //bring back menu
                PauseMenu.SetActive(false);
                //Make time go...*shrugs"...words
                Time.timeScale = 1f;
            }
        }
	}


}
