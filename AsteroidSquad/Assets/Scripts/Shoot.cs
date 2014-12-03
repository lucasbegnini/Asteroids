using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	public GameObject bullet;
	public float BulletVelocity;
	public float FireRate;
	public float angleVariation;
	public float range;
	public int damage;
	public float bulletOffset = 0;
	public float offsetX;
	public float offsetY;
	private float nextFire = 0;
	public int shootType;
	private int controlType=1;
	// Use this for initialization
	void Start () {
		controlType = PlayerPrefs.GetInt("Controls");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space) && (controlType == 1)) {
			shoot ();
		}
	}

	public void shoot(){
		switch (shootType) {
		case 0:	
			if(nextFire < Time.fixedTime){
				nextFire = Time.fixedTime + FireRate;
				ShootOneBullet();
			}
		break;
		case 1:
			if(nextFire < Time.fixedTime){
				nextFire = Time.fixedTime + FireRate;
				ShootTwoParallelBullets();
			}
		break;
		}

	}

	void ShootOneBullet(){
		float angle = rigidbody2D.rotation + 90 + Random.Range(-angleVariation,angleVariation);
		Vector3 position = new Vector3(transform.position.x+Mathf.Cos(angle*Mathf.Deg2Rad)*bulletOffset,transform.position.y+Mathf.Sin(angle*Mathf.Deg2Rad)*bulletOffset,transform.position.z);
		GameObject NewBullet = Instantiate(bullet, position, transform.rotation) as GameObject;
		NewBullet.transform.position += Vector3.forward;
		NewBullet.GetComponent<VerifyRange> ().setRange (range);
		NewBullet.GetComponent<BulletController> ().Damage = damage; 
		float dirx = BulletVelocity*Mathf.Cos(angle*Mathf.Deg2Rad);
		float diry = BulletVelocity*Mathf.Sin(angle*Mathf.Deg2Rad);
		NewBullet.rigidbody2D.velocity = new Vector2(dirx,diry) + rigidbody2D.velocity;
		Physics2D.IgnoreCollision(NewBullet.collider2D, collider2D);
	}

	void ShootTwoParallelBullets(){
		float angle = rigidbody2D.rotation + 90 + Random.Range(-angleVariation,angleVariation);
		float posX = transform.GetChild(0).transform.position.x;
		float posY = transform.GetChild(0).transform.position.y;
		Vector3 position = new Vector3(posX,posY,transform.position.z);
		GameObject NewBullet = Instantiate(bullet, position, transform.rotation) as GameObject;
		NewBullet.transform.position += Vector3.forward;
		NewBullet.GetComponent<VerifyRange> ().setRange (range);
		NewBullet.GetComponent<BulletController> ().Damage = damage;
		float dirx = BulletVelocity*Mathf.Cos(angle*Mathf.Deg2Rad);
		float diry = BulletVelocity*Mathf.Sin(angle*Mathf.Deg2Rad);
		NewBullet.rigidbody2D.velocity = new Vector2(dirx,diry) + rigidbody2D.velocity;
		Physics2D.IgnoreCollision(NewBullet.collider2D, collider2D);
		angle = rigidbody2D.rotation + 90 + Random.Range(-angleVariation,angleVariation);
		posX = transform.GetChild(1).transform.position.x;
		posY = transform.GetChild(1).transform.position.y;
		position = new Vector3(posX,posY,transform.position.z);
		NewBullet = Instantiate(bullet, position, transform.rotation) as GameObject;
		NewBullet.transform.position += Vector3.forward;
		NewBullet.GetComponent<BulletController> ().Damage = damage;
		NewBullet.GetComponent<VerifyRange> ().setRange (range);
		dirx = BulletVelocity*Mathf.Cos(angle*Mathf.Deg2Rad);
		diry = BulletVelocity*Mathf.Sin(angle*Mathf.Deg2Rad);
		NewBullet.rigidbody2D.velocity = new Vector2(dirx,diry) + rigidbody2D.velocity;
		Physics2D.IgnoreCollision(NewBullet.collider2D, collider2D);
	}
}
