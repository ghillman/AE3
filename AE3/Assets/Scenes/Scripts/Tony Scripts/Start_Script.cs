using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Script : MonoBehaviour
{
    //get the start menu
    public GameObject startMenu;

    public static bool KillMenu = false;
	// Update is called once per frame
	void Update ()
    {
        Time.timeScale = 0f;
        if (KillMenu)
            Destroy(gameObject);
	}
}
