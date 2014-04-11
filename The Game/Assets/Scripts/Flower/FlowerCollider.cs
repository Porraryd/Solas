using UnityEngine;
using System.Collections;

public class FlowerCollider : MonoBehaviour {

	public GUIText countText;
	public static int count = 0;

	// Use this for initialization
	void Start () {
		
		SetCountText (); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "PickUp")
		{
			count++;
			SetCountText();
			this.gameObject.SetActive(false);
		}
	}
	
	void SetCountText()
	{
		countText.text = "Flowers: " + count.ToString (); 
	}
}
