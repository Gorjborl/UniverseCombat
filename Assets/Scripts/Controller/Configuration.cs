using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Configuration : MonoBehaviour {

    public GameObject Ship;
    public Slider SensibilitySlider;
    public Text Title;


    // Touch Variables
    public float sensivity;

    // Use this for initialization
    void Start () {

        SensibilitySlider.value = PlayerPrefs.GetFloat("Sensivity");
        if (PlayerPrefs.GetInt("FirstLoad") != 1)
        {
            Title.text = "Welcome";
        }

        if (PlayerPrefs.GetInt("FirstLoad") == 1)
        {
            Title.text = "Configuration";
        }


    }
	
	// Update is called once per frame
	void Update () {

        PlayerPrefs.SetFloat("Sensivity", sensivity);
        AdjustSensibility();
        UserInput();


	}

    void UserInput()
    {

#if UNITY_IOS || UNITY_ANDROID
                
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                // Get movement of the finger since last frame
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

                // Move object across XY plane
                transform.Translate(touchDeltaPosition.x * sensivity, 0, touchDeltaPosition.y * sensivity);
                CheckValidPosition();


        }
#endif

    }

    void AdjustSensibility()
    {
        sensivity = SensibilitySlider.value;
    }

    void CheckValidPosition()
    {
        if (transform.position.x >= -19)
        {

        } else
        {
            transform.position += new Vector3(2, 0, 0);
        }


        if (transform.position.x <= 19)
        {

        } else
        {
            transform.position += new Vector3(-2, 0, 0);
        }

        if (transform.position.z >= -7)
        {

        }
        else
        {
            transform.position += new Vector3(0, 0, 2);
        }


        if (transform.position.z <= 53)
        {

        }
        else
        {
            transform.position += new Vector3(0, 0, -2);
        }
    }

    public void ExitConfig()
    {
        PlayerPrefs.SetInt("FirstLoad", 1);
        Application.LoadLevel("Intro");
    }

}
