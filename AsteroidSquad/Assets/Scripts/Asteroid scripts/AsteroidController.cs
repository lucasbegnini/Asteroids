using UnityEngine;
using System.Collections;

public class AsteroidController : MonoBehaviour {
		
	public int hitPoints;
	public bool last;
	public float splitForce;
	public GameObject frag1;
	public GameObject frag2;
	public GameObject hitExplosion;
	public GameObject orbPoint;
	public int numOfOrbs;
	public AudioSource sfx;
	private float colorLerpSpeed=10;


	void Start () {
		initialize ();
	}

	void Update () {
		renderer.material.color = Color.Lerp (renderer.material.color, Color.white, Time.deltaTime * colorLerpSpeed);
	}

	void initialize(){
		if(tag == "asteroid"){
			int mod = 20;
			rigidbody2D.angularVelocity =Random.Range(-3*mod,3*mod);
			rigidbody2D.AddForce(new Vector2(Random.Range(-mod,mod),Random.Range(-mod/2,mod/2)));
		}
	}

	public void TakeDamage(int damage){
		renderer.material.color = Color.red;
		hitPoints -= Mathf.Abs (damage);
		if(hitPoints<1){
			Split (splitForce);
		}
	}

	void Die(){
		sfx.volume = GameObject.Find ("SFX").GetComponent<Volume> ().GetVolume ();
		sfx.Play ();
		GameObject.Destroy (gameObject);
	}

	void Split(float force){

		int mod = 20;
		if((tag == "asteroid")&&(!last)){
			GameObject frag1 = Instantiate (this.frag1, transform.position, transform.rotation) as GameObject;
			frag1.rigidbody2D.angularVelocity =Random.Range(-3*mod,3*mod);
			float angle = transform.eulerAngles.z * Mathf.Deg2Rad;
			Vector2 splitForce = new Vector2(Mathf.Cos (angle),Mathf.Sin (angle));
			frag1.rigidbody2D.AddForce(splitForce*force);

			GameObject frag2 = Instantiate (this.frag2, transform.position, transform.rotation) as GameObject;
			 frag2.rigidbody2D.angularVelocity =Random.Range(-2*mod,2*mod);
			splitForce = new Vector2(Mathf.Cos (angle),Mathf.Sin (angle))*-1;
			frag2.rigidbody2D.AddForce(splitForce*force);
			}
		else
		if((tag!="asteroid")&&(!last)){
			GameObject frag1 = Instantiate (this.frag1, transform.position, transform.rotation) as GameObject;
			frag1.rigidbody2D.angularVelocity =Random.Range(mod,2*mod);
			float angle = (transform.eulerAngles.z+90) * Mathf.Deg2Rad;
			Vector2 splitForce = new Vector2(Mathf.Cos (angle),Mathf.Sin (angle));
			frag1.rigidbody2D.AddForce(splitForce*force);

			GameObject frag2 = Instantiate (this.frag2, transform.position, transform.rotation) as GameObject;
			frag2.rigidbody2D.angularVelocity =Random.Range(mod,2*mod);
			angle = (transform.eulerAngles.z-90) * Mathf.Deg2Rad;
			splitForce = new Vector2(Mathf.Cos (angle),Mathf.Sin (angle));
			frag2.rigidbody2D.AddForce(splitForce*force);
		}
		Instantiate (hitExplosion, transform.position, transform.rotation) ;
		for(int i =0; i < numOfOrbs;i++){
			GameObject orb = Instantiate (orbPoint, transform.position, transform.rotation)as GameObject ;
			orb.rigidbody2D.AddForce(new Vector2(Random.Range(-1,1),Random.Range(-1,1))*100);
		}
		Camera.main.GetComponent<CameraFollower> ().shake (5, 0.1f, 0.8f);
		Die ();
	}


}
