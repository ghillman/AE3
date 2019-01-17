using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hearts : MonoBehaviour
{
    //get heart objects
    public GameObject[] HeartObjects;

    private void Update()
    {
        //get rid of hearts as player takes damage, reset the scene if the player loses all of them
        switch(PlayerState.PlayerHealth)
        {
            case 4:
                Debug.Log("All Hearts");
                break;
            case 3:
                Debug.Log("1 Heart gone");
                HeartObjects[3].gameObject.SetActive(false);
                break;
            case 2:
                HeartObjects[2].gameObject.SetActive(false);
                break;
            case 1:
                HeartObjects[1].gameObject.SetActive(false);
                break;
            case 0:
                HeartObjects[0].gameObject.SetActive(false);
                break;


        }
    }
}
