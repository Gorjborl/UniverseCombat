using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public GameObject ForceShieldImprove;
    public GameObject GoldForceShield;
    public GameObject LiveUp;
	// Use this for initialization
	void Start () {
		
        

	}
	
	// Update is called once per frame
	void Update () {

        
	}



    public void DropProb(Vector3 DropPos)
    {
        int Result = Random.Range(1, 100);
        
        if (Result <= 3)
        {
            Instantiate(ForceShieldImprove, DropPos, Quaternion.identity);
        }

        if (Result <= 7 && Result > 3)
        {
            Instantiate(GoldForceShield, DropPos, Quaternion.identity);
        }

        if (Result > 7 && Result <= 10)
        {
            Instantiate(LiveUp, DropPos, Quaternion.identity);
        }
    }
}
