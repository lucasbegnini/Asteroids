using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {
	public float rotation;
	public float maxRotation;
	public float force;
	public float maxVelocity;
	private Animator animRef;
	public AudioSource sfx;
	private int controlType;
	// Use this for initialization
	void Start () {
		sfx.volume = GameObject.Find ("SFX").GetComponent<Volume> ().GetVolume ();
		animRef = GetComponent<Animator> ();
		rigidbody2D.centerOfMass = new Vector2 (0, 0.05f);
		controlType = GameObject.Find ("BGM").GetComponent<Controlls> ().GetControl ();
	}
	
	// Update is called once per frame
	void Update () {
		if (controlType == 1) {
			if (Input.GetKey (KeyCode.LeftArrow)) {
				MoveLeft();	
			} else if (Input.GetKey (KeyCode.RightArrow)) {
				MoveRight();	
			}else{
				rigidbody2D.angularVelocity = 0;
			}
			//Debug.Log (Mathf.Abs((rigidbody2D.rotation + 360)%360));
			if (Input.GetKey (KeyCode.UpArrow)) {
				Thrust();
				animRef.SetBool("acelerando",true);
			}
			else if(Input.touchCount <= 0){
				animRef.SetBool("acelerando",false);
			}
		}else if(controlType == 2){
			rigidbody2D.angularVelocity = Input.acceleration.y;
		}

	}

	public void MoveLeft(){
		if(rigidbody2D.angularVelocity + rotation/10 < maxRotation)
			rigidbody2D.angularVelocity += rotation/10;	
	}
	public void MoveRight(){
		if(rigidbody2D.angularVelocity - rotation/10 > -maxRotation)
			rigidbody2D.angularVelocity -= rotation/10;
	}
	public void Thrust(){
		if (!sfx.isPlaying) {
			sfx.Play();	
		}
		Vector2 vel = rigidbody2D.velocity;
		float angle = rigidbody2D.rotation + 90;
		float dirx = force*Mathf.Cos(angle*Mathf.Deg2Rad)/100;
		float diry = force*Mathf.Sin(angle*Mathf.Deg2Rad)/100;
		Vector2 direction = new Vector2(dirx,diry);
		rigidbody2D.velocity += direction;
		if (rigidbody2D.velocity.magnitude > maxVelocity)
						rigidbody2D.velocity = vel;
	
	}
}
