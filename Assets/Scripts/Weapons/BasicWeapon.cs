﻿using UnityEngine;
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
	
	public override bool Fire(GameObject shooter) {
		print ("ammo is " + currentAmmo);
		currentAmmo--;
		Bullet bullet = Instantiate(base.bulletPrefab, gunPoint.position, transform.rotation) as Bullet;
		bullet.m_Shooter = shooter;
		return true;
	}
}
