using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    public float speed;
    private float MoveSpeed;
    public Vector3 DropPos;
    

    // Use this for initialization
    void Start () {

        transform.rotation = Random.rotation;
        if ( speed != 0)
        {
            MoveSpeed = 1 + speed + 0.5f*( FindObjectOfType<BasicControls2>().Level -1 );
        } else if (speed == 0)
        {
            MoveSpeed = 1;
        }
        
        

    }
	
	// Update is called once per frame
	void Update () {

        transform.position += new Vector3(0, 0, -0.5f * MoveSpeed);

        if (transform.position.z <= -12)
        {
            Destroy(gameObject);
            FindObjectOfType<BasicControls2>().Score += 1 * FindObjectOfType<BasicControls2>().Level;
        }

        

        
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject.tag == "PlayerShip")
        {
            Destroy(gameObject);
            Instantiate(Resources.Load("Explosion"), transform.position, Quaternion.identity);            
            FindObjectOfType<BasicControls2>().UpdateForceShieldStat();
            FindObjectOfType<BasicControls2>().Score += 1 * FindObjectOfType<BasicControls2>().Level;
            FindObjectOfType<BasicControls2>().PlayHitAudio();
            DropPos = transform.position;
            FindObjectOfType<PowerUp2>().DropProb(DropPos);
        }

        if (collision.gameObject.tag == "Shoot")
        {
            Destroy(gameObject);
            Instantiate(Resources.Load("Explosion"), transform.position, Quaternion.identity);
            FindObjectOfType<BasicControls2>().PlayExplosionAudio();
            FindObjectOfType<BasicControls2>().Score += 1 * FindObjectOfType<BasicControls2>().Level;
        }
    }

}
