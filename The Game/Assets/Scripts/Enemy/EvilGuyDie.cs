using UnityEngine;
using System.Collections;

public class EvilGuyDie : MonoBehaviour {

	public GameObject goodGuy;

	void Die(){
		Instantiate (goodGuy, this.transform.position, this.transform.rotation);
		Destroy (this.gameObject);
	}
}
