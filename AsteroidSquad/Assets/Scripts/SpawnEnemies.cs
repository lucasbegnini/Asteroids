﻿using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour {
	public GameObject enemy;
	public int numberOfEnemies;
	public float time;
	public Transform LeftEdge;
	public Transform RightEdge;
	public Transform UpEdge;
	public Transform DownEdge;
	private GameStarter gamestarter;
	private bool started=false;
	// Use this for initialization
	void Start () {
		gamestarter = GameObject.Find ("Main Camera").GetComponent<GameStarter> ();

	}

	void Update(){
		if(gamestarter.started && !started){
			InvokeRepeating ("Spawn", time, time);
			started = true;
		}
	}
	
	// Update is called once per frame
	void Spawn () {
		for (int i = 0; i<numberOfEnemies; i++) {
			GameObject e = Instantiate(enemy) as GameObject;
			e.transform.position = new Vector3(Random.Range(LeftEdge.position.x,RightEdge.position.x),
			                                   Random.Range(DownEdge.position.y,UpEdge.position.y),
			                                   e.transform.position.z);
			e.rigidbody2D.rotation = Random.Range(0,359);
		}
	}
}
