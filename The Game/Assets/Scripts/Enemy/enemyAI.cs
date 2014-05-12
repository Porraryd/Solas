using UnityEngine;
using System.Collections;

public class enemyAI : MonoBehaviour 
{

	bool attacking;
	private Transform theTransform;
	public Transform target;
	private GameObject player;
	private Animator animator;
	Vector3 direction;
	Vector3 startPatrol;
	Vector3 endPatrol;
	float distance;

	// Use this for initialization
	void Awake ()
	{
		theTransform = transform;
		animator = GetComponent<Animator>();
		attacking = false;
		endPatrol = theTransform.position + ((Vector3.left)*10);
		startPatrol = theTransform.position;

	}
	void Start () 
	{

		player = GameObject.FindGameObjectWithTag("Player");
		target = player.transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		distance = Vector3.Distance(endPatrol, theTransform.position);
		if (!attacking)
		{
			patrolling();
		}

	}
	void OnTriggerStay(Collider col)
	{
		
		if (col.gameObject.tag == "Player")
		{
			attacking = true;
			direction = target.position - theTransform.position;
			direction.Normalize();
			theTransform.LookAt(target);
			animator.SetFloat ("speed", 1f);
		}
	}
	void patrolling()
	{

			if (distance <= 15)
			{
				Debug.Log(distance);
				direction = theTransform.position + Vector3.left;
				direction.Normalize();
				animator.SetFloat("speed", 1f);
				//transform.LookAt(startPatrol)
			}
			else if (distance > 15)
			{
				transform.LookAt(startPatrol);
				direction = theTransform.position + startPatrol;
				direction.Normalize();
				animator.SetFloat("speed", 1f);
			}
	}
}
