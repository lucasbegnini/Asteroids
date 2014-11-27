using UnityEngine;
using System.Collections;

public class Pauseble : MonoBehaviour {

	private Vector2 initVelocity;
	private float initAngVelocity;

	void Start () {
	
	}

	public void Pause(){
		if(GetComponent<Rigidbody2D>()!=null){
			initVelocity = rigidbody2D.velocity;
			initAngVelocity = rigidbody2D.angularVelocity;
			rigidbody2D.velocity = Vector2.zero;
			rigidbody2D.angularVelocity = 0;
		}

		if(GetComponent<Animator>() != null){
			GetComponent<Animator>().enabled = false;
		}

		if(tag=="Player"){
			GetComponent<ShipMovement>().enabled = false;
			GetComponent<Shoot>().enabled = false;
			GetComponent<Animator>().enabled = false;
		}
	}

	public void Despause(){
		if(GetComponent<Rigidbody2D>()!=null){
			rigidbody2D.velocity = initVelocity;
			rigidbody2D.angularVelocity = initAngVelocity;
		}
		if(GetComponent<Animator>() != null){
			GetComponent<Animator>().enabled = true;
		}

		if(tag=="Player"){
			GetComponent<ShipMovement>().enabled = true;
			GetComponent<Shoot>().enabled = true;
			GetComponent<Animator>().enabled = true;
		}

	}
}
