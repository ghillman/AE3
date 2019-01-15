using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBoulders : MonoBehaviour {
    public GameObject Platform;
    public GameObject CameraScrpt;
    public GameObject CameraCenter;
    public float FallTimer;
    private float _FallTimer;
    private float ShakingTimer;
    private bool Shaken;
    public float ShakingIntervals;
    private Vector3 ShakingPosition;
    private float Timer;
    private Vector3 CameraStart;
    private bool CameraTaken;
    // Use this for initialization
    void Start () {
        Shaken = false;
        Timer = 10;
        CameraTaken = true;
	}

    // Update is called once per frame
    void Update()
    {
        if (Platform.GetComponent<BoulderPlatform>().Fall == true)
        {
            CameraTaken = false;
            _FallTimer += Time.deltaTime;
            if (_FallTimer >= FallTimer)
            {
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                _FallTimer = 0;
            }
            if(GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Dynamic && _FallTimer >= 0.05)
            {
                if(GetComponent<Rigidbody2D>().velocity.y == 0 && !Shaken)
                {
                    Debug.Log("ShakyBoi");
                    Shaken = true;
                    
                }
            }
        }
        if(!CameraTaken)
        {
            CameraStart = new Vector3 (CameraCenter.transform.position.x, CameraCenter.transform.position.y, -10);
            CameraTaken = true;
        }
        
        if(Shaken && ShakingTimer < 0.1)
        {
            
            CameraScrpt.transform.position = CameraStart;
            Debug.Log(CameraScrpt.transform.position);
            Timer += Time.deltaTime * ShakingIntervals;
            if (Timer >= (ShakingIntervals * Time.deltaTime) * ShakingIntervals)
            {
                
                Timer = 0;
                ShakingTimer += Time.deltaTime;
                ShakingPosition = new Vector3((Random.Range(-2,1)), (Random.Range(-2,1)), -10);
                CameraScrpt.transform.position = new Vector3(CameraScrpt.transform.position.x + ShakingPosition.x, CameraScrpt.transform.position.y + ShakingPosition.y, -10);
            }
        }
    }
}
