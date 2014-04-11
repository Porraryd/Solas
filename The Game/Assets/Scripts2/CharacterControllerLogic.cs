	using UnityEngine;
using System.Collections;

public class CharacterControllerLogic : MonoBehaviour {

	private Animator animator;

	public float directionDampTime = .25f;
	public ThirdPersonCamera gameCamera;
	public float directionSpeed = 3.0f;
	public float rotationDegreePerSecond = 120f;
	public GUIText countText;

	public static int count = 0;

	private float speed = 0.0f;
	private float direction = 0.0f;
	private float horizontal = 0.0f;
	private float vertical = 0.0f;
	private AnimatorStateInfo stateInfo;

	private int m_LocomotionId = 0;
	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator>();
		//count = 0;
		SetCountText (); 

		if (animator.layerCount >= 2);
		{
			animator.SetLayerWeight(1,1);
		}

		m_LocomotionId = Animator.StringToHash ("Base Layer.Locomotion");
	}
	
	// Update is called once per frame
	void Update () {
	
		if (animator) 
		{
			horizontal = Input.GetAxis("Horizontal");
			vertical = Input.GetAxis("Vertical");

			StickToWorldspace(this.transform, gameCamera.transform, ref direction, ref speed);


			animator.SetFloat ("speed", speed);
			animator.SetFloat ("direction", direction, directionDampTime, Time.deltaTime);
		

		}
	}

	void FixedUpdate () 
	{
		if (IsInLocomotion () && ((direction >= 0 && horizontal >= 0) || (direction < 0 && horizontal < 0))) 
		{
			Vector3 rotationAmount = Vector3.Lerp(Vector3.zero, new Vector3(0f, rotationDegreePerSecond * (horizontal < 0f ? -1f : 1f), 0f), Mathf.Abs(horizontal));
			Quaternion deltaRotation = Quaternion.Euler(rotationAmount * Time.deltaTime);
			this.transform.rotation = (this.transform.rotation * deltaRotation);
		}

	}


	public void StickToWorldspace(Transform root, Transform camera, ref float directionOut, ref float speedOut)
	{
		Vector3 rootDirection = root.forward;
		
		Vector3 stickDirection = new Vector3(horizontal, 0, vertical);
		
		speedOut = stickDirection.sqrMagnitude;		
		
		// Get camera rotation
		Vector3 CameraDirection = camera.forward;
		CameraDirection.y = 0.0f; // kill Y
		Quaternion referentialShift = Quaternion.FromToRotation(Vector3.forward, CameraDirection);
		
		// Convert joystick input in Worldspace coordinates
		Vector3 moveDirection = referentialShift * stickDirection;
		Vector3 axisSign = Vector3.Cross(moveDirection, rootDirection);
		
		Debug.DrawRay(new Vector3(root.position.x, root.position.y + 2f, root.position.z), moveDirection, Color.green);
		Debug.DrawRay(new Vector3(root.position.x, root.position.y + 2f, root.position.z), rootDirection, Color.magenta);
		Debug.DrawRay(new Vector3(root.position.x, root.position.y + 2f, root.position.z), stickDirection, Color.blue);
		Debug.DrawRay(new Vector3(root.position.x, root.position.y + 2.5f, root.position.z), axisSign, Color.red);
		
		float angleRootToMove = Vector3.Angle(rootDirection, moveDirection) * (axisSign.y >= 0 ? -1f : 1f);
	
		angleRootToMove /= 180f; 
		
		directionOut = angleRootToMove * directionSpeed;
	}

	public bool IsInLocomotion()
	{
		return stateInfo.nameHash == m_LocomotionId;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "PickUp")
		{
			other.gameObject.SetActive(false);
			count++;
			SetCountText();
		}
	}

	void SetCountText()
	{
		countText.text = "Flowers: " + count.ToString (); 
	}
}

	