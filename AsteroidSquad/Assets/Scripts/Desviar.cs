using UnityEngine;
using System.Collections;

public class Desviar : MonoBehaviour {
	public float VelAng;
	public bool desviar=true;
	public float distance;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update(){
		Vector3 vel = rigidbody2D.velocity.normalized;
		Debug.DrawLine (transform.GetChild(0).position, transform.GetChild(0).position+(distance*vel));
		Debug.DrawLine (transform.GetChild(1).position, transform.GetChild(1).position+(distance*vel));
		RaycastHit2D hit = Physics2D.Linecast (transform.GetChild(0).position, transform.GetChild(0).position+(distance*vel));

		if(hit.collider != null){
			if (hit.collider.tag == "asteroid") {

				if (desviar) {
					Debug.Log (hit.collider);
					rigidbody2D.angularVelocity = -VelAng;
				}
				desviar = false;
			}
		}else{
			hit = Physics2D.Linecast (transform.GetChild(1).position, transform.GetChild(1).position+(distance*vel));
			if(hit.collider != null){	
				
				if (hit.collider.tag == "asteroid") {
					//Debug.Log (hit.collider);
					if (desviar) {
						rigidbody2D.angularVelocity = VelAng;
					}
					desviar = false;
				}
			}else{
				hit = Physics2D.Linecast (transform.GetChild(2).position, transform.GetChild(2).position+(distance*vel));
				if(hit.collider != null){	
					
					if (hit.collider.tag == "asteroid") {
						//Debug.Log (hit.collider);
						if (desviar) {
							rigidbody2D.angularVelocity = VelAng;
						}
						desviar = false;
					}
				}else{
					desviar = true;
					rigidbody2D.angularVelocity = 0;
				}
			}
		}

	}
}
