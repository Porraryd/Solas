using UnityEngine;
using System.Collections;

public class BrushCollider : MonoBehaviour {
	
	public GameObject brush;
	public GameObject Particles;
	// Use this for initialization
	void Start () {
		brush.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){

		if (col.gameObject.tag == "Brush") {
						CharacterControllerLogic.hasBrush = true;
				brush.SetActive(true);
				Instantiate (Particles, col.transform.position, col.transform.rotation);
						Destroy (col.gameObject);
				}
	}
}
