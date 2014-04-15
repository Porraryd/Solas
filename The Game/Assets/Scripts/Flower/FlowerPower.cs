using UnityEngine;
using System.Collections;

public class FlowerPower : MonoBehaviour {

	private int counter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		counter = FlowerCollider.count;
		light.spotAngle = Random.Range(((counter * 20) + 20), ((counter * 20) + 20));
	}
}
