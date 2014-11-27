using UnityEngine;
using System.Collections;

public class PauseButton : Button {
	private bool paused;

	void OnMouseUpAsButton(){
		Up ();
		Respond ();
	}

	void FixedUpdate(){
		if (Input.GetKeyUp(KeyCode.Escape)){
			Respond ();
		}
	}
	
	public void Respond(){
		if(!paused)
			Pause ();
		else
			Despause();
	}

	public void Pause(){
		paused = true;
		PauseAsteroids ();
		PausePlayer ();
		PauseOthers ();
		GameObject.Find ("pause menu").GetComponent<DinamicImage> ().Enter ();
		GameObject.Find ("botoes").GetComponent<DinamicImage> ().Enter ();
	}

	public void Despause(){
		paused = false;
		DespauseAsteroids ();
		DesPausePlayers ();
		DesPauseOthers ();

		GameObject.Find ("botoes").GetComponent<DinamicImage> ().Exit ();
		GameObject.Find ("pause menu").GetComponent<DinamicImage> ().Exit ();
	}

	void PausePlayer(){
		GameObject.FindGameObjectWithTag ("Player").GetComponent<Pauseble>().Pause();
	}

	void DesPausePlayers(){
		GameObject.FindGameObjectWithTag ("Player").GetComponent<Pauseble>().Despause();
	}

	void PauseAsteroids(){
		GameObject[] asteroids = GameObject.FindGameObjectsWithTag("asteroid");
		for(int i =0, l = asteroids.Length;i<l;i++){
			asteroids[i].GetComponent<Pauseble>().Pause();
		}
		GameObject[] asteroidFrags = GameObject.FindGameObjectsWithTag("asteroid frag");
		for(int i =0, l = asteroidFrags.Length;i<l;i++){
			asteroidFrags[i].GetComponent<Pauseble>().Pause();
		}
	}

	void DespauseAsteroids(){
		GameObject[] asteroids = GameObject.FindGameObjectsWithTag("asteroid");
		for(int i =0, l = asteroids.Length;i<l;i++){
			asteroids[i].GetComponent<Pauseble>().Despause();
		}
		GameObject[] asteroidFrags = GameObject.FindGameObjectsWithTag("asteroid frag");
		for(int i =0, l = asteroidFrags.Length;i<l;i++){
			asteroidFrags[i].GetComponent<Pauseble>().Despause();
		}
	}


	void PauseOthers(){
		if (GameObject.FindGameObjectsWithTag ("bullet") != null) {
						GameObject[] bullets = GameObject.FindGameObjectsWithTag ("bullet");
						for (int i =0, l = bullets.Length; i<l; i++) {
								bullets [i].GetComponent<Pauseble> ().Pause ();
						}
				}
		if (GameObject.FindGameObjectsWithTag ("bullet") != null) {
						GameObject[] explosion = GameObject.FindGameObjectsWithTag ("explosion");
						for (int i =0, l = explosion.Length; i<l; i++) {
								explosion [i].GetComponent<Pauseble> ().Pause ();
						}
				}
		}


	void DesPauseOthers(){
		if (GameObject.FindGameObjectsWithTag ("bullet") != null) {
		GameObject[] bullets = GameObject.FindGameObjectsWithTag("bullet");
		for(int i =0, l = bullets.Length;i<l;i++){
			bullets[i].GetComponent<Pauseble>().Despause();
			}
		}
		if (GameObject.FindGameObjectsWithTag ("explosion") != null) {
						GameObject[] explosion = GameObject.FindGameObjectsWithTag ("explosion");
						for (int i =0, l = explosion.Length; i<l; i++) {
								explosion [i].GetComponent<Pauseble> ().Despause ();
						}
				}
	}
}
