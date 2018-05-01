using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public GameObject ForceShieldImprove;
    
	// Use this for initialization
	void Start () {
		
        

	}
	
	// Update is called once per frame
	void Update () {

        
	}



    public void DropProb(Vector3 DropPos)
    {
        int Result = Random.Range(1, 100);
        Debug.Log(Result.ToString());
        if (Result <= 5)
        {
            Instantiate(ForceShieldImprove, DropPos, Quaternion.identity);
        }

    }
}
