using UnityEngine;
using System.Collections;

public class GooglePlayLogin : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnMouseDown()
	{
		
		// authenticate user:
		Social.localUser.Authenticate((bool success) => {
			// handle success or failure
		});
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
