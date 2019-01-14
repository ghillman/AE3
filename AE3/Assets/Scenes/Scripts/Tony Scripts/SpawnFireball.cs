using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFireball : MonoBehaviour
{
    public GameObject fireball;
    private bool isFireball = false;

    private void Update()
    {
        if (!isFireball)
        {
            Instantiate(fireball);
            isFireball = true;
        }
        if (FindObjectOfType<deactivate>().touched == true)
        {
            isFireball = false;
            FindObjectOfType<deactivate>().touched = false;
        }

    }

}
