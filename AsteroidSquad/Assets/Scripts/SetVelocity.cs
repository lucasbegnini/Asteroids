using UnityEngine;
using System.Collections;

public class SetVelocity : MonoBehaviour {
	public float velocity;
	public float rotation;
	// Use this for initialization
	void Start () {
		int angle = Random.Range (0, 359);
		float dirx = velocity*Mathf.Cos(angle*Mathf.Deg2Rad);
		float diry = velocity*Mathf.Sin(angle*Mathf.Deg2Rad);
		Vector2 direction = new Vector2(dirx,diry);
		rigidbody2D.velocity = direction;
		rigidbody2D.angularVelocity = rotation;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
