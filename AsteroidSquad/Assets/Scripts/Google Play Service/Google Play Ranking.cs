using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GooglePlayRanking : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void OnMouseDown()
	{
		string IdPlacar = "CgkIr7PsmY8CEAIQAQ";
		// post score 12345 to leaderboard ID "Cfji293fjsie_QA")

		Social.ReportScore(PlayerPrefs.GetInt("highscore"), "CgkIr7PsmY8CEAIQAQ", (bool success) => {
			// handle success or failure
		});

		
		//Social.ShowAchievementsUI();
		((PlayGamesPlatform) Social.Active).ShowLeaderboardUI();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
