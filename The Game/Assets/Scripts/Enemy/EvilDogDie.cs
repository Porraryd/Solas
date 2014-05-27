using UnityEngine;
using System.Collections;

public class EvilDogDie : MonoBehaviour {
	
	public GameObject Particles;
	
	void Die(){
		Instantiate (Particles, this.transform.position, this.transform.rotation);
		Destroy (this.gameObject);
	}
}
