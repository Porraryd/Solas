using UnityEngine;
using System.Collections;

public class FlowerCollider : MonoBehaviour {

	public GUIText countText;
	public static int count = 0;
	//public PlayerHealth ph;

	// Use this for initialization
	void Start () {
		
		SetCountText (); 
		//ph = (PlayerHealth)GetComponent ("PlayerHealth");
		//ph.curHealth = count;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "PickUp")
		{
			count++;
			ph.curHealth = count;
			SetCountText();
			other.gameObject.SetActive(false);
		}
	}*/
	
	void SetCountText()
	{
		countText.text = "Flowers: " + count.ToString (); 
	}
}
