﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManager2 : MonoBehaviour {

    
    public void StartGame()
    {
        Application.LoadLevel("level2");
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

    void GameOver()
    {
       
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
