using UnityEngine;
using System.Collections;

public class BasicWeapon : AbstractWeapon {

	// Use this for initialization
	void Start () {
		base.maxAmmo = 30;
		base.currentAmmo = base.maxAmmo;
		base.fireRate = 10;
		base.suggestedRange = 100;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Fire() {
		base.Fire ();
	}
}
