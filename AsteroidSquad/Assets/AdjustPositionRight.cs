using UnityEngine;
using System.Collections;

public class AdjustPositionRight : MonoBehaviour {
	public float RelativePositionX;
	public float RelativePositionY;
	// Use this for initialization
	void Start () {
		float posx = Screen.width - RelativePositionX;//* RelativePositionX;
		float posy = RelativePositionY;//* RelativePositionY;
		transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (posx, posy, 1));
	}
	
	// Update is called once per frame
	void Update () {
		float posx = Screen.width - RelativePositionX;//* RelativePositionX;
		float posy = RelativePositionY;//* RelativePositionY;
		transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (posx, posy, 1));
	}
}
