using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {
	public bool Buttons=true;
	// Use this for initialization
	void Update(){
		if (Buttons) {
			if(PlayerPrefs.GetInt("Controls") == 1){
				GetComponent<TextMesh>().color = Color.red;
			}else{
				GetComponent<TextMesh>().color = Color.white;
			}	
		}else{
			if(PlayerPrefs.GetInt("Controls") == 2){
				GetComponent<TextMesh>().color = Color.red;
			}else{
				GetComponent<TextMesh>().color = Color.white;
			}	
		}
	}
	void OnMouseDown(){
		PlayerPrefs.SetInt ("Controls", Buttons?1:2);
	}
}
