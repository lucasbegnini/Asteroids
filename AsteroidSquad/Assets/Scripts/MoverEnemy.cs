using UnityEngine;
using System.Collections;

public class MoverEnemy : MonoBehaviour {
	public float velocity;
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
}
