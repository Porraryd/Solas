using UnityEngine;
using System.Collections;

public class pauseGame : MonoBehaviour 
{
	bool pause;
	public int checkPause;
	GUIStyle largeFont;
	// Use this for initialization
	void Start () 
	{
		pause = false;
		checkPause = 0;
		largeFont = new GUIStyle();
		largeFont.fontSize = 40;
	}
	
	// Update is called once per frame
	void Update () 
	{
		 if (Input.GetKeyDown("p"))
		 {
		 	if (checkPause % 2 == 0)
		 	{
             	Time.timeScale =0;
            	 pause = true;
            	 checkPause++;

            }
            else
            {
            	Time.timeScale=1;
            	pause = false;
            	checkPause++;

            }
         }
	
	}
	void OnGUI()
	{
		if (pause)
		{
			Debug.Log("KUKEN");
			 GUI.Label(new Rect(Screen.width/2-50, Screen.height/2-25, 100, 50), "Game paused", largeFont);
		}
	}
}
