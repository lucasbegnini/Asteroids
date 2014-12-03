using UnityEngine;
using System.Collections;

public class naveGiganteController : MonoBehaviour {
	public float velocity;
	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = Vector2.right * -velocity;
		foreach (Rigidbody2D r in transform.GetComponentsInChildren<Rigidbody2D>()) {
			r.velocity = Vector2.right * -velocity;
			Physics2D.IgnoreCollision(r.gameObject.collider2D, gameObject.collider2D);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D c){
		if (c.tag == "bullet") {
			GetComponent<TakeDamage>().takeDamage(c.GetComponent<BulletController>().Damage, c);	
			Instantiate(c.GetComponent<BulletController>().hitExplosion, c.transform.position, Quaternion.Euler(Vector3.zero));
			Destroy(c.gameObject);

		}
	}
}
