using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BasicControls : MonoBehaviour {


    public Image ShieldRadialBar;
    private float FillTimer = 0.5f;
    private bool PlayerHit;
    private bool ShieldUpgrade;

    public GameObject Ship;
    public GameObject ShipParticle;
    private Rigidbody ShipBody;
    private GameObject ShootFire1;
    private int HorizontalSpeed = 35;
    private Vector3 SpaceShipPosition;

    private int PlayerLives;
    public int ForceShield;
    public GameObject ShieldGreen;
    public GameObject ShieldYellow;
    public GameObject ShieldRed;

    public Text ScoreText;
    public int Score;
    public Text Lives;

    public GameObject ForceImprove;
    // Use this for initialization
    void Start() {

        Rigidbody PlayerShipbody = this.GetComponent<Rigidbody>();
        PlayerLives = 1;
        ForceShield = 3;
        Lives.text = PlayerLives.ToString();
        ScoreText.text = Score.ToString();

    }

    // Update is called once per frame
    void Update() {

        UserInput();
        SpaceShipPosition = Ship.transform.position;
        ShipParticle.transform.position = Ship.transform.position;
        ForceShieldStat();
        ShieldBarColor();
        ShieldBarDecrease();
        ShieldBarIncrease();
        ScoreText.text = Score.ToString();
        Lives.text = PlayerLives.ToString();



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
        if (transform.position.x >= -19)
        {

        } else
        {
            transform.position += new Vector3(1, 0, 0);
        }


        if (transform.position.x <= 19)
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
            Instantiate(Resources.Load("Explosion"), transform.position + new Vector3(0, 0, 6), Quaternion.identity);
            UpdateForceShieldStat();


        }

        if (collision.gameObject.tag == "ShieldUp")
        {
            UpgradeForceShield();
            Destroy(GameObject.FindGameObjectWithTag("ShieldUp"));
        }


    }

    void ShieldBarColor()
    {        
            if (ForceShield == 3)
            {
                //ShieldRadialBar.fillAmount = 1f;   
                ShieldRadialBar.color = new Color32(66, 244, 122, 100);
                

            }

            if (ForceShield == 2)
            {                
                //ShieldRadialBar.fillAmount = 0.67f ;                
                ShieldRadialBar.color = new Color32(255, 242, 0, 100);
                
            }

            if (ForceShield == 1)
            {
            
                //ShieldRadialBar.fillAmount = 0.33f;                
                ShieldRadialBar.color = new Color32(237, 35, 35, 100);
                
            }

            if (ForceShield == 0)
            {
                //ShieldRadialBar.fillAmount = 0;
                
            }

    }

    void ShieldBarDecrease()
    {
        if (PlayerHit)
        {
            if( ForceShield == 2)
            {
                if(ShieldRadialBar.fillAmount >= 0.67f)
                {
                    ShieldRadialBar.fillAmount -= 0.33f * Time.deltaTime;
                }
            }

            if (ForceShield == 1)
            {
                if (ShieldRadialBar.fillAmount >= 0.33f)
                {
                    ShieldRadialBar.fillAmount -= 0.33f * Time.deltaTime;
                }
            }

            if (ForceShield == 0)
            {
                if (ShieldRadialBar.fillAmount >= 0f)
                {
                    ShieldRadialBar.fillAmount -= 0.33f * Time.deltaTime;
                }
            }
        }
    }

    void ShieldBarIncrease()
    {
        if (ShieldUpgrade)
        {
            if (ForceShield == 3)
            {
                if (ShieldRadialBar.fillAmount <= 1f)
                {
                    ShieldRadialBar.fillAmount += 0.33f * Time.deltaTime;
                }
            }
            if (ForceShield == 2)
            {
                if (ShieldRadialBar.fillAmount <= 0.67f)
                {
                    ShieldRadialBar.fillAmount += 0.33f * Time.deltaTime;
                }
            }

            if (ForceShield == 1)
            {
                if (ShieldRadialBar.fillAmount <= 0.33f)
                {
                    ShieldRadialBar.fillAmount += 0.33f * Time.deltaTime;
                }
            }
            
        }
    }

    public void ForceShieldStat()
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

    public void UpdateForceShieldStat()
    {
        
        if (ForceShield != 0)
        {
            ForceShield--;
            PlayerHit = true;
            
            

        }
        else if (ForceShield == 0)
        {
            if (PlayerLives != 0 && ForceShield == 0)
            {
                PlayerLives--;
                this.transform.position = new Vector3(0, 0, 0);
                ForceShield = 3;
                ShieldUpgrade = true;
            }
            if( PlayerLives == 0 && ForceShield == 0)
            {
                GameOver();
            }
            
        }
        Debug.Log(PlayerLives.ToString());
        
    }

    public void UpgradeForceShield()
    {
        if (ForceShield != 3)
        {
            ForceShield++;
            ShieldUpgrade = true;
        }
        else if (ForceShield == 3)
        {
            
        }

    }
    void GameOver()
    {
        Application.LoadLevel("GameOver");
    }

    public void ShieldBarColorFill()
    {
        if (ForceShield == 3)
        {
            if (ShieldRadialBar.fillAmount <= 1)
            {
                ShieldRadialBar.fillAmount += 0.33f * Time.deltaTime;
            }

            ShieldRadialBar.color = new Color32(66, 244, 122, 100);

        }

        if (ForceShield == 2)
        {

            
            if (ShieldRadialBar.fillAmount <= 0.67f)
            {
                ShieldRadialBar.fillAmount += 0.33f * Time.deltaTime;
            }

            ShieldRadialBar.color = new Color32(222, 239, 31, 100);
        }

        if (ForceShield == 1)
        {

            
            if (ShieldRadialBar.fillAmount <= 0.33f)
            {
                ShieldRadialBar.fillAmount += 0.33f * Time.deltaTime;
            }
            ShieldRadialBar.color = new Color32(237, 35, 35, 100);
        }

        if (ForceShield == 0)
        {
            if (ShieldRadialBar.fillAmount >= 0)
            {
                ShieldRadialBar.fillAmount += 0.33f * Time.deltaTime;
            }

        }


    }



}
