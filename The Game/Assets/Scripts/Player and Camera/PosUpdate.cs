using UnityEngine;
using System.Collections;

public class PosUpdate : MonoBehaviour {
	private float lightRadius;
	private float currentLightRadius;
	Vector4 PlayerPos;
	public bool debugMode = false;
	private float fadeSpeed = 1.00f;

	private float yVelocity = 0.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//Update position in shader
		PlayerPos = this.transform.position;
		PlayerPos.y = 0.0f;
		Shader.SetGlobalVector ("_PlayerPosition", PlayerPos);


		lightRadius = PlayerHealth.curHealth * 0.1f;
		if (debugMode == true)
			Shader.SetGlobalFloat ("_VisibleDistance", 1000);
		else {
			currentLightRadius = Mathf.SmoothDamp (currentLightRadius, lightRadius, ref yVelocity, fadeSpeed);
			Shader.SetGlobalFloat ("_VisibleDistance", currentLightRadius);
		}
	}
}
