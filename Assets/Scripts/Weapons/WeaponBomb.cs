using UnityEngine;
using System.Collections;

public class WeaponBomb : AbstractWeapon {

    private float lastShotTime;

    // Use this for initialization
    void Start()
    {
        base.maxAmmo = 5;
        base.currentAmmo = base.maxAmmo;
        base.fireRate = 2f;
        base.suggestedRange = 50;
        base.gunPoint = transform.FindChild("Gunpoint");
    }

    public override bool Fire(GameObject shooter, Quaternion rotation, Vector3 velocity)
    {
        if (Time.time - lastShotTime > fireRate)
        {
            Debug.Log("ammo is " + currentAmmo);
            currentAmmo--;
            gunPoint.rotation = rotation;
            Bullet bullet = Instantiate(bulletPrefab, gunPoint.position, gunPoint.GetChild(0).rotation) as Bullet;
            bullet.m_Shooter = shooter;
            bullet.rigidbody.velocity += velocity;
            
            lastShotTime = Time.time;
            return true;
        }
        else
        {
            return false;
        }
    }
}
