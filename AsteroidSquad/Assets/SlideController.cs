using UnityEngine;
using System.Collections;

public class SlideController : MonoBehaviour {
	public float max;
	public float min;
	public enum volume {BGM, SFX};
	public volume vol;
	private float v;
	private GameObject controller;
	// Use this for initialization
	void Start () {
		if (vol == volume.BGM) {
			controller = GameObject.Find("BGM");
		} else {
			controller = GameObject.Find("SFX");
		}
		float posx = min + controller.GetComponent<Volume> ().GetVolume ()*(max-min);
		transform.position = new Vector3(posx, transform.position.y, transform.position.z);
	}

	// Update is called once per frame
	void Update () {
		v = (transform.position.x - min)/(max - min);
		v = Mathf.Round(v*100)/100;
		controller.GetComponent<Volume> ().SetVolume (v);
	}

	void OnMouseDrag(){
		if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > min && Camera.main.ScreenToWorldPoint(Input.mousePosition).x < max) {
			float posx = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
			transform.position = new Vector3(posx, transform.position.y, transform.position.z);
		}
	}
}
