using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA3 : MonoBehaviour {

    public GameObject EnemyShip;
    private bool Hit;
    private Transform Player;

    private float ShotTimer = 0.001f;
    private Vector3 SpaceShipPosition;
    private Vector3 ShootPosition;
    private float Distance;
    public Vector3 DropPos;

    private bool InsideArea;

    public int EnemyLives;

    public float MovementTimer = 0;
    Vector3 MovementDirection;


    // Use this for initialization
    void Start()
    {
        EnemyLives = 2;

    }

    // Update is called once per frame
    void Update()
    {
        InsideCombatArea();
        SpaceShipPosition = EnemyShip.transform.position;
                
        if (!InsideArea)
        {
            transform.position += new Vector3(0, 0, -0.2f);
        } else if (InsideArea)
        {
           
            EnemyShipMove();
        }
            

            if (transform.position.z <= -12)
            {
                DestroyObject(this.gameObject);
            }

        
        ShootToPlayer();


    }

    void EnemyShipMove()
    {
        MovementTimer -= Time.deltaTime;
        if (MovementTimer <= 0)
        {
            MovementDirection = EnemyShipDirection();            
            MovementTimer = 0.5f;
        }
        if (InsideArea)
        {
            this.transform.position += MovementDirection;
        } else if(!InsideArea)
        {
            MovementTimer = 0;
        }
        
               
        
    }

    Vector3 EnemyShipDirection()
    {
        int DirectionValue;
        DirectionValue = Random.Range(1, 4);
        Vector3 RandomDirectionVector = new Vector3(0, 0, 0.2f);
        switch (DirectionValue)
        {
            case 1:
                RandomDirectionVector = new Vector3(0, 0, 0.2f);
                break;
            case 2:
                RandomDirectionVector = new Vector3(0, 0, -0.2f);
                break;
            case 3:
                RandomDirectionVector = new Vector3(0.2f, 0, 0);
                break;
            case 4:
                RandomDirectionVector = new Vector3(-0.2f, 0, 0);
                break;

        }
        return RandomDirectionVector;

    }

    

    void ShootToPlayer()
    {
        

        if (InsideArea)
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
        if (this.transform.position.z <= 53)
        {
            if (this.transform.position.z >= -7)
            {
                InsideArea = true;

            }

        }
        else
        {
            InsideArea = false;
        }

        return InsideArea;

    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shoot")
        {
            DestroyObject(FindObjectOfType<FireShot1>().gameObject);
            Instantiate(Resources.Load("Explosion"), transform.position, Quaternion.identity);
            UpdateEnemyLives();

        }
    }*/

    public void UpdateEnemyLives()
    {
        if (EnemyLives != 0)
        {
            EnemyLives--;
            
            
        } else if (EnemyLives == 0)
        {
            DropPos = transform.position;
            DestroyObject(this.gameObject);
            FindObjectOfType<BasicControls>().Score++;
            FindObjectOfType<PowerUp>().DropProb(DropPos);
        }
    }
}
