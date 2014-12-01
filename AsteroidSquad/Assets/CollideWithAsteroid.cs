using UnityEngine;
using System.Collections;

public class CollideWithAsteroid : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D c){
		if (c.gameObject.tag == "asteroid") {
			Destroy(gameObject);	
		}
	}
}
