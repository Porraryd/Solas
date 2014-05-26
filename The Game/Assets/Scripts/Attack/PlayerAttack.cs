using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public Rigidbody projectile;
	public float projectileSpeed = 20;
	public GameObject BulletSpawn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	private void OnAttack(){
		Rigidbody instantiatedProjectile = Instantiate (projectile,
		                                                BulletSpawn.transform.position,
		                                                transform.rotation)
			as Rigidbody; // reference conversion to rigidbody
		
		//make the object move
		instantiatedProjectile.velocity = transform.TransformDirection (new Vector3 (0, 0, projectileSpeed));
		//rigidbody.AddRelativeForce (new Vector3 (0, 0, projectileSpeed), ForceMode.Impulse);

	}
}
