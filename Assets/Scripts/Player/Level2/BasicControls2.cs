using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BasicControls2 : MonoBehaviour {


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
    
    public int PlayerLives;
    public int ForceShield;
    public GameObject ShieldGreen;
    public GameObject ShieldYellow;
    public GameObject ShieldRed;
    public GameObject ShieldGold;
    
    public Text ScoreText;
    public int Score;
    public Text Lives;
    private int multiplier;
    public int Level;
    private int LevelMultiplier;

    public GameObject ForceImprove;
    public int ShotsLeft;
    public Text ShotsLeftText;

    public AudioClip Explosion;
    public AudioClip Hit;
    public AudioClip PowerUp;
    private AudioSource SoundFile;

    public Canvas Pause_Canvas;
    public Canvas Hud_Canvas;
    public Button PauseBtn;
    private bool PauseBtnClick;
    public GameObject MusicContainer;
    private AudioSource Music;
    public Button ResumeButton;
    private bool ResumeClick;
    public Button OptionButton;
    private bool OptionClick;
    public bool IsPaused;
    static bool IsPausedinit = false;

    public Canvas Option_Canvas;    
    public Slider SensibilitySlider;

    public Button ResumeButton2;
    

    // Touch Variables
    public float sensivity;
    public float ShotTimer = 0;
    public float NormalShotTimer = 0.5f;    
    Vector3 ShootPosition;
    

    private int CurrentScore = 0;
    private int startingHighScore;
    
    // Use this for initialization
    void Start() {
        
        SensibilitySlider.value = PlayerPrefs.GetFloat("Sensivity");        
        IsPaused = IsPausedinit;
        Time.timeScale = 1;
        SoundFile = GetComponent<AudioSource>();
        Music = MusicContainer.GetComponent<AudioSource>();
        Rigidbody PlayerShipbody = this.GetComponent<Rigidbody>();
        ShotsLeft = 0;
        PlayerLives = 1;
        ForceShield = 3;
        multiplier = 1;
        LevelMultiplier = 1;
        Level = 1;
        Lives.text = PlayerLives.ToString();
        ScoreText.text = Score.ToString();
        ShotsLeftText.text = ("x ") + ShotsLeft.ToString();

        startingHighScore = PlayerPrefs.GetInt("AsteroidsHighScore");

        Score = PlayerPrefs.GetInt("AsteroidsContinueScore");


    }

    // Update is called once per frame
    void Update() {

        PlayerPrefs.SetFloat("Sensivity", sensivity);

        UserInput();
        SpaceShipPosition = Ship.transform.position;
        ShipParticle.transform.position = Ship.transform.position;
        ForceShieldStat();
        ShieldBarColor();
        ShieldBarDecrease();
        ShieldBarIncrease();
        ScoreText.text = Score.ToString();
        Lives.text = PlayerLives.ToString();
        ShotsLeftText.text = ("x ") + ShotsLeft.ToString();
        UpdateLives();
        
        UpdateHighScore();
        UpdateLevel();
        AdjustSensibility();

        ResumeClick = false;
        ResumeButton.onClick.AddListener(ClickResume);
        
        ResumeButton2.onClick.AddListener(ClickResume);

        PauseBtnClick = false;
        PauseBtn.onClick.AddListener(ClickPause);

        OptionClick = false;
        OptionButton.onClick.AddListener(ClickOption);

    }

    void UserInput()
    {

#if UNITY_IOS || UNITY_ANDROID
        if (ResumeClick || PauseBtnClick)
        {
            GoToPause();
        }

        if (OptionClick)
        {
            GoToOptions();
        }

        if (!IsPaused)
        {

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                // Get movement of the finger since last frame
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

                // Move object across XY plane
                transform.Translate(touchDeltaPosition.x * sensivity, 0, touchDeltaPosition.y * sensivity);
                CheckValidPosition();
                
                
            }else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && Input.GetTouch(0).deltaPosition.magnitude <= 2)
            {
                
                    ShotCounter();
                
            }

        }
#else
        //Keyboard Input for Test Purposes
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            MoveUp();
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            MoveDown();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            ShotCounter();
        }

        if (Input.GetKeyDown(KeyCode.Escape) || ResumeClick || PauseBtnClick)
        {
            GoToPause();
        }

        if (OptionClick)
        {
            GoToOptions();
        }

            /*if (Input.GetKeyDown(KeyCode.X))
            {
                FirePlasma1();
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                DoublePlasma();
            }*/
#endif
        
    }

    void MoveLeft()
    {
        transform.position += new Vector3(-1 * Time.deltaTime * HorizontalSpeed, 0, 0);
        CheckValidPosition();
    }

    void MoveRight()
    {
        transform.position += new Vector3(1 * Time.deltaTime * HorizontalSpeed, 0, 0);
        CheckValidPosition();
    }

    void MoveUp()
    {
        transform.position += new Vector3(0, 0, 1 * Time.deltaTime * HorizontalSpeed);
        CheckValidPosition();
    }

    void MoveDown()
    {
        transform.position += new Vector3(0, 0, -1 * Time.deltaTime * HorizontalSpeed);
        CheckValidPosition();
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
        ShootFire1 = (GameObject)Instantiate(Resources.Load("FireBall1Level2"), SpaceShipPosition, Quaternion.identity);

    }
    
    void DoublePlasma()
    {
        /*SpaceShipPosition += new Vector3(-1f, 0, 0f);
        ShootFire1 = (GameObject)Instantiate(Resources.Load("Plasma1"), SpaceShipPosition, Quaternion.identity);
        SpaceShipPosition += new Vector3(2f, 0, 0);
        GameObject ShootFire2 = (GameObject)Instantiate(Resources.Load("Plasma1"), SpaceShipPosition, Quaternion.identity);*/
        SpaceShipPosition += new Vector3(-2f, 0, 0f);
        ShootFire1 = (GameObject)Instantiate(Resources.Load("DoublePlasma"), SpaceShipPosition, Quaternion.identity);
    }
    
    void ShieldBarColor()
    {        
            if (ForceShield == 3)
            {                 
                ShieldRadialBar.color = new Color32(66, 244, 122, 100);            

            }

            if (ForceShield == 2)
            {                 
                ShieldRadialBar.color = new Color32(255, 242, 0, 100);
                
            }

            if (ForceShield == 1)
            {            
                ShieldRadialBar.color = new Color32(237, 35, 35, 100);
                
            }

            if (ForceShield == 0)
            {
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
        
    public void RechargeShoot()
    {
        ShotsLeft += 3;
    }

    public void ShotCounter()
    {
        if ( ShotsLeft > 0)
        {
            FireShoot1();
            ShotsLeft--;
        }
                
    }

    public void UpdateForceShieldStat()
    {
                   
        if (ForceShield != 0 )
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
                NormalShotTimer = 0.5f;
                
            }
            if( PlayerLives == 0 && ForceShield == 0)
            {
                GameOver();
            }
            
        }
                
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


    void UpdateLives()
    {
        
        if (Score == multiplier * 100)
        {
            PlayerLives++;
            multiplier++;
        }
                
    }

    void UpdateLevel()
    {
        int LevelComparator = LevelMultiplier * 10 + (10 * Level * Level - 1);
        if (Score >= LevelComparator)
        {
            Level++;
            LevelMultiplier++;
            if (Level <= 7)
            {
                if (FindObjectOfType<Spawner2>().SpawnLeastWait >= 0)
                {
                    FindObjectOfType<Spawner2>().SpawnLeastWait -= Level * 0.05f;
                }
                else if (FindObjectOfType<Spawner2>().SpawnLeastWait <= 0)
                {
                    FindObjectOfType<Spawner2>().SpawnLeastWait = 0;
                }

                if (FindObjectOfType<Spawner2>().SpawnMostWait >= 1.25f)
                {
                    FindObjectOfType<Spawner2>().SpawnMostWait -= Level * 0.05f;
                }
                else
                {
                    FindObjectOfType<Spawner2>().SpawnMostWait = 1.25f;
                }


            }
            else
            {

            }

        }
        
    }

    public void PlayHitAudio()
    {
        SoundFile.PlayOneShot(Hit);
    }

    public void PlayExplosionAudio()
    {
        SoundFile.PlayOneShot(Explosion);
    }

    public void PlayPowerUpAudio()
    {
        SoundFile.PlayOneShot(PowerUp);
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        IsPaused = true;
        Music.Pause();
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        IsPaused = false;
        Music.Play();
    }

    void ClickPause()
    {
        PauseBtnClick = true;
    }


    void ClickResume()
    {
        ResumeClick = true;
    }

    void ClickOption()
    {
        OptionClick = true;
    }

    void GoToPause()
    {
        if (Time.timeScale == 1)
        {
            PauseGame();
            Pause_Canvas.gameObject.SetActive(true);
            Hud_Canvas.gameObject.SetActive(false);

        }
        else
        {
            ResumeGame();
            Pause_Canvas.gameObject.SetActive(false);
            Hud_Canvas.gameObject.SetActive(true);
            Option_Canvas.gameObject.SetActive(false);
        }
    }

    void GoToOptions()
    {
                   
            Option_Canvas.gameObject.SetActive(true);
            Pause_Canvas.gameObject.SetActive(false);
            Hud_Canvas.gameObject.SetActive(false);

        
    }

    void AdjustSensibility()
    {
        sensivity = PlayerPrefs.GetFloat("Sensivity");
        sensivity = SensibilitySlider.value;
    }


    public void UpdateHighScore()
    {
        CurrentScore = Score;

        if (CurrentScore > startingHighScore)
        {
            PlayerPrefs.SetInt("AsteroidsHighScore", CurrentScore);
        }
        
    }

    void GameOver()
    {
        PlayerPrefs.SetInt("AsteroidsLastScore", CurrentScore);
        Application.LoadLevel("GameOverLevel2");
    }
}
