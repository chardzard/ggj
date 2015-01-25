using UnityEngine;
using System.Collections;

public class WeaponLaser : AbstractWeapon {

    private float lastShotTime;

    // Use this for initialization
    void Start()
    {
        base.maxAmmo = 10;
        base.currentAmmo = base.maxAmmo;
        base.fireRate = 3f;
        base.suggestedRange = 200;
        base.gunPoint = transform.FindChild("Gunpoint");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override bool Fire(GameObject shooter, Quaternion rotation, Vector3 velocity)
    {
        if (Time.time - lastShotTime > fireRate)
        {
            lastShotTime = Time.time;
            Debug.Log("ammo is " + currentAmmo);
            currentAmmo--;
            Bullet bullet = Instantiate(bulletPrefab, gunPoint.position, rotation) as Bullet;
            bullet.m_Shooter = shooter;
            return true;
        }
        else
        {
            return false;
        }
    }

    public override int CurrentAmmo
    {
        get { return 42; }
    }
}
