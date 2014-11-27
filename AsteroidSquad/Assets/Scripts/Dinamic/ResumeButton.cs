using UnityEngine;
using System.Collections;

public class ResumeButton : Button {

	void OnMouseUpAsButton(){
		Up ();
		Respond ();
	}
	
	void Respond(){
		GameObject.Find ("pause button").GetComponent<PauseButton> ().Respond ();
	}

}
