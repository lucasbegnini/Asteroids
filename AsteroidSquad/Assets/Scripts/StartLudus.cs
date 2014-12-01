using UnityEngine;
using System.Collections;

public class StartLudus : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetFloat ("SFXVolume", 0.5f);
		PlayerPrefs.SetFloat ("BGMVolume", 0.5f);
		PlayerPrefs.SetInt ("Controls", 1);
	
	}
}
