using UnityEngine;
using System.Collections;

public abstract class AbstractWeapon : MonoBehaviour {
	protected int maxAmmo;
	protected int currentAmmo;
	protected int fireRate;
	protected int suggestedRange;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public int MaxAmmo {
		get { return maxAmmo; }
	}
	
	public int CurrentAmmo {
		get { return currentAmmo; }
	}

	public int FireRate {
		get { return fireRate; }
	}

	public int SuggestedRange {
		get { return suggestedRange; }
		set { suggestedRange = value; }
	}
	
	protected void Fire() {
		currentAmmo--;
	}
}
