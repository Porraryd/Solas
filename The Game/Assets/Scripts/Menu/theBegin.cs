﻿using UnityEngine;
using System.Collections;

public class theBegin : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{	

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnMouseDown()
	{

		if (this.name == "Play")
		{
			Application.LoadLevel("Einars gosscen");

		}
		else if (this.name == "Instructions")
		{
			Application.LoadLevel("InstructionScene");

		}
		else if (this.name == "Quit")
		{
			Application.Quit();
		}
		

	}
}
