using UnityEngine;
using System.Collections;

public class SpellGenerator : MonoBehaviour {

	Spell spell = new Buff ();

	// Use this for initialization
	void Start () {
	
		Spell spell = CreateSpell ();

	}

	public void Update(){

	}
	
	public Spell CreateSpell(){

		if (spell is Buff) {
			Debug.Log ("Buff");
				} 

		else if (spell is AoE) {
			Debug.Log ("AoE");
				} 

		else if (spell is Bolt) {
			Debug.Log ("Bolt");
				}
		 
		return spell;
	}
}
