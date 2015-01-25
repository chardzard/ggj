using UnityEngine;
using System.Collections;

public class WeaponBurst : AbstractWeapon
{
    private float lastShotTime;

    // Use this for initialization
    void Start()
    {
        base.maxAmmo = 30;
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
            for (int i = 0; i < gunPoint.childCount; i++)
            {
                Bullet bullet = Instantiate(bulletPrefab, gunPoint.position, gunPoint.GetChild(i).rotation) as Bullet;
                bullet.m_Shooter = shooter;
                bullet.rigidbody.velocity += velocity;
            }
            lastShotTime = Time.time;
            return true;
        }
        else
        {
            return false;
        }
    }
}
