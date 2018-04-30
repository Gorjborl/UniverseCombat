using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour {

    private bool Collider;
    public GameObject EnemyShip;
    private bool Hit;
    private Transform Player;

    private float ShotTimer = 1f;
    private Vector3 SpaceShipPosition;

    private bool InsideArea;


	// Use this for initialization
	void Start () {

        Rigidbody EnemyShipbody = this.GetComponent<Rigidbody>();
        Player = GameObject.FindGameObjectWithTag("PlayerShip").transform;
        SpaceShipPosition = EnemyShip.transform.position;


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

        InsideCombatArea();

        ShootToPlayer();
        
        Debug.Log(InsideArea);
        
            
        
	}

    void ShootToPlayer()
    {
        if (InsideArea)
        {

            ShotTimer -= Time.deltaTime;
            if (ShotTimer <= 0)
            {
                SpaceShipPosition += new Vector3(-0.1f, 0, 0f);
                Instantiate(Resources.Load("FireBall2"), SpaceShipPosition, Quaternion.identity);
                ShotTimer = 1f;
            }
            
                
        }
        
    }

    bool InsideCombatArea()
    {
        if(transform.position.z <= 53)
        {
            if (transform.position.z >= -7)
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
