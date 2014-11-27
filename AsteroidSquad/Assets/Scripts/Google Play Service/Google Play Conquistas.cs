using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GooglePlayConquistas : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		VerificarConquista ();
	}

	void VerificarConquista()
	{
		if (PlayerPrefs.GetFloat ("your score") >= 5) 
		{
			Social.ReportProgress("CgkIr7PsmY8CEAIQAA", 100.0f, (bool success) => {
				// handle success or failure
			});
		}

		if (PlayerPrefs.GetFloat ("your score") >= 10) 
		{
			Social.ReportProgress("CgkIr7PsmY8CEAIQAg", 100.0f, (bool success) => {
				// handle success or failure
			});
		}

		if (PlayerPrefs.GetFloat ("your score") >= 20) 
		{
			Social.ReportProgress("CgkIr7PsmY8CEAIQAw", 100.0f, (bool success) => {
				// handle success or failure
			});
		}

		if (PlayerPrefs.GetFloat ("your score") >= 40) 
		{
			Social.ReportProgress("CgkIr7PsmY8CEAIQBA", 100.0f, (bool success) => {
				// handle success or failure
			});
		}

		if (PlayerPrefs.GetFloat ("your score") >= 100) 
		{
			Social.ReportProgress("CgkIr7PsmY8CEAIQBQ", 100.0f, (bool success) => {
				// handle success or failure
			});
		}

		if (PlayerPrefs.GetFloat ("your score") >= 1) 
		{
			Social.ReportProgress("CgkIr7PsmY8CEAIQBg", 100.0f, (bool success) => {
				// handle success or failure
			});
		}

	}
}
