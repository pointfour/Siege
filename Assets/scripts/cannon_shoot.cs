using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon_shoot : MonoBehaviour {
	public GameObject cannonBall;
	public Transform cannonSpawn;
	public float POWER;

	//fire rates
	private float nextfire = 0.0f;
	private float firerate = 5f;
	public float lifetime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextfire) {
			nextfire = Time.time + firerate;
			CMDShoot ();
		}
	}
	void CMDShoot(){
		var bullet = (GameObject)Instantiate (
			cannonBall,
			cannonSpawn.position,
			cannonSpawn.rotation);
		// Add velocity to the bullet
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * POWER;
		bullet.GetComponent<Rigidbody>().angularVelocity = new Vector3(0,100,0);
		// Destroy the bullet after 3 seconds
		Destroy(bullet, lifetime);
	}
}
