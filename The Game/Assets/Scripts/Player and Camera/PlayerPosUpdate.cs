using UnityEngine;
using System.Collections;

public class PlayerPosUpdate : MonoBehaviour {

	private float fadeSpeed = 0.1f;

	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null) {
			// Pass the player location to the shader
			renderer.sharedMaterial.SetVector("_PlayerPosition", player.transform.position);
			float distance = renderer.sharedMaterial.GetFloat("_VisibleDistance");
			distance = Mathf.Lerp(distance, FlowerCollider.count*0.5f+2f, fadeSpeed);
			renderer.sharedMaterial.SetFloat("_VisibleDistance", distance);
	}
}
}