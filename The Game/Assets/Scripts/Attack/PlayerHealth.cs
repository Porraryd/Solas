using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int maxHealth = 100;
	public static int curHealth = 0;
	public float healthBarLength;

	public static int count = 0;

	// Use this for initialization
	void Start () {

		healthBarLength = Screen.width / 2;
		//FlowerCollider fc = (FlowerCollider)GetComponent ("FlowerCollider");
	}
	
	// Update is called once per frame
	void Update () {
	
		AddjustCurrentHealth (0);
	}

	void OnGUI(){
		GUI.Box (new Rect (200, 10, healthBarLength, 20), curHealth + "/" + maxHealth);
	}

	public void AddjustCurrentHealth(int adj){

		curHealth += adj;

		if (curHealth < 1)
						curHealth = 0;

		if (curHealth > maxHealth)
						curHealth = maxHealth;

		if (maxHealth < 1)
						maxHealth = 1;


		//healthBarLength = (Screen.width / 2) * (curHealth / (float)maxHealth);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "PickUp")
		{
			curHealth++;
			//ph.curHealth = count;
			//SetCountText();
			other.gameObject.SetActive(false);
		}
	}


}
