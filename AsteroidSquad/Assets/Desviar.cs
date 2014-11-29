using UnityEngine;
using System.Collections;

public class Desviar : MonoBehaviour {
	public float velocity;
	public float distance;
	public float VelAng;
	public bool desviar=true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float angle = rigidbody2D.rotation;
		float dirx = velocity*Mathf.Cos(angle*Mathf.Deg2Rad)/100;
		float diry = velocity*Mathf.Sin(angle*Mathf.Deg2Rad)/100;
		Vector2 direction = new Vector2(dirx,diry);
		rigidbody2D.velocity = direction;

	}

	void OnTriggerStay2D(Collider2D c){
		if (c.tag == "asteroid") {
			if (desviar) {
				rigidbody2D.angularVelocity = Random.Range(0.0f,1.0f)<=0.5f?-VelAng:VelAng;
			}
			desviar = false;
		}
	}

	void OnTriggerExit2D(Collider2D c){
		desviar = true;
		rigidbody2D.angularVelocity = 0;
	}
}
