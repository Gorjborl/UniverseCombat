using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicControls : MonoBehaviour {


    
    public GameObject Ship;
    public GameObject FPCamera;
    public GameObject ThirdCamera;
    public int HorizontalSpeed = 0;
	// Use this for initialization
	void Start () {

        Input.gyro.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {

        
            //Ship.transform.Translate(Input.acceleration.x * Time.deltaTime * HorizontalSpeed, 0, 0 );
            Ship.transform.Rotate(0,-Input.gyro.rotationRateUnbiased.y, 0);
            Ship.transform.Rotate(-Input.gyro.rotationRateUnbiased.x, 0, 0);
            ChangeCamera();		
	}

    void ChangeCamera()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ThirdCamera.gameObject.SetActive(true);
            FPCamera.gameObject.SetActive(false);
            
        }
    }
}
