using UnityEngine;
using System.Collections;

public class SpawnAsteroids : MonoBehaviour {
	public GameObject AsteroidPrefab;
	public int NumeroDeAsteroids;
	public Vector4 borders;
	private GameObject [] asteroids;
	private GameObject ship;
	// Use this for initialization
	void Start () {
		for(int i = 0;i<NumeroDeAsteroids;i++){
			RandomSpawnInMap();
		}
	}

	public void RandomSpawnInMap(){
		Instantiate(AsteroidPrefab, new Vector3(Random.Range(borders.x,borders.y),Random.Range(borders.z,borders.w), transform.position.z), Quaternion.identity);
	}

}
