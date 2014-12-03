using UnityEngine;
using System.Collections;

public class TakeDamage : MonoBehaviour {
	public int hitPoints;
	public GameObject explosion;
	// Use this for initialization

	public void takeDamage(int damage){
		hitPoints -= Mathf.Abs (damage);
		if(hitPoints<1){
			GameObject e = Instantiate(explosion) as GameObject;
			e.transform.position = transform.position;
			Destroy(gameObject);
		}
	}
}
