using UnityEngine;
using System.Collections;

public class PlayerPosUpdateTerrain : MonoBehaviour {
	
	private float fadeSpeed = 1.00f;
	
	private GameObject player;
	private float yVelocity = 0.0f;
	public Terrain terrain;

	int count = 0;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		count = PlayerHealth.curHealth;
		
		if (player != null) {
			// Pass the player location to the shader
			Vector3 playerPos = player.transform.position;
			playerPos.y = 0.0f;
			terrain.renderer.sharedMaterial.SetVector("_PlayerPosition", playerPos);
			float distance = renderer.sharedMaterial.GetFloat("_VisibleDistance");
			distance = Mathf.SmoothDamp(distance, count*0.5f+2f, ref yVelocity, fadeSpeed);
			terrain.renderer.sharedMaterial.SetFloat("_VisibleDistance", distance);
		}
	}
}