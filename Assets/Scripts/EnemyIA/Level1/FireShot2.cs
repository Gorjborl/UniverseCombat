using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShot2 : MonoBehaviour {

    public GameObject fireball1;
    private Vector3 ColPosition;
    private Transform Player;
    private Vector3 Target;
    private Vector3 NormalizedDirection;
    public float speed = 0.6f;
    
	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("PlayerShip").transform;
        Target = new Vector3(Player.position.x, 0, Player.position.z);
        fireball1 = this.GetComponent<GameObject>();

        NormalizedDirection = (Target - transform.position).normalized;
        
	}
	
	// Update is called once per frame
	void Update () {

        transform.position += NormalizedDirection * 1f;
        
        if(transform.position.x >= 20)
        {
            Destroy(this.gameObject);
        }

        if(transform.position.x <= -20)
        {
            Destroy(this.gameObject);
        }

        if(transform.position.z <= -12)
        {
            Destroy(this.gameObject);
        }

        if (transform.position.z >= 60)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "PlayerShip")
        {
            FindObjectOfType<BasicControls>().PlayHitAudio();
            DestroyObject(this.gameObject);
            Instantiate(Resources.Load("Explosion"), transform.position, Quaternion.identity);
            FindObjectOfType<BasicControls>().UpdateForceShieldStat();

        }
    }
    
    


}
