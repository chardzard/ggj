using UnityEngine;
using System.Collections;

public abstract class AbstractWeapon : MonoBehaviour {
	protected int maxAmmo;
	protected int currentAmmo;
	protected float fireRate;
	protected float suggestedRange;
	protected Transform gunPoint;
	
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
	
	public float FireRate {
		get { return fireRate; }
	}
	
	public float SuggestedRange {
		get { return suggestedRange; }
		set { suggestedRange = value; }
	}

	public Transform GunPoint {
		get { return gunPoint; }
	}
	
	public bool Fire(GameObject shooter) {
		currentAmmo--;
		return true;
	}
}
