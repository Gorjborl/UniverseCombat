using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicControls : MonoBehaviour {



    public GameObject Ship;
    public GameObject ShipParticle;
    private Rigidbody ShipBody;
    private GameObject ShootFire1;
    private int HorizontalSpeed = 35;
    private Vector3 SpaceShipPosition;

    private int PlayerLives;
	// Use this for initialization
	void Start () {

        Rigidbody PlayerShipbody = this.GetComponent<Rigidbody>();
        PlayerLives = 3;

    }
	
	// Update is called once per frame
	void Update () {

        UserInput();
        SpaceShipPosition = Ship.transform.position;
        ShipParticle.transform.position = Ship.transform.position;

            
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
            PlayerLives--;
            Debug.Log(PlayerLives.ToString());

            if (PlayerLives == 0)
            {
                GameOver();
            }
        }
    
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
