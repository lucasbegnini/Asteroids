using UnityEngine;
using System.Collections;

public class AdjustSizeByScreen : MonoBehaviour {
	public float dpi;
	// Use this for initialization
	void Start () {
		dpi = Screen.dpi;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector3 (dpi/120, dpi/120, 1);
	}
}
