using UnityEngine;
using System.Collections;

public class theBegin : MonoBehaviour 
{

	private Color startcolor;
	private GameObject play;
	private GameObject instructs;
	private GameObject quit;
	GUIStyle largeFont;
	private bool showInstructions;
	// Use this for initialization
	void Start () 
	{	
		startcolor = Color.white;
		play = GameObject.Find("Play");
		instructs = GameObject.Find("Instructions");
		quit = GameObject.Find("Quit");
		showInstructions = false;
		largeFont = new GUIStyle();
		largeFont.fontSize = 40;
		largeFont.normal.textColor = Color.white;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnMouseDown()
	{

		if (this.name == "Play")
		{
			Application.LoadLevel("Level 1");

		}
		else if (this.name == "Instructions")
		{
			showInstructions = true;
			play.SetActive(false);
			quit.SetActive(false);
			//instructs.SetActive(false); //av nån facking anledning funkar icke if-statement i OnGUI om jag kör setActive på instructs.
			renderer.enabled=false;
			Debug.Log(showInstructions);


		}
		else if (this.name == "Quit")
		{
			Application.Quit();
		}
	}

	void OnMouseOver()
	{
		if (this.name == "Play")
		{
			//startcolor = renderer.material.color;
			renderer.material.color = Color.yellow;
		}
		else if (this.name == "Instructions")
		{

			//startcolor = renderer.material.color;
			renderer.material.color = Color.yellow;
		}
		else if (this.name == "Quit")
		{
			//startcolor = renderer.material.color;
			renderer.material.color = Color.yellow;
		}

	}
	void OnMouseExit()
	{
		renderer.material.color = startcolor;
	}
	void OnGUI()
	{
		if (showInstructions)
		{
			Debug.Log("KUK");	
			GUI.Label(new Rect(Screen.width/2 - 300, Screen.height/2 - 100, 100, 20), "FÅNGA BLOMMOR DITT JÄVLA AS", largeFont);
		}
	}
}
