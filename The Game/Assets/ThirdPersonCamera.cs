using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour {

	public float distanceAway;
	public float distanceUp;
	public Vector3 offset = new Vector3(0f, 1.5f, 0f);


	private Transform followTransform;
	private Vector3 targetPosition;
	private Vector3 lookDir;

	private Vector3 velocityCamSmooth = Vector3.zero;
	private float camSmoothDampTime = 0.05f;


	void Start () {
		followTransform = GameObject.FindWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 characterOffset = followTransform.position + new Vector3(0f, distanceUp, 0f);

		lookDir = characterOffset - this.transform.position; 
		lookDir.y = 0.0f;
		lookDir.Normalize ();

		targetPosition = characterOffset + followTransform.up * distanceUp - lookDir * distanceAway;

		CompensateForWalls (characterOffset, ref targetPosition);
		smoothPosition (this.transform.position, targetPosition);

		transform.LookAt (followTransform);
	}

	void smoothPosition(Vector3 fromPos, Vector3 toPos)
	{
		this.transform.position = Vector3.SmoothDamp(fromPos, toPos, ref velocityCamSmooth, camSmoothDampTime); 

	}

	private void CompensateForWalls(Vector3 fromObject, ref Vector3 toTarget)
	{
		Debug.DrawLine(fromObject, toTarget, Color.cyan);
		// Compensate for walls between camera
		RaycastHit wallHit = new RaycastHit();		
		if (Physics.Linecast(fromObject, toTarget, out wallHit)) 
		{
			Debug.DrawRay(wallHit.point, wallHit.normal, Color.red);
			toTarget = new Vector3(wallHit.point.x+(0.4f*wallHit.normal.x), toTarget.y, wallHit.point.z+(0.4f*wallHit.normal.z));
		}
	}
}
