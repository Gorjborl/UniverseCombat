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

        
	}
	
	// Update is called once per frame
	void Update () {

        UserInput();
            	
	}

    void UserInput()
    {
        //Keyboard Input for Test Purposes
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-0.5f, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(0.5f, 0, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, 0, 0.5f);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, 0, -0.5f);
        }
    }
    
}
