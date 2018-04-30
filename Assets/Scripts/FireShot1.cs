using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShot1 : MonoBehaviour {

    public GameObject fireball1;
    private Vector3 ColPosition;
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
        
        if (collision.gameObject.tag == "EnemyShip")
        {
            Debug.Log("cago");
            DestroyObject(this.gameObject);
            Instantiate(Resources.Load("Explosion"), transform.position, Quaternion.identity);
            DestroyObject(GameObject.FindGameObjectWithTag("EnemyShip"));
            
        }
    }
    


}
