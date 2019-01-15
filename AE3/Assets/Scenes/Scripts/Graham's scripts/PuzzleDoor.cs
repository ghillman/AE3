using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDoor : MonoBehaviour {
    public SpriteRenderer Red;
    public SpriteRenderer Yellow;
    public SpriteRenderer Blue;
    public SpriteRenderer Green;
    public Sprite _Red;
    public Sprite _Yellow;
    public Sprite _Blue;
    public Sprite _Green;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Red.sprite == _Red && Yellow.sprite == _Yellow && Green.sprite == _Green && Blue.sprite == _Blue)
        {
            GetComponent<EdgeCollider2D>().enabled = false;
        }
	}
}
