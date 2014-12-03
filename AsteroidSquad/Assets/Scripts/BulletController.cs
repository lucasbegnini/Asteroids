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
		try{audio.volume = PlayerPrefs.GetFloat("SFXVolume");}catch{}
		audio.Play ();
		Physics2D.IgnoreLayerCollision (10, 10, true);
	}

	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "asteroid" || coll.gameObject.tag == "asteroid frag"){
			coll.gameObject.GetComponent<AsteroidController>().TakeDamage(damage);
			die ();
			if(shakeOnHit)
				Camera.main.GetComponent<CameraFollower> ().shake (10, 0.1f, 0.5f);
			Instantiate(hitExplosion,transform.position,Quaternion.Euler(Vector3.zero));
		}
		if (coll.gameObject.tag == "enemies") {
			coll.gameObject.GetComponent<TakeDamage>().takeDamage(damage);
			die ();
			if(shakeOnHit)
				Camera.main.GetComponent<CameraFollower> ().shake (10, 0.1f, 0.5f);
			Instantiate(hitExplosion,transform.position,Quaternion.Euler(Vector3.zero));
		}
	}

	void die(){
		GameObject.Destroy (gameObject);
	}
}
