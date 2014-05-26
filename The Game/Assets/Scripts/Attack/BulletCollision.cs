using UnityEngine;
using System.Collections;

public class BulletCollision : MonoBehaviour {

	//public GameObject go;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){

		if (col.gameObject.tag == "Grass") 
			Destroy (gameObject);	

		if (col.gameObject.tag == "Tree")
			Destroy (gameObject);

		if (col.gameObject.tag == "Stone")
			Destroy (gameObject);

		if (col.gameObject.tag == "Enemy") {
			Destroy (gameObject);
			Destroy (col.gameObject);
		}

		

			/*if(go.gameObject.tag == "Enemy"){
				Debug.Log("SKJUUUUT!!");
			}*/
		
	}
}
