using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioController : MonoBehaviour {

    public GameObject[] Planets;
    private GameObject CurrentPlanet;
    private int RandPlanet;
    Vector3 SpawnPosition;

    private void Start()
    {
        PlanetInstantiate();
    }

    private void Update()
    {                
        CurrentPlanet.transform.position += new Vector3(0, 0, -0.1f);

        if(CurrentPlanet.transform.position.z <= -50)
        {
            Destroy(CurrentPlanet.gameObject);
            PlanetInstantiate();
        }
        
    }   
        
    void PlanetInstantiate()
    {
        RandPlanet = Random.Range(0, 5);
        SpawnPosition = new Vector3(Random.Range(-45, 45), -50f, 130);
        CurrentPlanet = Instantiate(Planets[RandPlanet],SpawnPosition,Quaternion.identity);
    }

}
