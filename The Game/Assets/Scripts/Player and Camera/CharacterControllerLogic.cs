using UnityEngine;
using System.Collections;

public class CharacterControllerLogic : MonoBehaviour {

	private Animator animator;

	public float directionDampTime = .25f;
	public ThirdPersonCamera gameCamera;
	public float directionSpeed = 3.0f;
	public float rotationDegreePerSecond = 120f;
	public float rotationSpeed = 10f;
	public Transform groundChecker;
	public LayerMask whatIsGround;

	private float speed = 0.0f;
	private float horizontal = 0.0f;
	private float vertical = 0.0f;
	private AnimatorStateInfo stateInfo;

	private bool isFalling = false;
	public float jumpHeight = 6.0f;
	private int m_LocomotionId = 0;
	public static bool hasBrush = false;

	void Start () {

		animator = GetComponent<Animator>();


		if(animator.layerCount >= 2)
		{
			animator.SetLayerWeight(1, 1);
		}	

		//hash the locomotion id for performance 
		m_LocomotionId = Animator.StringToHash ("Base Layer.Locomotion");
	}
	
	// Update is called once per frame
	void Update () {

		stateInfo = animator.GetCurrentAnimatorStateInfo(0);

		//get input from controller
		horizontal = Input.GetAxis("Horizontal");
		vertical = Input.GetAxis("Vertical");
		if (Input.GetButton("Jump") && !isFalling)
		{	
			Jump();
		}
		if (Input.GetButton ("Fire1") && hasBrush) {
				animator.SetBool ("attack", true);
				} else
						animator.SetBool ("attack", false);
	}
	
	void FixedUpdate () 
	{

		isFalling = !Physics.Raycast(groundChecker.position, new Vector3(0f, -1f,0f), 0.2f, whatIsGround);


		if (animator) 
		{
			if(isFalling)
				animator.SetBool ("grounded", false);
			else
				animator.SetBool("grounded", true);
			//transform the input to worldspace. 
			StickToWorldspace(this.transform, gameCamera.transform, ref speed);
			
			//update the speed of the animation
			animator.SetFloat ("speed", speed);
		}

		 

	}


	public void StickToWorldspace(Transform root, Transform camera, ref float speedOut)
	{
		Vector3 rootDirection = root.forward;
		
		Vector3 stickDirection = new Vector3(horizontal, 0, vertical);
		
		speedOut = stickDirection.sqrMagnitude;		
		
		// Get camera rotation
		Vector3 CameraDirection = camera.forward;
		CameraDirection.y = 0.0f; // kill Y
		Quaternion referentialShift = Quaternion.FromToRotation(Vector3.forward, Vector3.Normalize(CameraDirection));
		
		// Convert joystick input in Worldspace coordinates
		Vector3 moveDirection = referentialShift * stickDirection;
		Vector3 axisSign = Vector3.Cross(moveDirection, rootDirection);
		
		//Debug.DrawRay(new Vector3(root.position.x, root.position.y + 2f, root.position.z), moveDirection, Color.green);
		//Debug.DrawRay(new Vector3(root.position.x, root.position.y + 2f, root.position.z), rootDirection, Color.magenta);
		//Debug.DrawRay(new Vector3(root.position.x, root.position.y + 2.5f, root.position.z), axisSign, Color.red);

		float angleRootToMove;
		if (speedOut < 0.05f) 
		{
			angleRootToMove = 0;
		} else {
			angleRootToMove = Vector3.Angle (rootDirection, moveDirection) * (axisSign.y >= 0 ? -1f : 1f);


			if (Mathf.Abs (angleRootToMove) > 0.1f) {
				Vector3 rotationAmount = Vector3.Lerp (Vector3.zero, new Vector3 (0f, angleRootToMove, 0f), Time.deltaTime * rotationSpeed);
				Quaternion deltaRotation = Quaternion.Euler (rotationAmount);

				this.transform.rotation = (this.transform.rotation * deltaRotation);
			}
		}
	}

	public void Jump()
	{
		//Jumping
		rigidbody.velocity = new Vector3(0,jumpHeight,0);
		//isFalling = true;
	}

	public void Attack()
	{
			

	}

	//checks if character is in locomotion (moving)
	public bool IsInLocomotion()
	{
		return stateInfo.nameHash == m_LocomotionId;
	}

	
}

	