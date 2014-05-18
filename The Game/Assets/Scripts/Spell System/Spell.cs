using UnityEngine;
using System.Collections;

public class Spell : ISpell {
	//Add a path to the Effects folder
	private float _coolDownTimer;
	private bool _ready;

	public string Name { get; set; }
	public bool LineOfSight { get; set; }
	public string Description { get; set; }
	public float BaseCoolDownTime { get; set; }
	public float CoolDownVariance { get; set; }

	public Spell(){


		//GameObject Effect { get; set; }

		Name = "Need Name";
		LineOfSight = true;
		Description = "Need a Desc..";
		
		BaseCoolDownTime = 2.0f;
		CoolDownVariance = .2f;
		CoolDownTimer = 0;
		Ready = true;


	}

	#region ISpell implementation

	public void Cast ()
	{
		throw new System.NotImplementedException ();
	}

	public void Update ()
	{
		throw new System.NotImplementedException ();
	}






	public GameObject Effect {
		get {
			throw new System.NotImplementedException ();
		}
		set {
			throw new System.NotImplementedException ();
		}
	}




	public float CoolDownTimer {
		get {
			return _coolDownTimer;
		}

		private set {
			_coolDownTimer = value;
		}
	}

	public bool Ready {
		get {
			return _ready;
		}

		private set {
			_ready = value;
		}
	}

	#endregion



}
