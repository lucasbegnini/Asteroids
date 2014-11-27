using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {
	public GameObject[] buttons;
	private ShipMovement shipmov;
	private Shoot shoot;
	private GameObject leftButton;
	private GameObject rightButton;
	private GameObject upButton;
	private GameObject fireButton;
	// Use this for initialization
	void Start () {
		shipmov = GetComponent<ShipMovement> ();
		shoot = GetComponent<Shoot> ();
		leftButton = GameObject.FindGameObjectWithTag("left button");
		rightButton = GameObject.FindGameObjectWithTag("right button");
		fireButton = GameObject.FindGameObjectWithTag("fire button");
		upButton = GameObject.FindGameObjectWithTag("thrust button");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			for(int i = 0; i < Input.touchCount; i++) {
				Vector3 mouse = Camera.main.ScreenToWorldPoint (Input.touches[i].position);

				if (fireButton.collider2D.bounds.Contains (mouse)) {
					shoot.shoot();
				}else if (upButton.collider2D.bounds.Contains (mouse)) {
					shipmov.Thrust();
				}else if (leftButton.collider2D.bounds.Contains (mouse)) {
					shipmov.MoveLeft();
				}else if (rightButton.collider2D.bounds.Contains (mouse)) {
					shipmov.MoveRight();
				}
			}
		}

	}
}
