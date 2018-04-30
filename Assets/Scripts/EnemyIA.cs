using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour {

    private bool Collider;
    public GameObject EnemyShip;
    private bool Hit;

	// Use this for initialization
	void Start () {

        Rigidbody EnemyShipbody = this.GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {

        if (!Hit)
        {
            transform.position += new Vector3(0, 0, -0.5f);

            if (transform.position.z <= -12)
            {
                DestroyObject(this.gameObject);
            }
        } else if (Hit)
        {
            DestroyObject(this.gameObject);
        }
            
        
            
        
	}

    
}
