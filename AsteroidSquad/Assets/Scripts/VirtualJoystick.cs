using UnityEngine;
using System.Collections;

public class VirtualJoystick : MonoBehaviour {
	
	public LayerMask whatIsButton;
	private ShipMovement characterController;
	private Shoot shoot;
	private int controlType=1;
	void Start () {
		characterController = GetComponent<ShipMovement> ();
		shoot = GetComponent<Shoot> ();
		controlType = PlayerPrefs.GetInt("Controls");
	}

	void FixedUpdate () {

		int touchCont = Input.touchCount;
		for(int i = 0 ; i < touchCont;i++){
			
			Touch touch = Input.GetTouch(i);
			RaycastHit hit;
			Vector3 touchPos = Camera.allCameras[1].ScreenToWorldPoint(touch.position);
			if (controlType == 1) {
				if(Physics.Raycast(touchPos,Vector3.forward, out hit,whatIsButton)){
					
					if(hit.collider.tag == "left button")
						characterController.MoveLeft(5);
					else
						if(hit.collider.tag == "right button")
							characterController.MoveRight(5);
					else 

						if(hit.collider.tag == "fire button")
							shoot.shoot();
					if(hit.collider.tag == "thrust button"){
						characterController.Thrust();
						GetComponent<Animator> ().SetBool("acelerando",true);
					}
					else 
						GetComponent<Animator> ().SetBool("acelerando",false);
				}
			}else if(controlType == 2){
				if(touchPos.x > Camera.allCameras[1].transform.position.x){
					characterController.Thrust();
					GetComponent<Animator> ().SetBool("acelerando",true);
				}else{
					GetComponent<Animator> ().SetBool("acelerando",false);
				}
				if(touchPos.x < Camera.allCameras[1].transform.position.x){
					shoot.shoot();
				}
				if(touch.phase == TouchPhase.Ended){
					GetComponent<Animator> ().SetBool("acelerando",false);
				}
			}
		}
	}
}
