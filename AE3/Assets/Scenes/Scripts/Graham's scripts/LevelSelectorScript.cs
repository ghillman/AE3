using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectorScript : MonoBehaviour {
    
    public GameObject Player;
    public SpriteRenderer Arrow;
    private bool Traverse;
    public int level;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Traverse == true && Player.GetComponent<PlayerMovement>().Interacting == true && Player.GetComponent<PlayerMovement>().Interacted == true)
        {
            PlayerState.Level = level;
            switch (level)
                {
                case 1:
                    {

                        SceneManager.LoadScene("Level_1");
                        break;
                    }
                case 2:
                    {

                        SceneManager.LoadScene("Level_2");
                        break;
                    }
                case 3:
                    {

                        SceneManager.LoadScene("Level_3");
                        break;
                    }
                case 4:
                    {

                        SceneManager.LoadScene("Level_4");
                        break;
                    }
                case 5:
                    {

                        SceneManager.LoadScene("Level_5");
                        break;
                    }
                case 6:
                    {

                        SceneManager.LoadScene("Level_6");
                        break;
                    }
                case 7:
                    {

                        SceneManager.LoadScene("Level_7");
                        break;
                    }
                case 8:
                    {

                        SceneManager.LoadScene("Level_8");
                        break;
                    }
                case 9:
                    {

                        SceneManager.LoadScene("Level_9");
                        break;
                    }
                case 10:
                    {

                        SceneManager.LoadScene("Level_10");
                        break;
                    }
                case 11:
                    {

                        SceneManager.LoadScene("Level_11");
                        break;
                    }
                case 12:
                    {

                        SceneManager.LoadScene("Level_12");
                        break;
                    }
                case 13:
                    {

                        SceneManager.LoadScene("Level_13");
                        break;
                    }
                case 14:
                    {

                        SceneManager.LoadScene("Level_14");
                        break;
                    }
                case 15:
                    {

                        SceneManager.LoadScene("Level_15");
                        break;
                    }
                case 16:
                    {

                        SceneManager.LoadScene("Level_16");
                        break;
                    }
                case 17:
                    {

                        SceneManager.LoadScene("Level_17");
                        break;
                    }
                case 18:
                    {

                        SceneManager.LoadScene("Level_18");
                        break;
                    }
                case 19:
                    {

                        SceneManager.LoadScene("Level_19");
                        break;
                    }
                case 20:
                    {

                        SceneManager.LoadScene("Level_20");
                        break;
                    }
                case 21:
                    {

                        SceneManager.LoadScene("Level_21");
                        break;
                    }
                case 22:
                    {

                        SceneManager.LoadScene("Level_22");
                        break;
                    }
                case 23:
                    {

                        SceneManager.LoadScene("Level_23");
                        break;
                    }
                case 24:
                    {

                        SceneManager.LoadScene("Level_24");
                        break;
                    }
                case 25:
                    {

                        SceneManager.LoadScene("Level_25");
                        break;
                    }
                case 26:
                    {

                        SceneManager.LoadScene("Level_26");
                        break;
                    }
                case 27:
                    {

                        SceneManager.LoadScene("Level_27");
                        break;
                    }
                case 28:
                    {

                        SceneManager.LoadScene("Level_28");
                        break;
                    }
                case 29:
                    {

                        SceneManager.LoadScene("Level_29");
                        break;
                    }
                case 30:
                    {

                        SceneManager.LoadScene("Level_30");
                        break;
                    }
                case 31:
                    {

                        SceneManager.LoadScene("Level_31");
                        break;
                    }
                case 32:
                    {

                        SceneManager.LoadScene("Level_32");
                        break;
                    }
                case 33:
                    {

                        SceneManager.LoadScene("Level_33");
                        break;
                    }
                case 34:
                    {

                        SceneManager.LoadScene("Level_34");
                        break;
                    }
                case 35:
                    {

                        SceneManager.LoadScene("Level_35");
                        break;
                    }
                case 36:
                    {

                        SceneManager.LoadScene("Level_36");
                        break;
                    }
                case 37:
                    {

                        SceneManager.LoadScene("Level_37");
                        break;
                    }
                case 38:
                    {

                        SceneManager.LoadScene("Level_38");
                        break;
                    }
                case 39:
                    {

                        SceneManager.LoadScene("Level_39");
                        break;
                    }
                case 40:
                    {

                        SceneManager.LoadScene("Level_40");
                        break;
                    }
            }
            Player.GetComponent<PlayerMovement>().Interacted = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Traverse == false)
            {
                Traverse = true;
                Arrow.enabled = true;
            }

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Traverse == true)
            {
                Traverse = false;
                Arrow.enabled = false;
            }

        }
    }
}
