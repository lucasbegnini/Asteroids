using UnityEngine;
using System.Collections;

public class CollideWithAsteroid : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D c){
		if (c.gameObject.tag == "asteroid") {
			Destroy(gameObject);	
		}
	}
}
