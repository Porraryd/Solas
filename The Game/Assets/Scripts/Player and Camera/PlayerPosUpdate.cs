﻿using UnityEngine;
using System.Collections;

public class PlayerPosUpdate : MonoBehaviour {

	private float fadeSpeed = 1.00f;

	public GameObject player;
	private float yVelocity = 0.0f;

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
			renderer.sharedMaterial.SetVector("_PlayerPosition", player.transform.position);
			float distance = renderer.sharedMaterial.GetFloat("_VisibleDistance");
			distance = Mathf.SmoothDamp(distance, count*0.5f+2f, ref yVelocity, fadeSpeed);
			renderer.sharedMaterial.SetFloat("_VisibleDistance", distance);
	}
}
}