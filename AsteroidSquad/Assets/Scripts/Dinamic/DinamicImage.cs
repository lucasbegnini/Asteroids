using UnityEngine;
using System.Collections;

public class DinamicImage : MonoBehaviour {

	public Vector2 targetPos;
	protected Vector2 initPos;
	public float inSpeed;
	public float outSpeed;
	public float inDelay;
	public float outDelay;
	protected bool canEnter;
	protected bool canExit;
	static public bool canExitS; 

	void Awake(){
		canExitS = false;
		}
	void Start () {
		initPos = transform.localPosition;
	}

	void Update () {
	
		if(canEnter){
			DoEnter();
		}

		if(canExit || canExitS){
			DoExit();
		}

	}

	public void Enter(){
		Invoke ("TurnCanEnterTrue", inDelay);
	}

	public void Exit(){
		Invoke ("TurnCanExitTrue", outDelay);
	}

	public void ExiteAll(){
		Invoke ("TurnCanExitSTrue", outDelay);
	}

	protected void DoEnter(){
		canExit = false;
		transform.localPosition = Vector3.Lerp (transform.localPosition,new Vector3 (targetPos.x,targetPos.y,5), Time.deltaTime*inSpeed);
		if (Vector2.Distance(transform.localPosition,targetPos)<0.05f)
						canEnter = false;
	}

	protected void DoExit(){
		canEnter = false;
		transform.localPosition = Vector3.Lerp (transform.localPosition,new Vector3 (initPos.x,initPos.y,5), Time.deltaTime*outSpeed);
		if (Vector2.Distance(transform.localPosition,initPos)<0.05f)
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
