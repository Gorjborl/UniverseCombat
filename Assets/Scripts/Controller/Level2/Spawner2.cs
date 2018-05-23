using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour {

    public GameObject[] Enemies;
    public GameObject[] PowerUp;
    public Vector3 SpawnValues;
    public float SpawnWait;
    public float SpawnMostWait;
    public float SpawnLeastWait;
    public int StartWait;
    public bool stop;
    public int EnemiesSpawned = 0;

    private GameObject RandomAsteroid;
    

    int RandEnemy;
    int RandSize;
    int RandSelect;
    int RandPowerUp;
    float RandSpeed;

	// Use this for initialization
	void Start () {

        StartCoroutine(WaitSpawner());

	}
	
	// Update is called once per frame
	void Update () {

        SpawnWait = Random.Range(SpawnLeastWait, SpawnMostWait);
        


    }

    IEnumerator WaitSpawner()
    {
        yield return new WaitForSeconds(StartWait);

        while (!stop)
        {
            RandEnemy = Random.Range(0, 5);
            RandSize = Random.Range(40, 80);
            RandSpeed = Random.Range(0, 1);
            RandPowerUp = Random.Range(0, 3);
            RandSelect = Random.Range(0, 100);
            Vector3 SpawnPosition = new Vector3(Random.Range(-18, 18),0, 60 );
            if(RandSelect < 95)
            {
                RandomAsteroid = Instantiate(Enemies[RandEnemy], SpawnPosition, Quaternion.identity);
                RandomAsteroid.transform.localScale = Vector3.one * RandSize;
                FindObjectOfType<Asteroid>().speed = RandSpeed;
                EnemiesSpawned++;
            }

            if(RandSelect >= 95)
            {
                Instantiate(PowerUp[RandPowerUp], SpawnPosition, Quaternion.identity);
            }
            
            yield return new WaitForSeconds(SpawnWait);

        }
    }


}
