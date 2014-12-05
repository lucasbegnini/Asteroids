using UnityEngine;
using System.Collections;

public class SerpentMovement : MonoBehaviour {
	public SerpentMovement Target;
	public int MaxDistance;
	private int distance=0;
	private Vector2 Direction;
	public float velocity;
	public float angular;
	public float angularVariation;
	public float multi;
	private GameObject player;
	private Vector3 posicao;
	public Vector3[] posicoes;
	public bool follow;
	// Use this for initialization
	void Start () {
		posicoes = new Vector3[MaxDistance];
		for(int i =0;i<MaxDistance;i++){
			posicoes[i] = transform.position;
		}
		Physics2D.IgnoreLayerCollision (11, 11, true);
		player = GameObject.FindGameObjectWithTag ("Player");
		rigidbody2D.angularVelocity = angular;
	}
	
	
	void FixedUpdate () {
		if (follow) {			
			transform.position = Target.posicaoAnterior(MaxDistance-1);
		}else{
			float angle = rigidbody2D.rotation;
			float dirx = velocity*Mathf.Cos(angle*Mathf.Deg2Rad)/100;
			float diry = velocity*Mathf.Sin(angle*Mathf.Deg2Rad)/100;
			Vector2 direction = new Vector2(dirx,diry);
			rigidbody2D.velocity = direction;
			Vector3 target = player.rigidbody2D.position - rigidbody2D.position;
			angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
			if(rigidbody2D.rotation < -angularVariation + angle){
				rigidbody2D.angularVelocity = angular;
			}else if(rigidbody2D.rotation > angularVariation + angle){
				rigidbody2D.angularVelocity = -angular;
			}
		}
		for(int i=MaxDistance-1;i>0;i--){
			posicoes[i] = posicoes[i-1];
		}
		posicoes [0] = transform.position;
	}

	public Vector3 posicaoAnterior(int index){
		return posicoes[index];
	}

}
