using UnityEngine;
using System.Collections;

public class MenuStarter : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		GetComponent<SceeneChangerButton> ().Enter ();
	
	}
}
