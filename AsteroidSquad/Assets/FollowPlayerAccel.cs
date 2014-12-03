using UnityEngine;
using System.Collections;

public class FollowPlayerAccel : MonoBehaviour {
	public float distance;
	private GameObject player;
	public float accel;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		Physics2D.IgnoreCollision (player.collider2D, collider2D, true);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 target = player.transform.position - transform.position;
		float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
		float dirx = accel*Mathf.Cos(angle*Mathf.Deg2Rad)/100;
		float diry = accel*Mathf.Sin(angle*Mathf.Deg2Rad)/100;
		Vector2 direction = new Vector2(dirx,diry);
		rigidbody2D.AddForce (direction);
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		//rigidbody2D.rotation -= 90;
	}
}
