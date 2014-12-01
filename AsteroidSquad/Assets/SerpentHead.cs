using UnityEngine;
using System.Collections;

public class SerpentHead : MonoBehaviour {
	public float velocity;
	public float angular;

	
	void FixedUpdate () {
//			if (Input.GetMouseButtonDown (0)) {
//				Direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//				Vector3 target = Direction - rigidbody2D.position;
//				float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
//				transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
//			}
//			rigidbody2D.velocity = Direction - rigidbody2D.position;
		float angle = rigidbody2D.rotation;
		float dirx = velocity*Mathf.Cos(angle*Mathf.Deg2Rad)/100;
		float diry = velocity*Mathf.Sin(angle*Mathf.Deg2Rad)/100;
		Vector2 direction = new Vector2(dirx,diry);
		rigidbody2D.velocity = direction;
		if(Input.GetKey(KeyCode.LeftArrow)){
			rigidbody2D.angularVelocity = angular;
		}
		if(Input.GetKey(KeyCode.RightArrow)){
			rigidbody2D.angularVelocity = -angular;
		}

	}
}
