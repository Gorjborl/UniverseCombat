using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicControls : MonoBehaviour {


    
    public GameObject Ship;
    private int HorizontalSpeed = 35;
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
                transform.position += new Vector3(-1 * Time.deltaTime * HorizontalSpeed, 0, 0);
                CheckValidPosition();
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(1 * Time.deltaTime * HorizontalSpeed, 0, 0);
                CheckValidPosition();
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += new Vector3(0, 0, 1 * Time.deltaTime * HorizontalSpeed);
                CheckValidPosition();
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += new Vector3(0, 0, -1 * Time.deltaTime * HorizontalSpeed);
                CheckValidPosition();
            }

            if (Input.GetKey(KeyCode.Z))
            {
                //esta wea deberia disparar
            }
        
        
    }
    

    void CheckValidPosition()
    {
        if ( transform.position.x >= -19)
        {

        } else
        {
            transform.position += new Vector3(1, 0, 0);
        }


        if(transform.position.x <= 19)
        {

        } else
        {
            transform.position += new Vector3(-1, 0, 0);
        }

        if (transform.position.z >= -7)
        {

        }
        else
        {
            transform.position += new Vector3(0, 0, 1);
        }


        if (transform.position.z <= 53)
        {

        }
        else
        {
            transform.position += new Vector3(0, 0, -1);
        }
    }
}
