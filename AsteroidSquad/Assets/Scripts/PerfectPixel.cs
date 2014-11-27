using UnityEngine;
using System.Collections;

public class PerfectPixel : MonoBehaviour {

	public float zoom = 1f;
	void Start () {
		float UnitsPerPixel = 1f / 100f;
		Camera.main.orthographicSize = (Screen.height / 2f) * UnitsPerPixel * (1/zoom);
	
	}
	

}