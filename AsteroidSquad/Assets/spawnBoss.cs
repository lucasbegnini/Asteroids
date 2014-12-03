using UnityEngine;
using System.Collections;

public class spawnBoss : MonoBehaviour {
	public GameObject [] bosses;
	public float time;
	private int index=-1;
	private GameObject actualboss;
	private bool addBoss=true;
	public Transform LeftEdge;
	public Transform RightEdge;
	public Transform UpEdge;
	public Transform DownEdge;
	// Use this for initialization
	void Start () {

	}

	void SpawnNewBoss(){
		actualboss = Instantiate (bosses [index]) as GameObject;
		actualboss.transform.position = new Vector3(Random.Range(LeftEdge.position.x,RightEdge.position.x),
		                                 			Random.Range(DownEdge.position.y,UpEdge.position.y),
		                                    		actualboss.transform.position.z);
		addBoss = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (actualboss == null && addBoss == true) {
			index++;
			if(index > bosses.Length){index =0;}
			addBoss = false;
			Invoke("SpawnNewBoss", time);
		}
	}
}
