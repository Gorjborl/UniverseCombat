using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public GameObject ForceShieldImprove;
    public GameObject GoldForceShield;
    public GameObject LiveUp;
    public GameObject RapidFire;
    public GameObject DoublePlasma;
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

        if (Result > 10 && Result <= 12)
        {
            Instantiate(RapidFire, DropPos, Quaternion.identity);
        }

        if (Result > 12 && Result <= 13)
        {
            Instantiate(DoublePlasma, DropPos, Quaternion.identity);
        }

        if (Result > 14 && Result <= 15)
        {
            Instantiate(Coin, DropPos, Quaternion.identity);
        }


    }
}
