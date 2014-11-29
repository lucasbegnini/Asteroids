using UnityEngine;
using System.Collections;

public class CheckCollisionWithAsteroids : MonoBehaviour {
	public AudioSource sfx;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.layer == 9) {
			GameObject.FindGameObjectWithTag("pauseButton").transform.position += Vector3.right*3;
			GameObject.FindGameObjectWithTag("pauseButton").GetComponent<PauseButton>().enabled = false;
			die();
			GoGameOver();
		}

	}

	void die(){
		sfx.volume = GameObject.Find ("SFX").GetComponent<Volume> ().GetVolume ();
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
		GameObject.Find ("botoes").GetComponent<DinamicImage> ().Enter ();
		//GameObject.Find ("score").GetComponent<scoreController> ().SetTextScore ();
		//GameObject.Find ("score").GetComponent<TextMesh> ().color = Color.black;
		//GameObject.Find ("score").transform.position += Vector3.down * 0.9f;
	}
}
