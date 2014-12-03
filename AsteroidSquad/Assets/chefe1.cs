using UnityEngine;
using System.Collections;

public class chefe1 : MonoBehaviour {
	public float distance;
	private GameObject player;
	public float velocity;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 target = player.transform.position - transform.position;
		float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
		float dirx = velocity*Mathf.Cos(angle*Mathf.Deg2Rad)/100;
		float diry = velocity*Mathf.Sin(angle*Mathf.Deg2Rad)/100;
		Vector2 direction = new Vector2(dirx,diry);
		rigidbody2D.velocity = direction;
		//transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
		//rigidbody2D.rotation -= 90;
	}

	void OnCollisionEnter2D(Collision2D c){
		if (c.gameObject.tag == "Player") {
			c.gameObject.GetComponent<CheckCollisionWithAsteroids>().TakeDamage(100);	
		}
	}
}
