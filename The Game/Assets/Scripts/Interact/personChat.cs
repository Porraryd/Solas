using UnityEngine;
using System.Collections;

public class personChat : MonoBehaviour 
{


    public string[] conversation = new string[6] {"Hello."," Someone stole my booze.","I really can't cope without my liquor.", 
    "Maybe you could help me retrieve it?", "I think he went to the right.","Go see that ugly tree over there. I think he could help you."};
    public float damping = 3.5f; 
    bool talking=false;
    private int currentLine;
    private string sentence = ""; 

    
    private GameObject tree;
    
 
    void Start () 
    {
      tree = GameObject.Find("myTree");
      tree.GetComponent<treeChat>().enabled=false;
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

              tree.GetComponent<treeChat>().enabled = true;
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
        sentence = conversation[currentLine];
      }
    }
    void OnGUI()
    {
      if (talking) //otherwise it will say first sentence without me entering the objects collider
        GUI.Label(new Rect(30,30,Screen.width,20), conversation[currentLine]);
    }
}
