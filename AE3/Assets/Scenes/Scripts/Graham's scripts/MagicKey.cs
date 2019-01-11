using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicKey : MonoBehaviour {
    public EdgeCollider2D Door;
	
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Door.enabled = false;
        Destroy(gameObject);
    }
}
