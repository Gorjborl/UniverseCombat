using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
        if (PlayerPrefs.GetInt("FirstLoad") != 1)
        {
            Application.LoadLevel("Config");
        }

        if (PlayerPrefs.GetInt("FirstLoad") == 1)
        {
            Application.LoadLevel("Intro");
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
