using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BasicControls : MonoBehaviour {



    public GameObject Ship;
    public GameObject ShipParticle;
    private Rigidbody ShipBody;
    private GameObject ShootFire1;
    private int HorizontalSpeed = 35;
    private Vector3 SpaceShipPosition;

    private int PlayerLives;
    private int ForceShield;
    public GameObject ShieldGreen;
    public GameObject ShieldYellow;
    public GameObject ShieldRed;

    public Text ScoreText;
    public int Score;
	// Use this for initialization
	void Start () {

        Rigidbody PlayerShipbody = this.GetComponent<Rigidbody>();
        PlayerLives = 1;
        ForceShield = 3;

        ScoreText.text = Score.ToString();

    }
	
	// Update is called once per frame
	void Update () {

        UserInput();
        SpaceShipPosition = Ship.transform.position;
        ShipParticle.transform.position = Ship.transform.position;
        ForceShieldStat();
        ScoreText.text = Score.ToString();


    }

    void UserInput()
    {
       
            //Keyboard Input for Test Purposes
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += new Vector3(-1 * Time.deltaTime * HorizontalSpeed, 0, 0);
                CheckValidPosition();
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(1 * Time.deltaTime * HorizontalSpeed, 0, 0);
                CheckValidPosition();
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += new Vector3(0, 0, 1 * Time.deltaTime * HorizontalSpeed);
                CheckValidPosition();
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += new Vector3(0, 0, -1 * Time.deltaTime * HorizontalSpeed);
                CheckValidPosition();
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                FireShoot1();
            }

            /*if (Input.GetKeyDown(KeyCode.X))
            {
                FirePlasma1();
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                DoublePlasma();
            }*/

    }
    

    void CheckValidPosition()
    {
        if ( transform.position.x >= -19)
        {

        } else
        {
            transform.position += new Vector3(1, 0, 0);
        }


        if(transform.position.x <= 19)
        {

        } else
        {
            transform.position += new Vector3(-1, 0, 0);
        }

        if (transform.position.z >= -7)
        {

        }
        else
        {
            transform.position += new Vector3(0, 0, 1);
        }


        if (transform.position.z <= 53)
        {

        }
        else
        {
            transform.position += new Vector3(0, 0, -1);
        }
    }

    void FireShoot1()
    {
        SpaceShipPosition += new Vector3(0.1f, 0, 0f);
        ShootFire1 = (GameObject)Instantiate(Resources.Load("FireBall1"), SpaceShipPosition, Quaternion.identity);
        
    }

    void FirePlasma1()
    {
        SpaceShipPosition += new Vector3(0.1f, 0, 0f);
        ShootFire1 = (GameObject)Instantiate(Resources.Load("Plasma1"), SpaceShipPosition, Quaternion.identity);

    }

    void DoublePlasma()
    {
        SpaceShipPosition += new Vector3(-1f, 0, 0f);
        ShootFire1 = (GameObject)Instantiate(Resources.Load("Plasma1"), SpaceShipPosition, Quaternion.identity);
        SpaceShipPosition += new Vector3(2f, 0, 0);
        GameObject ShootFire2 = (GameObject)Instantiate(Resources.Load("Plasma1"), SpaceShipPosition, Quaternion.identity);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyShip")
        {
            DestroyObject(GameObject.FindGameObjectWithTag("EnemyShip"));
            Instantiate(Resources.Load("Explosion"), transform.position + new Vector3 (0,0,6), Quaternion.identity);
            if (ForceShield != 0)
            {
                ForceShield--;
            } else if( ForceShield == 0)
            {
                GameOver();
            }
            
            
        }
    
    }

    void ForceShieldStat()
    {
        if (ForceShield == 3)
        {
            ShieldGreen.SetActive(true);
            ShieldYellow.SetActive(false);
            ShieldRed.SetActive(false);
        }
        if(ForceShield == 2)
        {
            ShieldGreen.SetActive(false);
            ShieldYellow.SetActive(true);
            ShieldRed.SetActive(false);
        }
        if(ForceShield == 1)
        {
            ShieldGreen.SetActive(false);
            ShieldYellow.SetActive(false);
            ShieldRed.SetActive(true);
        }
        if(ForceShield == 0)
        {
            ShieldGreen.SetActive(false);
            ShieldYellow.SetActive(false);
            ShieldRed.SetActive(false);
            
        }
    }

    void GameOver()
    {
        Application.LoadLevel("GameOver");
    }

    
}
