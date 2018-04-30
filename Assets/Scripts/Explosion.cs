using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	// Use this for initialization
	void Start () {

        DestroyObject(this.gameObject, 1.5f);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
