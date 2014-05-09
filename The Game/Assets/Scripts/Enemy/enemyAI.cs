using UnityEngine;
using System.Collections;

public class enemyAI : MonoBehaviour 
{

	public float speed = 2f;

	private Transform theTransform;
	public Transform target;
	private GameObject player;
	private Animator animator;
	
	public float enemySpeed;

	// Use this for initialization
	void Awake ()
	{
		theTransform = transform;
		animator = GetComponent<Animator>();

	}
	void Start () 
	{

		player = GameObject.FindGameObjectWithTag("Player");
		target = player.transform;
		
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay(Collider col)
	{
		
		if (col.gameObject.tag == "Player")
		{

			Vector3 direction = target.position - theTransform.position;
			direction.Normalize();
			theTransform.LookAt(target);
			//theTransform.position += direction * speed * Time.deltaTime;
			animator.SetFloat ("speed", 1f);
		}
	}
}
