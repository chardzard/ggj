using UnityEngine;
using System.Collections;

public class WeaponRapid : AbstractWeapon {

    private float lastShotTime;

    // Use this for initialization
    void Start()
    {
        base.maxAmmo = 100;
        base.currentAmmo = base.maxAmmo;
        base.fireRate = 0.1f;
        base.suggestedRange = 100;
        base.gunPoint = transform.FindChild("Gunpoint");
    }

    public override bool Fire(GameObject shooter, Quaternion rotation, Vector3 velocity)
    {
        if (Time.time - lastShotTime > fireRate)
        {
            Debug.Log("ammo is " + currentAmmo);
            currentAmmo--;
            Bullet bullet = Instantiate(bulletPrefab, gunPoint.position, rotation) as Bullet;
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
