using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi.Multiplayer;
using System.Collections.Generic;
using System;

	public class Conexao : RealTimeMultiplayerListener {

	const int MinOpponents = 1;
	const int MaxOpponents = 3;
	const int QuickGameOpponents = 1;

	private bool mShouldAutoAccept = false;
	private bool mSetupDone = false;
	// Use this for initialization
	private Invitation mInvitation = null;

	const int GameVariant = 0;

	const string RaceTrackName = "RaceTrack";
	
	static Conexao sInstance = null;

	// my participant ID
	private string mMyParticipantId = "";
	
	// room setup progress
	private float mRoomSetupProgress = 0.0f;
	// speed of the "fake progress" (to keep the player happy)
	// during room setup
	const float FakeProgressSpeed = 1.0f;
	const float MaxFakeProgress = 30.0f;
	float mRoomSetupStartTime = 0.0f;

	
	public enum GameState { SettingUp, Playing, Finished, SetupFailed, Aborted };
	private GameState mGameState = GameState.SettingUp;




	public void OnRoomConnected(bool sucess)
	{
		if (sucess) {
			mGameState = GameState.Playing;
			mMyParticipantId = GetSelf().ParticipantId;
		
			SetupGame();
			
		} else {
			mGameState = GameState.SetupFailed;
			
		}
		
	}

	private void SetupGame()
	{
		Application.LoadLevel("Player Select");
		//BehaviorUtils.MakeVisible (GameObject.Find (RaceTrackName), true);
	}


	private Participant GetSelf() {
		return PlayGamesPlatform.Instance.RealTime.GetSelf();
	}
	
	private List<Participant> GetPlayers() {
		return PlayGamesPlatform.Instance.RealTime.GetConnectedParticipants();
	}


	private Conexao() 
	{
		mRoomSetupStartTime = Time.time;
	}

	public static void CreateWithInvitationScreen() {
		sInstance = new Conexao();
		PlayGamesPlatform.Instance.RealTime.CreateWithInvitationScreen(MinOpponents, MaxOpponents,
		                                                               GameVariant, sInstance);
	}

	public static void CreateQuickGame() {
		sInstance = new Conexao();
		PlayGamesPlatform.Instance.RealTime.CreateQuickGame(QuickGameOpponents, QuickGameOpponents,
		                                                    GameVariant, sInstance);
	}

	public static void AcceptFromInbox() {
		sInstance = new Conexao();

		PlayGamesPlatform.Instance.RealTime.AcceptFromInbox(sInstance);//AcceptFromIbox recebe como param RealTimeMultiplayerListener da uma olhada!!!
	}

	public GameState State {
		get {
			return mGameState;
		}
	}
	
	public static Conexao Instance {
		get {
			return sInstance;
		}
	}



	public static void AcceptInvitation(string invitationId) {
		sInstance = new Conexao();
		PlayGamesPlatform.Instance.RealTime.AcceptInvitation(invitationId, sInstance);
	}
	
	public void OnPeersConnected(string[] peers) {
	}
	
	public void OnPeersDisconnected(string[] peers) {

	}

	public void OnRoomSetupProgress(float progress) {
		// update progress bar
		// (progress goes from 0.0 to 100.0)
	}

	public void OnLeftRoom() {

	}

	public void OnRealTimeMessageReceived(bool isReliable, string senderId, byte[] data) {

	}


}
