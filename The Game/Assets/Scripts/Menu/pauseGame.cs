using UnityEngine;
using System.Collections;

public class pauseGame : MonoBehaviour 
{
	bool pause;
	public int checkPause;
	GUIStyle myStyle;
	GUIStyle myStyle2;
	public Font myFont;
	string hover;
	// Use this for initialization
	void Start () 
	{
		pause = false; 
		checkPause = 0;
		myStyle = new GUIStyle();
		myStyle.fontSize = 40;
		myStyle.normal.textColor = Color.white;
		myStyle.font = myFont;
		myStyle2 = new GUIStyle();
		myStyle2.fontSize = 40;
		myStyle2.normal.textColor = Color.white;
		myStyle2.font = myFont;

		Screen.lockCursor = true;
		Screen.showCursor = false;

	}
	
	// Update is called once per frame
	void Update () 
	{
		 if (Input.GetKeyDown("escape"))
		 {
		 	if (checkPause % 2 == 0)
		 	{
             	Time.timeScale =0;
            	 pause = true;
            	 checkPause++;

				Screen.lockCursor = false;
				Screen.showCursor = true;
            }
            else
            {
            	Time.timeScale=1;
            	pause = false;
            	checkPause++;

				Screen.lockCursor = true;
				Screen.showCursor = false;
            }
         }
	}
	void OnGUI()
	{
		if (pause) //UGLY SHIT
		{
			Rect rect1 = new Rect(Screen.width/2-50, Screen.height/2-80, 100, 50);
			Rect rect2 = new Rect(Screen.width/2-50, Screen.height/2-135, 100, 50);
			Vector3 mousePosition = Input.mousePosition;
			mousePosition.y = Screen.height - mousePosition.y;
			 if (GUI.Button(rect1, "Continue", myStyle))
			 {
			 	
			 	Time.timeScale = 1;
			 	pause = false;
			 	checkPause++;
			 	
				Screen.lockCursor = true;
				Screen.showCursor = false;
			 }
			 else if(GUI.Button(rect2, "Main menu", myStyle2))
			 {
			 	Time.timeScale=1;
			 	pause = false;
			 	checkPause++;
			 	Application.LoadLevel("Menu");
			 }
			 if (rect1.Contains(mousePosition))
			 {
			 	myStyle.normal.textColor = Color.yellow;
			 }
			 else if (!(rect1.Contains(mousePosition)))
			 {
			 	myStyle.normal.textColor = Color.white;
			 }
			 if (rect2.Contains(mousePosition))
			 {
			 	myStyle2.normal.textColor = Color.yellow;
			 }
			 else if (!(rect2.Contains(mousePosition)))
			 {
			 	myStyle2.normal.textColor = Color.white;
			 }
		}
	}
		/*void OnMouseOver()
	{
		if (this.name == "Continue")
		{
			//startcolor = renderer.material.color;
			renderer.material.color = Color.yellow;
		}
		else if (this.name == "Main menu")
		{

			//startcolor = renderer.material.color;
			renderer.material.color = Color.yellow;
		}
	}*/



}
