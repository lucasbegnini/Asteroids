using UnityEngine;
using System.Collections;

public class TakeDamage : MonoBehaviour {
	public int hitPoints;
	public GameObject explosion;
	public int numOfOrbs;
	public GameObject orbPoint;
	// Use this for initialization

	public void takeDamage(int damage, Collider2D c){
		hitPoints -= Mathf.Abs (damage);
		if(hitPoints<1){
			GameObject e = Instantiate(explosion) as GameObject;
			e.transform.position = transform.position;
			Destroy(gameObject);
			if(c.tag == "bullet"){
				for(int i =0; i < numOfOrbs;i++){
					GameObject orb = Instantiate (orbPoint, transform.position, transform.rotation)as GameObject ;
					orb.rigidbody2D.AddForce(new Vector2(Random.Range(-1,1),Random.Range(-1,1))*100);
				}
			}
		}
	}
}
