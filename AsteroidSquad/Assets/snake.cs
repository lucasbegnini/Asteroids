using UnityEngine;
using System.Collections;

public class snake : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.childCount < 1) {
			Destroy(gameObject);	
		}
	}

	void OnCollisionEnter2D(Collision2D c){
		if (c.gameObject.tag == "Player") {
			c.gameObject.GetComponent<CheckCollisionWithAsteroids>().TakeDamage(100);	
		}
	}
}
