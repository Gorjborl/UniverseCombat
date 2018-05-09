using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour {

    
    public GameObject EnemyShip;
    private bool Hit;
    private Transform Player;

    private float ShotTimer = 0.001f;
    private Vector3 SpaceShipPosition;
    private Vector3 ShootPosition;
    private float Distance;

    private bool InsideArea;


	// Use this for initialization
	void Start () {
         
        
    }
	
	// Update is called once per frame
	void Update () {

        SpaceShipPosition = EnemyShip.transform.position;
        

        if (!Hit)
        {
            transform.position += new Vector3(0, 0, -0.6f);

            if (transform.position.z <= -12)
            {
                DestroyObject(this.gameObject);
            }
        } else if (Hit)
        {
            DestroyObject(this.gameObject);
        }

        ShootToPlayer();            
            
        
	}

    void ShootToPlayer()
    {
        InsideCombatArea();
        
        if(InsideArea)
        {
            ShotTimer -= Time.deltaTime;
            if (ShotTimer <= 0 && InsideArea)
            {
                ShootPosition = SpaceShipPosition + new Vector3(0.1f, 0, -9.5f);
                Instantiate(Resources.Load("FireBall2"), ShootPosition, Quaternion.identity);
                ShotTimer = 1.5f;
            }
        }
            
    }

    bool InsideCombatArea()
    {
        if(this.transform.position.z <= 53)
        {
            if (this.transform.position.z >= -7)
            {
                InsideArea = true;
                
            }
            
        } else 
        {
            InsideArea = false;
        }

        return InsideArea;

    }
        
}
