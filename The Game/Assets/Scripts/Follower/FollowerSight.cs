using UnityEngine;
using System.Collections;

public class FollowerSight : MonoBehaviour {

	public float fieldOfViewAngle = 110f;
	public bool playerInSight;
	public Vector3 personalLastSighting;

	private NavMeshAgent nav;
	private SphereCollider col;
	private Animator anim;
	//private LastPlayerSighting lastPlayerSighting;
	//private GammeObject player;
	private Animator playerAnim;
	//private PlayerHealth playerHealth;
	//private HashIDs hash;
	private Vector3 previousSighting;

	void Awake()
	{
		nav = GetComponent<NavMeshAgent>();
		col = GetComponent<SphereCollider>();
		anim = GetComponent<Animator>();
		//lastPlayerSighting = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<LastPlayerSighting>();
		//player = GameObject.FindGameObjectWithTag(Tags.player);
		//playerAnim = player.GetComponent<Animator>();
		//playerHealth = player.GetComponent<PlayerHealth>();
		//hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();

		//personalLastSighting = lastPlayerSighting.resetPosition;
		//previousSighting = lastPlayerSighting.resetPosition;
	}

	/*void Update()
	{
		if(lastPlayerSighting.position != previousSighting)
			personalLastSighting = lastPlayerSighting.position;

		previousSighting = lastPlayerSighting.position;

		if(playerHealth.health > 0f)
			anim.SetBool(hash.playerInSightBool, playerInSight);
		else
			anim.SetBool(hash.playerInSightBool, false);
	}

	void OnTriggerStay(Collider other)
	{
		if(other.gameObject == player)
		{
			playerInSight = false;

			Vector3 direction = other.transform.position - transform.position;
			float angle = Vector3.Angle(direction, transform.forward);
		}
	}*/

}
