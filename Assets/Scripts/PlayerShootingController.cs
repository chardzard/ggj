using UnityEngine;
using System.Collections;

public class PlayerShootingController : MonoBehaviour {

    public GameObject m_BulletPrefab;

    public Transform m_Gunpoint;

    public Vector3 m_CorsshairScreenLocation;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("Fire1"))
        {
            FireWeapon();
        }
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
        GameObject bulletInstance = Instantiate(m_BulletPrefab, m_Gunpoint.position, bulletRotation) as GameObject;
    }
}
