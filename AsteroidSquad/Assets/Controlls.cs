using UnityEngine;
using System.Collections;

public class Controlls : MonoBehaviour {
	private int controls=1;

	public void SetControl(int c){
		controls = c;
	}

	public int GetControl(){
		return controls;
	}
}
