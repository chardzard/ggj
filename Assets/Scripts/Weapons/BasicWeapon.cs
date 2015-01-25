using UnityEngine;
using System.Collections;

public class BasicWeapon : AbstractWeapon {
	
	// Use this for initialization
	void Start () {
		base.maxAmmo = 30;
		base.currentAmmo = base.maxAmmo;
		base.fireRate = 1f;
		base.suggestedRange = 100;
		base.gunPoint = transform.FindChild ("Gunpoint");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public override bool Fire(GameObject shooter, Quaternion rotation, Vector3 velocity) {
		Debug.Log ("ammo is " + currentAmmo);
		currentAmmo--;
        Bullet bullet = Instantiate(bulletPrefab, gunPoint.position, rotation) as Bullet;
		bullet.m_Shooter = shooter;
        bullet.rigidbody.velocity += velocity;
		return true;
	}

    public override int CurrentAmmo
    {
        get { return 42; }
    }
}
