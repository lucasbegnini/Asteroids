using UnityEngine;
using System.Collections;

public class ShootPlayer : MonoBehaviour {
	public float fireRate;
	public GameObject shoot;
	public float BulletVelocity;
	public int damage;
	public float bulletOffset;
	private GameObject player;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("Shoot", fireRate, fireRate);
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Shoot(){
		Vector3 target = player.transform.position - transform.position;
		float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
		Vector3 position = new Vector3(transform.position.x+Mathf.Cos(angle*Mathf.Deg2Rad)*bulletOffset,transform.position.y+Mathf.Sin(angle*Mathf.Deg2Rad)*bulletOffset,transform.position.z);
		GameObject NewBullet = Instantiate(shoot, position, transform.rotation) as GameObject;
		NewBullet.rigidbody2D.rotation = angle - 90;
		NewBullet.GetComponent<VerifyRange> ().setRange (5);
		NewBullet.GetComponent<BulletController> ().Damage = damage;
		float dirx = BulletVelocity*Mathf.Cos(angle*Mathf.Deg2Rad);
		float diry = BulletVelocity*Mathf.Sin(angle*Mathf.Deg2Rad);
		NewBullet.rigidbody2D.velocity = new Vector2(dirx,diry) + rigidbody2D.velocity;
		Physics2D.IgnoreCollision(NewBullet.collider2D, collider2D);
	}
}
