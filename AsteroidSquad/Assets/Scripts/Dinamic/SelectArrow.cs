using UnityEngine;
using System.Collections;

public class SelectArrow : Button {
	static private int numOfPlayers = 3;
	static public int nave;
	public float distance; // distancia de um player para o outro;
	public string direction; //right ou left
	public AudioSource sound;
	private Transform cameraTrans;

	void Start () {
		nave = 1;
		canExitS = false;
		initPos = transform.position;
		Enter ();
		animRef = GetComponent<Animator> ();
		cameraTrans = Camera.main.transform;
		sound.volume = PlayerPrefs.GetFloat("SFXVolume");
		audio.volume = PlayerPrefs.GetFloat("SFXVolume");

	}

	void OnMouseUpAsButton(){

		sound.Play ();
		Up ();
		Move ();
	}

	void Move(){
		if(direction=="right"){
			if(nave<numOfPlayers){
				nave++;
				cameraTrans.position = new Vector3(cameraTrans.position.x + distance,cameraTrans.position.y,cameraTrans.position.z);
			}else{
				nave = 0;
				cameraTrans.position = new Vector3(-5,cameraTrans.position.y,cameraTrans.position.z);
			}
		}
		if(direction=="left"){
			if((nave>0)){
				nave--;
				cameraTrans.position = new Vector3(cameraTrans.position.x - distance,cameraTrans.position.y, cameraTrans.position.z);
			}else{
				nave = numOfPlayers;
				cameraTrans.position = new Vector3(cameraTrans.position.x + (distance * numOfPlayers),cameraTrans.position.y, cameraTrans.position.z);
			}
		}
	}

}
