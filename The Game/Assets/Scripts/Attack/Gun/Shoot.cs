using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public Rigidbody projectile;
	public float speed = 20;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (Input.GetButton ("Fire1")) {

				Rigidbody instantiatedProjectile = Instantiate(projectile,
			                                               transform.position,
			                                               transform.rotation)
				as Rigidbody; // reference conversion to rigidbody

			//make the object move
			instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));

			//turn off collisions between the object and the player
			//Physics.IgnoreCollision(instantiatedProjectile.collider, transform.root.collider);

		}
	*/
	}
}
