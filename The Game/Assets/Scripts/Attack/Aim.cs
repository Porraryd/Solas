using UnityEngine;
using System.Collections;

public class Aim : MonoBehaviour {

	public Texture2D crosshairTexture;
	public Rect position;
	
	// Use this for initialization
	void Start () {
		
		Screen.showCursor = false;
		position = new Rect ((Screen.width - crosshairTexture.width) / 2, (Screen.height - crosshairTexture.height) / 2, 
		                crosshairTexture.width, crosshairTexture.height);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void OnGUI(){
		
		/*vectorx = Input.mousePosition.x;
		vectory = Input.mousePosition.y;

		GUI.DrawTexture (new Rect (vectorx - 15, -vectory + Screen.height - 15, 30, 30), crosshairTexture);*/
		
		GUI.DrawTexture(position, crosshairTexture);
	}
}
