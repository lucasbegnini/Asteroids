using UnityEngine;
using System.Collections;

public class ShootFourBullets : MonoBehaviour {
	public GameObject shoot;
	public float fireRate;
	public float BulletVelocity;
	public float bulletOffset;
	public bool canShoot=false;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("Shoot", fireRate, fireRate);
	}

	void Shoot(){
		if(canShoot){
			ShootDirection(0);
			ShootDirection(90);
			ShootDirection(180);
			ShootDirection(270);
		}
	}

	void ShootDirection(float dir){
		float angle = rigidbody2D.rotation + dir;
		Vector3 position = new Vector3(transform.position.x+Mathf.Cos(angle*Mathf.Deg2Rad)*bulletOffset,transform.position.y+Mathf.Sin(angle*Mathf.Deg2Rad)*bulletOffset,transform.position.z);
		GameObject NewBullet = Instantiate(shoot, position, transform.rotation) as GameObject;
		NewBullet.rigidbody2D.rotation += dir;
		NewBullet.transform.position += Vector3.forward;
		NewBullet.GetComponent<VerifyRange> ().setRange (3);
		NewBullet.GetComponent<BulletController> ().Damage = 1;
		NewBullet.rigidbody2D.rotation -= 90;
		float dirx = BulletVelocity*Mathf.Cos(angle*Mathf.Deg2Rad);
		float diry = BulletVelocity*Mathf.Sin(angle*Mathf.Deg2Rad);
		NewBullet.rigidbody2D.velocity = new Vector2(dirx,diry) + rigidbody2D.velocity;
		Physics2D.IgnoreCollision(NewBullet.collider2D, collider2D);
	}
}
