using UnityEngine;
using System.Collections;

public class FollowerAI : MonoBehaviour {

	public Transform target;
	public int moveSpeed;
	public int rotationSpeed;
	public int maxDistance;

	bool attacking;
	private GameObject player;
	private Animator animator;
	Vector3 direction;
	Vector3 startPatrol;
	Vector3 endPatrol;
	float distance;

	private Transform myTransform;

	void Awake()
	{
		myTransform = transform;
		animator = GetComponent<Animator> ();
		attacking = false;
		endPatrol = myTransform.position + ((Vector3.left) * 10);
		startPatrol = myTransform.position;
	}

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");

		target = player.transform;

		maxDistance = 2;
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine (target.position, myTransform.position, Color.yellow);

		//Look at target
		myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation
		                                        (target.position - myTransform.position), 
		                                        rotationSpeed * Time.deltaTime);

		//distance = Vector3.Distance (endPatrol, myTransform.position);

		/*if (!attacking) {
			Patrolling();	
		}*/

		//möjlig kod för förföljande
		if (Vector3.Distance (target.position, myTransform.position) > maxDistance) {

			//Move towards player
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		}
	}

	void OnTriggerStay(Collider col){

		if(col.gameObject.tag == "Player"){
			attacking = true;
			direction = target.position - myTransform.position;
			direction.Normalize();
			myTransform.LookAt(target);
			animator.SetFloat("speed", 1.0f);
		}
	}

	void Patrolling(){

		if (distance <= 15) {
			Debug.Log (distance);
			direction = myTransform.position + Vector3.left;
			direction.Normalize();
			animator.SetFloat("speed", 1.0f);
			//transform.LookAt(startPatrol);
		} 

		else if (distance > 15) {
			transform.LookAt(startPatrol);
			direction = myTransform.position + startPatrol;
			direction.Normalize();
			animator.SetFloat("speed", 1.0f);
		}
	}
}
