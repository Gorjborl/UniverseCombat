using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour {

    public void StartGame()
    {
        Application.LoadLevel("level1");
    }

    void GameOver()
    {
       
    }
	
    
}
