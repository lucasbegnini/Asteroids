using UnityEngine;
using System.Collections;

public class DesviarMudandoDirecao : MonoBehaviour {
	public float distancia;
	private bool desviando=false;
	public float direction;
	public Vector2 size;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit2D hit = Physics2D.BoxCast (rigidbody2D.position, size, rigidbody2D.rotation, rigidbody2D.velocity.normalized);
		if(hit.collider != null){
			if (hit.collider.tag == "asteroid") {
				if (!desviando) {
					float newdir = Random.Range(0.0f,1.0f)<=0.5f?-direction:direction;
					float rotation = rigidbody2D.angularVelocity;
					float angle = rigidbody2D.rotation + newdir;
					float dirx = rigidbody2D.velocity.magnitude*Mathf.Cos(angle*Mathf.Deg2Rad);
					float diry = rigidbody2D.velocity.magnitude*Mathf.Sin(angle*Mathf.Deg2Rad);
					Vector2 dir = new Vector2(dirx,diry);
					rigidbody2D.velocity = dir;
					rigidbody2D.angularVelocity = rotation;
				}
				desviando = true;
			}else{
				desviando = false;
			}
		}
	}
}
