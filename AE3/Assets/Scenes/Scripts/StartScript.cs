using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour {
    public int Playerhealth;
    public int Playerlevel;
    public int StartLevel;
	// Use this for initialization
	void Start () {

        PlayerState.PlayerHealth = Playerhealth;
        PlayerState.PlayerLevel = Playerlevel;
        PlayerState.Level = StartLevel;
        Debug.Log(PlayerState.PlayerHealth);
        Debug.Log(PlayerState.PlayerLevel);
        Debug.Log(PlayerState.Level);
        SceneManager.LoadScene("Level_1");
	}

}
