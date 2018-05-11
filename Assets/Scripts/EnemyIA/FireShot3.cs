using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShot3 : MonoBehaviour
{

    public GameObject fireball;
    
    

    // Use this for initialization
    void Start()
    {
        fireball = this.GetComponent<GameObject>();
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += new Vector3(0, 0, -0.6f);

        if (transform.position.x >= 20)
        {
            Destroy(this.gameObject);
        }

        if (transform.position.x <= -20)
        {
            Destroy(this.gameObject);
        }

        if (transform.position.z <= -12)
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
