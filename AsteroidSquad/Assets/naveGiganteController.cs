using UnityEngine;
using System.Collections;

public class naveGiganteController : MonoBehaviour {
	public float velocity;
	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = Vector2.right * -velocity;
		foreach (Rigidbody2D r in transform.GetComponentsInChildren<Rigidbody2D>()) {
			r.velocity = Vector2.right * -velocity;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
