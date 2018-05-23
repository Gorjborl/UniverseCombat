using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver2 : MonoBehaviour {

    public Text LastScore;
    public Text NewHighScore;
    public Text EarnedCoins;
    public Button RetryForCoinsButton;
    public Text RetryForCoinsBtnLabel;
    public Canvas InsufficientCoins;
    private int CoinsEarned;
    private int CurrentCoinBalance;    
    private int Retry;
    private int RetryCost;

    // Use this for initialization
    void Start()
    {        
        LastScore.text = PlayerPrefs.GetInt("AsteroidsLastScore").ToString() + "  Points";
        UpdateNewHighScore();
        GainCoins();
        EarnedCoins.text = CoinsEarned.ToString();
        PlayerPrefs.SetInt("AsteroidsContinueScore", 0);
        Retry = PlayerPrefs.GetInt("AsteroidsRetryCost");
        CoinCalculator();
        RetryForCoinsBtnLabel.text = "1up for  " + RetryCost + " Coins";

    }

    // Update is called once per frame
    void Update()
    {


    }

    void UpdateNewHighScore()
    {
        if (PlayerPrefs.GetInt("AsteroidsLastScore") >= PlayerPrefs.GetInt("AsteroidsHighScore"))
        {
            NewHighScore.text = "New Highscore!!";
        }
    }

    void GainCoins()
    {
        CoinsEarned = Mathf.RoundToInt(PlayerPrefs.GetInt("AsteroidsLastScore") / 150);
        CurrentCoinBalance = PlayerPrefs.GetInt("CoinBalance");
        PlayerPrefs.SetInt("CoinBalance", CurrentCoinBalance + CoinsEarned);
        CurrentCoinBalance = PlayerPrefs.GetInt("CoinBalance");
    }

    public void RetryWithCoins()
    {
        if (CurrentCoinBalance >= RetryCost)
        {
            PlayerPrefs.SetInt("AsteroidsContinueScore", PlayerPrefs.GetInt("AsteroidsLastScore"));
            PlayerPrefs.SetInt("CoinBalance", CurrentCoinBalance - RetryCost - CoinsEarned);
            PlayerPrefs.SetInt("AsteroidsRetryCost", 1);
            Application.LoadLevel("Level2");
        }
            

        else
        {
            InsufficientCoins.gameObject.SetActive(true);
        }
    }

    public void ClickOk()
    {
        InsufficientCoins.gameObject.SetActive(false);
    }

    void CoinCalculator()
    {
        if (Retry == 0)
        {
            RetryCost = Random.Range(1, 5);
        }

        if (Retry == 1)
        {
            RetryForCoinsButton.gameObject.SetActive(false);
        }
    }
}
