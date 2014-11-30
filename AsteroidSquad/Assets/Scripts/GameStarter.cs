using UnityEngine;
using System.Collections;

public class GameStarter : MonoBehaviour {

	public GameObject[] naves; 
	GameObject naveAtual;
	public SpriteRenderer personagem;
	private Vector2 mousePos;
	public Sprite[] personagens;

	void Awake () {
		//Instantiate (naves [SelectArrow.nave]);
		personagem.sprite = personagens [SelectArrow.nave];
	}

	void Start(){
		naveAtual = GameObject.FindGameObjectWithTag("Player");
		GameObject.FindGameObjectWithTag("pauseButton").transform.position += Vector3.right*3;
	}

	void FixedUpdate () {
		CheckForInput ();
		mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
	}

	void CheckForInput(){
		if(Input.GetMouseButtonDown(0)){
			audio.Play();
		//	naveAtual.transform.position = new Vector3 (0,0,0);//(mousePos.x,mousePos.y,naveAtual.transform.position.z);
		//	ActiveShip();
		}
	}

	void ActiveShip(){
		naveAtual.GetComponent<SpriteRenderer>().enabled = true;
		naveAtual.GetComponent<PolygonCollider2D>().enabled = true;
		naveAtual.GetComponent<ShipMovement>().enabled = true;
		naveAtual.GetComponent<Shoot>().enabled = true;
		naveAtual.GetComponent<VirtualJoystick>().enabled = true;
		naveAtual.GetComponent<Animator> ().enabled = true;
		gameObject.GetComponent<GameStarter> ().enabled = false;
		GameObject.FindGameObjectWithTag("pauseButton").transform.position -= Vector3.right*3;
	}
}
