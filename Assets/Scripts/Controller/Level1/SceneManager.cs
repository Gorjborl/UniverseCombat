using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour {


    private void Start()
    {
        PlayerPrefs.GetInt("CoinBalance");        
    }

    public void StartGame()
    {
        Application.LoadLevel("LevelSelect");
    }

    public void PlayLevel1()
    {
        PlayerPrefs.SetInt("RetryCost", 0);
        Application.LoadLevel("Level1");
    }

    public void PlayLevel2()
    {
        if (FindObjectOfType<LevelSelectController>().Level2Purchased)
        {
            PlayerPrefs.SetInt("AsteroidsRetryCost", 0);
            Application.LoadLevel("Level2");
        } else
        {
            FindObjectOfType<LevelSelectController>().ShowBuyOption();
        }        
    }

    public void RePlayLevel2()
    {
        PlayerPrefs.SetInt("AsteroidsRetryCost", 0);
        Application.LoadLevel("Level2");        
    }

    public void MainMenu()
    {
        Application.LoadLevel("Intro");
    }

    public void HighScores()
    {
        Application.LoadLevel("HighScores");
    }

    public void Help()
    {
        Application.LoadLevel("Help");
    }

    public void Config()
    {
        Application.LoadLevel("Config");
    }

    void GameOver()
    {
       
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
