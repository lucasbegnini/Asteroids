using UnityEngine;
using System.Collections;

public class RandomMathmaker : MonoBehaviour {
	
	private string NameNave;
	private GameStarter gamestarter;
	//Propriedades para os asteroids
	public Vector4 borders;
	public int NumeroDeAsteroids;
	public GameObject AsteroidPrefab;
	// Use this for initialization
	void Start () {
	
		PhotonNetwork.ConnectUsingSettings("0.1");
	}

	void OnGUI()
	{
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}

	void OnJoinedLobby()
	{
		PhotonNetwork.JoinRandomRoom();
	}

	void OnPhotonRandomJoinFailed()
	{
		Debug.Log("Can't join random room!");
		PhotonNetwork.CreateRoom(null);
	}



	void OnJoinedRoom()
	{
		//Cria os Asteroids para todos
		for(int i = 0;i<NumeroDeAsteroids;i++){
			PhotonNetwork.Instantiate(AsteroidPrefab.name,new Vector3(Random.Range(borders.x,borders.y),Random.Range(borders.z,borders.w), transform.position.z), Quaternion.identity, 0);
		}
		// Cria a Nave
		NameNave = FindObjectOfType<GameStarter> ().naves[SelectArrow.nave].name.ToString ();
		Debug.Log(NameNave);

		GameObject nave = PhotonNetwork.Instantiate(NameNave, Vector3.zero, Quaternion.identity, 0);


		ShipMovement controller = nave.GetComponent<ShipMovement>();
		controller.enabled = true;
	//	CameraFollower camera = nave.GetComponent<CameraFollower>();
	//	camera.enabled = true;
		Shoot shoot = nave.GetComponent<Shoot> ();
		shoot.enabled = true;
	}
	// Update is called once per frame
	void Update () {
	
	}

}
