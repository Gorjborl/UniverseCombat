using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp2 : MonoBehaviour {

    public GameObject ForceShieldImprove;
    public GameObject Ammo;
    public GameObject LiveUp;
    public GameObject Coin;
    
	// Use this for initialization
	void Start () {
		
        

	}
	
	// Update is called once per frame
	void Update () {

        
	}



    public void DropProb(Vector3 DropPos)
    {
        int Result = Random.Range(1, 100);
        
        if (Result <= 10)
        {
            Instantiate(Ammo, DropPos, Quaternion.identity);
        }

        if (Result > 10 && Result <= 13)
        {
            Instantiate(LiveUp, DropPos, Quaternion.identity);
        }

        if (Result > 13 && Result <= 16)
        {
            Instantiate(ForceShieldImprove, DropPos, Quaternion.identity);
        }

        if (Result >16 && Result <= 17)
        {
            Instantiate(Coin, DropPos, Quaternion.identity);
        }
        
    }
}
