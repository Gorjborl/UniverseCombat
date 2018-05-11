using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] Enemies;
    public Vector3 SpawnValues;
    public float SpawnWait;
    public float SpawnMostWait;
    public float SpawnLeastWait;
    public int StartWait;
    public bool stop;
    public int EnemiesSpawned = 0;
    public int MaxEnemies;

    int RandEnemy;

	// Use this for initialization
	void Start () {

        StartCoroutine(WaitSpawner());

	}
	
	// Update is called once per frame
	void Update () {

        SpawnWait = Random.Range(SpawnLeastWait, SpawnMostWait);

        if(EnemiesSpawned == MaxEnemies)
        {
            stop = true;
        }
        else
        {
            stop = false;
        }
        
	}

    IEnumerator WaitSpawner()
    {
        yield return new WaitForSeconds(StartWait);

        while (!stop)
        {
            RandEnemy = Random.Range(0, 4);
            Vector3 SpawnPosition = new Vector3(Random.Range(-18, 18),0, 60 );
            Instantiate(Enemies[RandEnemy], SpawnPosition , Quaternion.identity);
            EnemiesSpawned++;
            yield return new WaitForSeconds(SpawnWait);

        }
    }


}
