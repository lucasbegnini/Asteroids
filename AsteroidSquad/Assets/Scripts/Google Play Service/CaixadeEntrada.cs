using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using System.Collections.Generic;
using GooglePlayGames.BasicApi.Multiplayer;
using System;


public class CaixadeEntrada : MonoBehaviour {


	void Start () {
	
	}
	void OnMouseDown()
	{

		Conexao.AcceptFromInbox ();
	}

	// Update is called once per frame
	void Update () {

	}

}
