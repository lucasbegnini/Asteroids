using UnityEngine;
using System.Collections;

public class SetControls : MonoBehaviour {
	public int ControlType;
	private GameObject c;
	// Use this for initialization
	void Start () {
		c = GameObject.Find("BGM");
	}
	
	// Update is called once per frame
	void Update () {
		if (c.GetComponent<Controlls> ().GetControl () == ControlType) {
			GetComponent<TextMesh>().color = Color.red;	
		}else{
			GetComponent<TextMesh>().color = Color.white;	
		}
	}

	void OnMouseDown(){
		c.GetComponent<Controlls> ().SetControl (ControlType);
	}
}
