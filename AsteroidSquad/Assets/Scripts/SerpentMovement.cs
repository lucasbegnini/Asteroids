using UnityEngine;
using System.Collections;

public class SerpentMovement : MonoBehaviour {
	public Transform Target;
	public float Distance;
	private Vector2 Direction;
	public float velocity;
	public float angular;
	public float angularVariation;
	private GameObject player;
	// Use this for initialization
	void Start () {
		Physics2D.IgnoreLayerCollision (11, 11, true);
		player = GameObject.FindGameObjectWithTag ("Player");
		rigidbody2D.angularVelocity = angular;
	}


	void FixedUpdate () {
		if (Target != null) {
			Direction = Target.position;
			Vector3 target = Direction - rigidbody2D.position;
			float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.AngleAxis(angle, Vector3.forward),Time.deltaTime);
			rigidbody2D.velocity = (Direction - rigidbody2D.position)/Distance;
			rigidbody2D.rotation = Target.parent.rigidbody2D.rotation;
		}else{
			float angle = rigidbody2D.rotation;
			float dirx = velocity*Mathf.Cos(angle*Mathf.Deg2Rad)/100;
			float diry = velocity*Mathf.Sin(angle*Mathf.Deg2Rad)/100;
			Vector2 direction = new Vector2(dirx,diry);
			rigidbody2D.velocity = direction;
			Vector3 target = player.rigidbody2D.position - rigidbody2D.position;
			angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
			if(rigidbody2D.rotation < -angularVariation + angle){
				rigidbody2D.angularVelocity = angular;
			}else if(rigidbody2D.rotation > angularVariation + angle){
				rigidbody2D.angularVelocity = -angular;
			}
		}
	}
}
