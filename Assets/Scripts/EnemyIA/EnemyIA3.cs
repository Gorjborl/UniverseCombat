using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA3 : MonoBehaviour {

    public GameObject EnemyShip;
    public GameObject FireShot;
    private GameObject Shot1;
    private GameObject Shot2;
    private GameObject Shot3;
    private bool Hit;
    private Transform Player;

    private float ShotTimer = 0.001f;
    private float SubShotTimer = 0.001f;
    private int ShotCounter = 1;
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
        Shot1 = FireShot;
        Shot2 = FireShot;
        Shot3 = FireShot;
        EnemyLives = 2;

    }

    // Update is called once per frame
    void Update()
    {
        if ( !FindObjectOfType<BasicControls>().IsPaused)
        {
            InsideCombatArea();
            SpaceShipPosition = EnemyShip.transform.position;

            if (!InsideArea)
            {
                transform.position += new Vector3(0, 0, -0.2f);
            }
            else if (InsideArea)
            {

                EnemyShipMove();
            }


            if (transform.position.z <= -12)
            {
                DestroyObject(this.gameObject);
            }


            ShootToPlayer();
        }
        


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

            if (this.transform.position.x <= -15)
            {
                this.transform.position += new Vector3(0.2f, 0, 0);
                MovementTimer = 0.5f;
            }

            if (this.transform.position.x >= 15)
            {
                this.transform.position += new Vector3(-0.2f, 0, 0);
                MovementTimer = 0.5f;
            }

            if (this.transform.position.z <= -7)
            {

            }
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
            SubShotTimer -= Time.deltaTime;
            if (ShotTimer <= 0 && InsideArea)
            {
                    ShootPosition = SpaceShipPosition + new Vector3(0.1f, 0, -9.5f);
                    Shot1 = (GameObject)Instantiate(Resources.Load("FireBall2"), ShootPosition, Quaternion.identity);
                    ShotTimer = 1.3f;
            } 
            
        }

    }

    bool InsideCombatArea()
    {
        if (this.transform.position.z <= 53)
        {
            if (this.transform.position.z >= -7)
            {
                if (this.transform.position.x >= -19)
                {
                    if (this.transform.position.x <= 19)
                    {
                        InsideArea = true;
                    }
                }

            }

        }
        else
        {
            InsideArea = false;
        }

        return InsideArea;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shoot")
        {
            UpdateEnemyLives();
            FindObjectOfType<BasicControls>().PlayHitAudio();
        }

        if (collision.gameObject.tag == "PlayerShip")
        {

            FindObjectOfType<BasicControls>().UpdateForceShieldStat();
            FindObjectOfType<BasicControls>().UpdateForceShieldStat();
            FindObjectOfType<BasicControls>().UpdateForceShieldStat();
            FindObjectOfType<BasicControls>().PlayHitAudio();
            FindObjectOfType<BasicControls>().Score += 3;
            Instantiate(Resources.Load("Explosion"), transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

    }

    public void UpdateEnemyLives()
    {
        if (EnemyLives != 0)
        {
            EnemyLives--;


        } else if (EnemyLives == 0)
        {
            DropPos = transform.position;
            FindObjectOfType<BasicControls>().PlayExplosionAudio();
            DestroyObject(this.gameObject);
            Instantiate(Resources.Load("Explosion"), transform.position, Quaternion.identity);
            FindObjectOfType<BasicControls>().Score += 3;
            FindObjectOfType<PowerUp>().DropProb(DropPos);
        }
    }

    

}
