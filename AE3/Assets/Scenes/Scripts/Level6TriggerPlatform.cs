using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level6TriggerPlatform : MonoBehaviour
{

    public GameObject FirePlatform;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D Target)
    {
        if (Target.gameObject.CompareTag("Player"))
        {
            FirePlatform.GetComponent<FlamePlatform>().DoubleSpeed = true;
        }
    }
}
