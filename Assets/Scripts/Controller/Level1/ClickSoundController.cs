using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    [RequireComponent(typeof(Button))]
public class ClickSoundController : MonoBehaviour {

    public AudioClip SelectSound;

    private Button button { get { return GetComponent<Button>(); } }
    private AudioSource Source { get { return GetComponent<AudioSource>(); } }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Use this for initialization

    void Start () {
        gameObject.AddComponent<AudioSource>();
        Source.clip = SelectSound;
        Source.playOnAwake = false;
        button.onClick.AddListener( () => PlaySelectSound() );
	}
	
    void PlaySelectSound()
    {
        Source.PlayOneShot(SelectSound);

    }
	// Update is called once per frame
	void Update () {

        

	}
}
