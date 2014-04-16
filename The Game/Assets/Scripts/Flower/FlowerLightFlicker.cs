using UnityEngine;
using System.Collections;

public class FlowerLightFlicker : MonoBehaviour {

	float originalRange;
	public float frequency = 0.5f; 
	public float variance = 1f;
	// Use this for initialization
	void Start () {
		originalRange = light.range;
	}
	
	// Update is called once per frame
	void Update () {
		light.range = originalRange + (EvalWave ());


	}

	float EvalWave()
	{
		float x = Time.time * frequency; 
		float y;

		x = x - Mathf.Floor(x); 

		y = Mathf.Sin(x*2*Mathf.PI);

		return (y*variance);
	}

}
