using UnityEngine;
using System.Collections;

public class CollideWithBullet : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D c){
		if(c.tag == "bullet"){
			Destroy(gameObject);
		}
	}
}
