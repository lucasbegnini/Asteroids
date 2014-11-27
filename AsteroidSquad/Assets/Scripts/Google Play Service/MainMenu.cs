using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi.Multiplayer;


public class MainMenu : MonoBehaviour {



	// Use this for initialization
	void Start () {

		InvitationManager.Instance.Setup();
	
	}
	
	// Update is called once per frame
	void Update () {
	
		// if an invitation arrived, switch to the "invitation incoming" GUI
		// or directly to the game, if the invitation came from the notification
		Invitation inv = InvitationManager.Instance.Invitation;
		if (inv != null) {
			if (InvitationManager.Instance.ShouldAutoAccept) {
				// jump straight into the game, since the user already indicated
				// they want to accept the invitation!
				InvitationManager.Instance.Clear();
				Conexao.AcceptInvitation(inv.InvitationId);
				Application.LoadLevel("Select Player");
				//gameObject.GetComponent<RaceGui>().MakeActive();
			} else {
				// show the "incoming invitation" screen
				//gameObject.GetComponent<IncomingInvitationGui>().MakeActive();
			}
		}
	}
}
