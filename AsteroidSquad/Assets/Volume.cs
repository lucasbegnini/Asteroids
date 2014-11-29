using UnityEngine;
using System.Collections;

public class Volume : MonoBehaviour {
	private float volume=0.5f;

	public void SetVolume(float v){
		volume = v;
	}

	public float GetVolume(){
		return volume;
	}
}