using UnityEngine;
using System.Collections;

public class FollowMouseInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//SamsungTV.touchPadMode = SamsungTV.TouchPadMode.Mouse;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 5));
	}
}
