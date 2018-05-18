using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroMusic : MonoBehaviour
{
    private AudioSource Audio;
    private GameObject IntroAudioContainer;
    static bool AudioBegin = false;

    
    void Awake()
    {        
        if (!AudioBegin)
        {
            Audio = this.GetComponent<AudioSource>();
            Audio.Play();
            DontDestroyOnLoad(gameObject);
            AudioBegin = true;
        }
    }
    void Update()
    {
        if (Application.loadedLevelName == "Level1")
        {
            Audio.Pause();
            Destroy(this.gameObject);
            AudioBegin = false;
        }
    }
}



