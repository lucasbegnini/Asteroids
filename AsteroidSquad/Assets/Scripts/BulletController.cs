using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
	public GameObject hitExplosion;
	public bool shakeOnHit;
	private int damage;
	public int Damage{
		get{
			return damage;
		}
		set{
			damage = value;
		}

	}

	void Start () {
		audio.volume = GameObject.Find ("SFX").GetComponent<Volume> ().GetVolume ();
	}

	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll){
		if(coll.gameObject.layer == 9){
			coll.gameObject.GetComponent<AsteroidController>().TakeDamage(damage);
			die ();
			if(shakeOnHit)
				Camera.main.GetComponent<CameraFollower> ().shake (10, 0.1f, 0.5f);
			Instantiate(hitExplosion,transform.position,Quaternion.Euler(Vector3.zero));
		}
	}

	void OnCollisionEnter2D(Collision2D c){
		if(c.collider.gameObject.layer == 9){
			c.collider.gameObject.GetComponent<AsteroidController>().TakeDamage(damage);
			if(shakeOnHit)
				Camera.main.GetComponent<CameraFollower> ().shake (10, 0.1f, 0.5f);
			Instantiate(hitExplosion,transform.position,Quaternion.Euler(Vector3.zero));
		}
	}

	void die(){
		GameObject.Destroy (gameObject);
	}
}
