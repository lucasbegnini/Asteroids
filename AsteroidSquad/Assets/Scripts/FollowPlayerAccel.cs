using UnityEngine;
using System.Collections;

public class FollowPlayerAccel : MonoBehaviour {
	public float distance;
	private GameObject player;
	public float acceleracao;
	public float maxVelocity;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		Physics2D.IgnoreCollision (player.collider2D, collider2D, true);
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 vel = rigidbody2D.velocity;
		Vector3 target = player.transform.position - transform.position;
		float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
		float dirx = acceleracao*Mathf.Cos(angle*Mathf.Deg2Rad)/100;
		float diry = acceleracao*Mathf.Sin(angle*Mathf.Deg2Rad)/100;
		Vector2 direction = new Vector2(dirx,diry);
		rigidbody2D.velocity += direction;
		if (rigidbody2D.velocity.magnitude > maxVelocity) {
			rigidbody2D.velocity = vel;
		}
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		//rigidbody2D.rotation -= 90;
	}
}
