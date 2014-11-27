using UnityEngine;
using System.Collections;

public class DinamicImageWithScale : MonoBehaviour {
	
	public Vector2 targetScale;
	private Vector2 initScale;
	public float inSpeed;
	public float outSpeed;
	public float inDelay;
	public float outDelay;
	private bool canEnter;
	private bool canExit;
	static private bool canExitS;

	void Awake(){
		canExitS = false;
	}
	void Start () {
		initScale = transform.localScale;
		Enter ();
	}
	
	void Update () {
		
		if(canEnter){
			DoEnter();
		}
		
		if(canExit||canExitS||DinamicImage.canExitS||SceeneChangerButton.canExitS){
			DoExit();
		}
		
	}
	
	public void Enter(){
		Invoke ("TurnCanEnterTrue", 1.3f);
	}
	
	public void Exit(){
		Invoke ("TurnCanExitTrue", 0.3f);
	}

	public void ExiteAll(){
		Invoke ("TurnCanExitSTrue", 0.3f);
	}
	
	void DoEnter(){
		canExit = false;
		transform.localScale = Vector2.Lerp (transform.localScale,targetScale, Time.deltaTime*inSpeed);
		if (Vector2.Distance(transform.localScale,targetScale)==0)
			canEnter = false;
	}
	
	void DoExit(){
		canEnter = false;
		transform.localScale = Vector2.Lerp (transform.localScale,initScale, Time.deltaTime*outSpeed);
		if (Vector2.Distance(transform.localScale,initScale)==0)
			canExit = false;
	}
	
	void TurnCanEnterTrue(){
		canEnter = true;
	}
	void TurnCanExitTrue(){
		canExit = true;
	}

	void TurnCanExitSTrue(){
		canExitS = true;
	}
}
