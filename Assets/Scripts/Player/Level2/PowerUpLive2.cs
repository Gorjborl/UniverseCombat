using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpLive2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, 4.5f);
        transform.position += new Vector3(0, 0, -0.1f);

        if (transform.position.z <= -12)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerShip")
        {
            FindObjectOfType<BasicControls2>().PlayerLives++;
            Destroy(gameObject);
            FindObjectOfType<BasicControls2>().PlayPowerUpAudio();
        }
    }
}
