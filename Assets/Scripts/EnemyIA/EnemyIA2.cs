using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA2 : MonoBehaviour
{

    public GameObject EnemyShip;
    public GameObject FireShot;
    private GameObject Shot1;
    private GameObject Shot2;
    private bool Hit;
    private Transform Player;

    private float ShotTimer = 0.001f;    
    private int ShotCounter = 1;
    private Vector3 SpaceShipPosition;
    private Vector3 ShootPosition;
    private Vector3 ShootPositionL;
    private Vector3 ShootPositionR;
    private float Distance;
    public Vector3 DropPos;

    private bool InsideArea;

    public int EnemyLives;

    public float MovementTimer = 0;
    Vector3 MovementDirection;


    // Use this for initialization
    void Start()
    {
        EnemyLives = 1;
        Shot1 = FireShot;
        Shot2 = FireShot;

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
            transform.position += new Vector3(0, 0, -0.2f);
        }
        
        
        
        if (transform.position.z <= -12)
        {
            DestroyObject(this.gameObject);
        }


        ShootToPlayer();

    }

    void ShootToPlayer()
    {


        if (InsideArea)
        {
            ShotTimer -= Time.deltaTime;
            
            if (ShotTimer <= 0 && InsideArea)
            {
                ShootPosition = SpaceShipPosition + new Vector3(-2f, 0, -9.5f);
                Shot1 = (GameObject)Instantiate(FireShot, ShootPosition, Quaternion.identity);
                ShootPosition = SpaceShipPosition + new Vector3(2f, 0, -9.5f);
                Shot2 = (GameObject)Instantiate(FireShot, ShootPosition, Quaternion.identity);
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
            FindObjectOfType<BasicControls>().PlayHitAudio();
            Instantiate(Resources.Load("Explosion"), transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }


    }

    public void UpdateEnemyLives()
    {
        if (EnemyLives != 0)
        {
            EnemyLives--;


        }
        else if (EnemyLives == 0)
        {
            DropPos = transform.position;
            FindObjectOfType<BasicControls>().PlayExplosionAudio();
            DestroyObject(this.gameObject);
            Instantiate(Resources.Load("Explosion"), transform.position, Quaternion.identity);
            FindObjectOfType<BasicControls>().Score++;
            FindObjectOfType<PowerUp>().DropProb(DropPos);
        }
    }



}
