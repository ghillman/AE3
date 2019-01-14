using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BponeFletcher : MonoBehaviour {
    public GameObject Bone;
    public bool FacingLeft;
    private float _FireRate;
    public float FireRate;

	// Use this for initialization
    void Start()
    {
        
    }
	
	// Update is called once per frame]

	void Update () {

        _FireRate += Time.deltaTime;
        if (_FireRate >= FireRate)
        {
            if (FacingLeft)
            {
                Bone.GetComponent<BoneScript>().Direction = true;
            }
            else
            {
                Bone.GetComponent<BoneScript>().Direction = false;
            }
            Instantiate(Bone, transform.position, Quaternion.identity);
            GameObject _Bone = Instantiate(Bone, transform.position, Quaternion.identity);
           _Bone.transform.parent = gameObject.transform;
            _FireRate = 0;

        }

	}
}
