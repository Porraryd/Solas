using UnityEngine;
using System.Collections;

public class theBegin : MonoBehaviour 
{

	private Color startcolor;
	private GameObject play;
	private GameObject instructs;
	private GameObject quit;
	//private bool getBack;
	//GUIStyle myStyle;
	//private bool showInstructions;
	//public Font instructFont;
	// Use this for initialization
	void Start () 
	{	
		startcolor = Color.white;
		play = GameObject.Find("Play");
		instructs = GameObject.Find("Instructions");
		quit = GameObject.Find("Quit");
		//showInstructions = false;
		//myStyle = new GUIStyle();
		//GUI.skin.font = instructFont; //funkar, men kan EJ ändra text size då?
		/*myStyle.fontSize = 40;
		myStyle.normal.textColor = Color.white;
		myStyle.font = instructFont;
		getBack = false;*/
		
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
			/*showInstructions = true;
			play.SetActive(false);
			quit.SetActive(false);*/
			//instructs.SetActive(false); //av nån facking anledning funkar icke if-statement i OnGUI om jag kör setActive på instructs.
			Application.LoadLevel("instructionScene");

			//renderer.enabled=false;
		}
		else if (this.name == "Quit")
		{
			Application.Quit();
		}
		/*if (getBack == true)
		{
			Application.LoadLevel("Menu");
			getBack = false;
		}*/
	}

	void OnMouseOver()
	{
		if (this.name == "Play")
		{
			renderer.material.color = Color.yellow;
		}
		else if (this.name == "Instructions")
		{

			renderer.material.color = Color.yellow;
		}
		else if (this.name == "Quit")
		{
			renderer.material.color = Color.yellow;
		}

	}
	void OnMouseExit()
	{
		renderer.material.color = startcolor;
	}
	/*void OnGUI() Denna vill inte ändra på fonten(????). Kör instructionScene istället.
	{
		if (showInstructions)
		{	
			Rect rect = new Rect(Screen.width/2 - 300, Screen.height/2 - 100, 100, 20);
			GUI.Label(rect, "The world is now a dark and inhospitable place. \n Everything has changed, including your friends. \n You have to save them. Good luck.", myStyle);
			getBack = true;
			
		}
	}*/
}
