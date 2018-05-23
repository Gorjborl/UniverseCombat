using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

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
        //PlayerPrefs.SetInt("CoinBalance", 0);
        Debug.Log(PlayerPrefs.GetInt("CoinBalance").ToString());
        UpdateNewHighScore();
        LastScore.text = PlayerPrefs.GetInt("LastScore").ToString() + "  Points";
        GainCoins();
        EarnedCoins.text = CoinsEarned.ToString();
        PlayerPrefs.SetInt("ContinueScore",0);
        Retry = PlayerPrefs.GetInt("RetryCost");
        CoinCalculator();
        RetryForCoinsBtnLabel.text = "1up for  " + RetryCost + " Coins";
        

    }

    // Update is called once per frame
    void Update()
    {


    }

    void UpdateNewHighScore()
    {
        if (PlayerPrefs.GetInt("LastScore") >= PlayerPrefs.GetInt("HighScore"))
        {
            NewHighScore.text = "New Highscore!!";
        }
    }

    void GainCoins()
    {
        CoinsEarned = Mathf.RoundToInt(PlayerPrefs.GetInt("LastScore") / 150);
        CurrentCoinBalance = PlayerPrefs.GetInt("CoinBalance");
        PlayerPrefs.SetInt("CoinBalance", CurrentCoinBalance + CoinsEarned);
        CurrentCoinBalance = PlayerPrefs.GetInt("CoinBalance");
    }

    public void RetryWithCoins()
    {
        if (CurrentCoinBalance >= RetryCost)
        {
            PlayerPrefs.SetInt("ContinueScore", PlayerPrefs.GetInt("LastScore"));
            PlayerPrefs.SetInt("CoinBalance", CurrentCoinBalance - RetryCost - CoinsEarned);
            PlayerPrefs.SetInt("RetryCost", 1);
            Application.LoadLevel("Level1");
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
        if ( Retry == 0)
        {
            RetryCost = Random.Range(1, 5);
        }

        if (Retry == 1)
        {
            RetryForCoinsButton.gameObject.SetActive(false);
        }
    }
}
