using UnityEngine;
using System.Collections;

public class VerifyRange : MonoBehaviour {
	private float range;
	//private Vector3 PlayerPosition;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		range -= Time.deltaTime;
		if(range<0)
			Destroy(gameObject);
		/*if (Vector3.Distance (PlayerPosition, transform.position) > range) {
			Destroy(gameObject);
		}*/
	}
	public void setRange(float r){
		range = r;
	}
}
