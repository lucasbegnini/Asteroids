using UnityEngine;
using System.Collections;

public class WrapEffect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay2D(Collider2D other) {
		if (other.tag == "edgeleft") {
			float x = (-0.98f)*transform.position.x;
			transform.position = new Vector3(x,transform.position.y,transform.position.z);
		}
		if (other.tag == "edgeright") {
			float x = (-0.98f)*transform.position.x;
			transform.position = new Vector3(x,transform.position.y,transform.position.z);
		}
		if (other.tag == "edgeup") {
			float y = (-0.98f)*transform.position.y;
			transform.position = new Vector3(transform.position.x,y,transform.position.z);
		}
		if (other.tag == "edgedown") {
			float y = (-0.98f)*transform.position.y;
			transform.position = new Vector3(transform.position.x,y,transform.position.z);
		}
	}
}
