using UnityEngine;
using System.Collections;

public class SceeneChangerButton : Button {
	public string sceene;
	public AudioSource sound;
	void OnMouseUpAsButton(){
		Up ();
		ExiteAll ();
		sound.volume = GameObject.Find ("SFX").GetComponent<Volume> ().GetVolume ();
		sound.Play ();
		Invoke("Respond",1f);
	}
	
	void Respond(){
		Application.LoadLevel (sceene);
	}
	
}
