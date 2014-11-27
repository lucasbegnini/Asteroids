using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using System;
public class Ranking : MonoBehaviour {

	// Use this for initialization
	void Start () {

		
	}
	void OnMouseDown()
	{
		string IdPlacar = "CgkIr7PsmY8CEAIQAQ";
		// post score 12345 to leaderboard ID "Cfji293fjsie_QA")

		Social.ReportScore(Convert.ToInt32(Math.Ceiling(PlayerPrefs.GetFloat("best score"))),"CgkIr7PsmY8CEAIQAQ", (bool sucess) => {
		});
		
		
		//Social.ShowAchievementsUI();
		((PlayGamesPlatform) Social.Active).ShowLeaderboardUI();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
