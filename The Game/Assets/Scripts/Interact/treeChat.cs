using UnityEngine;
using System.Collections;

public class treeChat : MonoBehaviour {
	bool talking;
	int currentLine;
	string currentTalk;
	public string[] conversation = new string[5] {"If I have that junkie's booze?","Of course I don't.","I already told you, I don't have it.", 
    "God, you're awfully intrusive. Alright, he can have some of mine.", "Here you go."};
	// Use this for initialization
	string sentence="";
	private GameObject drunkard;
	void Start () 
	{
		drunkard = GameObject.Find("Drunkard");
      	drunkard.GetComponent<drunkenChat>().enabled=false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(talking)
        {
          if(Input.GetKeyDown(KeyCode.A))
          {
            
            if (currentLine <= conversation.Length)
            {
                currentLine++;
                sentence = conversation[currentLine];
            }
            else
            {
              currentLine=0;
              sentence="";
              talking=false;
              drunkard.GetComponent<drunkenChat>().enabled = true;
            }
          }
        }
	}

	void OnTriggerEnter(Collider col)
    {
      if (col.gameObject.tag=="Player")
      {
        	talking = true;
        	currentLine=0;
        	currentTalk = conversation[currentLine];
        
      }
    }

    void OnGUI()
    {
      if (talking) //otherwise it will say first sentence without me entering the objects collider
        GUI.Label(new Rect(30,30,Screen.width,20), conversation[currentLine]);
    }
}
