using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShot1Level2 : MonoBehaviour {

    public GameObject fireball1;
    private Vector3 ColPosition;
    public int ShipsDestroyed = 0;
    public int Score = 0;

    public Vector3 DropPos;

    
    // Use this for initialization
    void Start () {
        
        fireball1 = this.GetComponent<GameObject>();
        
	}
	
	// Update is called once per frame
	void Update () {

        transform.position += new Vector3(0, 0, 0.6f);
        if(transform.position.z > 65)
        {
            Destroy(this.gameObject);
        }
        
        
	}

    
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Asteroid")
        {
            FindObjectOfType<BasicControls2>().PlayExplosionAudio();
            DestroyObject(gameObject);
            Instantiate(Resources.Load("Explosion"), transform.position, Quaternion.identity);
            DropPos = transform.position;
            FindObjectOfType<PowerUp2>().DropProb(DropPos);


        }
    }
    
    
    

}
