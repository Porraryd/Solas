using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int maxHealth = 100;
	public static int curHealth = 0;
	private float healthBarLength;
	public float healthDecayRate = 1f;

	private float timePassed;
	private bool immune = false;
	public float immuneTime = 0.05f;
	private float immuneTimer = 0f;
	private GameObject playerbody;
	private Color playerMainColor;
	// Use this for initialization
	void Start () {
		curHealth = 50;
		healthBarLength = Screen.width / 2;
		//FlowerCollider fc = (FlowerCollider)GetComponent ("FlowerCollider");

		timePassed = 10 / healthDecayRate;

		playerbody = GameObject.Find ("Body");
		playerMainColor = playerbody.renderer.material.color;
	}
	
	// Update is called once per frame
	void Update () {
				AdjustCurrentHealth (0);

				timePassed -= Time.deltaTime;

				if (timePassed < 0f) {
						AdjustCurrentHealth (-1);
						timePassed += 10 / healthDecayRate;
				}
		}

	void OnGUI(){
		GUI.Box (new Rect (200, 10, healthBarLength, 20), curHealth + "/" + maxHealth);
	}

	public void AdjustCurrentHealth(int adj){
		if (immuneTimer > 0) {
			immuneTimer -= Time.deltaTime;	
		}
		if (immuneTimer <= 0){
			immuneTimer = 0f;
			playerbody.renderer.material.color = playerMainColor;
		}
		curHealth += adj;
		if ((adj < -4) && (immuneTimer == 0f)) {
			playerbody.renderer.material.color = Color.red;
			immuneTimer = immuneTime;
		}
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
			AdjustCurrentHealth(10);
			//ph.curHealth = count;
			//SetCountText();
			other.gameObject.SetActive(false);
		}
	}


}
