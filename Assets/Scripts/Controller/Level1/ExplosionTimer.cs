using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTimer : MonoBehaviour {

	
	void Update () {


        Destroy(this.gameObject, 1.5f);
	}
}
