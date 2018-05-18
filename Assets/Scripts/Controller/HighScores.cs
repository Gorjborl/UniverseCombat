using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScores : MonoBehaviour {

    public Text HighScoreText;
    public Text HighScoreText2;
    public Text HighScoreText3;
    public Text HighScoreText4;
    public Text HighScoreText5;

    // Use this for initialization
    void Start()
    {        

        HighScoreText.text = PlayerPrefs.GetInt("HighScore").ToString() + " Points";
        HighScoreText2.text = PlayerPrefs.GetInt("HighScore2").ToString() + " Points";
        HighScoreText3.text = PlayerPrefs.GetInt("HighScore3").ToString() + " Points";
        HighScoreText4.text = PlayerPrefs.GetInt("HighScore4").ToString() + " Points";
        HighScoreText5.text = PlayerPrefs.GetInt("HighScore5").ToString() + " Points";

    }

    // Update is called once per frame
    void Update()
    {

    }
}
