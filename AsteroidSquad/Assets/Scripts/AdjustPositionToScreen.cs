using UnityEngine;
using System.Collections;

public class AdjustPositionToScreen : MonoBehaviour {
	public string anchor;
	public float RelativePositionX;
	public float RelativePositionY;
	// Use this for initialization
	void Start () {
		if (anchor == "topleft") {
			float posx = Screen.width * RelativePositionX;
			float posy = Screen.height - (Screen.height * RelativePositionY);
			transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (posx, posy, 10));
		}else if(anchor == "downleft"){
			float posx = Screen.width * RelativePositionX;
			float posy = Screen.height * RelativePositionY;
			transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (posx, posy, 10));
		}else if(anchor == "downright"){
			float posx = Screen.width - (Screen.width * RelativePositionX);
			float posy = Screen.height * RelativePositionY;
			transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (posx, posy, 10));
		}else if(anchor == "topright"){
			float posx = Screen.width - (Screen.width * RelativePositionX);
			float posy = Screen.height - (Screen.height * RelativePositionY);
			transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (posx, posy, 10));
		}

	}
	
	// Update is called once per frame
	void Update () {



	}
}
