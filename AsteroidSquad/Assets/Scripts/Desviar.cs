using UnityEngine;
using System.Collections;

public class Desviar : MonoBehaviour {
	public float VelAng;
	public bool desviar=true;
	public Vector2 size;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update(){
		RaycastHit2D hit = Physics2D.BoxCast (rigidbody2D.position, size, rigidbody2D.rotation, rigidbody2D.velocity.normalized);
		if(hit.collider != null){
			if (hit.collider.tag == "asteroid") {
				if (desviar) {
					rigidbody2D.angularVelocity = Random.Range(0.0f,1.0f)<=0.5f?-VelAng:VelAng;
				}
				desviar = false;
			}else{
				desviar = true;
				rigidbody2D.angularVelocity = 0;
			}
		}
	}


}
