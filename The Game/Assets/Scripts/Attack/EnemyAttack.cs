using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {
	
	public GameObject player;
	public Transform target;
	public float attackTimer;
	public float coolDown;
	private Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		attackTimer = 0;
		coolDown = 2.0f;

		player = GameObject.FindGameObjectWithTag ("Player");
		target = player.transform;
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetBool ("attack",false);	
		if (attackTimer > 0)
			attackTimer -= Time.deltaTime;
		
		if (attackTimer < 0)
			attackTimer = 0;


		if(attackTimer == 0){
			Attack();
			attackTimer = coolDown;
		}
	}
	
	private void Attack(){
		float distance = Vector3.Distance (target.position, transform.position);
		
		Vector3 dir = (target.transform.position - transform.position).normalized;
		
		float direction = Vector3.Dot (dir, transform.forward);
		
		Debug.Log (direction);

		if (distance < 2.5f && direction > 0.3) {
			animator.SetBool ("attack", true);
			PlayerHealth eh = (PlayerHealth)target.GetComponent ("PlayerHealth");
			player.rigidbody.velocity = transform.forward * 100;
			eh.AdjustCurrentHealth (-5);

		}
	}
}
