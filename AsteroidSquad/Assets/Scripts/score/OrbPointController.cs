using UnityEngine;
using System.Collections;

public class OrbPointController : MonoBehaviour {
	private scoreController scoreControllerRef;
	private Vector3 playerPos;
	GameObject player;
	public GameObject particle;
	private float time;
	private float speed;
	// Use this for initialization
	void Start () {
		scoreControllerRef = GameObject.Find ("score").GetComponent<scoreController> ();
		speed = Random.Range (6f, 10f);
		time =Random.Range(0.2f,0.5f);
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		time -= Time.deltaTime;
		playerPos = player.transform.position;
		Vector2 direction = new Vector2(playerPos.x-transform.position.x,playerPos.y-transform.position.y);
		direction.Normalize();
		float distance = Vector2.Distance(transform.position,playerPos);
		Vector3 velocity = direction*speed;
		if (time < 0) {
				rigidbody2D.velocity =  (velocity);
		}


	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			rigidbody2D.velocity = Vector2.zero;
			GameObject p = Instantiate(particle) as GameObject;
			p.transform.position = transform.position;
			p.transform.position -= Vector3.forward*20;
			scoreControllerRef.AddToScore(1);
			GameObject.Destroy(gameObject);

		}
	}
}
