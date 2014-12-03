using UnityEngine;
using System.Collections;

public class CheckCollisionWithAsteroids : MonoBehaviour {
	public AudioSource sfx;
	public int hitPoints; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "asteroid" || other.gameObject.tag == "asteroid frag") {
			other.gameObject.GetComponent<AsteroidController>().TakeDamage(200);
			TakeDamage(25);
		}
		if(other.gameObject.tag == "enemyBullet"){
			TakeDamage(other.gameObject.GetComponent<BulletController>().Damage);
			Destroy(other.gameObject);
		}
	}

	public void TakeDamage(int damage){
		//GetComponent<PolygonCollider2D> ().enabled = false;
		Physics2D.IgnoreLayerCollision (0, 9, true);
		Invoke ("DeactiveCollider", 1.5f);
		hitPoints -= Mathf.Abs (damage);
		if(hitPoints<1){
			die();
			GameObject.FindGameObjectWithTag("pauseButton").transform.position += Vector3.right*3;
			GameObject.FindGameObjectWithTag("pauseButton").GetComponent<PauseButton>().enabled = false;
			GoGameOver();
		}else{
			GetComponent<Animator>().SetBool("takeDamage",true);
		}
	}

	void DeactiveCollider(){
		Physics2D.IgnoreLayerCollision (0, 9, false);
		GetComponent<Animator>().SetBool("takeDamage",false);
	}

	void die(){
		sfx.volume = PlayerPrefs.GetFloat("SFXVolume");
		sfx.Play ();
		GameObject [] points = GameObject.FindGameObjectsWithTag("orb");
		foreach(GameObject p in points){
			GameObject.Destroy(p);
		}
		Camera.main.GetComponent<CameraFollower> ().shake (5, 0.2f, 0.8f);
		gameObject.GetComponent<Animator>().SetTrigger( "explodir" );
		rigidbody2D.velocity = Vector2.zero;
		rigidbody2D.rotation = 0;
		rigidbody2D.isKinematic = true;
		GetComponent<Shoot>().enabled = false;
		GetComponent<ShipMovement>().enabled = false;
		GetComponent<VirtualJoystick>().enabled = false;
		GetComponent<PolygonCollider2D> ().enabled = false;
	}
	
	void GoGameOver()
	{
		GameObject.Find ("game over").GetComponent<DinamicImage> ().Enter ();
		try{GameObject.Find ("botoes").GetComponent<DinamicImage> ().Enter ();}catch{}
		//GameObject.Find ("score").GetComponent<scoreController> ().SetTextScore ();
		//GameObject.Find ("score").GetComponent<TextMesh> ().color = Color.black;
		//GameObject.Find ("score").transform.position += Vector3.down * 0.9f;
	}
}
