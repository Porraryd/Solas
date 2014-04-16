using UnityEngine;
using System.Collections;

public class PlayerPosUpdate : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null) {
			// Pass the player location to the shader
			renderer.sharedMaterial.SetVector("_PlayerPosition", player.transform.position);
			renderer.sharedMaterial.SetFloat("_VisibleDistance", FlowerCollider.count*0.3f+2f);
	}
}
}