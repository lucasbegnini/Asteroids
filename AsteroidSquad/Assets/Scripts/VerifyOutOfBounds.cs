using UnityEngine;
using System.Collections;

public class VerifyOutOfBounds : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.tag == "edgeleft" || other.tag == "edgeright" || other.tag == "edgeup" || other.tag == "edgedown") {
			Destroy(this.gameObject);	
		}
	}
}
