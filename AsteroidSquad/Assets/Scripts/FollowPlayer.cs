using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	public float distance;
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<ShootByTime>().canShoot = false;
		if(Vector3.Distance(transform.position, player.transform.position) < distance){
			GetComponent<ShootByTime>().canShoot = true;
			Vector3 target = player.transform.position - transform.position;
			float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
	}
}
