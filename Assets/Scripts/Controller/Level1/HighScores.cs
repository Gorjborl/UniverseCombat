using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScores : MonoBehaviour {

    public Text HighScoreText;
    public Text AsteroidsHighScoreText;
    

    // Use this for initialization
    void Start()
    {        

        HighScoreText.text = PlayerPrefs.GetInt("HighScore").ToString() + " Points";
        AsteroidsHighScoreText.text = PlayerPrefs.GetInt("AsteroidsHighScore").ToString() + " Points";
        

    }

    // Update is called once per frame
    void Update()
    {

    }
}
