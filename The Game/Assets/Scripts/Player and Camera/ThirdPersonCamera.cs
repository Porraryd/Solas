using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour {
	
	public float camSmoothDampTime = 0.15f;
	public float radius = 2f;
	public float mouseHorizontalSpeed = 0.14f;
	public float mouseVerticalSpeed = 0.08f;


	private Transform followTransform;
	private Vector3 targetPosition;
	private Vector3 lookDir;
	private CamStates CamState;
	private float latitudeOffset = 0f;
	private float longitudeOffset = 0f;
	private Vector3 velocityCamSmooth = Vector3.zero;
	private Vector3 offset = new Vector3 (0f, 0f, 0f);


	public enum CamStates
	{
		Follow,
		FirstPerson,
		Target,
		Free
	}


	void Start () {
		followTransform = GameObject.Find ("CameraFollowObject").transform;
	}

	void LateUpdate () {

		if (Input.GetAxis ("Target") < 0.01f) {
			CamState = CamStates.Follow;
		} else {
			CamState = CamStates.Target;
		}

		switch(CamState)
		{
			case CamStates.Follow:
				//set look direction
				lookDir = followTransform.position - this.transform.position; 
				lookDir.y = 0.0f;
				lookDir.Normalize ();
				
				updateMouse();

				//target position, what position the camera wants to reach
			targetPosition = followTransform.position + offset;

			break;
			case CamStates.Target:
				lookDir = followTransform.forward;
				
			targetPosition = followTransform.position + offset ;
			break;
		}

		//check if wall collision
		CompensateForWalls (followTransform.position, ref targetPosition);
		
		//move smoothly towards targetposition
		smoothPosition (this.transform.position, targetPosition);
		
		//make sure the camera is looking towards the player
		transform.LookAt (followTransform);
	}
	
	void smoothPosition(Vector3 fromPos, Vector3 toPos)
	{
		this.transform.position = Vector3.SmoothDamp(fromPos, toPos, ref velocityCamSmooth, camSmoothDampTime); 
	}

	private void CompensateForWalls(Vector3 fromObject, ref Vector3 toTarget)
	{
		// Compensate for walls between camera by casting a ray from the player to the camera
		RaycastHit wallHit = new RaycastHit();		
		//if a collision with something occurs, change the targetposition
		if (Physics.Linecast(fromObject, toTarget, out wallHit)) 
		{
			toTarget = new Vector3(wallHit.point.x+(0.4f*wallHit.normal.x), toTarget.y, wallHit.point.z+(0.4f*wallHit.normal.z));
		}
	}


	private void updateMouse()
	{
		float deltaY = Input.GetAxis ("Mouse Y");
		float deltaX = Input.GetAxis ("Mouse X");

		longitudeOffset = (longitudeOffset < 0.1f ? 0.1f : (longitudeOffset + deltaY * mouseVerticalSpeed));
		longitudeOffset = (longitudeOffset > 2.5f ? 2.5f : longitudeOffset);

		latitudeOffset = (latitudeOffset + -deltaX * mouseHorizontalSpeed)%(Mathf.PI*2);

		offset.y = radius * Mathf.Cos (longitudeOffset);
		offset.x = radius * Mathf.Sin (longitudeOffset) * Mathf.Cos (latitudeOffset);
		offset.z = radius * Mathf.Sin (longitudeOffset) * Mathf.Sin (latitudeOffset);
	}

}
