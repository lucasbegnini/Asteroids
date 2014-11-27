using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class Inicializar : MonoBehaviour {

	// Use this for initialization
	// Use this for initialization
	void Start () {
		// recommended for debugging:
		PlayGamesPlatform.DebugLogEnabled = true;
		
		// Activate the Google Play Games platform
		PlayGamesPlatform.Activate();
		
		Social.localUser.Authenticate((bool success) => {
			// handle success or failure
		});
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
