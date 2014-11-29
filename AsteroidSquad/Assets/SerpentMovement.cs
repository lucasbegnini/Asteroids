using UnityEngine;
using System.Collections;

public class SerpentMovement : MonoBehaviour {
	public Transform Target;
	public float Distance;
	private Vector2 Direction;
	// Use this for initialization
	void Start () {

	}


	void FixedUpdate () {
		Direction = Target.position;
		Vector3 target = Direction - rigidbody2D.position;
		float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		rigidbody2D.velocity = (Direction - rigidbody2D.position)/Distance;
	}
}
