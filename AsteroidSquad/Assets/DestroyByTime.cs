using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {
	public float time;
	// Use this for initialization
	void Start () {
		try{audio.volume = GameObject.Find ("SFX").GetComponent<Volume> ().GetVolume ();}catch{}
		Invoke ("DestroyNow", time);
	}
	
	// Update is called once per frame
	void DestroyNow () {
		Destroy (gameObject);
	}
}
