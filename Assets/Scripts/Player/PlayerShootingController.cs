using UnityEngine;
using System.Collections;

public class PlayerShootingController : MonoBehaviour {

    public Bullet m_BulletPrefab;

    public Transform m_Gunpoint;

    public Vector3 m_CorsshairScreenLocation;

    private CharacterMotor characterMoter;

    private Animator gunAnimator;

	// Use this for initialization
	void Start () {
        characterMoter = GetComponent<CharacterMotor>();
        gunAnimator = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("Fire1"))
        {
            FireWeapon();
            gunAnimator.SetTrigger("Shooting");
        }
        Vector3 velocity = characterMoter.movement.velocity;
        velocity.y = 0f;
        gunAnimator.SetBool("Grounded", characterMoter.IsGrounded());
        gunAnimator.SetBool("Jumping", Input.GetKeyDown(KeyCode.Space));
        gunAnimator.SetFloat("Velocity", velocity.magnitude);
	}

    void FireWeapon()
    {
        Ray aimPoint = Camera.main.ViewportPointToRay(m_CorsshairScreenLocation);
        RaycastHit hit;
        Vector3 fireDirection;
        if (Physics.Raycast(aimPoint, out hit))
        {
            Debug.Log(hit.point);
            fireDirection = hit.point - m_Gunpoint.position;
        }
        else
        {
            fireDirection = aimPoint.direction;
        }
        Quaternion bulletRotation = Quaternion.LookRotation(fireDirection);
        Bullet bulletInstance = Instantiate(m_BulletPrefab, m_Gunpoint.position, bulletRotation) as Bullet;
        bulletInstance.m_Shooter = gameObject;
    }
}
