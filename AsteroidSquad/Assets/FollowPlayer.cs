using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	public float range;
	private GameObject player;
	public int damage;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(transform.position, player.transform.position) < range){
			Vector3 target = player.transform.position - transform.position;
			float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
	}

	void OnCollisionEnter2D(Collision2D c){
		if (c.gameObject.tag == "Player") {
			c.gameObject.GetComponent<CheckCollisionWithAsteroids>().TakeDamage	(damage);
		}
	}
}
