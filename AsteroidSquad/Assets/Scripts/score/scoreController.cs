using UnityEngine;
using System.Collections;

public class scoreController : MonoBehaviour {
	private float score;
	public float bestScore;
	private float preScore;
	private float acumulateScore;
	// Use this for initialization
	void Start () { 
		score = 0f;
		bestScore = PlayerPrefs.GetFloat ("best score", 0);
	}
	
	// Update is called once per frame
	void Update () {
		score = Mathf.MoveTowards (score, preScore, Time.deltaTime*10);
		gameObject.GetComponent<TextMesh> ().text = Mathf.FloorToInt(score)+"";
		PlayerPrefs.SetFloat ("your score", preScore);
		if (preScore > bestScore) {
			bestScore = preScore;
			PlayerPrefs.SetFloat ("best score", bestScore);
		}
	}
	public void AddToScore(int value){
		preScore += value; 
	}
	public void RestartScore(){
		score = 0;
		preScore = 0;
	}
	public string GetScoreAsText(){
		string txt = "Seus pontos " + preScore + "\nRecorde " + bestScore + "";
		return txt;
	}

	public void SetTextScore(){
		GetComponent<TextMesh>().text = "Seus pontos " + preScore + "\nRecorde " + bestScore + "";
	}
}
