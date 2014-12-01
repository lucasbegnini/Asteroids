using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {
	public float rotation;
	public float maxRotation;
	public float force;
	public float maxVelocity;
	private Animator animRef;
	public AudioSource sfx;
	private int controlType=1;
	// Use this for initialization
	void Start () {
		sfx.volume = PlayerPrefs.GetFloat("SFXVolume");
		animRef = GetComponent<Animator> ();
		rigidbody2D.centerOfMass = new Vector2 (0, 0.05f);
		controlType = PlayerPrefs.GetInt("Controls");
	}
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD
		if (Input.GetKey(KeyCode.LeftArrow)) {
			MoveLeft();	

		} else if (Input.GetKey(KeyCode.RightArrow)) {
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
=======
		if (controlType == 1) {
			if (Input.GetKey (KeyCode.LeftArrow)) {
				MoveLeft(1);	
			} else if (Input.GetKey (KeyCode.RightArrow)) {
				MoveRight(1);	
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
			//if(-Input.acceleration.x * rotation > maxRotation && -Input.acceleration.x * rotation < -maxRotation){
				rigidbody2D.angularVelocity = Mathf.Round((-Input.acceleration.x * rotation)*10)/10;
				Debug.Log(rigidbody2D.angularVelocity);
			//}
>>>>>>> ed3a1afdb752202e18b726b533528f6951e5c03d
		}

	}

	public void MoveLeft(float x){
		if(rigidbody2D.angularVelocity + rotation/10 < maxRotation){
			rigidbody2D.angularVelocity += x*rotation/10;	

		}
	}
	public void MoveRight(float x){
		if(rigidbody2D.angularVelocity - rotation/10 > -maxRotation)
			rigidbody2D.angularVelocity -= x*rotation/10;
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
