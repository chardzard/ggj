using UnityEngine;
using System.Collections;
using System;

public class PlayerShootingController : MonoBehaviour {

    public Transform m_Gunpoint;

    public Vector3 m_CorsshairScreenLocation;

    public Transform weaponTransform;

    public AbstractWeapon startingWeapon;

    private AbstractWeapon weapon;

    private CharacterMotor characterMoter;

    private Animator gunAnimator;

    public void WeaponUpdate(AbstractWeapon weaponPrefab)
    {
        if (weapon != null)
            Destroy(weapon);
        weapon = Instantiate(weaponPrefab, weaponTransform.position, weaponTransform.rotation) as AbstractWeapon;
        weapon.transform.localScale = weapon.transform.localScale;
        weapon.transform.parent = Camera.main.transform;
        m_Gunpoint = weapon.transform.FindChild("Gunpoint");
        gunAnimator = weapon.GetComponent<Animator>();
    }

	// Use this for initialization
	void Start () {
        characterMoter = GetComponent<CharacterMotor>();
        gunAnimator = GetComponentInChildren<Animator>();
        WeaponUpdate(startingWeapon);
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButton("Fire1"))
        {
            gunAnimator.SetBool("Shooting", FireWeapon());
        }
        else
        {
            gunAnimator.SetBool("Shooting", false);
        }
        gunAnimator.SetBool("Grounded", characterMoter.IsGrounded());
        gunAnimator.SetBool("Jumping", Input.GetKeyDown(KeyCode.Space));

        Vector3 velocity = characterMoter.movement.velocity;
        velocity.y = 0f;
        gunAnimator.SetFloat("Velocity", velocity.magnitude);
	}

    bool FireWeapon()
    {
        Ray aimPoint = Camera.main.ViewportPointToRay(m_CorsshairScreenLocation);
        RaycastHit hit;
        Vector3 fireDirection = Vector3.zero;
        bool directionSet = false;
        if (Physics.Raycast(aimPoint, out hit))
        {
            Debug.Log(hit.point);
            if (hit.distance >= 1f)
            {
                directionSet = true;
            }
            fireDirection = hit.point - m_Gunpoint.position;
        }
        if (!directionSet)
        {
            fireDirection = aimPoint.direction;
        }
        Quaternion bulletRotation = Quaternion.LookRotation(fireDirection);
        return weapon.Fire(gameObject, bulletRotation, characterMoter.movement.velocity);
    }
}
